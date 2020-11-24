using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.DataModels
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FullName { get; set; }
        public int MobilePhone { get; set; }
        public string Email { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
