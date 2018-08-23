using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShowcaseProduct.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ShowcaseProduct.Models.Account;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext dbcontext;
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;
        public AccountController(ApplicationDbContext context)
        {
            dbcontext = context;
        }
        // GET Register
        public IActionResult Register()
        {
            var test = dbcontext.Roles.FirstOrDefault();
            ViewBag.Name = new SelectList(dbcontext.Roles.Where(u => !u.Name.Contains("Admin"))
                                            .ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            /*if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();*/

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signManager.SignInAsync(user,false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = user.Id, code = code },
                protocol: Request.Scheme);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //Assign Role to user Here   
                    await this._userManager.AddToRoleAsync(user.Id, model.UserRoles);
                    //Ends Here 
                    return RedirectToAction("Index", "Users");
                }
                ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                                          .ToList(), "Name", "Name");
               // AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);



        }
    }
}
