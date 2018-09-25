using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using ISMWebApp.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ISMWebApp.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string returnUrl = "/")
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Credentials credentials, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AuthenticationApiClient client = new AuthenticationApiClient(new Uri($"https://{_configuration["Auth0:Domain"]}/"));

                    var result = await client.GetTokenAsync(new ResourceOwnerTokenRequest
                    {
                        ClientId = _configuration["Auth0:ClientId"],
                        ClientSecret = _configuration["Auth0:ClientSecret"],
                        Scope = "openid profile",
                        Realm = "Username-Password-Authentication", // Specify the correct name of your DB connection
                        Username = credentials.Email,
                        Password = credentials.Password
                    });

                    // Get user info from token
                    var user = await client.GetUserInfoAsync(result.AccessToken);

                    // Create claims principal
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId),
                        new Claim(ClaimTypes.Name, user.FullName)

                    }, CookieAuthenticationDefaults.AuthenticationScheme));

                    // Sign user into cookie middleware
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToLocal(returnUrl);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(credentials);
        }

        [Authorize]
        [HttpGet("Logout")]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in the 
                // **Allowed Logout URLs** settings for the app.
                RedirectUri = Url.Action("Index", "Admin")
            });
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
        }
    }
}