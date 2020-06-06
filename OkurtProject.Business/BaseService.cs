using OkurtProject.Business.Contracts;
using System;

namespace OkurtProject.Business
{
    public class BaseService : IBaseService
    {
        protected readonly IServiceProvider _serviceProvider;

        public BaseService()
        {

        }

        public BaseService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
