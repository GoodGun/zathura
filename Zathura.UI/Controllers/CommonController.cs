using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Zathura.UI.Helper;

namespace Zathura.UI.Controllers
{
    public class CommonController : Controller
    {
        private const string scrapeUrl = "http://spor.test.hurriyet.com.tr/spor-yeni/";

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
            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            HtmlDocument doc = web.Load(scrapeUrl);

            var ratingItem = doc.DocumentNode.SelectSingleNode("//div[@class='league-table ']");
            if (ratingItem != null)
            {
                ViewBag.RatingTable = ratingItem.InnerHtml;
            }

            return PartialView("_Rating");
        }
    }
}