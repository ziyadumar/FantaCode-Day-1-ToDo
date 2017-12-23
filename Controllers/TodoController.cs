using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FantaCode.Todo.Controllers
{
    [Route("v1/[controller]")]
    public class TodoController : Controller
    {
        [HttpGet]
        public async Task<String> Get() {
            return "Hello Todo!";
        }
    }
}
