using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public string Thumb { get; set; }
        public string ListImage { get; set; }
        public string Content { get; set; }
        public string Keyword { get; set; }
        public string Price { get; set; }
        public string PriceSale { get; set; }
        public string MadeIn { get; set; }
        public string ListBranch { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> Position { get; set; }
        public Nullable<int> ViewTime { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public string CreateBy { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string SeoUrl { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Tags { get; set; }
        public string[] ProductSize { get; set; }
        public string[] ProductColor { get; set; }
    }
}
