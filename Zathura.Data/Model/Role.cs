using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class Role : BaseEntity
    {
        [Display(Name = "Rol Adı :")]
        [MinLength(3, ErrorMessage = "Lütfen 3 karakterden uzun değer giriniz!"), MaxLength(20, ErrorMessage = "Lütfen 20 karakterden kısa değer giriniz!")]
        public string Name { get; set; }
    }
}
