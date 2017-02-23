using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zathura.Admin.Helper
{
    public class ResultJson
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExStackTrace { get; set; }
    }
}