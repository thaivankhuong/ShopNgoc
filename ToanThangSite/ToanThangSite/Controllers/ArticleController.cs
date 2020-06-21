using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using PagedList;
using static ToanThangSite.Business.Common.SetMetatag;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Controllers  
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult ArticleList(int page=1)
        {
            SeoMeta item = SeoMetaBusiness.GetById(2);
            Metatag tag = new Metatag();
            tag.title = item.Title;
            tag.siteName = "Tôm Hùm Tôm Càng Xanh";
            tag.pageType = "website";
            tag.description = item.Description;
            tag.robots = "index,follow";
            tag.canonica = "http://tomhumalaska.vn";
            tag.image = item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.KeyWord;
            tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            // Load DB set meta tag values
            IPagedList<Article> model;
            ViewBag.UrlArticle = Request.Url.AbsoluteUri;
            model = ArticleBusiness.GetAll(page, 8);
            return View(model);

        }
        public ActionResult ArticleDetail(int id)
        {
            Article item = ArticleBusiness.GetByID(id);
            Metatag tag = new Metatag();
            tag.title = item.MetaTitle != "" ? item.MetaTitle : item.Title;
            tag.siteName = "Thảo Dược Toàn Thắng";
            tag.pageType = "article";
            tag.description = item.MetaDescription != "" ? item.MetaDescription : item.Description;
            tag.robots = "index,follow";
            tag.canonica = "http://thaoduoctoanthang.com";
            tag.image = "http://thaoduoctoanthang.com/" + item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.Keyword;
            tag.FBadmins = "";
            tag.publishedTime = item.CreateTime.ToString();
            tag.updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString();
            tag.tags = item.Keyword;
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            ArticleBusiness.AddviewTime(id);
            return View(item);
        }
        public ActionResult ArticleHot()
        {
            return PartialView(ArticleBusiness.GetHot());
        }
    }
}