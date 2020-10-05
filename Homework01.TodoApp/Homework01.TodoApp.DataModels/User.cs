using System;
using System.Collections.Generic;
using System.Text;

namespace Homework01.TodoApp.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Todo> Todos { get; set; }
    }
}
