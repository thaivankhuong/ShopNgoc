using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Services.Core
{
    public static class SeoMetaServices
    {
        public static List<SeoMeta> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<SeoMeta> Lst = new List<SeoMeta>();
                Lst = db.SeoMetas.ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static SeoMeta GetById(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                SeoMeta item = new SeoMeta();
                item = db.SeoMetas.FirstOrDefault(x => x.ID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool Update(int ID,SeoMeta item)
        {
            try
            {
                DBEntities db = new DBEntities();
                SeoMeta model = db.SeoMetas.Find(ID);
                model.Title = item.Title;
                model.Description = item.Description;
                model.KeyWord = item.KeyWord;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
