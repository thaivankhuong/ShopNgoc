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
    public class SliderController : Controller
    {
        // GET: Admin/Slider
        public ActionResult SliderList()
        {
            List<Slider> item = new List<Slider>();
            item = SliderBusiness.GetAll();
            return View(item);
        }

        [HttpGet]
        public ActionResult SliderCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SliderCreate(Slider item)
        {
            if (SliderBusiness.Create(item))
            {
                return RedirectToAction("SliderList", "Slider");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult SliderUpdate(int ID)
        {
            return View(SliderBusiness.GetByID(ID));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SliderUpdate(Slider item,int ID)
        {
            if (SliderBusiness.Update(ID, item))
            {
                return RedirectToAction("SliderList", "Slider");
            }
            return RedirectToAction("Error", "Home");
        }
        public string ChangeImageSlider(string id, string picture)
        {
            if (id == null)
            {
                return "Mã không tồn tại!";
            }
            if (!SliderBusiness.ChangeImage(Convert.ToInt32(id), picture))
            {
                return "Mã không tồn tại!";
            }
            return "";
        }

        public string DeleteSlider(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!SliderBusiness.Delete(Convert.ToInt32(id)))
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