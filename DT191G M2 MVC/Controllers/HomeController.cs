using DT191G_M2_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PagedList;
using System.Web.Mvc.Html;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using PagedList.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Security;
//using System.Text.Json.Serialization;
//using System.Xml.Linq;
//using static System.Collections.Specialized.BitVector32;

namespace DT191G_M2_MVC.Controllers // name of app.Controllers
{
    public class HomeController : Controller  // name of file : Controller
    {

        public IActionResult Index()
        {
            //Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            string? messageCookie = HttpContext.Request.Cookies["message"];
            ViewBag.message = messageCookie;

            return View();
        }

        //[HttpPost("/index")]
        [HttpPost]
        public IActionResult Index(string username)
        {

            //Create a new cookie for with options  //tutorial: www.youtube.com/watch?v=6-n_Y4DHe-U
            //Create first options
            CookieOptions cookieOptions = new();

            //Create Expiry date option
            int nrHrs = 10;
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddHours(nrHrs)); //AddDay() or AddHours()
            
            //Add the Cookie to Browser.
            HttpContext.Response.Cookies.Append("username", username, cookieOptions);

            ViewBag.messageCookies = "Cookies added successfully. They will self-destruct in " + nrHrs + " hours.";

            //Add Cookie ViewBag.message
            string message = ViewBag.messageCookies;
            HttpContext.Response.Cookies.Append("message", message);

            //Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            return RedirectToAction("Index");

        }

        public IActionResult DeleteCookie()
        {
            if (HttpContext.Request.Cookies["username"] == null)
                return RedirectToAction("Index", "Index"); //cookie doesn't exist


            HttpContext.Response.Cookies.Delete("username");
            
            ViewBag.name = "";
            ViewBag.cookiesDeleted = "Goodbye. This cookie has been deleted.";

            //Add Cookie ViewBag.cookiesDeleted
            CookieOptions cookieOptions = new();     
            int nrSec = 10;  //Create Expiry date option
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(nrSec)); //AddDay() or AddHours()
            string message = ViewBag.cookiesDeleted;
            HttpContext.Response.Cookies.Append("message", message, cookieOptions);

            return RedirectToAction("Index");
        }

        [Route("/about")]
        public IActionResult About()
        {
            ///Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            return View();
        }


        [Route("/seeportfolio")]
        public IActionResult SeePortfolio()
        {
            var JsonStr = System.IO.File.ReadAllText("portfolio.json");
            var JsonObj = JsonConvert.DeserializeObject<List<PortfolioModel>>(JsonStr);

            ///Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;


            return View(JsonObj);
        }

        [Route("/projects")] // eg. /Home/Projects/1
        public IActionResult Projects(int? page)
        {

            // Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            // Retrieve data list
            var JsonStr = System.IO.File.ReadAllText("portfolio.json");
            var JsonObj = JsonConvert.DeserializeObject<List<PortfolioModel>>(JsonStr);

            // Set up pagination (use plugin pagedlist)
            int pageSize = 2;
            int pageNumber = (page ?? 1); 
            
            var viewModel = JsonObj.ToPagedList(pageNumber, pageSize);

            return View(viewModel);

        }
        // does not work either
        //public IActionResult Projects(int? page)
        //{

        //    // Retrieve existing cookie and send to view
        //    string? nameCookie = HttpContext.Request.Cookies["username"];
        //    ViewBag.name = nameCookie;

        //    // Retrieve data list
        //    var JsonStr = System.IO.File.ReadAllText("portfolio.json");
        //    var JsonObj = JsonConvert.DeserializeObject<List<PortfolioModel>>(JsonStr);

        //    // Set up pagination (use plugin pagedlist)
        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);

        //    var viewModel = JsonObj.ToPagedList(pageNumber, pageSize);

        //    // find total nr pages based on size of model and how many elements displayed per page
        //    int totalCount = Convert.ToInt32(viewModel.Count / pageSize);

        //    //create staticPageList, defining your viewModel, current page, page size and total number of pages.
        //    IPagedList<PortfolioModel> send = new StaticPagedList<PortfolioModel>(viewModel, pageNumber + 1, pageSize, totalCount);

        //    return View(send);
        //    //return View(viewModel);
        //}

        public IActionResult Next(int i)
        {
            i++;
            ViewBag.i = i;

            var JsonStr = System.IO.File.ReadAllText("portfolio.json");
            var JsonObj = JsonConvert.DeserializeObject<List<PortfolioModel>>(JsonStr);

            ///Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            //return RedirectToAction("Index", "projects");
            return View(JsonObj);
        }


        [Route("/portfolio")] 
        public IActionResult Portfolio()
        {
            //Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;

            return View();
        }


        [HttpPost("/portfolio")]
        public IActionResult Portfolio(PortfolioModel model)
        {
            
            if (ModelState.IsValid)
            {
                // form filled in correctly
                var JsonStr = System.IO.File.ReadAllText("portfolio.json");
                var JsonObj = JsonConvert.DeserializeObject<List<PortfolioModel>>(JsonStr);

                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                    System.IO.File.WriteAllText("portfolio.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                    ModelState.Clear();
                } 
                else
                {
                    
                    System.IO.File.WriteAllText("portfolio.json", JsonConvert.SerializeObject(model, Formatting.Indented));
                    
                    ModelState.Clear();
                }
            }

            ///Retrieve existing cookie and send to view
            string? nameCookie = HttpContext.Request.Cookies["username"];
            ViewBag.name = nameCookie;
            
            return View();
            //return RedirectToAction("Index", "SeePortfolio");
        }

    }
}
