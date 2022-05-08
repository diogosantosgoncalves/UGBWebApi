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
    public class PerdasController : Controller
    {
        private readonly AppDbContext _context;

        public PerdasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Nome,Caixa,Qtde")] List<Perda> listPerda)
        {
            if (ModelState.IsValid)
            {
                foreach (Perda perda in listPerda)
                    _context.Add(perda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok();
        }
    }
}
