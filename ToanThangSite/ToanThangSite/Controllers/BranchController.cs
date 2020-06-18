using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;

namespace ToanThangSite.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult HomeList()
        {
            return PartialView(BranchBusiness.GetAll());
        }

        public ActionResult BranchProduct(string[] ID)
        {
            return PartialView(BranchBusiness.GetListID(ID));
        }
    }
}