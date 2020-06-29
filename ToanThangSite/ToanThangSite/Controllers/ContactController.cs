using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using static ToanThangSite.Business.Common.SetMetatag;
using System.Web.Script.Serialization;
using ToanThangSite.Entities.Models;
using Newtonsoft.Json;

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
            tag.siteName = "mkfashion";
            tag.pageType = "website";
            tag.description = item.Description;
            tag.robots = "index,follow";
            tag.canonica = ConfigModel.urlCofig;  
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
            return View(BranchBusiness.GetAll().FirstOrDefault());
        }

        [HttpPost]
        public string OrderCreate(Order model , string productname = "")
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Order models = model as Order;
                string json = model.ProductName;
                var results = JsonConvert.DeserializeObject<List<ProductCart>>(json);
                string result = OrderBusiness.Create(models, results);



                return result;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}