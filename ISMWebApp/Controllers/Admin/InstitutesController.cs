using System.Threading.Tasks;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class InstitutesController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        public InstitutesController(PgSqlContext pgSqlContext)
        {
            this._pgSqlContext = pgSqlContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await this._pgSqlContext.Institutes.ToListAsync());
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Institute insititute)
        {
            try
            {
                insititute.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    this._pgSqlContext.Add(insititute);
                    await this._pgSqlContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(insititute);
        }
    }
}