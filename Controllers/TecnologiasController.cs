using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Decola.Models;

namespace Decola.Controllers
{
    public class TecnologiasController : Controller
    {
        private readonly Context _context;

        public TecnologiasController(Context context)
        {
            _context = context;
        }

        // GET: Tecnologias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tecnologias.ToListAsync());
        }

        // GET: Tecnologias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            return View(tecnologia);
        }

        // GET: Tecnologias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tecnologias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologias.FindAsync(id);
            if (tecnologia == null)
            {
                return NotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tecnologia tecnologia)
        {
            if (id != tecnologia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiaExists(tecnologia.Id))
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
            return View(tecnologia);
        }

        // GET: Tecnologias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologia = await _context.Tecnologias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            return View(tecnologia);
        }

        // POST: Tecnologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnologia = await _context.Tecnologias.FindAsync(id);
            _context.Tecnologias.Remove(tecnologia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiaExists(int id)
        {
            return _context.Tecnologias.Any(e => e.Id == id);
        }
    }
}
