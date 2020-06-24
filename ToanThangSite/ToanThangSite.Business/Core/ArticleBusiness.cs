using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Services.Core;
using ToanThangSite.Entities.Core;
using System.Web;
using PagedList;
using ToanThangSite.Entities.Models;
using ToanThangSite.Business.Common;

namespace ToanThangSite.Business.Core
{
    public class ArticleBusiness
    {
        public static List<Article> GetAll()
        {
            try
            {
                return ArticleServices.GetAll();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static List<Article> GetSimilar(int ID)
        {
            try
            {
                return ArticleServices.GetSimilar(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<Article> GetHot()
        {
            try
            {
                return ArticleServices.GetHot();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static IPagedList<Article> GetAll(int page, int pageSize)
        {
            try
            {
                return ArticleServices.GetAll(page,pageSize);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static Article GetByID(int ID)
        {
            try
            {
                return ArticleServices.GetByID(ID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static bool Create(Article item)
        {
            try
            {
                DBEntities db = new DBEntities();
                item.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                item.Thumb = "/Areas/Admin/Content/FileUploads/_thumbs/Images/" + item.Avatar.Substring(item.Avatar.LastIndexOf("/") + 1);
                item.CreateBy = HttpContext.Current.User.Identity.Name;
                item.CreateTime = DateTime.Now;
                item.ModifyBy = HttpContext.Current.User.Identity.Name;
                item.ModifyTime = DateTime.Now;
                if (item.Description == null || item.Description == string.Empty || item.Description == "")
                {
                    item.Description = item.Title;
                }
                item.ViewTime = 0;
                db.Articles.Add(item);
                db.SaveChanges();
                db.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(int id, Article item)
        {
            try
            {
                DBEntities db = new DBEntities();
                Article model = db.Articles.Find(id);
                model.SeoUrl = item.Title.ToUrlFormat(true) + ".html";
                model.Title = item.Title;
                model.Description = item.Description;
                model.Avatar = item.Avatar;
                model.Thumb = item.Thumb;
                model.Content = item.Content;
                model.Keyword = item.Keyword;
                model.ModifyBy = HttpContext.Current.User.Identity.Name;
                model.ModifyTime = DateTime.Now;
                model.Position = item.Position;
                model.Status = item.Status;
                model.MetaTitle = item.MetaTitle;
                model.DescriptionLong = item.DescriptionLong;
                model.MetaDescription = item.MetaDescription;
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
                Article item = db.Articles.Find(id);
                db.Articles.Remove(item);
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
                Article item = db.Articles.Find(Convert.ToInt32(id));
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
                Article model = db.Articles.Find(id);
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
