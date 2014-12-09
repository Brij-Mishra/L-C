using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class MenuItem
    {
        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string NutritionDetails { get; set; }

        public int DiscountPercent { get; set; }

        [Required]
        public Double Price { get; set; }

        public bool IsAvailable { get; set; }
        public ICollection<Picture> Pics { get; private set; }

        public ICollection<QnA> Questions { get; private set; }

        public MenuItem()
        {
            Pics = new List<Picture>();
            Questions = new List<QnA>();
        }
    }
}