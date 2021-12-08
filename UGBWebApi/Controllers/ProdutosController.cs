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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        [HttpGet("id")]
        public async Task<IActionResult> Index(int id)
        {
            return Ok(await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "vale1", "vale2" };
        //}

        // GET: Produtos/Details/5
        //[HttpGet]
        //public async Task<IActionResult> Details(int? id)
        //{
        //if (id == null)
        //{
        //    return NotFound();
        //}

        //var produto = await _context.Produtos
        //    .FirstOrDefaultAsync(m => m.Id == id);
        //if (produto == null)
        //{
        //    return NotFound();
        //}

        //    return Ok(produto);
        //    return Ok(await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id));
        //}

        // GET: Produtos/Create
        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return Ok();
        //}

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Caixa,Qtde")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(produto);
        }

        //// GET: Produtos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var produto = await _context.Produtos.FindAsync(id);
        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(produto);
        //}

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Caixa,Qtde")] Produto produto)
        //{
        //    if (id != produto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(produto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProdutoExists(produto.Id))
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
        //    return View(produto);
        //}

        // GET: Produtos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var produto = await _context.Produtos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (produto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(produto);
        //}

        // POST: Produtos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var produto = await _context.Produtos.FindAsync(id);
        //    _context.Produtos.Remove(produto);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //public bool ProdutoExists(int id)
        //{
        //    return _context.Produtos.Any(e => e.Id == id);
        //}
    }
}
