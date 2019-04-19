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
    }
}