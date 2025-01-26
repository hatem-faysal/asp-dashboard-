

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using testcrud.Data;
using testcrud.Data.Static;
using testcrud.Data.ViewModels;
using testcrud.Models;

namespace testcrud.Controllers
{
    [Route("admin")]

    public class AccountController : Controller
    {
        private readonly EcommerceDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            EcommerceDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet("login")]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginVM model)
        {
            Console.WriteLine("11");
            // if(ModelState.IsValid)  return View(model);
            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                Console.WriteLine("222");
                //Check Password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
                if (passwordCheck)
                {
                    Console.WriteLine("333");
                    var Result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    Console.WriteLine("444");
                    if (Result.Succeeded)
                    {
                        Console.WriteLine("555");
                        return RedirectToAction("Index", "Home");
                    }
                    Console.WriteLine("666");
                }
                return View(model);
            }
            return View(model);
        }
        [HttpGet("Register")]
        public IActionResult Register()
        {
            var Result = new RegisterVM();
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {

            var user = await _userManager.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                return View(model);
            }
            var newUser = new ApplicationUser() { Email = model.EmailAddress, FullName = model.FullName, UserName = model.EmailAddress.Split('@')[0] };
            var Result = await _userManager.CreateAsync(newUser, model.Password);
            if (Result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("CompleteRegister");
            }
            return View(model);
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

    }



}
