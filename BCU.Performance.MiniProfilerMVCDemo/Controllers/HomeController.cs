using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace BCU.Performance.MiniProfilerMVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MiniProfiler profiler = MiniProfiler.Current;

            using (profiler.Step("Loading Homepage View"))
            {
                using (profiler.Step("Doing Complex Calculations"))
                {
                    Thread.Sleep(300);
                }

                return View();
            }
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

        public ActionResult GetAwesomness(string awesomeString)
        {
            var awesomeObject = new MyAwesomeClass();

            if (awesomeString == "Too Damn Awesome")
            {
                awesomeObject.TheBestString = "Best String!";
                awesomeObject.AnEvenBetterString = "So Damn Awesome!";
            }
            else
            {
                awesomeObject.TheBestString = "Meh";
                awesomeObject.AnEvenBetterString = "It is all a Lie!";
            }

            return Json(awesomeObject, JsonRequestBehavior.AllowGet);
        }
    }

    public class MyAwesomeClass
    {
        public string TheBestString { get; set; }

        public string AnEvenBetterString { get; set; }
    }
}