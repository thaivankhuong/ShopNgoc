using ToanThangSite.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToanThangSite.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Slider()
        {
            var slider = SliderBusiness.GetAll().Where(x => x.Status == true).ToList();
            return PartialView(SliderBusiness.GetAll().Where(x => x.Status == true).ToList());
        }
    }
}