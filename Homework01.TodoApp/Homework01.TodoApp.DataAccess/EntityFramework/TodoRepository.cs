using Homework01.TodoApp.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework01.TodoApp.DataAccess.EntityFramework
{
    public class TodoRepository : IRepository<Todo>
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Todo> GetAll()
        {
            return _context.Todos;
        }

        public void Insert(Todo entity)
        {
            _context.Todos.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Todo entity)
        {
            _context.Todos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Todo entity)
        {
            _context.Todos.Update(entity);
            _context.SaveChanges();
        }
    }
}
