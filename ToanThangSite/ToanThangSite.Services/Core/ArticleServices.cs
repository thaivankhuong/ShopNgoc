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
    public class ArticleServices
    {
        public static List<Article> GetAll()
        {
            try
            {
                DBEntities db = new DBEntities();
                List< Article> Lst = db.Articles.OrderByDescending(x=>x.CreateTime).ToList();
                db.Dispose();
                return Lst;
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
                DBEntities db = new DBEntities();
                List<Article> Lst = db.Articles.OrderByDescending(x => x.CreateTime).Take(4).ToList();
                db.Dispose();
                return Lst;
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
                DBEntities db = new DBEntities();
                List<Article> Lst = db.Articles.OrderByDescending(x => x.CreateTime).Where(x=>x.ArticleID!=ID).Take(4).ToList();
                db.Dispose();
                return Lst;
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
                DBEntities db = new DBEntities();
                IPagedList<Article> Lst = db.Articles.OrderByDescending(x => x.CreateTime).ToPagedList(page,pageSize);
                db.Dispose();
                return Lst;
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
                DBEntities db = new DBEntities();
                Article item = db.Articles.FirstOrDefault(x => x.ArticleID == ID);
                db.Dispose();
                return item;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
