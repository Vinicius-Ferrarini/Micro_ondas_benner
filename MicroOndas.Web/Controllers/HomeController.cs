using Microsoft.AspNetCore.Mvc;
using MicroOndas.Dominio;

namespace MicroOndas.Web.Controllers;

public class HomeController : Controller
{
    private static Forno _forno = new Forno();

    public IActionResult Index()
    {
        return View(_forno);
    }
}