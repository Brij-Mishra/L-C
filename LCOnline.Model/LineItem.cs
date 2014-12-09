using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCOnline.Model
{
    public class LineItem
    {
        [Required]
        public int LineItemId { get; set; }

        public int MenuItemId { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public double FinalPrice { get; set; }

        // TODO: DateCreated is not required
        public DateTime DateCreated { get; set; }

        public int Count { get; set; }
    }
}
