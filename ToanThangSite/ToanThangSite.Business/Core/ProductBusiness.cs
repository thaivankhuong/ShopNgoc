using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Core;
using ToanThangSite.Entities.Models;
using ToanThangSite.Business.Common;

namespace ToanThangSite.Business.Core
{
    public class ProductBusiness
    {

        public static List<Product> GetAll()
        {
            try
            {
                return ProductServices.GetAll();
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
                return ProductServices.GetSimilar(ID);
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
                return ProductServices.GetWithkey(key);
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
                return ProductServices.GetHot();
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
                return ProductServices.GetTypical();
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
                return ProductServices.GetAll(page, pageSize);
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
                return ProductServices.GetByCategoryID(page, pageSize, CategoryID);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public static IPagedList<Product> GetByCollectionID(int page, int pageSize, int CollectionId)
        {
            try
            {
                return ProductServices.GetByCollectionID(page, pageSize, CollectionId);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public static List<Product> GetProducSearch(string search)
        {
            try
            {
                return ProductServices.GetProducSearch( search);
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

        public static Product GetByID(int ID)
        {
            try
            {
                return ProductServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static bool Create(ProductModel item)
        {
            try
            {
                DBEntities db = new DBEntities();
                var product = new Product();
                product.Code = item.Code;
                product.Title = item.Title;
                product.Description = item.Description;
                product.Avatar = item.Avatar;
                product.ListImage = item.ListImage;
                product.Content = item.Content;
                product.Keyword = item.Keyword;
                product.Price = item.Price;
                product.PriceSale = item.PriceSale;
                product.MadeIn = item.MadeIn;
                product.ListBranch = item.ListBranch;
                product.Status = item.Status;
                product.Position = item.Position;
                product.ViewTime = item.ViewTime;
                product.CategoryID = item.CategoryID;
                product.MetaTitle = item.MetaTitle;
                product.MetaDescription = item.MetaDescription;
                product.Tags = item.Tags;

                product.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                product.Thumb = item.Avatar;// "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                product.CreateBy = HttpContext.Current.User.Identity.Name;
                product.CreateTime = DateTime.Now;
                product.ModifyBy = HttpContext.Current.User.Identity.Name;
                product.ModifyTime = DateTime.Now;
                product.ViewTime = 0;
                product.CollectionId = item.CollectionId;
                product.ProductColor = item.ProductColor.Count() > 0 ? string.Join(",", item.ProductColor).ToString() : null;
                product.ProductSize = item.ProductSize.Count() > 0 ? string.Join(",", item.ProductSize).ToString() : null;
                if (item.Description == null || item.Description == string.Empty || item.Description == "")
                {
                    item.Description = item.Title;
                }
                db.Products.Add(product);
                db.SaveChanges();

                //Reason r = new Reason();
                //r.Title = "5 LÝ DO ĐỂ BẠN MUA HÀNG TẠI TOMHUMALASKA.VN";
                //r.ProductID = item.ProductID;
                //r.Content = "Cam kết bán giá rẻ nhất cho người tiêu dùng|Sản phẩm Tươi sống|Tư vấn mua Hiệu quả – Chuyên nghiệp – Tận tâm|Thanh toán thu tiền tận nơi trên toàn quốc|Được đổi trả hàng hoá";
                //db.Reasons.Add(r);
                //db.SaveChanges();
                //db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, ProductModel item)
        {
            try
            {
                DBEntities db = new DBEntities();
                Product model = db.Products.Find(id);
                model.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                model.Code = item.Code;
                model.Title = item.Title;
                model.Description = item.Description;
                model.Avatar = item.Avatar;
                model.Thumb = item.Avatar;// "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                model.Content = item.Content;
                model.Keyword = item.Keyword;
                model.ModifyBy = HttpContext.Current.User.Identity.Name;
                model.ModifyTime = DateTime.Now;
                model.Position = item.Position;
                model.Status = item.Status;
                model.CategoryID = item.CategoryID;
                model.ListBranch = item.ListBranch;
                model.ListImage = item.ListImage;
                model.MadeIn = item.MadeIn;
                model.Price = item.Price;
                model.PriceSale = item.PriceSale;
                model.MetaTitle = item.MetaTitle;
                model.MetaDescription = item.MetaDescription;
                model.Tags = item.Tags;
                model.ProductColor = item.ProductColor.Count() > 0 ? string.Join(",", item.ProductColor).ToString() : null;
                model.ProductSize = item.ProductSize.Count() > 0 ? string.Join(",", item.ProductSize).ToString() : null;
                model.CollectionId = item.CollectionId;
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
                Product item = db.Products.Find(id);
                db.Products.Remove(item);
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
                Product item = db.Products.Find(Convert.ToInt32(id));
                item.Avatar = picture;
                item.Thumb = "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + picture.Substring(picture.LastIndexOf("/") + 1);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool AddviewTime(int id)
        {
            try
            {
                DBEntities db = new DBEntities();
                Product model = db.Products.Find(id);
                model.ViewTime = model.ViewTime + 1;
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<ProductColor> GetAllProductColor()
        {
            try
            {
                return ProductServices.GetAllProductColor();
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
                return ProductServices.GetAllProductSize();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
