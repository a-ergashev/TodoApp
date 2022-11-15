using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Domain
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public TodoStatus Status { get; set; } = TodoStatus.NotStarted;

        public TodoList TodoList { get; set; }
    }
}
