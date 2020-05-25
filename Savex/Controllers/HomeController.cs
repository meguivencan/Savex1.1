using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Savex.Models;
using Savex.Models.User;

namespace Savex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SavexContext _context;
        private const string SessionKey = "session";


        public HomeController(ILogger<HomeController> logger, SavexContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index(string userId)
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([Bind("Username,Password")] Account loginInfo, string username)
        {
            try
            {
                var account = await _context.Account.Include(p => p.AccountRoles).FirstOrDefaultAsync(p => p.Username == username);

                if (account != null)
                {
                    ViewData["InvalidUsernamePassword"] = false;
                    Response.Cookies.Append(SessionKey, "loggedin", new CookieOptions() { Expires = DateTime.Now.AddMinutes(5) });
                    ViewBag.Message = "";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["InvalidUsernamePassword"] = true;
                    ViewBag.Message = "error";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "error";
                return View();
            }
        }

        public IActionResult SignOut()
        {
            Response.Cookies.Delete(SessionKey);
            return RedirectToAction(nameof(SignIn));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
