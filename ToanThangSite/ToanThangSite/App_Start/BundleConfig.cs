using System.Web;
using System.Web.Optimization;

namespace ToanThangSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                "~/Scripts/js/jquery-2.1.3.min.js",
    "~/Scripts/js/uikit.min.js",
    "~/Scripts/js/library.js",
    "~/Scripts/js/slideshow.min.js",
    "~/Scripts/js/slider.min.js",
    "~/Scripts/js/jquery.flexslider-min.js",
    "~/Scripts/js/sticky.min.js",
    "~/Scripts/js/readmore.js",
    "~/Scripts/js/owl.carousel2cbe.js",
    "~/Scripts/js/script.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/flexslider.css",
                "~/Content/css/uikit.docs.min.css",
                "~/Content/css/library.css",
                "~/Content/css/animate.css",
                "~/Content/css/owl.carousel.css",
                "~/Content/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Content/ajs").Include(
"~/Areas/Admin/Scripts/js/jquery-1.9.1.min.js",
"~/Areas/Admin/Scripts/js/jquery-migrate-1.1.1.min.js",
"~/Areas/Admin/Scripts/js/jquery-ui-1.9.2.min.js",
"~/Areas/Admin/Scripts/js/jquery.flot.min.js",
"~/Areas/Admin/Scripts/js/jquery.flot.resize.min.js",
"~/Areas/Admin/Scripts/js/bootstrap.min.js",
"~/Areas/Admin/Scripts/js/jquery.uniform.min.js",
"~/Areas/Admin/Scripts/js/jquery.dataTables.min.js",
"~/Areas/Admin/Scripts/js/modernizr.min.js",
"~/Areas/Admin/Scripts/js/detectizr.min.js",
"~/Areas/Admin/Content/prettify/prettify.js",
"~/Areas/Admin/Scripts/js/jquery.cookie.js",
"~/Areas/Admin/Scripts/js/jquery.jgrowl.js",
"~/Areas/Admin/Scripts/js/chosen.jquery.min.js",
"~/Areas/Admin/Scripts/js/jquery.alerts.js",
"~/Areas/Admin/Scripts/js/custom.js",
"~/Areas/Admin/Scripts/tinymce/js/tinymce/tinymce.min.js"
));

            bundles.Add(new StyleBundle("~/Content/acss").Include(
                       "~/Areas/Admin/Content/css/style.default.css",
                       "~/Areas/Admin/Content/prettify/prettify.css"
                     ));

        }
    }
}
