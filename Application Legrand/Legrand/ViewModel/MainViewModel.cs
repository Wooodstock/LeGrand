using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Legrand.ServiceLegrand;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Legrand.Model;
using Legrand.Model.Services;
using System.Windows;

namespace Legrand.ViewModel {

    public class MainViewModel : BaseViewModel {

        #region Rooms
        public ICommand showRoomCommand { get; set; }
        
        private ObservableCollection<Room> listRooms;
        public ObservableCollection<Room> ListRooms {

            get { return listRooms; }
            set { NotifyPropertyChanged(ref listRooms, value); }
        }

        private async void ShowRoom(Room room) {

            await base.RunAsyncTask(() => {
                Messenger.Default.Send<Room>(room);
            });
        }

        public async void GetRoomList() {

            await base.RunAsyncTask(() => {
                this.serviceHome.GetRoomList((rooms) => {
                    var listRooms = rooms;
                    Deployment.Current.Dispatcher.BeginInvoke(() => {
                        this.ListRooms = listRooms;
                    });
                });
            });
        }
        #endregion

        #region Programs
        public ICommand showProgramCommand { get; set; }

        private ObservableCollection<Program> listPrograms;
        public ObservableCollection<Program> ListPrograms {

            get { return listPrograms; }
            set { NotifyPropertyChanged(ref listPrograms, value); }
        }

        private async void ShowProgram(Program program) {

            await base.RunAsyncTask(() => {
                Messenger.Default.Send<Program>(program);
            });
        }

        public async void GetProgramList() {

            await base.RunAsyncTask(() => {
                this.serviceProgram.GetProgramList((program) => {
                    var listPrograms = program;
                    Deployment.Current.Dispatcher.BeginInvoke(() => {
                        this.ListPrograms = listPrograms;
                    });
                });
            });
        }
        #endregion

        public MainViewModel() {

            this.showRoomCommand = new RelayCommand<Room>(ShowRoom);
            GetRoomList();

            this.showProgramCommand = new RelayCommand<Program>(ShowProgram);
            GetProgramList();
        }
    }
}