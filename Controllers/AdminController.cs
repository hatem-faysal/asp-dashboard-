
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testcrud.Data;
using testcrud.Models;

namespace testcrud.Controllers
{
    public class AdminController : Controller
    {
        private readonly EcommerceDbContext _context;

        public AdminController(EcommerceDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Response = _context.ApplicationUsers.ToList();
            return View(Response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var admin = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (admin != null)
            {
                return View(admin);
            }
            return View();
        }
        
    }
}
