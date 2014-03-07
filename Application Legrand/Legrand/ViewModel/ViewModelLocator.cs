using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Legrand.ViewModel {

    public class ViewModelLocator {

        public ViewModelLocator() {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<RoomViewModel>(true);
            SimpleIoc.Default.Register<ProgramViewModel>(true);
        }

        public LoginViewModel   LoginVM     { get { return ServiceLocator.Current.GetInstance<LoginViewModel>(); } }
        public MainViewModel    MainVM      { get { return ServiceLocator.Current.GetInstance<MainViewModel>(); } }
        public RoomViewModel    RoomVM      { get { return ServiceLocator.Current.GetInstance<RoomViewModel>(); } }
        public ProgramViewModel ProgramVM   { get { return ServiceLocator.Current.GetInstance<ProgramViewModel>(); } }

        public static void Cleanup() {

        }
    }
}