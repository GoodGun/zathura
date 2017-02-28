﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zathura.Data.Model
{
    public class MediaItem : BaseEntity
    {
        [Display(Name = "Media Path")]
        public string Url { get; set; }

        public Content Content { get; set; }

        public int Type { get; set; }
    }
}
