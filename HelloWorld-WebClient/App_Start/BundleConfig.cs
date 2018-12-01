using System.Web.Optimization;

namespace HelloWorldSample.WebClient
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var headerScriptBundle = new ScriptBundle("~/bundles/scripts/header").Include(
                "~/Content/scripts/libs/modernizr-*"
            );
            var footerScriptBundle = new ScriptBundle("~/bundles/scripts/footer").Include(
                "~/Content/node_modules/jquery/dist/jquery.js",
                "~/Content/node_modules/bootstrap/dist/js/bootstrap.js",
                "~/Content/node_modules/vue/dist/vue.js",
                "~/Content/node_modules/vue-simple-spinner/dist/vue-simple-spinner.js"
            );
            var headerStyleBundle = new StyleBundle("~/bundles/styles/header").Include(
                "~/Content/styles/libs/bootstrap.css",
                "~/Content/styles/site.css"
            );

            bundles.Add(headerStyleBundle);
            bundles.Add(headerScriptBundle);
            bundles.Add(footerScriptBundle);
        }
    }
}
