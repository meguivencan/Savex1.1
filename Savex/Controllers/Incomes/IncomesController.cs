using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Savex.Models.Incomes;

namespace Savex.Controllers.Incomes
{
    public class IncomesController : Controller
    {
        private readonly SavexContext _context;

        public IncomesController(SavexContext context)
        {
            _context = context;
        }

        // GET: Incomes
        public async Task<IActionResult> Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            string uname = ViewBag.Username;


            var savexContext = _context.Income
                .Include(i => i.CashLocation)
                .Include(i => i.IncomeType)
                .Where(i => i.Account.Username == uname);
            return View(await savexContext.ToListAsync());
        }

        // GET: Incomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .Include(i => i.CashLocation)
                .Include(i => i.IncomeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // GET: Incomes/Create
        public IActionResult Create()
        {
            ViewData["CashLocationId"] = new SelectList(_context.CashLocation, "Id", "CashLocationName");
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "IncomeTypeName");
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Username");
            return View();
        }

        // POST: Incomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Amount,IncomeTypeId,Date,Comment,Status,CashLocationId,AccountId")] Income income)
        {
            if (ModelState.IsValid)
            {
                _context.Add(income);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashLocationId"] = new SelectList(_context.CashLocation, "Id", "Id", income.CashLocationId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Id", income.IncomeTypeId);
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Username");

            return View(income);
        }

        // GET: Incomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            ViewData["CashLocationId"] = new SelectList(_context.CashLocation, "Id", "Id", income.CashLocationId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Id", income.IncomeTypeId);
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Username");

            return View(income);
        }

        // POST: Incomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Amount,IncomeTypeId,Date,Comment,Status,CashLocationId")] Income income)
        {
            if (id != income.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(income);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncomeExists(income.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CashLocationId"] = new SelectList(_context.CashLocation, "Id", "Id", income.CashLocationId);
            ViewData["IncomeTypeId"] = new SelectList(_context.IncomeType, "Id", "Id", income.IncomeTypeId);
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Username");

            return View(income);
        }

        // GET: Incomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var income = await _context.Income
                .Include(i => i.CashLocation)
                .Include(i => i.IncomeType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }

            return View(income);
        }

        // POST: Incomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var income = await _context.Income.FindAsync(id);
            _context.Income.Remove(income);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.Id == id);
        }
    }
}
