using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using static ToanThangSite.Business.Common.SetMetatag;

namespace ToanThangSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[CompressContent]
        public ActionResult Index()
        {
            SeoMeta item = SeoMetaBusiness.GetById(1);
            Metatag tag = new Metatag();
            tag.title = item.Title;
            tag.siteName = "Shop Ngoc Vo";
            tag.pageType = "website";
            tag.description = item.Description;
            tag.robots = "index,follow";
            tag.canonica = "http://shopngocvo.vn";
            tag.image = item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.KeyWord;
            tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            return View();
        }
        public ActionResult Slider()
        {
            return View(ProductCategoryBusiness.GetAll());
        }

    }
}