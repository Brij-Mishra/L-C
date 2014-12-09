using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class CartItem
    {
        [Required]
        public int CartItemId { get; set; }

        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public DateTime DateCreated { get; set; }

        public int Count { get; set; }
    }
}