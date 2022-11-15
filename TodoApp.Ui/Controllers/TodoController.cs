using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TodoApp.Domain;
using TodoApp.Ui.Data;

namespace TodoApp.Ui.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDataContext _context;
        public TodoController(TodoDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.Todos);
        }

        [HttpPost]
        public ActionResult<Todo> Create([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            todo.CreationDate = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return Created($"Get/{todo.Id}", todo);
        }

        [HttpGet]
        public ActionResult<Todo> Get(int Id)
        {
            var todo = _context.Todos.Find(Id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut]
        public ActionResult<Todo> Update(int Id, [FromBody] Todo todo)
        {
            if (Id != todo.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Todos.Update(todo);
            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var todo = _context.Todos.Find(Id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
