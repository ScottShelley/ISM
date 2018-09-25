using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ISMWebApp.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        private readonly DbConnection _connection;
        public AdminController(PgSqlContext pgSqlContext, DbConnection connection)
        {
            this._pgSqlContext = pgSqlContext;
            _connection = connection;

        }

        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpDelete("delete/{table}/{id}/{value}")]
        public async Task<IActionResult> OnPostDeleteAsync(string table, int? id, bool? value)
        {
            if (table == null || value == null || id == null)
            {
                return NotFound();
            }

            using (IDbConnection dbConnection = _connection)
            {
                try
                {
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync($"UPDATE {table} SET isdeleted={value} WHERE id = {id};");
                    return Ok(true);
                }
                catch (System.Exception)
                {
                    return NotFound("Not Working!");
                }
                finally
                {
                    dbConnection.Close();
                }
                
            }

            
        }
    }
}
