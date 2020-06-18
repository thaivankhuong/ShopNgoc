using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToanThangSite.Entities.Models
{
    public class SeoModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<SeoModel> LstSeoModel()
        {
            List<SeoModel> Lst = new List<SeoModel>();
            Lst.Add(new SeoModel { ID = 1, Name = "Trang Chủ" });
            Lst.Add(new SeoModel { ID = 2, Name = "Dự Án" });
            Lst.Add(new SeoModel { ID = 3, Name = "Dịch Vụ" });
            Lst.Add(new SeoModel { ID = 4, Name = "Sản Phẩm" });
            Lst.Add(new SeoModel { ID = 5, Name = "Tin Tức" });
            Lst.Add(new SeoModel { ID = 6, Name = "Giới Thiệu" });
            Lst.Add(new SeoModel { ID = 7, Name = "Tuyển Dụng" });
            Lst.Add(new SeoModel { ID = 8, Name = "Liên Hệ" });
            return Lst;

        }
    }
    
}
