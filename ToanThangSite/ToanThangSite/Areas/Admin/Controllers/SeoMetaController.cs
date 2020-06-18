using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class SeoMetaController : Controller
    {
        [Authorize]
        // GET: Admin/SeoMeta
        public ActionResult SeoMetaList()
        {
            return View(SeoMetaBusiness.GetAll());
        }
        [HttpGet]
        public ActionResult SeoMetaEdit(int ID=0)
        {
            return View(SeoMetaBusiness.GetById(ID));
        }

        [HttpPost]
        public ActionResult SeoMetaEdit(int ID ,SeoMeta model)
        {
            if(SeoMetaBusiness.Update(ID,model))
            {
                return RedirectToAction("SeoMetaList", "SeoMeta");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}