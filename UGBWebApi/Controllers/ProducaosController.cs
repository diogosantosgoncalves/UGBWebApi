using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UGBWebApi.Context;
using UGBWebApi.Models;

namespace UGBWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducaosController : Controller
    {
        private readonly AppDbContext _context;

        public ProducaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Producaos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producoes.ToListAsync());
        }

        // GET: Producaos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producao = await _context.Producoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (producao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(producao);
        //}

        // GET: Producaos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Producaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,IndiceDisponibilidade,IndicePerfomance,IndiceQualidade,Resultado,QtdeProduzida,Fechado")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producao);
        }

        // GET: Producaos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producao = await _context.Producoes.FindAsync(id);
        //    if (producao == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(producao);
        //}

        // POST: Producaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Data,IndiceDisponibilidade,IndicePerfomance,IndiceQualidade,Resultado,QtdeProduzida,Fechado")] Producao producao)
        //{
        //    if (id != producao.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(producao);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProducaoExists(producao.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(producao);
        //}

        // GET: Producaos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var producao = await _context.Producoes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (producao == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(producao);
        //}

        // POST: Producaos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var producao = await _context.Producoes.FindAsync(id);
        //    _context.Producoes.Remove(producao);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProducaoExists(int id)
        //{
        //    return _context.Producoes.Any(e => e.Id == id);
        //}
    }
}
