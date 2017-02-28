using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class Category : BaseEntity
    {
        public int ParentCategoryId { get; set; }

        [MinLength(2, ErrorMessage = "Lütfen {0} karakterden uzun değer giriniz!"), MaxLength(150, ErrorMessage = "Lütfen 150 karakterden kısa değer giriniz!")]
        [Required]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Lütfen {0} karakterden uzun değer giriniz!"), MaxLength(150, ErrorMessage = "Lütfen 150 karakterden kısa değer giriniz!")]
        public string Url { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<Content> Contents { get; set; }
    }
}
