using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class CustomValidator : ValidatorStrategy
    {
        Func<string, bool> _action;
        string _defaultMessage = "This field is not valid";

        public CustomValidator(Func<string, bool> action, string failureMessage = "") : base(failureMessage)
        {
            _action = action;
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
            return _action(value);
        }
    }
}
