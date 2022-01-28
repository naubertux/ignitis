using System.Web;
using System.Web.Optimization;

namespace Ignitis
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                // datatables
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",

                // knockoutjs
                "~/Scripts/knockout-3.5.1.js",
                "~/Scripts/knockout.mapping-latest.js",
                "~/Scripts/app/koDataTables.js",
                
                //Musu paciu apsirasyti skriptai
                "~/Scripts/app/common.js",
                "~/Scripts/app/koExtenders.js"


            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/registracijosPozymiai").Include(
                "~/Scripts/vm/registracijos-pozymiai.js"));
        }
    }
}
