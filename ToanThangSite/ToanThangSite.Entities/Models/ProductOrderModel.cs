using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
   public class ProductOrderModel
    {
        public string CustommerName { get; set; }
        public string Avatar { get; set; }
        public string NameProduct { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Price { get; set; }
        public string PriceSale { get; set; }

    }
}
