using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;

namespace ToanThangSite.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Header()
        {
            return PartialView(ProductCategoryBusiness.GetAll());

        }

    }
}