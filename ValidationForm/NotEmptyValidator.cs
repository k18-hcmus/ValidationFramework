using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class NotEmptyValidator : ValidatorStrategy
    {
        protected override string GetFailureMessage()
        {
            return "This field could not be null";
        }

        protected override string GetSuccessMessage()
        {
            return "OK!";
        }

        protected override bool Test(string value)
        {
            return value != null && value.Length > 0;
        }
    }
}
