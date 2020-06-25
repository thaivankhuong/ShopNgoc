using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToanThangSite.Entities.Core;

namespace ToanThangSite.Controllers
{
    public class FriendlyUrlRouteHandler : System.Web.Mvc.MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            var friendlyUrl = (string)requestContext.RouteData.Values["FriendlyUrl"];
            DBEntities db = new DBEntities();

            if(friendlyUrl!=null&& friendlyUrl != string.Empty)
            {
                if (friendlyUrl.Contains("tags-"))
                {
                    requestContext.RouteData.Values["controller"] = "Product";
                    requestContext.RouteData.Values["action"] = "ProductTags";
                    requestContext.RouteData.Values["key"] = friendlyUrl.Replace("tags-", "").Replace(".html", "");
                    return base.GetHttpHandler(requestContext);
                }

                //if (friendlyUrl.Contains("pg") && friendlyUrl.Contains("san-pham-noi-bat.html"))
                //{
                //    string seourl = friendlyUrl.Substring(0, friendlyUrl.LastIndexOf('=') - 2);
                //    requestContext.RouteData.Values["controller"] = "Product";
                //    requestContext.RouteData.Values["action"] = "ProductListTypical";
                //    requestContext.RouteData.Values["page"] = friendlyUrl.Substring(friendlyUrl.LastIndexOf('=') + 1);
                //    return base.GetHttpHandler(requestContext);
                //}

                //if (friendlyUrl=="san-pham-noi-bat.html")
                //{
                //    requestContext.RouteData.Values["controller"] = "Product";
                //    requestContext.RouteData.Values["action"] = "ProductListTypical";
                //    requestContext.RouteData.Values["page"] = 1;
                //    return base.GetHttpHandler(requestContext);
                //}

                if (friendlyUrl.Contains("pg"))
                {
                    string seourl = friendlyUrl.Substring(0, friendlyUrl.LastIndexOf('=') - 2);
                    requestContext.RouteData.Values["controller"] = "Product";
                    requestContext.RouteData.Values["action"] = "ProductList";
                    requestContext.RouteData.Values["id"] = db.ProductCategories.FirstOrDefault(x => x.SeoUrl == seourl).ProductCategoryID.ToString();
                    requestContext.RouteData.Values["page"] = friendlyUrl.Substring(friendlyUrl.LastIndexOf('=') + 1);
                    return base.GetHttpHandler(requestContext);
                }


                foreach (var item in db.ProductCategories.Where(x => x.Status == true && x.SeoUrl != "stockists.html" && x.SeoUrl != "contact.html" && x.SeoUrl != "blogs.html" && x.SeoUrl != "about.html"))
                {
                    if (item.SeoUrl == friendlyUrl)
                    {
                        requestContext.RouteData.Values["controller"] = "Product";
                        requestContext.RouteData.Values["action"] = "ProductList";
                        requestContext.RouteData.Values["id"] = item.ProductCategoryID.ToString();

                        return base.GetHttpHandler(requestContext);
                    }
                }
                foreach (var item in db.Articles.Where(x => x.Status == 1))
                    {
                        if (item.SeoUrl == friendlyUrl)
                        {
                            requestContext.RouteData.Values["controller"] = "Article";
                            requestContext.RouteData.Values["action"] = "ArticleDetail";
                            requestContext.RouteData.Values["id"] = item.ArticleID.ToString();

                            return base.GetHttpHandler(requestContext);
                        }
                    }

                    foreach (var item in db.Products.Where(x => x.Status == true))
                    {
                        if (item.SeoUrl == friendlyUrl)
                        {
                            requestContext.RouteData.Values["controller"] = "Product";
                            requestContext.RouteData.Values["action"] = "ProductDetail";
                            requestContext.RouteData.Values["id"] = item.ProductID.ToString();

                            return base.GetHttpHandler(requestContext);
                        }
                    }


                    requestContext.RouteData.Values["controller"] = "Home";
                    requestContext.RouteData.Values["action"] = "Index";
                    requestContext.RouteData.Values["id"] = "0";

                    return base.GetHttpHandler(requestContext);
            }
            else
            {
                requestContext.RouteData.Values["controller"] = "Home";
                requestContext.RouteData.Values["action"] = "Index";
                requestContext.RouteData.Values["id"] = "0";

                return base.GetHttpHandler(requestContext);
            }
            
        }
    }
}