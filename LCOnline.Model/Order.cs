using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public Double TotalPrice { get; set; }

        public Double DiscountedPrice { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        public DateTime CurrentStatusTime { get; set; }

        [Required]
        public Enums.PaymentMethod PaymentMethod { get; set; }

        [Required]
        public Enums.DeliveryStatus DeliveryStatus { get; set; }

        public string OrderComment { get; set; }

        [Required]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public int UserAccountId { get; set; }

        public virtual UserAccount UserAccount { get; set; }

         [Required]
        public virtual ICollection<LineItem> LineItems { get; private set; }

         public Order()
        {
            LineItems = new List<LineItem>();
        }

    }
}