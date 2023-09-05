using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HouseAndWindows.Data;
using HouseAndWindows.Models;

namespace HouseAndWindows.Controllers
{
    public class WindowsController : Controller
    {
        private readonly HouseAndWindowsContext _context;

        public WindowsController(HouseAndWindowsContext context)
        {
            _context = context;
        }

        // GET: Windows
        public async Task<IActionResult> Index()
        {
              return _context.Window != null ? 
                          View(await _context.Window.ToListAsync()) :
                          Problem("Entity set 'HouseAndWindowsContext.Window'  is null.");
        }

        // GET: Windows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Window == null)
            {
                return NotFound();
            }

            var window = await _context.Window
                .FirstOrDefaultAsync(m => m.id == id);
            if (window == null)
            {
                return NotFound();
            }

            return View(window);
        }

        // GET: Windows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Windows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,value")] Window window)
        {
            if (ModelState.IsValid)
            {
                _context.Add(window);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(window);
        }

        // GET: Windows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Window == null)
            {
                return NotFound();
            }

            var window = await _context.Window.FindAsync(id);
            if (window == null)
            {
                return NotFound();
            }
            return View(window);
        }

        // POST: Windows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,value")] Window window)
        {
            if (id != window.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(window);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WindowExists(window.id))
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
            return View(window);
        }

        // GET: Windows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Window == null)
            {
                return NotFound();
            }

            var window = await _context.Window
                .FirstOrDefaultAsync(m => m.id == id);
            if (window == null)
            {
                return NotFound();
            }

            return View(window);
        }

        // POST: Windows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Window == null)
            {
                return Problem("Entity set 'HouseAndWindowsContext.Window'  is null.");
            }
            var window = await _context.Window.FindAsync(id);
            if (window != null)
            {
                _context.Window.Remove(window);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WindowExists(int id)
        {
          return (_context.Window?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
