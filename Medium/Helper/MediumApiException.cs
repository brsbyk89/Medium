using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Medium.Helper
{
    public class MediumApiException : Exception
    {
        public MediumApiException(string message) : base(message)
        {

        }

        public MediumApiException(Exception exception) : base(exception.Message, exception)
        {

        }

        public MediumApiException(string message, Exception exception) : base(message, exception)
        {

        }

        public MediumApiException(IEnumerable<string> message) : base(string.Join(",", message.Distinct()))
        {

        }

        public MediumApiException(IEnumerable<string> message, Exception exception) : base(string.Join(",", message.Distinct()), exception)
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
