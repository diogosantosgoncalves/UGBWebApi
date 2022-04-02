using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UGBWebApi.Context;
using UGBWebApi.Models;

namespace UGBWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadasController : Controller
    {
        private readonly AppDbContext _context;

        public ParadasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Parada>>> GetParadas()
        //{
        //    return await _context.Paradas.ToListAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Id,Observacao,HoraInicial,HoraFinal,CodigoProducao,Tempo")] Parada parada)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(parada);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return Ok(parada);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CodigoProducao,Observacao,Tempo,HoraInicial,HoraFinal")] Parada parada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(parada);
        }
    }
}
