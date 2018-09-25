using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using ISMWebApp.Models;
using ISMWebApp.Services;
using ISMWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    [Authorize]
    public class ImageController : Controller
    {
        private IS3Service _service { get; set; }
        private readonly PgSqlContext _pgSqlContext;
        public ImageController(IS3Service service, PgSqlContext pgSqlContext)
        {
            this._service = service;
            _pgSqlContext = pgSqlContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await this._pgSqlContext.Images.ToListAsync());
        }

        [HttpGet("api")]
        public async Task<IActionResult> GetImages()
        {
            var data = await this._pgSqlContext.Images
                .Where(d => d.IsDeleted == false)
                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("upload")]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost("upload")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(ImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                string url = await this._service.UploadAsync(model.Image);

                if (url != null)
                {
                    await this._pgSqlContext.Database.ExecuteSqlCommandAsync($"INSERT INTO image(name, url, key, isdeleted) VALUES ({model.Name}, {url}, {model.Image.FileName}, false);");

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", S3Service.Error);
                }
                
            }
            
            return View(model);
        }
        
    }
}