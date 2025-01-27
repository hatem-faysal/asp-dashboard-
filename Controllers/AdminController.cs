
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

    }
}
