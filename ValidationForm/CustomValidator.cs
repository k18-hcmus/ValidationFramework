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
        protected override string GetFailureMessage()
        {
            return "False";
        }

        public CustomValidator(Func<string, bool> action)
        {
            _action = action;
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
