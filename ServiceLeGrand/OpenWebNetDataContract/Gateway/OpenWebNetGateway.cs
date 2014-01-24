using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLegrand.WallAccess
{
    #region Enumeration

    public enum WHO
    {
        Scenarios = 0,
        Lighting = 1,
        Automation = 2,
        PowerManagement = 3,
        Heating = 4,
        Alarm = 5,
        RemoteControl = 6, // c'e' su USB ma non TCP controllare
        Multimedia = 7,
        OutsideInterface = 13,
        SoundSystem = 16,
        DiagnosticAutomation = 1001,
        DiagnosticHeating = 1004,
        DiagnosticDevice = 1013,
        None
    }

    public enum OpenSocketType
    {
        Command, // Used to send commands
        SuperCommand, // Used to send scenar commands
        Monitor  // Used to monitor asynchronous events on the device
    }

    public enum OpenWebNetErrorType
    {
        Nack,
        Exception,
        PasswordNeeded
    }

    enum Status
    {
        Disconnected,     // TCP disconnected
        WaitConnection,   // waiting to complete connection
        WaitAck,          // waiting the first ACK response
        WaitAck2,         // waiting the second ACK response
        Handshaked,       // handshaking complete.
        CommandProcessing // a command is being processed by the server
    }

    #endregion

    public partial class OpenWebNetGateway
    {
        #region Attributs

        protected Dictionary<string, int> chiValues;

        public event EventHandler<OpenWebNetDataEventArgs> DataReceived;
        public event EventHandler<OpenWebNetDataEventArgs> MessageReceived;
        public event EventHandler<OpenWebNetErrorEventArgs> ConnectionError;
        public event EventHandler Connected;

        public const int MAX_LENGTH_OPEN = 1024;
        public const string MSG_START = "*";
        public const string MSG_END = "##";
        public const string ACK = "*#*1##";
        public const string NACK = "*#*0##";
        public const string NACK_NOP = "*#*2##";
        public const string NACK_RET = "*#*3##";
        public const string NACK_COLL = "*#*4##";
        public const string NACK_NOBUS = "*#*5##";
        public const string NACK_BUSY = "*#*6##";
        public const string NACK_PROC = "*#*7##";

        internal const string CMD_BUS = "*{0}*{1}*{2}##"; // *CHI*COSA*DOVE##
        internal const string CMD_BUS_NO_WHERE = "*{0}*{1}##"; // *CHI*COSA##
        internal const string CMD_EXT_IFACE = "*#{0}**{1}##";
        internal const string CMD_SET_DIMENSION = "*#{0}*{1}*#{2}##"; // *#CHI*DOVE*#GRANDEZZA*VAL## 
        internal const string GET_STATE = "*#{0}*{1}##"; // *#CHI*DOVE##
        internal const string GET_STATE_NO_WHERE = "*#{0}##"; // *#CHI##
        internal const string GET_DIMENSION = "*#{0}*{1}*{2}##"; // *#CHI*DOVE*GRANDEZZA##
        internal const string SET_STATE = "*#{0}*{1}#{2}##"; // *#CHI*DOVE#LIV#INT##

        public event EventHandler Disconnected;

        public AsyncCallback onDataReady;
        public AsyncCallback onSendData;

        private Status status;
        private OpenSocketType socketType;
        private EndPoint endPoint;
        private Socket socket;

        private string host;
        private int port;
        private string bufferString;
        private string dataToSend;
        private byte[] buffer;
        private const int bufferSize = 10000;
        private bool openWebConnOk;

        internal const string PROT_CMD = "*99*0##";
        internal const string PROT_MON = "*99*1##";
        internal const string PROT_SCMD = "*99*9##";

        #endregion

        public OpenWebNetGateway(string host, int port, OpenSocketType socketType)
        {
            int[] values;
            string[] names;

            chiValues = new Dictionary<string, int>();
            names = Enum.GetNames(typeof(WHO));
            values = (int[])Enum.GetValues(typeof(WHO));

            for (int i = 0; i < names.Length; i++)
                chiValues.Add(names[i], values[i]);

            //Ethernet Connection 
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException("host");

            if (port < 0)
                throw new ArgumentOutOfRangeException("port");

            this.host = host;
            this.port = port;
            this.socketType = socketType;
            this.status = Status.Disconnected;
            this.buffer = new byte[bufferSize];
            this.bufferString = String.Empty;
            this.dataToSend = string.Empty;
            this.onDataReady = new AsyncCallback(OnDataReady);
            this.onSendData = new AsyncCallback(OnSendData);
        }

        #region Public Properties

        public string Host
        {
            get
            {
                return host;
            }

            set
            {
                if (string.IsNullOrEmpty(host))
                    throw new ArgumentNullException("host");

                host = value;
            }
        }

        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("port");

                port = value;
            }
        }

        public bool IsConnected
        {
            get
            {
                return (socket != null && socket.Connected);
            }
        }

        public bool IsConnectedToGateway
        {
            get
            {
                return openWebConnOk;
            }
        }

        #endregion

        #region Public methods

        public void Connect()
        {
            try
            {
                if (IsConnected)
                    return;

                status = Status.WaitConnection;
                bufferString = string.Empty;

                if (endPoint == null)
                    endPoint = new IPEndPoint(IPAddress.Parse(host), port);

                if (socket == null)
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                }

                socket.BeginConnect(endPoint, new AsyncCallback(OnConnect), null);
            }
            catch (Exception ex)
            {
                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.Exception, ex));

                status = Status.Disconnected;
            }
        }

        public void Disconnect()
        {
            status = Status.Disconnected;
            openWebConnOk = false;

            if (socket != null)
            {
                if (IsConnected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;
                }

                if (Disconnected != null)
                    Disconnected(this, EventArgs.Empty);
            }
        }

        public void SendCommand(WHO who, string what, string where)
        {
            if (socketType == OpenSocketType.Monitor)
                throw new NotSupportedException("Non e' possibile inviare comandi in una sessione Monitor");

            status = Status.CommandProcessing;

            if (who == WHO.OutsideInterface)
            {
                SendData(string.Format(CMD_EXT_IFACE, chiValues[who.ToString()], what));
            }
            else
            {
                if (where == string.Empty)
                    SendData(string.Format(CMD_BUS_NO_WHERE, chiValues[who.ToString()], who));
                else
                    SendData(string.Format(CMD_BUS, chiValues[who.ToString()], what, where));
            }
        }

        public void GetStateCommand(WHO who, string where)
        {
            status = Status.CommandProcessing;

            if (string.IsNullOrEmpty(where))
                SendData(string.Format(GET_STATE_NO_WHERE, chiValues[who.ToString()]));
            else
                SendData(string.Format(GET_STATE, chiValues[who.ToString()], where));
        }

        public void SendData(string data)
        {
            ASCIIEncoding enc;
            byte[] _buffer;

            if (!openWebConnOk && !IsConnected)
                throw new InvalidOperationException("First you have to call Connect");

            try
            {
                if (openWebConnOk && !IsConnected)
                {
                    status = Status.WaitConnection;
                    dataToSend = data;

                    if (socket == null)
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    }

                    socket.BeginConnect(endPoint, new AsyncCallback(OnConnect), null);

                    return;
                }

                enc = new ASCIIEncoding();
                _buffer = enc.GetBytes(data);

                socket.BeginSend(_buffer, 0, _buffer.Length, SocketFlags.None, onSendData, null);
            }
            catch (Exception ex)
            {
                // gestione exception

                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.Exception, ex));
            }
        }

        #endregion

        #region Private Methods

        private void ManageConnectionStatus(string message)
        {
            if (status == Status.WaitAck || status == Status.WaitAck2)
            {
                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.PasswordNeeded, null));
            }

            // gestione dei NACK

            switch (status)
            {
                case Status.WaitAck:
                    if (message == ACK)
                    {
                        status = Status.WaitAck2;

                        if (socketType == OpenSocketType.Command)
                            SendData(PROT_CMD);
                        else if (socketType == OpenSocketType.Monitor)
                            SendData(PROT_MON);
                        else
                            SendData(PROT_SCMD);
                    }
                    else
                    {
                        status = Status.Disconnected;
                        Disconnect();
                    }
                    break;
                case Status.WaitAck2:
                    if (message == ACK)
                    {
                        status = Status.Handshaked;

                        if (!openWebConnOk)
                        {
                            if (Connected != null)
                                Connected(this, EventArgs.Empty);

                            openWebConnOk = true;
                        }

                        // invio i dati dopo aver eseguito la riconnessione

                        if (dataToSend != string.Empty)
                        {
                            SendData(dataToSend);
                            dataToSend = string.Empty;
                        }
                    }
                    else
                    {
                        status = Status.Disconnected;
                        Disconnect();
                    }
                    break;
                case Status.CommandProcessing:
                    status = Status.Handshaked;
                    break;
            }
        }

        private void OnSendData(IAsyncResult res)
        {
            try
            {
                socket.EndSend(res);
            }
            catch (Exception ex)
            {
                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.Exception, ex));
            }
        }

        private void OnConnect(IAsyncResult result)
        {
            try
            {
                // sistemare

                if (!socket.Connected)
                    throw new SocketException((int)SocketError.ConnectionRefused);

                socket.EndConnect(result);
                status = Status.WaitAck;
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, onDataReady, null);
            }
            catch (Exception ex)
            {
                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.Exception, ex));
            }
        }

        private void OnDataReady(IAsyncResult result)
        {
            int index;
            int numBytes;
            string data, message;
            ASCIIEncoding enc;

            try
            {
                if (!IsConnected)
                    return;

                numBytes = socket.EndReceive(result);

                if (numBytes == 0)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;

                    return;
                }

                enc = new ASCIIEncoding();
                data = enc.GetString(buffer, 0, numBytes);

                if (DataReceived != null)
                    DataReceived(this, new OpenWebNetDataEventArgs(data));

                // si occupa della gestione dei messaggi...

                data = data.Trim();

                if ((index = data.IndexOf(MSG_END)) < 0)
                {
                    // non ho un messaggio completo

                    if (bufferString == string.Empty)
                    {
                        bufferString = data;
                        return;

                    }
                    else
                    {
                        bufferString += data;
                    }
                }
                else
                {
                    while ((index = data.IndexOf(MSG_END)) >= 0)
                    {
                        message = data.Substring(0, index + MSG_END.Length);
                        data = data.Remove(0, index + MSG_END.Length);

                        if (bufferString == string.Empty)
                            bufferString = message;
                        else
                            bufferString += message;

                        if (MessageReceived != null)
                            MessageReceived(this, new OpenWebNetDataEventArgs(bufferString));

                        ManageConnectionStatus(bufferString);

                        bufferString = string.Empty;
                    }

                    if (data != "")
                        bufferString = data;
                }

                if (IsConnected)
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, onDataReady, null);
            }
            catch (Exception ex)
            {
                if (ConnectionError != null)
                    ConnectionError(this, new OpenWebNetErrorEventArgs(OpenWebNetErrorType.Exception, ex));
            }
        }

        #endregion

        //Check if Open message is well formed (taken from OpenClientSocket.cs)
        public static bool IsWellFormedMessage(string message)
        {
            if (message.Length > MAX_LENGTH_OPEN)
                return false;

            // check if it is too short to contain the message delimiters
            if (message.Length < MSG_START.Length + MSG_END.Length)
                return false;

            // check start and end delimiters
            if (
                message[0] != MSG_START[0]
                || message[message.Length - 2] != MSG_END[0]
                || message[message.Length - 1] != MSG_END[1]
                )
                return false;

            // check if it is ACK
            if (message == MSG_START + ACK + MSG_END)
                return true;

            // check if it is NACK
            if (message == MSG_START + NACK + MSG_END)
                return true;

            // valid characters are '0' to '9' and '*' and '#' 
            foreach (char c in message)
            {
                if (
                    (c < '0' || c > '9')
                    && !(c == '*' || c == '#')
                    )
                    return false;
            }
            return true;

        }



    }

    #region OpenWebNet EventArgs

    public class OpenWebNetMessageEventArgs : EventArgs
    {
        private Message message;

        public OpenWebNetMessageEventArgs(Message message)
            : base()
        {
            if (message == null)
                throw new ArgumentNullException("message");

            this.message = message;
        }

        public Message Message
        {
            get
            {
                return message;
            }
        }
    }

    public class OpenWebNetDataEventArgs : EventArgs
    {
        private string data;

        public OpenWebNetDataEventArgs(string data)
            : base()
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException("data");

            this.data = data;
        }

        public string Data
        {
            get
            {
                return data;
            }
        }
    }

    public class OpenWebNetErrorEventArgs : EventArgs
    {
        public OpenWebNetErrorType ErrorType { get; private set; }
        public Exception Exception { get; private set; }

        public OpenWebNetErrorEventArgs(OpenWebNetErrorType errorType, Exception ex)
            : base()
        {
            this.ErrorType = errorType;
            this.Exception = ex;
        }
    }

    #endregion
}
