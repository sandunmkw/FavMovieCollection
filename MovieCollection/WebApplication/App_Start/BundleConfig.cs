using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/favMoiveApp").Include(
                            "~/Scripts/framework/jquery-1.10.2.min.js",
                            "~/Scripts/framework/jquery-ui.js",
                            "~/node_modules/bootstrap/dist/js/bootstrap.min.js",
                            "~/Scripts/framework/angular.min.js",
                            "~/Scripts/framework/angular-route.js",
                            "~/Scripts/app/app.core.js",
                            "~/Scripts/app/app.core.ui.js",
                            "~/Scripts/app/app.js",
                            "~/Scripts/app/services/ajaxService.js",
                            "~/Scripts/app/film/createFilmController.js",
                            "~/Scripts/app/film/listFilmsController.js",
                            "~/Scripts/app/film/detailFilmController.js"
                         ));
        }
    }
}
