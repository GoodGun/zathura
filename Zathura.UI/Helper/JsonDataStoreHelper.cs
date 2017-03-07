using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Newtonsoft.Json;

namespace Zathura.UI.Helper
{
    public static class JsonDataStoreHelper
    {
        private readonly static string CacheKey = "Data_";
        public static string GetData( string jsonName)
        {
            string json = string.Empty;
            var cache = HttpContext.Current.Cache;
            var filePath = HttpContext.Current.Server.MapPath(string.Format("~/App_Data/{0}.json", jsonName));

            if (cache[string.Format(CacheKey + "{0}", jsonName)] == null)
            {
                json = File.ReadAllText(filePath);
                var depend = new CacheDependency(filePath);
                cache.Insert(string.Format(CacheKey + "{0}", jsonName), json, depend);
            }
            else
            {
                json = (string)cache[string.Format(CacheKey + "{0}", jsonName)];
            }

            return json;
        }
    }
}