using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISMWebApp.Controllers.API
{
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        private readonly DbConnection _connection;
        public LocationController(PgSqlContext pgSqlContext, DbConnection connection)
        {
            _pgSqlContext = pgSqlContext;
            _connection = connection;
        }

        public async Task<IActionResult> Index()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return Ok(await dbConnection.QueryAsync("SELECT id, country, instituteid, postcode, state, street, suburb FROM public.locations WHERE isdeleted = false;"));
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
                return Ok(await dbConnection.QueryAsync<Location>("SELECT * FROM locations WHERE isdeleted = false AND id=@Id;", new { Id = id }));
            }            
        }

        [HttpGet("byinstitute/{id}")]
        public async Task<IActionResult> GetbyInstitute(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return Ok(await dbConnection.QueryAsync<Location>("SELECT * FROM locations WHERE isdeleted = false AND instituteid=@Id;", new { Id = id }));
            }            
        }
    }
}