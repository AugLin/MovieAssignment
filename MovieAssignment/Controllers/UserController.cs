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
        private readonly IUsersService _usersService;

        public UserController(IUsersService service)
        {
            _usersService = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                var userFound = _usersService.GetUsersByEmail(user.Email);
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
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var existingUser = _usersService.GetUsersByEmail(user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "A user with this email already exists.");
                    return View(user);
                }

                var salt = GenerateSalt();

                var hashedPassword = HashPassword(user.HashedPassword, salt);

                user.Salt = salt;
                user.HashedPassword = hashedPassword;
                
                _usersService.AddUsers(user);

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
