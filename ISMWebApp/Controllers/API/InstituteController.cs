using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISMWebApp.Controllers.API
{
    [Route("api/[controller]")]
    public class InstituteController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        private readonly DbConnection _connection;
        public InstituteController(PgSqlContext pgSqlContext, DbConnection connection)
        {
            _pgSqlContext = pgSqlContext;
            _connection = connection;
        }

        public async Task<IActionResult> Index()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return Ok(await dbConnection.QueryAsync("SELECT * FROM public.institutes"));
            }            
        }
    }
}