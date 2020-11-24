using CollegeApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.Services
{
    public interface IStudentService
    {
        void CreateStudent(StudentModel request);
    }
}
