using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ISMWebApp.Controllers.API
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        private readonly DbConnection _connection;
        public CourseController(PgSqlContext pgSqlContext, DbConnection connection)
        {
            _pgSqlContext = pgSqlContext;
            _connection = connection;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return Ok(await dbConnection.QueryAsync("SELECT id, description, imgurl, name, level FROM public.courses WHERE isdeleted = false;"));
            }            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                Course obj = await dbConnection.QueryFirstOrDefaultAsync<Course>("SELECT * FROM courses WHERE id=@Id", new { Id = id });
                if (obj == null) {
                    return NotFound();
                }
                // obj.CourseInstitute = dbConnection.Query<CourseInstitute>("SELECT * FROM coursesinstitute WHERE courseid = @Id;", new { Id = obj.Id }).ToList();
                // Institute insObj = dbConnection.Query<Institute>("SELECT * FROM courses WHERE id=@Id", new { Id = id }).FirstOrDefault();

                return Ok(obj);
            }            
        }

        [HttpGet("CourseInstitute/{id}")]
        public async Task<IActionResult> CourseInstitute(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string sql = "SELECT * FROM coursesinstitute ci WHERE ci.isdeleted = false AND courseid = @id";
            using (IDbConnection dbConnection = _connection)
            {
                var obj = dbConnection.Query<CourseInstitute>(sql, new { Id = id }).ToArray();

                if (obj == null) return NotFound();

                int index = 0;
                foreach (var item in obj)
                {
                    obj[index].Institute = await dbConnection.QueryFirstOrDefaultAsync<Institute>("SELECT i.id, i.description, i.imgurl, i.provider, i.institutename FROM institutes i INNER JOIN coursesinstitute ci ON ci.institutionid = i.id AND i.isdeleted = false AND institutionid = @id", new { Id = item.InstitutionId });
                    obj[index].CourseLocations = dbConnection.Query<CourseLocation>("SELECT * FROM public.courselocations cl WHERE cl.isdeleted = false AND courseinstituteid = @id;", new { Id = item.Id }).ToList();

                    if (obj[index].CourseLocations != null)
                    {
                        int clIndex = 0;
                        foreach (var itemCL in obj[index].CourseLocations)
                        {
                            obj[index].CourseLocations[clIndex].Location = await dbConnection.QueryFirstOrDefaultAsync<Location>("SELECT * FROM locations l WHERE l.isdeleted = false AND id = @Id;", new { Id = itemCL.LocationId});
                            clIndex++;
                        }
                    }
                    
                    index++;
                }
                dbConnection.Close();

                return Ok(obj);
            }
        }

        public Course FindByID(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Course>("SELECT * FROM customer WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

    }
}