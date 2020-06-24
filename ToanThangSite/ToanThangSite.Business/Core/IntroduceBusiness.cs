using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class IntroduceBusiness
    {
        public static List<Introduce> GetAll()
        {
            try
            {
                return IntroduceServices.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Introduce GetTop1()
        {
            try
            {
                return IntroduceServices.GetTop1();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Introduce> GetTop3()
        {
            try
            {
                return IntroduceServices.GetTop3();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Introduce GetByID(int ID)
        {
            try
            {
                return IntroduceServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static bool Create(Introduce item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.Thumb = "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                item.CreateBy = HttpContext.Current.User.Identity.Name;
                item.CreateTime = DateTime.Now;
                item.ModifyBy = HttpContext.Current.User.Identity.Name;
                item.ModifyTime = DateTime.Now;
                if (item.Description == null || item.Description == string.Empty || item.Description == "")
                {
                    item.Description = item.Title;
                }
                db.Introduces.Add(item);

                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, Introduce item)
        {
            try
            {
                DBEntities db = new DBEntities();
                Introduce model = db.Introduces.Find(id);
                model.Avatar = item.Avatar;
                model.Thumb = item.Thumb;
                model.Title = item.Title;
                model.Description = item.Description;
                model.Content = item.Content;
                model.ModifyBy = HttpContext.Current.User.Identity.Name;
                model.ModifyTime = DateTime.Now;
                model.Position = item.Position;
                model.Status = item.Status;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ChangeImage(int id, string picture)
        {
            try
            {
                DBEntities db = new DBEntities();
                Introduce item = db.Introduces.Find(Convert.ToInt32(id));
                item.Avatar = picture;
                item.Thumb = "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Introduce item = db.Introduces.Find(id);
                db.Introduces.Remove(item);
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
