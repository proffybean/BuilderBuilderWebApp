using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuilderBuilderWebApp.BusinessLogic;

namespace BuilderBuilderWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Builder(FormCollection form)
        {
            string inputString = form["entry"];

            Variables v = ParseInput(inputString);

            Printer p = new Printer(v);
            string myClass = p.PrintBuilderClass();
            //return myClass;
            ViewBag.Builder = myClass;

            return View("BuilderPost");
        }

        private static Variables ParseInput(string inputString)
        {
            var foo = new List<string>();
            var result = inputString.Split(new string[] { "\r", "\r\n", "\n", "{" }, StringSplitOptions.RemoveEmptyEntries);

            // Parse classname
            var matches = System.Text.RegularExpressions.Regex.Matches(result[0], @"\w*class\s+(\w+)");
            string classname = matches[0].Groups[1].Value;

            // sanitize fields of access modifiers
            for (int i = 1; i < result.Length; i++)
            {
                result[i] = result[i].Replace("public", "");
                result[i] = result[i].Replace("private", "");
                result[i] = result[i].Replace(";", "");
                result[i] = result[i].Trim();
            }

            var variables = new Variables();
            variables.className = classname; // result[0];

            // now that fields are sanitized, 
            foreach (var res in result.Skip(1))
            {
                string[] var = res.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                variables.members.Add(new Member(var[0], var[1]));
            }

            return variables;
        }
    }
}