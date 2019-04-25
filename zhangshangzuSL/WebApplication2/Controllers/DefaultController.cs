using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestIService;

namespace WebApplication2.Controllers
{
    public class DefaultController : Controller
    {
        public IUserService UserSerive { get; set; }
        // GET: Default
        public ActionResult Index()
        {
            bool b = UserSerive.CheckLogin("abc", "213");
            return Content(b.ToString());
        }

        public ActionResult Test()
        {
            Dog dog = new Dog() {BirthDate=DateTime.Now,Id=5,Name="TMAN" };
            return Json(dog);
        }
        [HttpGet]
        public ActionResult TestJson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestJson(FormCollection fc)
        {
            Dog dog = new Dog() { BirthDate = DateTime.Now, Id = 5 };
            //  return Json(dog);
            return new JsonNetResult() { Data = dog };
            
        }

    }
}