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
    public class IntroduceController : Controller
    {
        // GET: Introduce
        public ActionResult Introduce(int id=0)
        {
            List<Introduce> model = new List<Introduce>();
            model = IntroduceBusiness.GetTop3();
            Metatag tag = new Metatag();
            //tag.title = model.Title;
            //tag.siteName = "Tôm Hùm Tôm Càng Xanh";
            //tag.pageType = "object";
            //tag.description = model.Description;
            //tag.robots = "index,follow";
            //tag.canonica = "http://tomhumalaska.vn";
            //tag.image = "http://tomhumalaska.vn/Content/images/logo.png";
            //tag.locale = "vi_VN";
            //tag.keywords = "giới thiệu thảo dược toàn thắng";
            //tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            return View(model);
        }

    }
}