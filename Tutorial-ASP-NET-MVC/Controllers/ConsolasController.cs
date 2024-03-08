using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutorial_ASP_NET_MVC.Data;
using Tutorial_ASP_NET_MVC.Models;

namespace Tutorial_ASP_NET_MVC.Controllers
{
    public class ConsolasController : Controller
    {
        private readonly Tutorial_ASP_NET_MVCContext _context;

        public ConsolasController(Tutorial_ASP_NET_MVCContext context)
        {
            _context = context;
        }

        // GET: Consolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consola.ToListAsync());
        }

        // GET: Consolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consola = await _context.Consola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consola == null)
            {
                return NotFound();
            }

            return View(consola);
        }

        // GET: Consolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,PrecioBruto,TipoIva")] Consola consola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consola);
        }

        // GET: Consolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consola = await _context.Consola.FindAsync(id);
            if (consola == null)
            {
                return NotFound();
            }
            return View(consola);
        }

        // POST: Consolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,PrecioBruto,TipoIva")] Consola consola)
        {
            if (id != consola.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsolaExists(consola.Id))
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
            return View(consola);
        }

        // GET: Consolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consola = await _context.Consola
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consola == null)
            {
                return NotFound();
            }

            return View(consola);
        }

        // POST: Consolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consola = await _context.Consola.FindAsync(id);
            if (consola != null)
            {
                _context.Consola.Remove(consola);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsolaExists(int id)
        {
            return _context.Consola.Any(e => e.Id == id);
        }
    }
}
