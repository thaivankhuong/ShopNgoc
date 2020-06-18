using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToanThangSite.Entities.Models;
using ToanThangSite.Entities.Core;
using ToanThangSite.Services.Common;


namespace ToanThangSite.Services.Core
{
    public class SearchResultServices
    {

        public static List<SearchResultViewModel> GetAllSearch(string KeyWord)
        {
            try
            {
                List<SearchResultViewModel> Model = new List<SearchResultViewModel>();
                DBEntities db = new DBEntities();
                foreach (var item in db.Articles.Where(x => x.Title.ToLower().Contains(KeyWord.Replace("-"," ").ToLower())).ToList())
                {
                    SearchResultViewModel i = new SearchResultViewModel();
                    i.Title = item.Title;
                    i.Thumbs = item.Thumb;
                    i.CreateBy = item.CreateBy;
                    i.CreateTime = item.CreateTime;
                    i.Description = item.Description;
                    i.ViewTime = item.ViewTime;
                    i.Url = "/tin-tuc/chi-tiet/" + item.Title.ToUrlFormat(true) + "-" + item.ArticleID + ".html";
                    Model.Add(i);
                }


                foreach (var item in db.Products.Where(x => x.Title.ToLower().Contains(KeyWord.Replace("-", " ").ToLower())).ToList())
                {
                    SearchResultViewModel i = new SearchResultViewModel();
                    i.Title = item.Title;
                    i.Thumbs = item.Thumb;
                    i.CreateBy = item.CreateBy;
                    i.CreateTime = item.CreateTime;
                    i.Description = item.Description;
                    i.ViewTime = item.ViewTime;
                    i.Url = "/san-pham/chi-tiet/" + item.Title.ToUrlFormat(true) + "-" + item.ProductID + ".html";
                    Model.Add(i);
                }
                db.Dispose();
                return Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
