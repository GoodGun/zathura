using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Zathura.UI.Helper;

namespace Zathura.UI.Controllers
{
    public class CommonController : Controller
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var json = JsonDataStoreHelper.GetData(Common.GetEnumDescription(JsonFiles.Menu));
            var menu = JsonConvert.DeserializeObject<List<Zathura.UI.Models.MenuItem>>(json);
            ViewBag.MenuItems = menu;
            return PartialView("_Menu");
        }

        [ChildActionOnly]
        public ActionResult Rating()
        {
            return PartialView("_Rating");
        }
    }
}