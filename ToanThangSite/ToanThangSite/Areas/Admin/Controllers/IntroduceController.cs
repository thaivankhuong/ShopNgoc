using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class IntroduceController : Controller
    {
        [Authorize]
        // GET: Admin/Introduce
        public ActionResult IntroduceList()
        {
            return View(IntroduceBusiness.GetAll());
        }
        [HttpGet]
        public ActionResult IntroduceCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IntroduceCreate(Introduce item)
        {
            if (IntroduceBusiness.Create(item))
            {
                return RedirectToAction("IntroduceList", "Introduce");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult IntroduceEdit(int id)
        {
            Introduce item = IntroduceBusiness.GetByID(id);
            return View(item);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult IntroduceEdit(int id, Introduce item)
        {
            if (IntroduceBusiness.Update(id, item))
            {
                return RedirectToAction("IntroduceList", "Introduce");
            }
            return RedirectToAction("Error", "Home");
        }

        public string DeleteIntroduce(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!IntroduceBusiness.Delete(Convert.ToInt32(id)))
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

        public string ShowDetailIntro(int id)
        {
            try
            {
                return IntroduceBusiness.GetByID(id).Content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string ChangeImageIntroduce(string id, string picture)
        {
            if (id == null)
            {
                return "Mã không tồn tại!";
            }
            if (!IntroduceBusiness.ChangeImage(Convert.ToInt32(id), picture))
            {
                return "Mã không tồn tại!";
            }
            return "";
        }
    }
}