using Legrand.ServiceLegrand;
using System;

namespace Legrand.Model.Services {

    public class BaseService {
        protected ServiceLegrandClient serviceLegrand;

        public BaseService() {

            this.serviceLegrand = new ServiceLegrandClient("BasicHttpBinding_IServiceLegrand");
        }
    }
}