using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


    public void Add(Todo item)
    {
        using (IDbConnection dbConnection = GetConnection())
        {
            string sQuery = "INSERT INTO Todo (Task, Description)"
                            + " VALUES(@Task, @Description)";
            dbConnection.Open();
            dbConnection.Execute(sQuery, item);
        }
    }

    public void Update(Todo item1)
    {
        using (System.Data.IDbConnection dbConnection = GetConnection())
        {
            string sQuery = "UPDATE Todo SET Task = @Task,"
                           + " Description = @Description," 
                           + " WHERE Todoid = @Todoid";
            dbConnection.Open();
            dbConnection.Query(sQuery, item1);
        }
    }



        
    }
}