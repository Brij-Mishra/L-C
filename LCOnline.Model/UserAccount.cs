using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class UserAccount
    {
        [Required]
        public int UserAccountId { get; set; }

        [Required]
        public string UserAccountName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public DateTime? DateofBirth { get; set; }

        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public virtual ICollection<Order> Orders { get; private set; }

        public virtual ICollection<Address> Addresses { get; private set; }

        public UserAccount()
        {
            Addresses = new List<Address>();
            Orders = new List<Order>();
        }
    }
}