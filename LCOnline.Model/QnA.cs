using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LCOnline.Model
{
    public class QnA
    {
         [Required]
        public int QnAId { get; set; }

        [Required]
        public string Question { get; set; }

        public string Answer1 { get; set; }

        public string Answer2 { get; set; }

        public string Answer3 { get; set; }

        public string Answer4 { get; set; }

        public string Answer5 { get; set; }

        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public virtual MenuItem MenuItem { get; set; }

        public string SelectedAnswer { get; set; }
    }
}