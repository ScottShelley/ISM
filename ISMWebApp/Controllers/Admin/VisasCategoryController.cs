using System.Threading.Tasks;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class VisasCategoryController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        public VisasCategoryController(PgSqlContext pgSqlContext)
        {
            this._pgSqlContext = pgSqlContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _pgSqlContext.VisasCategorys.OrderBy(o => o.IsDeleted).ToListAsync());
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisasCategory visasCategory)
        {
            visasCategory.IsDeleted = false;
            if (ModelState.IsValid)
            {
                this._pgSqlContext.Add(visasCategory);
                await this._pgSqlContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet("edit/{visaUrl}")]
        public async Task<IActionResult> Edit(string visaUrl)
        {
            if (visaUrl == string.Empty)
            {
                return NotFound();
            }

            var data = await this._pgSqlContext.VisasCategorys.SingleOrDefaultAsync(s => s.VisaUrl == visaUrl);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost("edit/{visaUrl}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string visaUrl, VisasCategory visasCategory)
        {
            if (visaUrl != visasCategory.VisaUrl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._pgSqlContext.Update(visasCategory);
                    await this._pgSqlContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(visasCategory);
        }

        [HttpDelete("delete/{visaUrl}")]
        public async Task<IActionResult> Delete(string visaUrl)
        {
            if (visaUrl == string.Empty)
            {
                return NotFound();
            }

            var visasCategory = await this._pgSqlContext.VisasCategorys.SingleOrDefaultAsync(s => s.VisaUrl == visaUrl);

            if (visasCategory == null)
            {
                return NotFound();
            }

            visasCategory.IsDeleted =! visasCategory.IsDeleted;
            this._pgSqlContext.Update(visasCategory);
            await this._pgSqlContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}