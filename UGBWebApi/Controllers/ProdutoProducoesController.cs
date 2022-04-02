using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoProducoesController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoProducoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,NomeProduto,Qtde,QtdeEstimada,Unidade")] ProdutoProducao produtoProducao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoProducao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(produtoProducao);
        }
    }
}
