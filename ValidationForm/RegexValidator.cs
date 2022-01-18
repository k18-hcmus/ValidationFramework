using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValidationForm
{
    abstract class RegexValidator : ValidatorStrategy
    {
        string _defaultMessage = "Regex validator failed";
        public RegexValidator(string failureMessage = ""): base(failureMessage)
        {
            if (string.IsNullOrEmpty(failureMessage)) {
                this.failureMessage = _defaultMessage;
            }
        }
        protected override bool Test(string value)
        {
            return Regex.IsMatch(value, GetRegex());
        }

        protected abstract string GetRegex();
    }
}
