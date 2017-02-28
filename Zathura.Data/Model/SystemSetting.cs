using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class SystemSetting
    {
        [Key]
        public int ID { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
