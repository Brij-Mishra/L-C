using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCOnline.Models
{
    public class CartVM
    {
        public int CartId { get; set; }

        public int ShoppingCartId { get; set; }

        public string ItemImageUrl { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int Count { get; set; }

        public double UnitPrice { get; set; }

        public double CartItemPrice { get; set; }
    }
}