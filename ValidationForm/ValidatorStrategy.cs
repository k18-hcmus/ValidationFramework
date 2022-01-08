using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    abstract class ValidatorStrategy
    {
        public virtual ValidationResult Validate(string value)
        {
            if (value != null && Test(value))
                return new ValidationResult(true, GetSuccessMessage());
            return new ValidationResult(false, GetFailureMessage());
        }

        protected abstract bool Test(string value);
        protected abstract string GetSuccessMessage();
        protected abstract string GetFailureMessage();
    }
}
