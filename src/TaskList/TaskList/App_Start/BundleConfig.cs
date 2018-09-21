using System.Web;
using System.Web.Optimization;

namespace TaskList
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/modern-business.css",
                      "~/Content/jquery.dataTables.min.css",
                      "~/Content/Error.css",
                      "~/Content/site.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/TaskList").Include(
                "~/Scripts/TaskList.js",
                "~/Scripts/meta.modal.js",
               "~/Scripts/meta.loading.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
            "~/Scripts/jquery.maskmoney.js",
            "~/Scripts/jquery.maskedinput.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/TaskManager").Include(
              "~/Scripts/TaskManager/TaskManager.js"));
          

            #region DataTable

            bundles.Add(new Bundle("~/bundles/jptablemin").Include(
                "~/Scripts/jquery.datatables.js"
            ));

            bundles.Add(new Bundle("~/bundles/jptablecustom").Include(
                "~/Scripts/jquery.datatables.custom-filter.js"
            ));

            #endregion DataTable
        }
    }
}
