﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Savex.Models.Expenses;

namespace Savex.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly SavexContext _context;

        public ExpensesController(SavexContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {

            ViewBag.Username = HttpContext.Session.GetString("Username");
            string uname = ViewBag.Username;


            var savexContext = _context.Expense
                .Include(e => e.Account)
                .Include(e => e.ExpenseType)
                .Where(e => e.Account.Username == uname);


            return View(await savexContext.ToListAsync());
        }

        public async Task<IActionResult> SoonToBuy()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            string uname = ViewBag.Username;

            var savexContext = _context.Expense
                .Include(e => e.Account)
                .Include(e => e.ExpenseType)
                .Where(e => e.Account.Username == uname);

            return View(await savexContext.ToListAsync());
        }


        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.Account)
                .Include(e => e.ExpenseType)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Username");
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseType, "Id", "ExpenseTypeName");

            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,ExpenseTypeId,AccountId,Date,Comment,Title,Status,SoonToBuy,PriorityLevel")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", expense.AccountId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseType, "Id", "ExpenseTypeName", expense.ExpenseTypeId);
            return View(expense);
        }


        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", expense.AccountId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseType, "Id", "ExpenseTypeName", expense.ExpenseTypeId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,ExpenseTypeId,AccountId,Date,Comment,Title,Status,SoonToBuy,PriorityLevel")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "Id", expense.AccountId);
            ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseType, "Id", "ExpenseTypeName", expense.ExpenseTypeId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.Account)
                .Include(e => e.ExpenseType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expense = await _context.Expense.FindAsync(id);
            _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.Id == id);
        }
    }
}
