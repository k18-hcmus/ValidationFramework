using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class Student
    {
        [EmailValidator()]
        public string Email { get; set; }
        [NotEmptyValidator("Name can not be empty!")]
        [LengthValidator(1, 50)]
        public string Name { get; set; }
        [LengthValidator(1, 50)]
        public string StudentId { get; set; }
    }
}
