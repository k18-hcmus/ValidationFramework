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
        protected override string GetFailureMessage()
        {
            return String.Format("This field must be in length from {0} to {1}", min, max);
        }

        public LengthValidator(int min = 0, int max = int.MaxValue)
        {
            this.min = min;
            this.max = max;
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
