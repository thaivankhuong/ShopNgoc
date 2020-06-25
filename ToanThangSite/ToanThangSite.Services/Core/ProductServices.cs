using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Core;
using ToanThangSite.Entities.Models;

namespace ToanThangSite.Services.Core
{
    public class ProductServices
    {
        public static List<Product> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Product> Lst = db.Products.OrderByDescending(x => x.Position).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<Product> GetSimilar(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                int? CateID = db.Products.Find(ID).CategoryID;
                List<Product> Lst = db.Products.OrderByDescending(x => x.CreateTime).Where(x => x.CategoryID == CateID && x.ProductID != ID).Take(3).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<Product> GetHot()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Product> Lst = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.Position).Take(12).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<Product> GetTypical()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Product> Lst = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.ViewTime).Take(12).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static IPagedList<Product> GetAll(int page, int pageSize)
        {
            try
            {
                DBEntities db = new DBEntities();
                IPagedList<Product> Lst = db.Products.OrderByDescending(x => x.CreateTime).ToPagedList(page, pageSize);
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static IPagedList<Product> GetByCategoryID(int page, int pageSize, int CategoryID)
        {
            try
            {
                DBEntities db = new DBEntities();
                IPagedList<Product> Lst = db.Products.Where(x=>x.CategoryID==CategoryID).OrderByDescending(x => x.CreateTime).ToPagedList(page, pageSize);
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static List<Product> GetProducSearch(string search)
        {
            try
            {
                DBEntities db = new DBEntities();
                List<Product> Lst = db.Products.Where(x => x.Title.Contains(search)).OrderByDescending(x => x.CreateTime).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Product GetByID(int ID)
        {
            try
            {
                DBEntities db = new DBEntities();
                Product item = db.Products.FirstOrDefault(x => x.ProductID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<Product> GetWithkey(string key)
        {
            try
            {
                key = key.Replace("-", " ");
                DBEntities db = new DBEntities();
                List<Product> Lst = db.Products.Where(x => x.Status == true && x.Tags.Contains(key) || x.Content.Contains(key) || x.Keyword.Contains(key) || x.Description.Contains(key)).ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<ProductColor> GetAllProductColor()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<ProductColor> Lst = db.ProductColors.ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<ProductSize> GetAllProductSize()
        {
            try
            {
                DBEntities db = new DBEntities();
                List<ProductSize> Lst = db.ProductSizes.ToList();
                db.Dispose();
                return Lst;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
