using System;
using System.Collections.Generic;

namespace OkurtProject.Common
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message)
        {

        }

        public ApiException(Exception exception) : base(exception.Message, exception)
        {

        }

        public ApiException(string message, Exception exception) : base(message, exception)
        {

        }

        public ApiException(IEnumerable<string> message) : base(string.Join(",", message.Distinct()))
        {

        }

        public ApiException(IEnumerable<string> message, Exception exception) : base(string.Join(",", message.Distinct()), exception)
        {

        }

        public override string ToString()
        {
            if (InnerException == null)
            {
                return base.ToString();
            }

            return string.Format(CultureInfo.InvariantCulture, "{0} [See nested exception: {1}]", base.ToString(), InnerException);
        }
    }
}
