using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace ValidationForm
{
    class RuleHandler<T>
    {
        private ValidatorStrategy validator;
        private Expression<Func<T, object>> expression;
        private RuleHandler<T> next;

        public RuleHandler(Expression<Func<T, object>> expression)
        {
            this.expression = expression;
        }

        private RuleHandler<T> setNext(RuleHandler<T> next)
        {
            this.next = next;
            return next;
        }

        public RuleHandler<T> Use(ValidatorStrategy validator)
        {
            if (this.validator != null)
            {
                RuleHandler<T> ruleHandler = new RuleHandler<T>(expression);
                ruleHandler.validator = validator;
                return setNext(ruleHandler);
            } 
            else
            {
                this.validator = validator;
                return this;
            }
        }

        public string GetPropertyValue(T validateObj)
        {
            MemberExpression memberExpression;

            if (expression.Body is UnaryExpression)
            {
                UnaryExpression unaryExpression = (UnaryExpression)(expression.Body);
                memberExpression = (MemberExpression)(unaryExpression.Operand);
            }
            else
            {
                memberExpression = (MemberExpression)(expression.Body);
            }

            return (string)((PropertyInfo)memberExpression.Member).GetValue(validateObj);
        }

        public void Validate(T validateObj, Action<ValidationResult> callback)
        {
            string value = GetPropertyValue(validateObj);
            callback(validator.Validate(value));
            if (next != null)
            {
                next.Validate(validateObj, callback);
            }
        }
    }
}
