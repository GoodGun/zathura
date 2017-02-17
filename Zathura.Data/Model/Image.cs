using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Display(Name = "Image Path")]
        public string ImageUrl { get; set; }

        public Content Content { get; set; }
    }
}
