using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Atividade_31.Models;
using Atividade_31.Contextos;

namespace Atividade_31.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PaisContexto _context;

        public HomeController(ILogger<HomeController> logger, PaisContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Exercicio_1_Paises()
        {
            List<PaisModel> listaPaises = new List<PaisModel>();

            //----pega dados da tabela
            listaPaises = (from pais in _context.Paises
                           select pais).ToList();

            // Inser um item na lista
            listaPaises.Insert(0, new PaisModel { Id = 0, Nome = "Selecione" });
            ViewBag.ListaPaises = listaPaises;
            return View();
        }


        [HttpPost]
        public IActionResult Exercicio_1_Paises(PaisModel pais)
        {
            if (pais.Id == 0)
            {
                ModelState.AddModelError("", "Selecione um pais");
            }

            ViewBag.ValorSelecionado = pais.Id;

            List<PaisModel> listaPaises = new List<PaisModel>();

            //----pega dados da tabela
            listaPaises = (from p in _context.Paises
                           select p).ToList();

            // Inser um item na lista
            listaPaises.Insert(0, new PaisModel { Id = 0, Nome = "Selecione" });
            ViewBag.ListaPaises = listaPaises;
            return View();
        }
    }
      
}
