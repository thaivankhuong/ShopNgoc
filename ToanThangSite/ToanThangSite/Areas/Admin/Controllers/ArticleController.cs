using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Entities.Core;
using ToanThangSite.Business.Core;

namespace ToanThangSite.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        // GET: Admin/Article
        public ActionResult ArticleList()
        {
            List<Article> item = new List<Article>();
            item = ArticleBusiness.GetAll();
            return View(item);
        }

        [HttpGet]
        public ActionResult ArticleCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput (false)]
        public ActionResult ArticleCreate(Article item)
        {
            if (ArticleBusiness.Create(item))
            {
                return RedirectToAction("ArticleList", "Article");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public ActionResult ArticleEdit(int id)
        {
            Article item = ArticleBusiness.GetByID(id);
            return View(item);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ArticleEdit(int id,Article item)
        {
            if (ArticleBusiness.Update(id,item))
            {
                return RedirectToAction("ArticleList", "Article");
            }
            return RedirectToAction("Error", "Home");
        }

        public string ChangeImageArticle(string id,string picture)
        {
            if(id==null)
            {
                return "Mã không tồn tại!";
            }
            if (!ArticleBusiness.ChangeImage(Convert.ToInt32(id), picture))
            {
                return "Mã không tồn tại!";
            }
            return "";
        }

        public string DeleteArticle(string id)
        {
            try
            {
                if (id == null)
                {
                    return "Mã không tồn tại!";
                }

                if(!ArticleBusiness.Delete(Convert.ToInt32(id)))
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
        public string ShowDetailA(int id)
        {
            try
            {
                return ArticleBusiness.GetByID(id).Content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}