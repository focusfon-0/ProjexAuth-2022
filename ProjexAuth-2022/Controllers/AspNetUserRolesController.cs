using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjexAuth_2022.Models;

namespace ProjexAuth_2022.Controllers
{
    [Authorize (Roles ="Beheerder")]
    public class AspNetUserRolesController : Controller
    {
        private readonly ProjexDbFinalContext _context;

        public AspNetUserRolesController(ProjexDbFinalContext context)
        {
            _context = context;
        }

        // GET: AspNetUserRoles
        public async Task<IActionResult> Index()
        {
              return View(await _context.AspNetUserRoles.ToListAsync());
        }

        // GET: AspNetUserRoles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AspNetUserRoles == null)
            {
                return NotFound();
            }

            var aspNetUserRole = await _context.AspNetUserRoles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (aspNetUserRole == null)
            {
                return NotFound();
            }

            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] AspNetUserRole aspNetUserRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUserRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AspNetUserRoles == null)
            {
                return NotFound();
            }

            var aspNetUserRole = await _context.AspNetUserRoles.FindAsync(id);
            if (aspNetUserRole == null)
            {
                return NotFound();
            }
            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] AspNetUserRole aspNetUserRole)
        {
            if (id != aspNetUserRole.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspNetUserRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUserRoleExists(aspNetUserRole.UserId))
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
            return View(aspNetUserRole);
        }

        // GET: AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AspNetUserRoles == null)
            {
                return NotFound();
            }

            var aspNetUserRole = await _context.AspNetUserRoles
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (aspNetUserRole == null)
            {
                return NotFound();
            }

            return View(aspNetUserRole);
        }

        // POST: AspNetUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AspNetUserRoles == null)
            {
                return Problem("Entity set 'ProjexDbFinalContext.AspNetUserRoles'  is null.");
            }
            var aspNetUserRole = await _context.AspNetUserRoles.FindAsync(id);
            if (aspNetUserRole != null)
            {
                _context.AspNetUserRoles.Remove(aspNetUserRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUserRoleExists(string id)
        {
          return _context.AspNetUserRoles.Any(e => e.UserId == id);
        }
    }
}
