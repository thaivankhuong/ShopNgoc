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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult ProductList()
        {
            List<Product> item = new List<Product>();
            item = ProductBusiness.GetAll();
            return View(item);
        }

        [HttpGet]
        public ActionResult ProductCreate()
        {
            ViewBag.Branch = BranchBusiness.GetAll();
            ViewBag.ProductCategory = ProductCategoryBusiness.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductCreate(Product item)
        {
            if (ProductBusiness.Create(item))
            {
                return RedirectToAction("ProductList", "Product");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult ProductEdit(int id)
        {
            ViewBag.Branch = BranchBusiness.GetAll();
            ViewBag.ProductCategory = ProductCategoryBusiness.GetAll();
            Product item = ProductBusiness.GetByID(id);
            return View(item);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ProductEdit(int id, Product item)
        {
            if (ProductBusiness.Update(id, item))
            {
                return RedirectToAction("ProductList", "Product");
            }
            return RedirectToAction("Error", "Home");
        }

        public string ChangeImageProduct(string id, string picture)
        {
            if (id == null)
            {
                return "Mã không tồn tại!";
            }
            if (!ProductBusiness.ChangeImage(Convert.ToInt32(id), picture))
            {
                return "Mã không tồn tại!";
            }
            return "";
        }

        public string DeleteProduct(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!ProductBusiness.Delete(Convert.ToInt32(id)))
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
        public string ShowDetailP(int id)
        {
            try
            {
                return ProductBusiness.GetByID(id).Content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public ActionResult ProductReason(int id)
        {
            try
            {
                if (ReasonBusiness.GetByProduct(id) != null)
                {
                    return RedirectToAction("EditReason", new { id = id }); 
                }
                else
                {
                    return RedirectToAction("CreateReason", new { id = id });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("ProductList", "Product");
            }
        }

        public ActionResult CreateReason(int id)
        {
            Reason item = new Reason();
            item.ProductID = id;
            return View(item);
        }

        [HttpPost]
        public ActionResult CreateReason(Reason model)
        {
            try
            {
                if (ReasonBusiness.Create(model))
                {
                    return RedirectToAction("ProductList", "Product");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        public ActionResult EditReason(int id)
        {
            Reason item = ReasonBusiness.GetByProduct(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult EditReason(Reason model,int id)
        {
            try
            {
                if (ReasonBusiness.Edit(model,id))
                {
                    return RedirectToAction("ProductList", "Product");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception)
            {
                return View(model);
            }
        }

    }
}