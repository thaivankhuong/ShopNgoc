using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ToanThangSite.Business.Common;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;

namespace ToanThangSite.Business.Core
{
    public class ProductCategoryBusiness
    {
        public static List<ProductCategory> GetAll()
        {
            try
            {
                return ProductCategoryServices.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static ProductCategory GetByID(int ID)
        {
            try
            {
                return ProductCategoryServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static bool Create(ProductCategory item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                item.CreateBy = HttpContext.Current.User.Identity.Name;
                item.CreateTime = DateTime.Now;
                item.ModifyBy = HttpContext.Current.User.Identity.Name;
                item.ModifyTime = DateTime.Now;
                db.ProductCategories.Add(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, ProductCategory item)
        {
            try
            {
                DBEntities db = new DBEntities();
                ProductCategory model = db.ProductCategories.Find(id);
                model.SeoUrl = item.Title.ToUrlFormat(true)+".html";
                model.Title = item.Title;
                model.ModifyBy = HttpContext.Current.User.Identity.Name;
                model.ModifyTime = DateTime.Now;
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
        public static bool Delete(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                ProductCategory item = db.ProductCategories.Find(id);
                if (db.Products.Where(x => x.CategoryID == id).Count() > 0)
                {
                    return false;
                }
                db.ProductCategories.Remove(item);
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
