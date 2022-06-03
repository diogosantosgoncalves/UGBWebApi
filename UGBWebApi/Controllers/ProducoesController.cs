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
    public class ProducoesController : Controller
    {
        private readonly AppDbContext _context;

        public ProducoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Data,IndiceDisponibilidade,IndicePerfomance,IndiceQualidade,Resultado,IdTurno,IdSetor,IdProduto")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(producao);
        }

        [HttpGet("UltimoCodigo")]
        public int GetUltimoCodigo()
        {
            return  _context.Producoes.OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;
        }
    }
}
