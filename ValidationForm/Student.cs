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
        [NotEmptyValidator()]
        public string Name { get; set; }
        public string StudentId { get; set; }
    }
}
