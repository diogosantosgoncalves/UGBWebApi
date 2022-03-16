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
    public class SetorsController : Controller
    {
        private readonly AppDbContext _context;

        public SetorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Setors.
        [HttpGet("id")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await _context.Setores.FirstOrDefaultAsync(m => m.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetSetors()
        {
            return await _context.Setores.ToListAsync();
        }

        // GET: Setors/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var setor = await _context.Setores
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (setor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(setor);
        //}

        // GET: Setors/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Setors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,HorasProducao")] Setor setor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(setor);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(setor);
        //}

        // GET: Setors/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var setor = await _context.Setores.FindAsync(id);
        //    if (setor == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(setor);
        //}

        // POST: Setors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,HorasProducao")] Setor setor)
        //{
        //    if (id != setor.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(setor);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SetorExists(setor.Id))
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
        //    return View(setor);
        //}

        // GET: Setors/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var setor = await _context.Setores
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (setor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(setor);
        //}

        // POST: Setors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var setor = await _context.Setores.FindAsync(id);
        //    _context.Setores.Remove(setor);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SetorExists(int id)
        //{
        //    return _context.Setores.Any(e => e.Id == id);
        //}
    }
}
