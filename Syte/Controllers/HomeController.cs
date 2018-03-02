using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibarySyte.ParseSyte.Olimpikz.Parse;
using Syte.MyParse.LogicaParse;

namespace Syte.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult My()
        {
            return View();
        }
        [HttpPost]
        public string Mys()
        {
            ParseOlimp parse = new ParseOlimp();
            return parse.HtmlParse();
        }
    }
}