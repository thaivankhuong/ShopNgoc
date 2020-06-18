using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        public ActionResult ProductCategoryList()
        {

            return View(ProductCategoryBusiness.GetAll());
        }

        [HttpGet]
        public ActionResult ProductCategoryCreate()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ProductCategoryEdit(int id)
        {
            return View(ProductCategoryBusiness.GetByID(id));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductCategoryCreate(ProductCategory item)
        {
            if (ProductCategoryBusiness.Create(item))
            {
                return RedirectToAction("ProductCategoryList", "ProductCategory");
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductCategoryEdit(int id, ProductCategory item)
        {
            if (ProductCategoryBusiness.Update(id, item))
            {
                return RedirectToAction("ProductCategoryList", "ProductCategory");
            }
            return RedirectToAction("Error", "Home");
        }
        public string DeleteProductCategory(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!ProductCategoryBusiness.Delete(Convert.ToInt32(id)))
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