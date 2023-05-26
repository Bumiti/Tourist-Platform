using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tourist_Platform.Models;

namespace Tourist_Platform.Controllers
{
    public class AdminLogicsController : Controller
    {
        private readonly TouristDbContext _context;

        public AdminLogicsController(TouristDbContext context)
        {
            _context = context;
        }

        // GET: AdminLogics
        public async Task<IActionResult> Index()
        {
              return _context.AdminLogics != null ? 
                          View(await _context.AdminLogics.ToListAsync()) :
                          Problem("Entity set 'TouristDbContext.AdminLogics'  is null.");
        }

        // GET: AdminLogics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminLogics == null)
            {
                return NotFound();
            }

            var adminLogic = await _context.AdminLogics
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminLogic == null)
            {
                return NotFound();
            }

            return View(adminLogic);
        }

        // GET: AdminLogics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminLogics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AdminName,AdminUsername,Password,ConfirmPassword")] AdminLogic adminLogic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminLogic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminLogic);
        }

        // GET: AdminLogics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminLogics == null)
            {
                return NotFound();
            }

            var adminLogic = await _context.AdminLogics.FindAsync(id);
            if (adminLogic == null)
            {
                return NotFound();
            }
            return View(adminLogic);
        }

        // POST: AdminLogics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,AdminName,AdminUsername,Password,ConfirmPassword")] AdminLogic adminLogic)
        {
            if (id != adminLogic.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminLogic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminLogicExists(adminLogic.AdminId))
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
            return View(adminLogic);
        }

        // GET: AdminLogics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminLogics == null)
            {
                return NotFound();
            }

            var adminLogic = await _context.AdminLogics
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminLogic == null)
            {
                return NotFound();
            }

            return View(adminLogic);
        }

        // POST: AdminLogics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminLogics == null)
            {
                return Problem("Entity set 'TouristDbContext.AdminLogics'  is null.");
            }
            var adminLogic = await _context.AdminLogics.FindAsync(id);
            if (adminLogic != null)
            {
                _context.AdminLogics.Remove(adminLogic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminLogicExists(int id)
        {
          return (_context.AdminLogics?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
