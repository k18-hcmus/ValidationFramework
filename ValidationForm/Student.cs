using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationForm
{
    class Student
    {
        [LengthValidator(1, 10)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
    }
}
