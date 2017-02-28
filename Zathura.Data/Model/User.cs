using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class User : BaseEntity
    {

        [MaxLength(50, ErrorMessage = "Ad Alanı 50 karakterden uzun olamaz!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Soyad Alanı 50 karakterden uzun olamaz!")]
        [Display(Name = "SoyAd")]
        public string Surname { get; set; }

        [Display(Name = "e-mail")]
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Geçerli bir e-mail adresi giriniz!")]
        public string Email { get; set; }

        [MaxLength(16, ErrorMessage = "Şifre Alanı 16 karakterden uzun olamaz!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [Required]
        public string Password { get; set; }
        
        public virtual Role Role { get; set; }
    }
}
