using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class EmailValidator : RegexValidator
    {
        protected override string GetFailureMessage()
        {
            return "Your Email is not valid";
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
