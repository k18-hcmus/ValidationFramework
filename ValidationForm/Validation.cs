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

        public static List<ValidationResult> TryValidateObject(T validateObj)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();

            var properties = validateObj.GetType().GetProperties();
            foreach (var property in properties)
            {
                foreach (var attr in property.GetCustomAttributes(false))
                {
                    ValidatorStrategy validatorStrategy = attr as ValidatorStrategy;
                    if (validatorStrategy != null)
                    {
                        Console.WriteLine((string)(property.GetValue(validateObj)));
                        ValidationResult result = validatorStrategy.Validate((string)(property.GetValue(validateObj)));
                        validationResults.Add(result);
                    }
                }
            }

            return validationResults;
        }
    }
}
