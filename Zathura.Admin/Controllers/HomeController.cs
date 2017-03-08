using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Zathura.Admin.CustomFilter;
using Zathura.Logs;

namespace Zathura.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [LoginFilter]
        public ActionResult Index()
        {
            LogHelper.Error("Log eklendi");
            return View();
        }
    }
}