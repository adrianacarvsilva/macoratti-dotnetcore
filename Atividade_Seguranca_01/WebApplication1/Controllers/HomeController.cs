using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/home/getnomeusuario")]
        //[Authorize]
        public IActionResult GetNomeUsuario()
        {
            return new ObjectResult(new
            {
                Username = User.Identity.Name
            });
        }
    }
}