using Microsoft.AspNetCore.Mvc;

namespace testcrud.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index()
        {
            return View();
        }        
    }
}