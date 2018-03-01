using System.Web.Optimization;

namespace MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Javascript
            bundles.Add(new ScriptBundle("~/bundles/scripts/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/datatable").Include(
                        "~/Scripts/DataTable/jquery.dataTables.js",
                        "~/Scripts/DataTable/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts/custom").Include(
                        "~/Scripts/general.js"));

            // CSS
            bundles.Add(new StyleBundle("~/bundles/styles/bootstrap").Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/styles/datatable").Include(
                        "~/Content/DataTable/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/bundles/styles/custom").Include(
                        "~/Content/main-theme.css"));
        }
    }
}