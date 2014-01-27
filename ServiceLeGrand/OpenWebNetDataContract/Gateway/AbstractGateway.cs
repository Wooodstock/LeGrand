using OpenWebNetDataContract.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWebNetDataContract.Gateway
{
    [DataContract]
    public abstract class AbstractGateway
    {
        private OpenWebNetGateway openWebNetGateway;

        public OpenWebNetGateway OpenWebNetGateway
        {
            get { return openWebNetGateway; }
            set { openWebNetGateway = value; }
        }

        private SQLite sqLite;

        public SQLite SqLite
        {
            get { return sqLite; }
            set { sqLite = value; }
        }
        
    }
}
