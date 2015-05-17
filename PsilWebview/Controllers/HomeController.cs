using PsilWebview.PSilRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PsilWebview.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return new FilePathResult(@"Views/Home/InterpreterConsole.html", "text/html");
            return View();
        }

        [HttpGet]
        public ActionResult PsilEval(string command)
        {
            var output = PSilEngine.Execute(command);
            var jsonResult = new JsonResult { Data = new { result = output, status = string.Empty } };
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
            //return new JsonResult( { Data = new { evalResult = command, status = string.Empty },JsonRequestBehavior.AllowGet };
        }


        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}