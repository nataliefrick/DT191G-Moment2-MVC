using Microsoft.AspNetCore.Mvc;

namespace DT191G_M2_MVC.Controllers
{
    public class VisiterController : Controller
    {
        public IActionResult Index()
        {
            string? value = "Unknown";
            if (Request.Cookies["visiterName"] != null)
            {
                value = Request.Cookies["visiterName"];

            }
            return View("index", value);
        }
    }
}
