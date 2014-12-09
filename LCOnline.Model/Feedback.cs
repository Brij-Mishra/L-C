using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class Feedback
    {
        [Required]
        public int FeedbackId { get; set; }

        public string OverAllComment { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public ICollection<QnA> QnAs { get; private set; }

        public Feedback()
        {
            QnAs = new List<QnA>();
        }
    }
}