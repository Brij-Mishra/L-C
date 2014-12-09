using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Enums
    {
        public enum PaymentMethod
        {
            Debitcard,
            Creditcard,
            Internetbanking
        }

        public enum ShoppingCartStatus
        {
            Open,
            Expired,
            ConvertedasOrder
        }

        public enum DeliveryStatus
        {
            PaymentInitiated,
            PaymentFailed,
            PaymentDone,
            Notified,
            OrderPrepared,
            OrderOut,
            Delivered
        }

        public enum OfferOn
        {
            MenuItem,
            CartItem,
            Total,
            Promo,
            GiftVoucher
        }

        public enum DiscountType
        {
            Percentage,
            Absolute
        }
    }
}