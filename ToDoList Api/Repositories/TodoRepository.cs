using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace FantaCode.Todoapi.Repositories
{
    public class TodoRepository
    {

        private string connectionString;
        public TodoRepository()
        {
            connectionString = @"Server=localhost;Database=FcdOne;Trusted_Connection=true;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public IEnumerable<Todo> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<Todo>("SELECT * FROM Todo");
            }
        }

        public void Add(Todo item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "INSERT INTO Todo (Task, Description, Done)"
                                + " VALUES(@Task, @Description, @Done)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }

        public Todo View(int item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "Select * from Todo where Todoid = @id ";
                dbConnection.Open();
                List<Todo> todos = dbConnection.Query<Todo>(sQuery, new { id = item }).ToList();
                
                return todos.FirstOrDefault();
            }
        }

        public void Update(Todo item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "UPDATE Todo SET Task = @Task,"
                                + " Done = @Done ,"
                               + " Description = @Description"
                               + " WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        public void Done(Todo item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "UPDATE Todo SET "
                                + " Done = @Done "
                               + " WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        public void Delete(Todo item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "delete from Todo WHERE Todoid = @Todoid";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }
    }
}