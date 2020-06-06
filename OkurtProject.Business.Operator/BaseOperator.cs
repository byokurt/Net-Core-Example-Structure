using System;

namespace OkurtProject.Business.Operator
{
    public class BaseOperator
    {
        protected readonly IServiceProvider _serviceProvider;

        public BaseOperator()
        {

        }

        public BaseOperator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

    }
}
