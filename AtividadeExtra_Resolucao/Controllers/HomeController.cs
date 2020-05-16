using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtividadeExtra_Resolucao.Models;
using Microsoft.AspNetCore.Authorization;

namespace AtividadeExtra_Resolucao.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Gerente")]
        public IActionResult About()
        {
            ViewData["Message"] = "Bem-vindo GERENTE.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Bem-vindo Admin.";

            return View();
        }

        [Authorize(Roles = "Admin,Teste")]
        public IActionResult Teste()
        {
            ViewData["Message"] = "Bem-vindo Admin ou Teste.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
