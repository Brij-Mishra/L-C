using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Address
    {

        [Required]
        public int AddressId { get; set; }


        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Longitude { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string NearbyLandmark { get; set; }

        public string ZipCode { get; set; }

        public string LandLineNumber { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public bool IsDefault { get; set; }

        public DbGeography AddressLocation { get; set; }

        public int? UserAccountId  { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        public int? RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}