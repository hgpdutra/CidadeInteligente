#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CidadeInteligente.Dominio;
using CidadeInteligente.Infraestrutura.Config;

namespace CidadeInteligente.Controllers
{
    public class EstacaoRecargasController : Controller
    {
        private readonly CidadeInteligenteDbContext _context = new CidadeInteligenteDbContext();


        public EstacaoRecargasController()
        {
            //_context = context;
        }

        // GET: EstacaoRecargas
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstacaoRecargas.ToListAsync());
        }

        // GET: EstacaoRecargas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoRecarga = await _context.EstacaoRecargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacaoRecarga == null)
            {
                return NotFound();
            }

            return View(estacaoRecarga);
        }

        // GET: EstacaoRecargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstacaoRecargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo,Latitude,Longitude")] EstacaoRecarga estacaoRecarga)
        {
            if (ModelState.IsValid)
            {
                estacaoRecarga.Id = Guid.NewGuid();
                _context.Add(estacaoRecarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estacaoRecarga);
        }

        // GET: EstacaoRecargas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoRecarga = await _context.EstacaoRecargas.FindAsync(id);
            if (estacaoRecarga == null)
            {
                return NotFound();
            }
            return View(estacaoRecarga);
        }

        // POST: EstacaoRecargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Tipo,Latitude,Longitude")] EstacaoRecarga estacaoRecarga)
        {
            if (id != estacaoRecarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estacaoRecarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstacaoRecargaExists(estacaoRecarga.Id))
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
            return View(estacaoRecarga);
        }

        // GET: EstacaoRecargas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estacaoRecarga = await _context.EstacaoRecargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estacaoRecarga == null)
            {
                return NotFound();
            }

            return View(estacaoRecarga);
        }

        // POST: EstacaoRecargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var estacaoRecarga = await _context.EstacaoRecargas.FindAsync(id);
            _context.EstacaoRecargas.Remove(estacaoRecarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstacaoRecargaExists(Guid id)
        {
            return _context.EstacaoRecargas.Any(e => e.Id == id);
        }
    }
}
