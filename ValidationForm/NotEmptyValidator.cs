using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class NotEmptyValidator : ValidatorStrategy
    {
        string _defaultMessage = "This field could not be null";
        public NotEmptyValidator(string failureMessage = "") : base(failureMessage)
        {
            if(string.IsNullOrEmpty(failureMessage))
            {
                this.failureMessage = _defaultMessage;
            }
        }

        protected override bool Test(string value)
        {
            return value != null && value.Length > 0;
        }
    }
}
