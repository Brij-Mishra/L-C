using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LCOnline.Model;

namespace LCOnline.Models
{
    public class OrderVM
    {
        public int OrderNo { get; set; }
        public string OrderDetails { get; set; }

        public string AreatoSend { get; set; }

        public string Zip { get; set; }

        public string Status { get; set; }

        public DateTime OrderTime { get; set; }
    }
}