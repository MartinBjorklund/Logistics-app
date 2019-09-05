using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICAMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICAMVC.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly AuthService _authService;

        public AdminController(AuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userEmail, string role)
        {
            if (!ModelState.IsValid)
            {
                return View("Index"); // return View();
            }

            var userExist = await _authService.UserExist(userEmail);
            if (!userExist)
            {
                ModelState.AddModelError("UserDontExist", $"The user {userEmail} doesn't exist.");
                return View();
            }

            var userAlredyInRole = await _authService.IsInRoleAsync(userEmail, role);
            if (userAlredyInRole)
            {
                ModelState.AddModelError("UserAlreadyInRole", "The user is already in the role.");
                return View();
            }

            var roleExist = await _authService.RoleExistsAsync(role);
            if (!roleExist)
            {
                await _authService.CreateRoleAsync(role);
            }

            await _authService.AddToRoleAsync(userEmail, role);

            return View("UserAdded", userEmail);
        }
    }
}