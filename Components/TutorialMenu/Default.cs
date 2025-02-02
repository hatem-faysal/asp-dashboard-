using Microsoft.AspNetCore.Mvc;

namespace testcrud.Components.TutorialMenu
{
    public class TutorialMenuViewComponent:ViewComponent
    {
        public  IViewComponentResult Invoke(string category,string view,string controller,string action,string title,string editValue)
        {
            ViewData["category"] = category;
            ViewData["view"] = view;
            ViewData["controller"] = controller;
            ViewData["action"] = action;
            ViewData["title"] = title;
            ViewData["editValue"] = editValue;
            return View();
        }
    }
}