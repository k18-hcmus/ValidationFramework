using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ValidationForm
{
    class RegexValidator : ValidatorStrategy
    {
        string _defaultMessage = "Regex validator failed";
        string _regex;
        public RegexValidator(string regex, string failureMessage = "") : base(failureMessage)
        {
            if (string.IsNullOrEmpty(failureMessage))
            {
                this.failureMessage = _defaultMessage;
            }
            this._regex = regex;
        }
        public RegexValidator(string failureMessage = "") : base(failureMessage)
        {
            if (string.IsNullOrEmpty(failureMessage))
            {
                this.failureMessage = _defaultMessage;
            }
        }
        protected override bool Test(string value)
        {
            return Regex.IsMatch(value, GetRegex());
        }

        protected virtual string GetRegex()
        {
            return _regex;
        }
    }
}
