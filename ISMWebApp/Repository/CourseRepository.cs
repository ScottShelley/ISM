using System.Data;
using System.Data.Common;
using System.Linq;
using Dapper;
using ISMWebApp.Models;

namespace ISMWebApp.Repository
{
    public class CourseRepository
    {
        private readonly DbConnection _connection;
        public CourseRepository(DbConnection connection)
        {
            _connection = connection;
        }

        public Course FindByID(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Course>("SELECT * FROM courses WHERE id=@Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}