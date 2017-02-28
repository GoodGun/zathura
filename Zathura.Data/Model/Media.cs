using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class Media : BaseEntity
    {
        [Display(Name = "Media Path")]
        public string Url { get; set; }

        public Content Content { get; set; }
    }
}
