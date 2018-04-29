using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public object Post(string query)
        {
            var sc = new HR.GraphQL.HRGraphSchema();
            try
            {
                var dict = sc.GraphQL.ExecuteQuery(query);
                return JsonConvert.SerializeObject(dict);
            }
            catch (Exception ex)
            {

                throw;
            }

            //return View();
        }
    }
}
