using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight.Design;
using MvvmLight.Model;
using MvvmLight.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight {

    public class ViewModelLocator {

        static ViewModelLocator() {

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
                SimpleIoc.Default.Register<IServiceClient, DesignServiceClient>();
            else
                SimpleIoc.Default.Register<IServiceClient, ServiceClient>();

            SimpleIoc.Default.Register<VoirClientViewModel>();
        }

        public VoirClientViewModel VoirClientVM {

            get { return ServiceLocator.Current.GetInstance<VoirClientViewModel>(); }
        }

        public ListeClientsViewModel ListeClientsVM {

            get { return ServiceLocator.Current.GetInstance<ListeClientsViewModel>(); }
        }
    }
}
