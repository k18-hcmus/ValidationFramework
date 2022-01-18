using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class EmailValidator : RegexValidator
    {
        string _defaultMessage = "Your Email is not valid";
        public EmailValidator(string failureMessage = ""): base(failureMessage)
        {
            if(string.IsNullOrEmpty(failureMessage))
            {
                this.failureMessage = _defaultMessage;
            }
        }

        protected override string GetSuccessMessage()
        {
            return "Your email is OK!";
        }

        protected override string GetRegex()
        {
            return @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        }
    }
}
