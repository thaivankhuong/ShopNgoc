using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Business.Common;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;


namespace ToanThangSite.Business.Core
{
    public  class CollectionBusiness
    {
        public static List<Collection> GetAll()
        {
            try
            {
                return CollectionServices.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static IPagedList<Collection> GetAll(int page, int pageSize)
        {
            try
            {
                return CollectionServices.GetAll(page, pageSize);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<Collection> GetHot()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Collection> Lst = db.Collections.OrderByDescending(x => x.CreateDate).Take(3).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static Collection GetByID(int ID)
        {
            try
            {
                return CollectionServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static bool Create(Collection item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                item.CreateDate = DateTime.Now;
                db.Collections.Add(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, Collection item)
        {
            try
            {
                DBEntities db = new DBEntities();
                Collection model = db.Collections.Find(id);
                model.Avatar = item.Avatar;
                model.Title = item.Title;
                model.Deripstion = item.Deripstion;
                model.CreateDate = DateTime.Now;
                model.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
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
                Collection item = db.Collections.Find(id);
                db.Collections.Remove(item);
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
                Collection item = db.Collections.Find(Convert.ToInt32(id));
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
