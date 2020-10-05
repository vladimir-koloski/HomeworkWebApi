using System;
using System.Collections.Generic;
using System.Text;

namespace Homework01.TodoApp.DataModels
{
    public class Todo
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime TimeTodo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
