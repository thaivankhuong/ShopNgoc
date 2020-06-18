using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class SliderBusiness
    {
        public static List<Slider> GetAll()
        {
            try
            {
                return SliderServices.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static Slider GetByID(int ID)
        {
            try
            {
                return SliderServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static bool Create(Slider item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.Status = true;
                db.Sliders.Add(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, Slider item)
        {
            try
            {
                DBEntities db = new DBEntities();
                Slider model = db.Sliders.Find(id);
                model.Avatar = item.Avatar;
                model.Status = item.Status;
                model.Description = item.Description;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Slider item = db.Sliders.Find(id);
                db.Sliders.Remove(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool ChangeImage(int id, string picture)
        {
            try
            {
                DBEntities db = new DBEntities();
                Slider item = db.Sliders.Find(Convert.ToInt32(id));
                item.Avatar = picture;
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
