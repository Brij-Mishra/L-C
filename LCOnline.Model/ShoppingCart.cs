using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LCOnline.Model
{
    [KnownTypeAttribute(typeof(ShoppingCart))]
    public class ShoppingCart
    {
        [Required]
        public int ShoppingCartId { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime DateModified { get; set; }

        public double TotalPrice { get; set; }

        public Enums.ShoppingCartStatus ShoppingCartStatus { get; set; }
        
        public int? UserAccountId { get; set; }
         
        public virtual UserAccount UserAccount { get; set; }

        [Required]
        public virtual ICollection<CartItem> CartItems { get; private set; }

        public ShoppingCart()
        {
            CartItems = new List<CartItem>();
        }
    }
}