using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }       
        public ActionResult Neco()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "Trener")]
        public ActionResult Fitness()
        {
            ViewBag.Message = "......";
            ViewBag.neco = new int[]{ 0,1,8,3,10,1,2,100,50,90};

     

            return View();
        }
        
        public ActionResult Medical()
        {
            ViewBag.Message = "Nejaky text";

            return View();
        }

        public ActionResult Trener()
        {
            ViewBag.Message = "Neco";

            return View();
        }
    }
}