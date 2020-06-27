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
    public class CollectionController : Controller
    {
        // GET: Admin/Collection
        public ActionResult CollectionList()
        {
            List<Collection> item = new List<Collection>();
            item = CollectionBusiness.GetAll();
            return View(item);
        }

        [HttpGet]
        public ActionResult CollectionCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CollectionCreate(Collection item)
        {
            if (CollectionBusiness.Create(item))
            {
                return RedirectToAction("CollectionList", "Collection");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult CollectionUpdate(int ID)
        {
            return View(CollectionBusiness.GetByID(ID));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CollectionUpdate(Collection item, int ID)
        {
            if (CollectionBusiness.Update(ID, item))
            {
                return RedirectToAction("CollectionList", "Collection");
            }
            return RedirectToAction("Error", "Home");
        }
        public string ChangeImageCollection(string id, string picture)
        {
            if (id == null)
            {
                return "Mã không tồn tại!";
            }
            if (!CollectionBusiness.ChangeImage(Convert.ToInt32(id), picture))
            {
                return "Mã không tồn tại!";
            }
            return "";
        }

        public string DeleteCollection(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!CollectionBusiness.Delete(Convert.ToInt32(id)))
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