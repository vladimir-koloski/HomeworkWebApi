using CollegeApp.Models;
using CollegeApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using CollegeApp.DataModels;
using CollegeApp.Services.Helpers;

namespace CollegeApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;

        }
        public void CreateStudent(StudentModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName))
            {
                throw new Exception("Firstname is required");                    
            }

            if (!Validations.ValidateEmail(request.Email))
            {
                throw new Exception("Email is not at valid format");
            }

            if (!Validations.ValidatePhoneNumber(request.MobilePhone))
            {
                throw new Exception("Invalid phone number");
            }

            if (request.Subjects.Count <= 1)
            {
                throw new Exception("You must select at least two subjects to create Student Profile");
            }


            var student = new Student
            {
                FullName = request.FullName,
                MobilePhone = request.MobilePhone,
                Email = request.Email,
                Subjects = request.Subjects
            };

            

            _studentRepository.Insert(student);
        }
    }
}

