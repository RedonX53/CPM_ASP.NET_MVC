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
    public class EngineerSupervisorsController : Controller
    {
        private readonly AppIdentityDbContext _context;

        public EngineerSupervisorsController(AppIdentityDbContext context)
        {
            _context = context;
        }

        // GET: EngineerSupervisors
        public async Task<IActionResult> Index()
        {
            return _context.EngineerSupervisors != null ?
                        View(await _context.EngineerSupervisors.ToListAsync()) :
                        Problem("Entity set 'AppIdentityDbContext.EngineerSupervisors'  is null.");
        }

        // GET: EngineerSupervisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EngineerSupervisors == null)
            {
                return NotFound();
            }
            var engineerSupervisor = await _context.EngineerSupervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineerSupervisor == null)
            {
                return NotFound();
            }
            return View(engineerSupervisor);
        }
        // GET: EngineerSupervisors/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: EngineerSupervisors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,PhoneNumber,Address")] EngineerSupervisor engineerSupervisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineerSupervisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineerSupervisor);
        }
        // GET: EngineerSupervisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EngineerSupervisors == null)
            {
                return NotFound();
            }

            var engineerSupervisor = await _context.EngineerSupervisors.FindAsync(id);
            if (engineerSupervisor == null)
            {
                return NotFound();
            }
            return View(engineerSupervisor);
        }

        // POST: EngineerSupervisors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Address")] EngineerSupervisor engineerSupervisor)
        {
            if (id != engineerSupervisor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineerSupervisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineerSupervisorExists(engineerSupervisor.Id))
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
            return View(engineerSupervisor);
        }

        // GET: EngineerSupervisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EngineerSupervisors == null)
            {
                return NotFound();
            }

            var engineerSupervisor = await _context.EngineerSupervisors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineerSupervisor == null)
            {
                return NotFound();
            }

            return View(engineerSupervisor);
        }

        // POST: EngineerSupervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EngineerSupervisors == null)
            {
                return Problem("Entity set 'AppIdentityDbContext.EngineerSupervisors'  is null.");
            }
            var engineerSupervisor = await _context.EngineerSupervisors.FindAsync(id);
            if (engineerSupervisor != null)
            {
                _context.EngineerSupervisors.Remove(engineerSupervisor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineerSupervisorExists(int id)
        {
            return (_context.EngineerSupervisors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
