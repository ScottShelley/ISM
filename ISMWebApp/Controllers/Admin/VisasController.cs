using System.Threading.Tasks;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class VisasController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        public VisasController(PgSqlContext pgSqlContext)
        {
            this._pgSqlContext = pgSqlContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _pgSqlContext.VisasPages.ToListAsync());
        }
    }
}