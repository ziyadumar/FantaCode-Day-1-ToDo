using System.Collections.Generic;
using FantaCode.Todoapi;
using FantaCode.Todoapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FantaCode.Todoapi
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {

        private readonly TodoRepository todoRepository;

        public TodoController()
        {
            todoRepository = new TodoRepository();
        }

        // POST api/todo
        [HttpPost]
        public void Post([FromBody]Todo todo)
        {
            if (ModelState.IsValid)
                todoRepository.Add(todo);
        }

    [HttpGet]
    public IEnumerable<Todo> Get() => todoRepository.GetAll();


        // PUT api/todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo todo)
        {
            todo.TodoId = id;
            if (ModelState.IsValid)
                todoRepository.Update(todo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody]Todo todo)
        {
            todo.TodoId = id;
            if (ModelState.IsValid)
                todoRepository.Delete(todo);
        }


    }
}