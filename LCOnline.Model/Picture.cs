using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Picture
    {
        [Required]
        public int PictureId { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public virtual MenuItem MenuItem { get; set; }
    }
}