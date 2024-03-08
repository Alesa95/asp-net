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
    public class VideojuegosController : Controller
    {
        private readonly Tutorial_ASP_NET_MVCContext _context;

        public VideojuegosController(Tutorial_ASP_NET_MVCContext context)
        {
            _context = context;
        }

        // GET: Videojuegos
        public async Task<IActionResult> Index()
        {
            var tutorial_ASP_NET_MVCContext = _context.Videojuego.Include(v => v.Consola);
            return View(await tutorial_ASP_NET_MVCContext.ToListAsync());
        }

        // GET: Videojuegos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuego
                .Include(v => v.Consola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // GET: Videojuegos/Create
        public IActionResult Create()
        {
            ViewData["ConsolaId"] = new SelectList(_context.Consola, "Id", "Nombre");
            return View();
        }

        // POST: Videojuegos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Pegi,FechaLanzamiento,ConsolaId")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videojuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsolaId"] = new SelectList(_context.Consola, "Id", "Nombre", videojuego.ConsolaId);
            return View(videojuego);
        }

        // GET: Videojuegos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuego.FindAsync(id);
            if (videojuego == null)
            {
                return NotFound();
            }
            ViewData["ConsolaId"] = new SelectList(_context.Consola, "Id", "Nombre", videojuego.ConsolaId);
            return View(videojuego);
        }

        // POST: Videojuegos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Pegi,FechaLanzamiento,ConsolaId")] Videojuego videojuego)
        {
            if (id != videojuego.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videojuego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideojuegoExists(videojuego.Id))
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
            ViewData["ConsolaId"] = new SelectList(_context.Consola, "Id", "Nombre", videojuego.ConsolaId);
            return View(videojuego);
        }

        // GET: Videojuegos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuego
                .Include(v => v.Consola)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videojuego = await _context.Videojuego.FindAsync(id);
            if (videojuego != null)
            {
                _context.Videojuego.Remove(videojuego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideojuegoExists(int id)
        {
            return _context.Videojuego.Any(e => e.Id == id);
        }
    }
}
