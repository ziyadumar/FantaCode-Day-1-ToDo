using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fcdone
{
    [Route("v1/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoRepository todoRepository;
        public TodoController()
        {
            todoRepository = new TodoRepository();
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Todo> Get() => TodoRepository.GetAll();


        [HttpPut("{id}")]
    }

    public class Todo
    {
    }

    internal class TodoRepository
    {
        internal static IEnumerable<Todo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
