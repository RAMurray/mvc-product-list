using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProductList.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Display(Name = "Name")]
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        public IEnumerable<SelectListItem> Catagories { get; set; }
    }
}