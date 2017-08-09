using System;
using System.Web.Mvc;
using System.Web.Routing;
using DienChanOnline.DAL;
using Ninject;

namespace DienChanOnline.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();

            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IQueryBase>().To<QueryBase>();
            _ninjectKernel.Bind<ICustomerInfoQuery>().To<CustomerInfoQuery>();
            _ninjectKernel.Bind<IFormTypeQuery>().To<FormTypeQuery>();
            _ninjectKernel.Bind<ICustomerAccountQuery>().To<CustomerAccountQuery>();
        }
    }
}
