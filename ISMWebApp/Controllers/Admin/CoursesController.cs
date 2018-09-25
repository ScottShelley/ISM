using System.Threading.Tasks;
using ISMWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly PgSqlContext _pgSqlContext;
        public CoursesController(PgSqlContext pgSqlContext)
        {
            this._pgSqlContext = pgSqlContext;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await this._pgSqlContext.Courses.ToListAsync());
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this._pgSqlContext.Courses
                .SingleOrDefaultAsync(s => s.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                course.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    this._pgSqlContext.Add(course);
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
            return View(course);
        }

        [HttpPost("update")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._pgSqlContext.Update(course);
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
            return View(course);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this._pgSqlContext.Courses
                .Include(c => c.CourseInstitute)
                    .ThenInclude(c => c.Institute)
                .Include(l => l.CourseInstitute)
                    .ThenInclude(l => l.CourseLocations)
                        .ThenInclude(l => l.Location)
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpGet("link-institute/{id}")]
        public async Task<IActionResult> AddInstitute(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await this._pgSqlContext.Courses
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            var obj = new CourseInstitute { CourseId = course.Id, Id = 0 };

            return View(obj);
        }

        [HttpPost("link-institute/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInstitute(CourseInstitute model)
        {
            try
            {
                model.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    await this._pgSqlContext.Database.ExecuteSqlCommandAsync($"INSERT INTO coursesinstitute(courseid, institutionid, durationweeks, isdeleted, nontution, total, tution) VALUES ({model.CourseId}, {model.InstitutionId}, {model.DurationWeeks}, false, {model.NonTution}, {model.Total}, {model.Tution});");
                    // this._pgSqlContext.Add(model);
                    // await this._pgSqlContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), model.CourseId);
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            // var institutes = await this._pgSqlContext.Institutes.ToListAsync();
            // model.Institute = institutes;

            return View(model);
        }

        [HttpGet("link-location/{id}")]
        public async Task<IActionResult> AddLocation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstitute = await this._pgSqlContext.CourseInstitutes
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);

            if (courseInstitute == null)
            {
                return NotFound();
            }

            var obj = new CourseLocation { CourseInstituteId = courseInstitute.Id, CourseInstitute = courseInstitute };

            return View(obj);
        }

        [HttpPost("link-location/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLocation(CourseLocation model)
        {
            try
            {
                model.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    await this._pgSqlContext.Database.ExecuteSqlCommandAsync($"INSERT INTO courselocations(courseinstituteid, isdeleted, locationid) VALUES ({model.CourseInstituteId}, false, {model.LocationId});");
                    // this._pgSqlContext.Add(model);
                    // await this._pgSqlContext.SaveChangesAsync();

                    var courseInstitutes = await this._pgSqlContext.CourseInstitutes
                        .AsNoTracking()
                        .SingleOrDefaultAsync(s => s.Id == model.CourseInstituteId);

                    return RedirectToAction(nameof(Details), courseInstitutes.CourseId);
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            model.CourseInstitute = await this._pgSqlContext.CourseInstitutes
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == model.CourseInstituteId);

            return View(model);
        }
    }
}