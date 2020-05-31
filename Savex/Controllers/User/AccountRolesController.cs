using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Savex.Models.User;

namespace Savex.Controllers.User
{
    public class AccountRolesController : Controller
    {
        private readonly SavexContext _context;

        public AccountRolesController(SavexContext context)
        {
            _context = context;
        }

        // GET: AccountRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountRole.ToListAsync());
        }

        // GET: AccountRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountRole = await _context.AccountRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountRole == null)
            {
                return NotFound();
            }

            return View(accountRole);
        }

        // GET: AccountRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountRoleName")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountRole);
        }

        // GET: AccountRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountRole = await _context.AccountRole.FindAsync(id);
            if (accountRole == null)
            {
                return NotFound();
            }
            return View(accountRole);
        }

        // POST: AccountRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountRoleName")] AccountRole accountRole)
        {
            if (id != accountRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountRoleExists(accountRole.Id))
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
            return View(accountRole);
        }

        // GET: AccountRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountRole = await _context.AccountRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountRole == null)
            {
                return NotFound();
            }

            return View(accountRole);
        }

        // POST: AccountRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountRole = await _context.AccountRole.FindAsync(id);
            _context.AccountRole.Remove(accountRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountRoleExists(int id)
        {
            return _context.AccountRole.Any(e => e.Id == id);
        }
    }
}
