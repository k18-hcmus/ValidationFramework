using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    abstract class Validation<T>
    {
        private List<RuleHandler<T>> ruleHandlers;

        protected Validation()
        {
            ruleHandlers = new List<RuleHandler<T>>();
        }

        public RuleHandler<T> RuleFor(Expression<Func<T, object>> expression)
        {
            RuleHandler<T> ruleHandler = new RuleHandler<T>(expression);
            ruleHandlers.Add(ruleHandler);
            return ruleHandler;
        }

        public List<ValidationResult> Validate(T validateObj)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            foreach (RuleHandler<T> handler in ruleHandlers)
            {
                handler.Validate(validateObj, (validationResult) => {
                    validationResults.Add(validationResult);
                });
            }

            return validationResults;
        }
    }
}
