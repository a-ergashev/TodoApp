using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Domain
{
    [Table(name: "TodoLists")]
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
