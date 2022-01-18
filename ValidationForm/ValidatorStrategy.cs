using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    [AttributeUsage(AttributeTargets.Property)]
    abstract class ValidatorStrategy : Attribute
    {
        protected string failureMessage;

        protected ValidatorStrategy(string failureMessage)
        {
            this.failureMessage = failureMessage;
        }

        public virtual ValidationResult Validate(string value)
        {
            if (value != null && Test(value))
                return new ValidationResult(true, GetSuccessMessage());
            return new ValidationResult(false, GetFailureMessage());
        }

        protected abstract bool Test(string value);
        protected virtual string GetSuccessMessage()
        {
            return "OK";
        }
        protected virtual string GetFailureMessage()
        {
            if (string.IsNullOrEmpty(failureMessage))
            {
                return "Failed";
            }
            else
            {
                return failureMessage;
            }
        }
    }
}
