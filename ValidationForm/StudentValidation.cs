using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class StudentValidation : Validation<Student>
    {
        public StudentValidation() : base()
        {
            RuleFor(student => student.Email).Use(new EmailValidator()).Use(new LengthValidator(8));
            RuleFor(student => student.Name).Use(new LengthValidator(6, 12));
            RuleFor(student => student.StudentId).Use(new NotEmptyValidator()).Use(new CustomValidator((value) => value.Length == 1));
        }
    }
}
