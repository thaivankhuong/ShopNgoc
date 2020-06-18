﻿using PagedList;
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

        public static bool Create(Product item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                item.Thumb = item.Avatar;// "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                item.CreateBy = HttpContext.Current.User.Identity.Name;
                item.CreateTime = DateTime.Now;
                item.ModifyBy = HttpContext.Current.User.Identity.Name;
                item.ModifyTime = DateTime.Now;
                item.ViewTime = 0;
                if (item.Description == null || item.Description == string.Empty || item.Description == "")
                {
                    item.Description = item.Title;
                }
                db.Products.Add(item);
                db.SaveChanges();

                Reason r = new Reason();
                r.Title = "5 LÝ DO ĐỂ BẠN MUA HÀNG TẠI TOMHUMALASKA.VN";
                r.ProductID = item.ProductID;
                r.Content = "Cam kết bán giá rẻ nhất cho người tiêu dùng|Sản phẩm Tươi sống|Tư vấn mua Hiệu quả – Chuyên nghiệp – Tận tâm|Thanh toán thu tiền tận nơi trên toàn quốc|Được đổi trả hàng hoá";
                db.Reasons.Add(r);
                db.SaveChanges();
                db.Dispose();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool Update(int id, Product item)
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
    }
}