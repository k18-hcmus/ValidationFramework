using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class LengthValidator : ValidatorStrategy
    {
        int min, max;
        string _defaultMessage = "Length validate failed.";
        protected override string GetFailureMessage()
        {
            if (failureMessage.Equals(_defaultMessage))
            {
                return String.Format(_defaultMessage + "This field must be in length from {0} to {1}", min, max);
            }
            else
            {
                return failureMessage;
            }
        }

        public LengthValidator(int min = 0, int max = int.MaxValue, string failureMessage = ""): base(failureMessage)
        {
            this.min = min;
            this.max = max;
            if (string.IsNullOrEmpty(failureMessage))
            {
                this.failureMessage = _defaultMessage;
            }
        }

        protected override string GetSuccessMessage()
        {
            return "OK";
        }

        protected override bool Test(string value)
        {
            if (value.Length >= min && value.Length <= max)
                return true;
            return false;
        }
    }
}
