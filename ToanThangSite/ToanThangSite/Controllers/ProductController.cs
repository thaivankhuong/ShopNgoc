using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToanThangSite.Business.Core;
using ToanThangSite.Entities.Core;
using static ToanThangSite.Business.Common.SetMetatag;
using ToanThangSite.Entities.Models;

namespace ToanThangSite.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductList(int id = 0, int page = 1)
        {
            SeoMeta item = SeoMetaBusiness.GetById(3);
            Metatag tag = new Metatag();
            tag.title = item.Title;
            tag.siteName = "MK Fashion";
            tag.pageType = "object";
            tag.description = item.Description;
            tag.robots = "index,follow";
            tag.canonica = ConfigModel.urlCofig;
            tag.image = item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.KeyWord;
            tag.FBadmins = "";
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            IPagedList<Product> model;
            ViewBag.CatName = ProductCategoryBusiness.GetByID(id)?.Title;
            ViewBag.UrlProduct = Request.Url.AbsoluteUri;
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor();
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            ViewBag.ProductColor = listcolor;
            ViewBag.ProducSize = listsize;
            if (id == 0)
            {
                return RedirectToRoute("/404");
            }

            model = ProductBusiness.GetByCategoryID(page, 16, id);
            return View(model);
        }

        public ActionResult ProductListCollection(int id = 0, int page = 1)
        {
            IPagedList<Product> model;
            ViewBag.CatName = CollectionBusiness.GetByID(id)?.Title;
            ViewBag.UrlProduct = Request.Url.AbsoluteUri;
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor();
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            ViewBag.ProductColor = listcolor;
            ViewBag.ProducSize = listsize;
            if (id == 0)
            {
                return RedirectToRoute("/404");
            }

            model = ProductBusiness.GetByCollectionID(page, 16, id);
            return View("ProductList", model);
        }

        public ActionResult ProductSearch(string search)
        {
         
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor();
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            ViewBag.ProductColor = listcolor;
            ViewBag.ProducSize = listsize;
            List<Product> model;
            model = ProductBusiness.GetProducSearch(search);

            return View(model);
        }

        public ActionResult ProductDetail(int id)
        {
            Product item = ProductBusiness.GetByID(id);
            Metatag tag = new Metatag();
            tag.title = item.MetaTitle;
            if(item.MetaTitle == null || item.MetaTitle == null || item.MetaTitle == string.Empty)
            {
                tag.title = item.Title;
            }
            tag.siteName = "mkfashion";
            tag.pageType = "article";
            tag.description = item.MetaDescription != "" ? item.MetaDescription : item.Description;
            tag.robots = "index,follow";
            tag.canonica = ConfigModel.urlCofig;
            tag.image = ConfigModel.urlCofig + item.Avatar;
            tag.locale = "vi_VN";
            tag.keywords = item.Keyword;
            tag.FBadmins = "";
            tag.publishedTime = item.CreateTime.ToString();
            tag.updateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString();
            tag.tags = item.Keyword;
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            //ViewBag.ReasonTitle = ReasonBusiness.GetByProduct(item.ProductID).Title;
            //ViewBag.ReasonContent = ReasonBusiness.GetByProduct(item.ProductID).Content.Trim('|').Split('|');
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor()     ; 
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            if (!string.IsNullOrEmpty(item.ProductColor))
            {
                string[] arr = item.ProductColor.Split(',');
                listcolor = listcolor.Where(s => arr.Contains(s.Id.ToString())).ToList();
            }

            if (!string.IsNullOrEmpty(item.ProductSize))
            {
                string[] arr = item.ProductSize.Split(',');
                listsize = listsize.Where(s => arr.Contains(s.Id.ToString())).ToList();
            }

            ViewBag.ProductColor = listcolor;
            ViewBag.producSize = listsize;

            ProductBusiness.AddviewTime(id);
            if (item.ListImage == null || item.ListImage == "" || item.ListImage == string.Empty)
            {
                item.ListImage = item.Thumb + ";";
            }
            if (item.Tags == "" || item.Tags == null || item.Tags == string.Empty)
            {
                item.Tags = item.Title + ",";
            }
            return View(item);
        }
        public ActionResult ProductSimilar(int id)
        {
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor();
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            ViewBag.ProductColor = listcolor;
            ViewBag.ProducSize = listsize;
            return PartialView(ProductBusiness.GetSimilar(id));
        }
        public ActionResult HotProduct()
        {
            return PartialView(ProductBusiness.GetHot());
        }
        public ActionResult ProductTypical()
        {
            return PartialView(ProductBusiness.GetTypical());
        }
        public ActionResult ProductListTypical(int page = 1)
        {
            Metatag tag = new Metatag();
            ViewResult view = SetMetaTags(tag);
            ViewBag.Header = view.ViewBag.All;
            ViewBag.UrlProductTypical = Request.Url.AbsoluteUri;
            return PartialView(ProductBusiness.GetAll(page, 21));
        }
        public ActionResult ProductCategory()
        {
            return PartialView(ProductCategoryBusiness.GetAll().Take(8).ToList());
        }
        public ActionResult ProductTags(string key)
        {
            ViewBag.TagsProduct = key.Replace("-", " ");
            return View(ProductBusiness.GetWithkey(key));
        }

        public ActionResult HomeProduct()
        {
            List<ProductColor> listcolor = ProductBusiness.GetAllProductColor()     ; 
            List<ProductSize> listsize = ProductBusiness.GetAllProductSize();
            ViewBag.ProductColor = listcolor;
            ViewBag.ProducSize = listsize;
            var listgethot = ProductBusiness.GetHot();
            return PartialView(ProductBusiness.GetHot());
        }

        public ActionResult CartProduct()
        {
            return PartialView();
        }

        public ActionResult ProductCollection(int page = 1)
        {
            IPagedList<Collection> model;
            ViewBag.UrlCollection = Request.Url.AbsoluteUri;
            model = CollectionBusiness.GetAll(page,6);
            return View(model);
        }
    }
}