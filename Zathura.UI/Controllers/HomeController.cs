using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Zathura.UI.Helper;
using Zathura.UI.Models;

namespace Zathura.UI.Controllers
{
    public class HomeController : Controller
    {
        private const string scrapeUrlHome = "http://www.sporx.com/tvdebugun/";

        private const string scrapeUrlLive = "https://www.nesine.com/iddaa/canli-mac-sonuclari/";
        public ActionResult Index()
        {
            GetFilteredPage();
            return View();
        }

        public ActionResult Live(string page= "futbol")
        {
            GetLivePage(page);
            return View();
        }

        public ActionResult Filter(string page = "")
        {
            GetFilteredPage(page);
            return View("Index");
        }

        private void GetLivePage(string page)
        {
            Models.Program spot = null;
            List<Program> programs = null;

            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.UTF8
            };
            HtmlDocument doc = web.Load(scrapeUrlLive+ page);

            var liveTable = doc.DocumentNode.SelectSingleNode("//div[@id='result-list']");

            ViewBag.LiveTable = liveTable;
        }

        private void GetFilteredPage(string page = "")
        {
            Models.Program spot = null;
            List<Program> programs = null;

            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-9")
            };
            HtmlDocument doc = web.Load(scrapeUrlHome);

            var spotItem = doc.DocumentNode.SelectSingleNode("//div[@class='tvmanset-content active']");
            if (spotItem != null)
            {
                spot = new Program
                {
                    Name = Common.StripHTML(spotItem.SelectSingleNode(".//h1[@class='ctitle']").InnerHtml),
                    Channel = Common.StripHTML(spotItem.SelectSingleNode(".//p[@class='cdesc']").InnerHtml)
                };
            }

            var matchList = doc.DocumentNode.SelectNodes("//ul[@id='channelList']//li");

            if (matchList != null && matchList.Any())
            {
                programs = new List<Program>();

                foreach (var item in matchList)
                {
                    var program = new Program
                    {
                        Time = Common.StripHTML(item.SelectSingleNode(".//span[@class='ch-time']").InnerHtml),
                        Channel = Common.StripHTML(item.SelectSingleNode(".//span[@class='ch-name']").InnerHtml),
                        Name = Common.StripHTML(item.SelectSingleNode(".//span[@class='ch-text']").InnerHtml)
                    };

                    programs.Add(program);

                }
            }

            ViewBag.Page = page;
            ViewBag.SpotItem = spot;
            ViewBag.Programs = programs;
        }
    }
}