using Microsoft.AspNetCore.Mvc;
using PLACTECUGHH.DTOs.Auth;
using PLACTECUGHH.Models;
using PLACTECUGHH.Services.AuthService;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace PLACTECUGHH.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Register");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return View("Register", dto);

            if (await _authService.EmailExistsAsync(dto.email))
            {
                ModelState.AddModelError("email", "Email already exists.");
                return View("Register", dto);
            }

            await _authService.RegisterAsync(dto);

            return RedirectToAction("Index", "Home");
        }
    }
}
