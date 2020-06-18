using ToanThangSite.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        public ActionResult ContactList()
        {
            return View(ContactBusiness.GetAll());
        }
        public string DeleteContact(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!ContactBusiness.Delete(Convert.ToInt32(id)))
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
        public string ShowDetailCt(int id)
        {
            try
            {
                return ContactBusiness.GetByID(id).Content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}