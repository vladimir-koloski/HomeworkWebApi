using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.DataModels
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Semester { get; set; }
        public int StudentNumber { get; set; }

        public Student Student { get; set; }
    }
}
