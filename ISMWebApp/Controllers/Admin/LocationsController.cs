using System.Threading.Tasks;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class LocationsController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        public LocationsController(PgSqlContext pgSqlContext)
        {
            this._pgSqlContext = pgSqlContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var obj = await this._pgSqlContext.Locations
                .Include(i => i.Institute)
                .ToListAsync();

            return View(obj);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {
            try
            {
                location.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    this._pgSqlContext.Add(location);
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
            return View(location);
        }
    }
}