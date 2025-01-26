using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace testcrud.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult index()
        {
            return View();
        }        
    }
}