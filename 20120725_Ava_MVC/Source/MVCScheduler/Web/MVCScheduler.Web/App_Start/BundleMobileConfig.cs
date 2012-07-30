using System.Web;
using System.Web.Optimization;

namespace MVCScheduler.Web {
    public class BundleMobileConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquerymobile").Include("~/Scripts/jquery.mobile-*"));

            bundles.Add(new StyleBundle("~/Content/Mobile/css").Include("~/Content/Site.Mobile.css"));
            
            bundles.Add(new StyleBundle("~/Content/jquerymobile/css").Include(
				"~/Content/jquery.mobile-1.1.0.css",
				"~/Content/jquery.mobile.structure-1.1.0.css",
				"~/Content/jquery.mobile.theme-1.1.0.css"));
        }
    }
}