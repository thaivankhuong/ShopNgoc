using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        // GET: Admin/Branch
        public ActionResult List()
        {
            List<Branch> item = new List<Branch>();
            item = BranchBusiness.GetAll();
            return View(item);
        }

        [HttpGet]
        public ActionResult BranchCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BranchCreate(Branch item)
        {
            if (BranchBusiness.Create(item))
            {
                return RedirectToAction("BranchList", "Branch");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult BranchEdit(int id)
        {
            Branch item = BranchBusiness.GetByID(id);
            return View(item);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BranchEdit(int id, Branch item)
        {
            if (BranchBusiness.Update( item,id))
            {
                return RedirectToAction("BranchList", "Branch");
            }
            return RedirectToAction("Error", "Home");
        }


        public string DeleteBranch(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!BranchBusiness.Delete(Convert.ToInt32(id)))
                {
                    return "Mã không tồn tại!";
                }
                return "";
            }
            catch (Exception ex)
            {
                return "Đã xảy ra lỗi!";
            }
        }
    }
}