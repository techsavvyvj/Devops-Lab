using System.Web;
using System.Web.Optimization;

namespace HelloWorldSample
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Content/node_modules/jquery/dist/jquery.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Ĉontent/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Content/node_modules/bootstrap/dist/js/bootstrap.js"));

            bundles
                .Add(new StyleBundle("~/Content/css")
                .Include(
                      "~/Content/node_modules/bootstrap/dist/css/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
