using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using ToanThangSite.Entities.Models;
using static ToanThangSite.Business.Common.SetMetatag;

namespace ToanThangSite.Controllers
{
    public class IntroduceController : Controller
    {
        // GET: Introduce
        public ActionResult Introduce(int id=0)
        {
            List<Introduce> model = new List<Introduce>();
            model = IntroduceBusiness.GetTop3();
            Metatag tag = new Metatag();
            tag.title = model[0].Title;
            tag.siteName = "mkfashion";
            tag.pageType = "object";
            tag.description = model[0].Description;
            tag.robots = "index,follow";
            tag.canonica = ConfigModel.urlCofig;// "http://mkfashion.vn";
            tag.image = "http://mkfashion.vn/Content/img/logongocvo.jpg";
            tag.locale = "vi_VN";
            tag.keywords = "Introduce MK Fashion";
            tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            return View(model);
        }

    }
}