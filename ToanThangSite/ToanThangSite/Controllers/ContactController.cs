﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using static ToanThangSite.Business.Common.SetMetatag;
using System.Web.Script.Serialization;

namespace ToanThangSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            SeoMeta item = SeoMetaBusiness.GetById(4);
            Metatag tag = new Metatag();
            tag.title = item.Title;
            tag.siteName = "Tôm Hùm Tôm Càng Xanh";
            tag.pageType = "website";
            tag.description = item.Description;
            tag.robots = "index,follow";
            tag.canonica = "http://tomhumalaska.vn";
            tag.image = item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.KeyWord;
            tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Contact model)
        {
            if (ModelState.IsValid && model.FullName != null)
            {
                if (ContactBusiness.Create(model))
                {
                    return RedirectToAction("Contact");
                }
                else
                {
                    ModelState.AddModelError("", "Gửi liên hệ không thành công!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult Stockists()
        {
            return View();
        }

        [HttpPost]
        public string OrderCreate(Order model)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Order models = model as Order;
                string result = OrderBusiness.Create(models);



                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}