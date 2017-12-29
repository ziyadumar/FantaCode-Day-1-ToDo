using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ImageDBops.Repositories
{
    public class ImageRepository
    {

        private string connectionString;
        public ImageRepository()
        {
            connectionString = @"Server=localhost;Database=FcdOne;Trusted_Connection=true;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public IEnumerable<ImageModel> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<ImageModel>("SELECT * FROM ImageTable");
            }
        }

        public void Add(ImageModel item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "INSERT INTO ImageTable (ImageName, ImageData, ImageDescription)"
                                + " VALUES(@ImageName, @ImageData, @ImageDescription)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }


        public void Update(ImageModel item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"UPDATE ImageTable SET 
                                ImageDescription = @ImageDescription 
                                WHERE ImageId = @ImageId";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        public ImageModel Delete(int item)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "delete from ImageTable WHERE ImageId = @ImageId";
                dbConnection.Open();
                List<ImageModel> todos = dbConnection.Query<ImageModel>(sQuery, new { id = item }).ToList();
                
                return todos.FirstOrDefault();
            }
        }
    }
}