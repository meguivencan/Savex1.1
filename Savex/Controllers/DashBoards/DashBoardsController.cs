using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Savex.Models.DashBoards;
using Savex.Models.Expenses;
using Savex.Models.Incomes;

namespace Savex.Controllers.DashBoards
{
    public class DashBoardsController : Controller
    {
        private readonly SavexContext _context;

        public DashBoardsController(SavexContext savexContext)
        {
            _context = savexContext;
        }
        public IActionResult Index()
        {

            var expenses = _context.Expense.Include(e => e.Account).Include(e => e.ExpenseType);
            var incomes = _context.Income.Include(i => i.CashLocation).Include(i => i.IncomeType);

            DashBoard dashBoard = new DashBoard();
            dashBoard.TotalExpenses = expenses;
            dashBoard.TotalIncomes = incomes;

            return View(dashBoard);
        }
    }
}
