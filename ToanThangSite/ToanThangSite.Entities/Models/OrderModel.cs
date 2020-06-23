using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mobi { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> SendTime { get; set; }
        public string  jsonProduct { get; set; }
    }

    public class ProductCart
    {
        public int ? quantity { get; set; }
        public int ? productId { get; set; }
        public int ? price { get; set; }
        public int ? pricesale { get; set; }
        public int sizeid { get; set; }
        public int colorid { get; set; }
    }
}
