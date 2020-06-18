using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
    public class SearchResultViewModel
    {
        public string Thumbs { get; set; }
        public string Title { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateBy { get; set; }
        public int? ViewTime { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
