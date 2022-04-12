﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create([Bind("Id,NomeProduto,Qtde,QtdeEstimada,Unidade")] List<ProdutoProducao> listProdutoProducao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (ProdutoProducao produtoProducao in listProdutoProducao)
                        _context.Add(produtoProducao);
                    //    _context.add(produtoProducao);
                    //_context.AddRange<ProdutoProducao>(listProdutoProducao);
                    //listProdutoProducao.ToList().ForEach(a => _context.ProdutoProducoes.Add(a));
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return Ok();
            }
        }
    }
}