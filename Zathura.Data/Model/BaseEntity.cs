using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class BaseEntity
    {
        public int ID { get; set; }

        private DateTime _createDate = DateTime.Now;

        private DateTime _updateDate = DateTime.Now;

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        [Display(Name = "Güncelleme Tarihi")]
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        [Display(Name = "Durumu")]
        public int Status { get; set; }
    }
}
