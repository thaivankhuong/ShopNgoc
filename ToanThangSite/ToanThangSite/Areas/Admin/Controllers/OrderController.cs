using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult List()
        {
            return View(OrderBusiness.GetAll());
        }
        [HttpGet]
        public ActionResult OrderProductProduct(int Id)
        {
            return View(OrderBusiness.GetProductByOrderId(Id));
        }


        public string ChangeStatusOrder(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if (!OrderBusiness.ChangeStatus(Convert.ToInt32(id),false))
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

        public ActionResult ListOrder()
        {
            return View(OrderBusiness.GetAll());
        }
    }
}