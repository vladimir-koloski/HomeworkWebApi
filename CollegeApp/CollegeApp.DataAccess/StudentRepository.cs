using CollegeApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeApp.DataAccess
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly CollegeDbContext _context;

        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }
        public void Insert(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

    }
}
