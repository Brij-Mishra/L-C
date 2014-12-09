using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Restaurant
    {
        [Required]
        public int RestaurantId { get; set; }
        [MaxLength(500)]
        [Required]
        public string RName { get; set; }
        public double RRating { get; set; }
        public double RStar { get; set; }

        public int DiscountPrcentage { get; set; }

        public virtual ICollection<Address> Addresses { get; private set; }

        public virtual ICollection<Order> Orders { get; private set; }

        public virtual ICollection<MenuItem> MenuItems { get; private set; }

        public Restaurant()
        {
            Addresses = new List<Address>();
            Orders = new List<Order>();
            MenuItems = new List<MenuItem>();

        }
    }
}