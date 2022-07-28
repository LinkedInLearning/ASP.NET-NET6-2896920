using Microsoft.AspNetCore.Mvc;
using EvaluationProduit.MVC.Authentication;
using EvaluationProduit.MVC.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EvaluationProduit.MVC.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly UserManager<Utilisateur> _userManager;
        public AuthentificationController(SignInManager<Utilisateur> signInManager, UserManager<Utilisateur> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Utilisateur, model.MotDePasse, true, false);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))

                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Utilisateur user = new Utilisateur
                {
                    UserHandle = model.UserHandle,
                    UserName = model.Utilisateur,
                };
                var result = await _userManager.CreateAsync(user, model.MotDePasse);
                if (result.Succeeded)
                {
                    var addedUser = await _userManager.FindByNameAsync(model.Utilisateur);
                    await _userManager.AddToRoleAsync(addedUser, "Administrator");
                    await _userManager.AddToRoleAsync(addedUser, "User");

                    if (!string.IsNullOrWhiteSpace(model.Email))
                    {
                        Claim claim = new Claim(ClaimTypes.Email, model.Email);
                        await _userManager.AddClaimAsync(addedUser, claim);
                    }
                    return await Login(model);
                }
            }
            return View();
        }

        public async void CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Administrator", "Manager", "User" };
            foreach (var roleName in roleNames)
            {
                bool roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    IdentityRole role = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}

