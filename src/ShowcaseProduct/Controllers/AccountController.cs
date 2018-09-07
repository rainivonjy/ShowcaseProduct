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
using Microsoft.AspNetCore.Http.Authentication;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowcaseProduct.Controllers
{
    public class AccountController : Controller
    {
        ApplicationDbContext dbcontext;
        private SignInManager<ApplicationUser> _signManager;
        private UserManager<ApplicationUser> _userManager;
        private EmailSender emailSender;
        private  RoleManager<ApplicationRole> roleManager;
        public AccountController(ApplicationDbContext context, SignInManager<ApplicationUser> _signManager,
           UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> roleManager)
        {
            dbcontext = context;
            this._signManager = _signManager;
            this._userManager = _userManager;
            this.roleManager = roleManager;
            this.emailSender = new EmailSender();
        }
        //
        // GET: /Account/ConfirmEmail
        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return View("Error");
            }
            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        public IActionResult FacebookLogin()
        {
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            };
            return Challenge(authProperties, "Facebook");
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            ExternalLoginInfo info = await _signManager.GetExternalLoginInfoAsync();
            //info.Principal //the IPrincipal with the claims from facebook
            //info.ProviderKey //an unique identifier from Facebook for the user that just signed in
            //info.LoginProvider //a string with the external login provider name, in this case Facebook

            //to sign the user in if there's a local account associated to the login provider
            //var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);            
            //result.Succeeded will be false if there's no local associated account 

            //to associate a local user account to an external login provider
            //await _userInManager.AddLoginAsync(aUserYoullHaveToCreate, info);        
            return Redirect("~/");
        }


        // GET Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(ApplicationRole model)
        {
            if (ModelState.IsValid)
            {
                var role = new ApplicationRole();
                role.Name = model.Name;
                
                await roleManager.CreateAsync(role);
                return RedirectToAction("ListRole", "Account");
            }
            return View();
        }

        // GET AddRole
        public IActionResult AddRole()
        {
            return View();
        }
        // GET AddRole
        public IActionResult ListRole()
        {
            ViewData["allroles"] = dbcontext.Roles;
            return View();
        }


        // GET Register
        public IActionResult Register()
        {
            ViewBag.Name = new SelectList(dbcontext.Roles
                                            .ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
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

                        string callbackUrl = Url.Action("ConfirmEmail",
                 "Account", new
                 {
                     userid = user.Id,
                     token = code
                 },
                  protocol: HttpContext.Request.Scheme);
                   await emailSender.SendEmailAsync(model.UserName,model.Email, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                    //Assign Role to user Here   
                    await this._userManager.AddToRoleAsync(user, model.UserRoles);
                    //Ends Here 
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Name = new SelectList(dbcontext.Roles
                                          .ToList(), "Name", "Name");
               // AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
