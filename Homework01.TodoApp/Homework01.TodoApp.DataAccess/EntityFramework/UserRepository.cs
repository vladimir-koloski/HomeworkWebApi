using Homework01.TodoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework01.TodoApp.DataAccess.EntityFramework
{
    public class UserRepository : IRepository<User>
    {
        private readonly TodoDbContext _context;
        public UserRepository(TodoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
