using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace FantaCode.Todoapi.Interface
{
    public interface ITodoRepository
    {
    IEnumerable<Todo> GetAll();
    void Add(Todo item);
    Todo View(int item);
    void Update(Todo item1);
    void Done(Todo item1);
    Todo Delete(int item);
    }




    }
