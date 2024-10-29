using ApplicationCore.Contract.Service;
using ApplicationCore.Entities;
using GenFu.ValueGenerators.Music;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace MovieAssignment.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersServiceAsync _usersService;

        public UserController(IUsersServiceAsync service)
        {
            _usersService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            if (ModelState.IsValid)
            {
                var userFound = await _usersService.GetUsersByEmailAsync(user.Email);
                if (userFound != null)
                {
                    var hashedPassword = HashPassword(user.HashedPassword, userFound.Salt);
                    if (hashedPassword == userFound.HashedPassword)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    }
                }
                RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var existingUser = await _usersService.GetUsersByEmailAsync(user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "A user with this email already exists.");
                    return View(user);
                }

                var salt = GenerateSalt();

                var hashedPassword = HashPassword(user.HashedPassword, salt);

                user.Salt = salt;
                user.HashedPassword = hashedPassword;
                
                await _usersService.AddUsersAsync(user);

                return RedirectToAction("Login");
            }

            return View(user);
        }

        private string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var combinedPasswordSalt = password + salt;
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedPasswordSalt));
            return Convert.ToBase64String(hashedBytes);
        }

        private string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}
