using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShowcaseProduct.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext context;
        // GET Register
        public IActionResult Register()
        {
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                                            .ToList(), "Name", "Name");
            return View();
        }
    }
}
