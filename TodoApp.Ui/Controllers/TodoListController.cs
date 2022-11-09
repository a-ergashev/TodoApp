using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoApp.Domain;
using TodoApp.Ui.Data;

namespace TodoApp.Ui.Controllers
{
    public class TodoListController : Controller
    {
        private readonly TodoDataContext _context;
        public TodoListController(TodoDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Ok(_context.TodoLists);
        }

        [HttpPost]
        public ActionResult<TodoList> Create(TodoList todoList)
        {
            if (todoList == null || string.IsNullOrEmpty(todoList.Name))
            {
                return BadRequest();
            }

            _context.TodoLists.Add(todoList)
                ;
            _context.SaveChanges();

            return Created($"{nameof(Get)}/{todoList.Id}", todoList);
        }

        [HttpGet]
        public ActionResult<TodoList> Get(int Id)
        {
            var todoList = _context.TodoLists.Find(Id);

            if (todoList == null)
            {
                return NoContent();
            }

            return Ok(todoList);
        }

        [HttpPut]
        public ActionResult<TodoList> Update(int Id, TodoList todoList)
        {
            if (todoList == null || string.IsNullOrEmpty(todoList.Name)
                || Id != todoList.Id)
            {
                return BadRequest();
            }

            var todoL = _context.TodoLists.Find(Id);
            if (todoL == null)
            {
                return NotFound();
            }

            todoL.Name = todoList.Name;
            _context.Entry(todoL).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(todoL);
        }

        [HttpDelete]
        public ActionResult<TodoList> Delete(int Id)
        {
            var todoList = _context.TodoLists.Find(Id);

            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoLists.Remove(todoList);
            _context.SaveChanges();

            return todoList;
        }
    }
}
