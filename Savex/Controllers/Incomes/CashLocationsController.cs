using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Savex.Models.Incomes;

namespace Savex.Controllers.Incomes
{
    public class CashLocationsController : Controller
    {
        private readonly SavexContext _context;

        public CashLocationsController(SavexContext context)
        {
            _context = context;
        }

        // GET: CashLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashLocation.ToListAsync());
        }

        // GET: CashLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashLocation = await _context.CashLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashLocation == null)
            {
                return NotFound();
            }

            return View(cashLocation);
        }

        // GET: CashLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CashLocationName")] CashLocation cashLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashLocation);
        }

        // GET: CashLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashLocation = await _context.CashLocation.FindAsync(id);
            if (cashLocation == null)
            {
                return NotFound();
            }
            return View(cashLocation);
        }

        // POST: CashLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CashLocationName")] CashLocation cashLocation)
        {
            if (id != cashLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashLocationExists(cashLocation.Id))
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
            return View(cashLocation);
        }

        // GET: CashLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashLocation = await _context.CashLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashLocation == null)
            {
                return NotFound();
            }

            return View(cashLocation);
        }

        // POST: CashLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashLocation = await _context.CashLocation.FindAsync(id);
            _context.CashLocation.Remove(cashLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashLocationExists(int id)
        {
            return _context.CashLocation.Any(e => e.Id == id);
        }
    }
}
