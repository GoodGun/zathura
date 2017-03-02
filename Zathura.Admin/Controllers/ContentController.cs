using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;

namespace Zathura.Admin.Controllers
{
    public class ContentController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Add()
        {
            return View();
        }
    }
}