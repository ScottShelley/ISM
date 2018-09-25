using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers
{
    [Route("api/[controller]")]
    public class VisasController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        private readonly DbConnection _connection;
        public VisasController(PgSqlContext pgSqlContext, DbConnection connection)
        {
            this._pgSqlContext = pgSqlContext;
            this._connection = connection;

        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var data = this._pgSqlContext.VisasCategorys.Where(p => p.IsDeleted == false).ToList();
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> Get(string url)
        {
            if (url == null)
            {
                return NotFound();
            }

            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                VisasPage obj = await dbConnection.QueryFirstOrDefaultAsync<VisasPage>("SELECT id, url, description, imgurl, title FROM visaspage WHERE url = @Url AND isdeleted = false;", new { Url = url });
                if (obj == null) {
                    return NotFound();
                }
                obj.Visas = dbConnection.Query<Visas>("SELECT id, html, imgurl, title, visaspageid FROM visas WHERE visaspageid = @Id AND isdeleted = false;", new { Id = obj.Id}).ToList();
                dbConnection.Close();
                return Ok(obj);
            }
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            using (IDbConnection dbConnection = _connection)
            {
                dbConnection.Open();
                return Ok(dbConnection.Query<Visas>("SELECT * FROM visas"));
            }            
        }

    }
}