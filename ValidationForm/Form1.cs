using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            studentBindingSource.DataSource = new Student();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentBindingSource.EndEdit();
            Student student = studentBindingSource.Current as Student;
            Debug.WriteLine(student.ToString());
            if (student != null)
            {
                List<ValidationResult> results = new StudentValidation().Validate(student);
                //List<ValidationResult> results = new StudentValidation().Validate(student);

                string errorToShow = "";
                foreach (ValidationResult result in results)
                {
                    if (!result.isValid)
                    {
                        errorToShow += result.message + "\n";
                    }
                }

                if (errorToShow.Length > 0)
                {
                    MessageBox.Show(errorToShow, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Submit form successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
