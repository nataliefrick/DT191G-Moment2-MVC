using Microsoft.AspNetCore.Mvc;

namespace DT191G_M2_MVC.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriteCookie(string cookiename, string cookievalue, bool IsPersistent)
        {
            CookieOptions cookies = new CookieOptions();
            cookies.Expires = DateTime.Now.AddDays(1);

            if (IsPersistent)
            {
                // save into text file
                Response.Cookies.Append(cookiename, cookievalue, cookies);
            } else
            {
                Response.Cookies.Append(cookiename, cookievalue);
            }

            ViewBag.message = "Cookies added successfully";
            return View();
        }
        public IActionResult ReadCookie()
        {
            ViewBag.cookievalue = Request.Cookies["username"].ToString();
            return View();
        }
    
}
}
