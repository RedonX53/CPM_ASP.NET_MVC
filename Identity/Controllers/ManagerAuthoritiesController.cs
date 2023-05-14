using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Identity.Models;

namespace Identity.Controllers
{
    public class ManagerAuthoritiesController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public ManagerAuthoritiesController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: ManagerAuthorities
        public async Task<IActionResult> Index()
        {
            return _context.ManagerAuthorities != null ?
                        View(await _context.ManagerAuthorities.ToListAsync()) :
                        Problem("Entity set 'AppIdentityDbContext.ManagerAuthorities'  is null.");
        }

        // GET: ManagerAuthorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ManagerAuthorities == null)
            {
                return NotFound();
            }

            var managerAuthority = await _context.ManagerAuthorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managerAuthority == null)
            {
                return NotFound();
            }

            return View(managerAuthority);
        }

        // GET: ManagerAuthorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManagerAuthorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Address")] ManagerAuthority managerAuthority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(managerAuthority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(managerAuthority);
        }

        // GET: ManagerAuthorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ManagerAuthorities == null)
            {
                return NotFound();
            }

            var managerAuthority = await _context.ManagerAuthorities.FindAsync(id);
            if (managerAuthority == null)
            {
                return NotFound();
            }
            return View(managerAuthority);
        }

        // POST: ManagerAuthorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Address")] ManagerAuthority managerAuthority)
        {
            if (id != managerAuthority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(managerAuthority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerAuthorityExists(managerAuthority.Id))
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
            return View(managerAuthority);
        }

        // GET: ManagerAuthorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ManagerAuthorities == null)
            {
                return NotFound();
            }

            var managerAuthority = await _context.ManagerAuthorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (managerAuthority == null)
            {
                return NotFound();
            }

            return View(managerAuthority);
        }

        // POST: ManagerAuthorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ManagerAuthorities == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.ManagerAuthorities'  is null.");
            }
            var managerAuthority = await _context.ManagerAuthorities.FindAsync(id);
            if (managerAuthority != null)
            {
                _context.ManagerAuthorities.Remove(managerAuthority);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerAuthorityExists(int id)
        {
            return (_context.ManagerAuthorities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
