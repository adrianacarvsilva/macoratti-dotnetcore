using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeExtra_Resolucao.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeExtra_Resolucao.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(ApplicationDbContext contexto, RoleManager<IdentityRole> roleManager)
        {
            context = contexto;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public IActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole Role)
        {
            IdentityResult roleResult = await _roleManager.CreateAsync(new IdentityRole(Role.Name));
            return RedirectToAction("Index");
        }
    }
}