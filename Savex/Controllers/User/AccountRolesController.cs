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
            var savexContext = _context.AccountRole.Include(a => a.Account).Include(a => a.Role);
            return View(await savexContext.ToListAsync());
        }

        // GET: AccountRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountRole = await _context.AccountRole
                .Include(a => a.Account)
                .Include(a => a.Role)
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Username", "Username");
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id");
            return View();
        }

        // POST: AccountRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,RoleId")] AccountRole accountRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Username", "Username", accountRole.AccountId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", accountRole.RoleId);
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Username", "Username", accountRole.AccountId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", accountRole.RoleId);
            return View(accountRole);
        }

        // POST: AccountRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,RoleId")] AccountRole accountRole)
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
            ViewData["AccountId"] = new SelectList(_context.Account, "Username", "Username", accountRole.AccountId);
            ViewData["RoleId"] = new SelectList(_context.Set<Role>(), "Id", "Id", accountRole.RoleId);
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
                .Include(a => a.Account)
                .Include(a => a.Role)
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
