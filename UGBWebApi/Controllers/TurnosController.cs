﻿using System;
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
    public class TurnosController : Controller
    {
        private readonly AppDbContext _context;

        public TurnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Turnos
        [HttpGet("id")]
        public async Task<IActionResult> Index(int id)
        {
            return View(await _context.Turnos.FirstOrDefaultAsync(m => m.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnos()
        {
            return await _context.Turnos.ToListAsync();
        }

        // GET: Turnos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var turno = await _context.Turnos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (turno == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(turno);
        //}

        // GET: Turnos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Turnos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome,Qtde")] Turno turno)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(turno);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(turno);
        //}

        //// GET: Turnos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var turno = await _context.Turnos.FindAsync(id);
        //    if (turno == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(turno);
        //}

        //// POST: Turnos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Qtde")] Turno turno)
        //{
        //    if (id != turno.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(turno);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TurnoExists(turno.Id))
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
        //    return View(turno);
        //}

        //// GET: Turnos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var turno = await _context.Turnos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (turno == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(turno);
        //}

        //// POST: Turnos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var turno = await _context.Turnos.FindAsync(id);
        //    _context.Turnos.Remove(turno);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool TurnoExists(int id)
        //{
        //    return _context.Turnos.Any(e => e.Id == id);
        //}
    }
}
