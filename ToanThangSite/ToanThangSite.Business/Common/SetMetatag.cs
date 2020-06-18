using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ToanThangSite.Business.Common
{
    public static class SetMetatag
    {
        public static string ResolveDomainUrl(string url)
        {
            //Page page = System.Web.HttpContext.Current.Handler as Page;
            //string a = page.ResolveUrl(url);
            //string domainUrl = page.Request.Url.GetLeftPart(UriPartial.Authority);

            return url;
        }

        public static ViewResult SetMetaTags(Metatag Meta)
        {
            ViewResult view = new ViewResult();

            //1. Thiết lập các Meta Tag cho trang   

            string Metatag = "<meta name='revisit-after' content='7 days'/>";

            if (Meta.title != null)
            {
                Metatag += "<title>" + Meta.title + "</title>";
                Metatag += "<meta itemprop='name' content='" + Meta.title + "'>";
                Metatag += "<meta property='og:title' content='" + Meta.title + "' /> ";
                Metatag += "<meta name='twitter:title' content ='" + Meta.title + "'/>";
                Metatag += "<meta name='twitter:card' content ='summary'/>";
            }
            if (Meta.description != null)
            {
                Metatag += "<meta name='description' content ='" + Meta.description + "'/>";
                Metatag += "<meta name='twitter:description' content ='" + Meta.description + "'/>";
                Metatag += "<meta itemprop='description' content='" + Meta.description + "' />";
                Metatag += "<meta property='og:description' content='" + Meta.description + "' /> ";
            }
            if (Meta.image != null)
            {
                Metatag += "<meta itemprop='image' content='" +  Meta.image + "'>";
                Metatag += "<meta property='og:image' content='" + Meta.image+ "'/>";
                Metatag += "<meta name='twitter:image' content='" + Meta.image + "'/>";
            }
            if (Meta.locale != null)
            {
                Metatag += "<meta property='og:locale' content='" + Meta.locale + "' />";
            }
            if (Meta.pageType != null)
            {
                Metatag += "<meta property='og:type' content='" + Meta.pageType + "' />";
            }
            //if (Meta.canonica != null)
            //{
            //    Metatag += "<meta property='og:url' content='" + Meta.canonica + "' />";
            //    Metatag += "<link rel='canonical' href='" + Meta.canonica + "'/>";
            //}
            if (Meta.keywords != null)
            {
                Metatag += "<meta name='keywords' content='" + Meta.keywords + "'/>";
            }
            if (Meta.googleAuthor != null)
            {
                Metatag += "<link rel='author' href='" + Meta.googleAuthor + "'/>";
            }
            if (Meta.siteName != null)
            {
                Metatag += "<meta property='og:site_name' content='" + Meta.siteName + "' />";
                Metatag += "<meta name='twitter:site' content ='" + Meta.siteName + "'/>";
            }
            if (Meta.googlePublisher != null)
            {
                Metatag += "<link rel='publisher' href='" + Meta.googlePublisher + "' />";
            }
            if (Meta.robots != null)
            {
                Metatag += "<meta name='robots' content='" + Meta.robots + "'/>";
            }

            if (Meta.publishedTime != null)
            {
                Metatag += "<meta property='article:published_time' content='" + Meta.publishedTime + "' />";
            }

            if (Meta.updateTime != null)
            {
                Metatag += "<meta property='article:modified_time' content='" + Meta.updateTime + "' /> ";
            }

            if (Meta.section != null)
            {
                Metatag += "<meta property='article:section' content='" + Meta.section + "' />";
            }

            if (Meta.tags != null && Meta.tags != "")
            {
                foreach (string item in Meta.tags.Split(','))
                {
                    Metatag += "<meta property='article:tag' content='" + item + "' />";
                }

            }
            if (Meta.FBadmins != null)
            {
                Metatag += "<meta property='fb:admins' content='" + Meta.FBadmins + "' />";
            }

            view.ViewBag.All = Metatag;
            return view;
        }

        public class Metatag
        {
            /// <summary>
            /// Tiêu đề trang
            /// </summary>
            public string title { get; set; }

            /// <summary>
            /// Mô tả trang
            /// </summary>
            public string description { get; set; }

            /// <summary>
            /// Từ khóa
            /// </summary>
            public string keywords { get; set; }

            /// <summary>
            /// Config index cho trang
            /// </summary>
            public string robots { get; set; }


            /// <summary>
            /// Mã chứng thực site với google
            /// </summary>
            public string googleSiteVerification { get; set; }

            /// <summary>
            /// Link trang hiện tại
            /// </summary>
            public string canonica { get; set; }
            /// <summary>
            /// Tác giả google
            /// </summary>
            public string googleAuthor { get; set; }

            /// <summary>
            /// Người đăng google+
            /// </summary>
            public string googlePublisher { get; set; }

            /// <summary>
            /// Link đến hình đại diện cho bài viết
            /// </summary>
            public string image { get; set; }

            /// <summary>
            /// Mã ngôn ngữ site
            /// </summary>
            public string locale { get; set; }

            /// <summary>
            /// Loại trang
            /// </summary>
            public string pageType { get; set; }

            /// <summary>
            /// Tên site
            /// </summary>
            public string siteName { get; set; }

            /// <summary>
            /// Thời gian cập nhật bài viết
            /// </summary>
            public string updateTime { get; set; }

            /// <summary>
            /// Thời gian đăng bài viết
            /// </summary>
            public string publishedTime { get; set; }

            /// <summary>
            /// Tên chuyên mục của bài viết
            /// </summary>
            public string section { get; set; }

            /// <summary>
            /// Tên tag của bài viết, nếu nhiều tag phân cách chúng bằng dấu ","
            /// </summary>
            public string tags { get; set; }

            /// <summary>
            /// Facebook Admin ID trang
            /// </summary>
            public string FBadmins { get; set; }


            /// <summary>
            /// Mã chứng thực với Alex
            /// </summary>
            public string AlexaSiteVerification { get; set; }
        }
    }
}
