using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ToanThangSite.Controllers;
using ToanThangSite.Entities.Core;

namespace ToanThangSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // // Home router
            // routes.MapRoute(
            //     name: "Home",
            //     url: "",
            //     defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //     namespaces: new string[] { "ToanThangSite.Controllers" }
            // );

            // Introduce router
            routes.MapRoute(
                name: "Introduce",
                url: "about.html",
                defaults: new { controller = "Introduce", action = "Introduce", id = UrlParameter.Optional },
                namespaces: new string[] { "ToanThangSite.Controllers" }
            );
            // Contact router
            routes.MapRoute(
                name: "Contact",
                url: "contact.html",
                defaults: new { controller = "Contact", action = "Contact", id = UrlParameter.Optional },
                namespaces: new string[] { "ToanThangSite.Controllers" }
            );
            routes.MapRoute(
                name: "Stockists",
                url: "stockists.html",
                defaults: new { controller = "Contact", action = "Stockists", id = UrlParameter.Optional },
                namespaces: new string[] { "ToanThangSite.Controllers" }
            );
            // Article router
            routes.MapRoute(
                name: "Article",
                url: "tin-tuc.html",
                defaults: new { controller = "Article", action = "ArticleList", id = UrlParameter.Optional },
                namespaces: new string[] { "ToanThangSite.Controllers" }
            );
            routes.MapRoute(
               name: "ArticlePage",
               url: "tin-tuc.htmlpage={page}",
               defaults: new { controller = "Article", action = "ArticleList", page = UrlParameter.Optional },
               namespaces: new string[] { "ToanThangSite.Controllers" }
           );

            routes.MapRoute(
              name: "Cart",
              url: "cart.html",
              defaults: new { controller = "Product", action = "CartProduct", page = UrlParameter.Optional },
              namespaces: new string[] { "ToanThangSite.Controllers" }
          );
            // routes.MapRoute(
            //    name: "ArticleDetail",
            //    url: "tin/{title}-{id}.html",
            //    defaults: new { controller = "Article", action = "ArticleDetail", id = UrlParameter.Optional },
            //    namespaces: new string[] { "ToanThangSite.Controllers" }
            //);


            // // Product router
            // routes.MapRoute(
            //     name: "Product",
            //     url: "p/{title}-{id}.html",
            //     defaults: new { controller = "Product", action = "ProductList", id = UrlParameter.Optional },
            //     namespaces: new string[] { "ToanThangSite.Controllers" }
            // );
            // routes.MapRoute(
            //    name: "ProductPage",
            //    url: "p/{title}-{id}.htmlpage={page}",
            //    defaults: new { controller = "Product", action = "ProductList", page = UrlParameter.Optional, id = UrlParameter.Optional },
            //    namespaces: new string[] { "ToanThangSite.Controllers" }
            //);
            // routes.MapRoute(
            //    name: "ProductDetail",
            //    url: "{title}-{id}.html",
            //    defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
            //    namespaces: new string[] { "ToanThangSite.Controllers" }
            //);
            // Default 1
            routes.MapRoute(
            "Default1",
            "{FriendlyUrl}",
            namespaces: new string[] { "ToanThangSite.Controllers" }
       ).RouteHandler = new FriendlyUrlRouteHandler();
            // Default router
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ToanThangSite.Controllers" }
            );
          
           



        }
    }
}
