using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCOnline.Model
{
    public class Offer
    {
        public int OfferId { get; set; }

        public string OfferName { get; set; }

        public Enums.DiscountType DiscountType { get; set; }

        public Enums.OfferOn OfferOn { get; set; }

        public string DiscountQty { get; set; }

        public string OfferDescription { get; set; }

        public string OfferRule { get; set; }

        public int ItemId { get; set; }

        public DateTime OfferStart { get; set; }

        public DateTime OfferEnd { get; set; }
    }
}
