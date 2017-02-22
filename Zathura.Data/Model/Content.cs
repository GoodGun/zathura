using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [MaxLength(250, ErrorMessage = "Başlık Alanı 250 karakterden uzun olamaz!")]
        [Display(Name = "Başlık")]
        [Required]
        public string Title { get; set; }


        [MaxLength(250, ErrorMessage = "Kısa Açıklama Alanı 250 karakterden uzun olamaz!")]
        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }

        [MaxLength(2000, ErrorMessage = "Uzun Açıklama Alanı 2000 karakterden uzun olamaz!")]
        [Display(Name = "Uzun Açıklama")]
        public string Description { get; set; }
        public int ViewCount { get; set; }

        [Display(Name = "Durumu")]
        public int Status { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Yayın Tarihi")]
        public DateTime StartDate { get; set; }

        public virtual User User { get; set; }

        [MaxLength(255, ErrorMessage = "Image Alanı 255 karakterden uzun olamaz!")]
        [Display(Name = "Image")]
        public string ImageItem { get; set; }

        public virtual ICollection<Image> ImageItems { get; set; }

        public virtual ContentType ContentType { get; set; }

        public virtual Category Category { get; set; }
    }
}
