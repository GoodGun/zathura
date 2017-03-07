using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zathura.UI.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Url { get; set; }

        public string ScrapeUrl { get; set; }
    }
}