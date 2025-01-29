using Microsoft.AspNetCore.Mvc;

namespace testcrud.Components.TutorialMenu
{
    public class TutorialMenuViewComponent:ViewComponent
    {
        public  IViewComponentResult Invoke(string category)
        {
            ViewData["category"] = category;
            return View();
        }
    }
}