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
using Savex.Models.DashBoards;
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

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Username") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");

                string uname = ViewBag.Username;

                var expenses = _context.Expense
                    .Include(e => e.Account)
                    .Include(e => e.ExpenseType)
                    .Where(e => e.Account.Username == uname);


                var incomes = _context.Income
                    .Include(i => i.CashLocation)
                    .Include(i => i.IncomeType)
                    .Where(e => e.Account.Username == uname);

                DashBoard dashBoard = new DashBoard();
                dashBoard.TotalExpenses = expenses;
                dashBoard.TotalIncomes = incomes;



                return View(dashBoard);


            }
            else
            {
                return RedirectToAction(nameof(SignIn));
            }
           
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([Bind("Username,Password")] Account loginInfo, string username, string password)
        {
            try
            {
                
                var account = await _context.Account.Where(p => p.Username == username && p.Password == password).FirstOrDefaultAsync();


                if (account != null)
                {
                    HttpContext.Session.SetString("Username", username);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
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
            HttpContext.Session.Clear();
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
