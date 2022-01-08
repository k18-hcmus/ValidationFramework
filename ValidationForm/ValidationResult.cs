using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class ValidationResult
    {
        public bool isValid { get; }
        public string message { get; }

        public ValidationResult(bool isValid, string message)
        {
            this.isValid = isValid;
            this.message = message;
        }
    }
}
