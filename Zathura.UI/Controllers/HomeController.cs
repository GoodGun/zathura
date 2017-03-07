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
        // GET: Home
        public ActionResult Index()
        {
            List<Program> programs = null;

            var web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("iso-8859-9")
            };
            HtmlDocument doc = web.Load( "http://www.sporx.com/tvdebugun/");
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
            ViewBag.Programs = programs;
            return View();
        }
    }
}