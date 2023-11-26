using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotebookforContacts1.Database;
using NotebookforContacts1.Models;

namespace NotebookforContacts1.Controllers
{
    public class NotebooksController : Controller
    {
        private readonly NotebookContext1 _context;

        public NotebooksController(NotebookContext1 context)
        {
            _context = context;
        }

        // GET: Notebooks
        public async Task<IActionResult> Index()
        {
              return _context.notebooks != null ? 
                          View(await _context.notebooks.ToListAsync()) :
                          Problem("Entity set 'NotebookContext1.notebooks'  is null.");
        }

        // GET: Notebooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.notebooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // GET: Notebooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MobilePhone,JobTitle,BirthDate")] Notebook notebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notebook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notebook);
        }

        // GET: Notebooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.notebooks.FindAsync(id);
            if (notebook == null)
            {
                return NotFound();
            }
            return View(notebook);
        }

        // POST: Notebooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MobilePhone,JobTitle,BirthDate")] Notebook notebook)
        {
            if (id != notebook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notebook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotebookExists(notebook.Id))
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
            return View(notebook);
        }

        // GET: Notebooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.notebooks == null)
            {
                return NotFound();
            }

            var notebook = await _context.notebooks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notebook == null)
            {
                return NotFound();
            }

            return View(notebook);
        }

        // POST: Notebooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.notebooks == null)
            {
                return Problem("Entity set 'NotebookContext1.notebooks'  is null.");
            }
            var notebook = await _context.notebooks.FindAsync(id);
            if (notebook != null)
            {
                _context.notebooks.Remove(notebook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotebookExists(int id)
        {
          return (_context.notebooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
