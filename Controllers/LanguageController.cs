using testcrud.Models;
using testcrud.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace testcrud.Controllers;

public class LanguageController : Controller
{
    private readonly ILogger<LanguageController> _logger;
    private LanguageService _localization;
    public LanguageController(ILogger<LanguageController> logger, LanguageService localization)
    {
        _localization = localization;
        _logger = logger;
    }
    public void Index()
    {
        var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
    }
    #region Localization
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1)
        });
        return Redirect(Request.Headers["Referer"].ToString());
    }
    #endregion
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}