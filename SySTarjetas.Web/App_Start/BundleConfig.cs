using System.Configuration;
using System.Web.Optimization;
using SySTarjetas.Core.Common.Extensions;

namespace SySTarjetas.Web
{
    public static class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {
            RegisterStyleSheets(bundles);
            RegisterScripts(bundles);
            BundleTable.EnableOptimizations = ConfigurationManager.AppSettings["Bundles.EnableOptimizations"].ToBoolean();
            BundleTable.Bundles.UseCdn = ConfigurationManager.AppSettings["Bundles.UseCdn"].ToBoolean();
            Scripts.DefaultTagFormat = @"<script src=""{0}"" type=""text/javascript""></script>";
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/scripts-header")
               .Include("~/scripts/angular.js")
               .Include("~/scripts/jquery-1.10.2.js")
               .Include("~/scripts/modernizr-2.6.2.js"));

            bundles.Add(new ScriptBundle("~/scripts/scripts-footer")
               .Include("~/scripts/bootstrap.js")
               .Include("~/scripts/angular-resource.js")
               .Include("~/scripts/angular-sanitize.js")
               .Include("~/scripts/angular-route.js")
               .Include("~/scripts/angular-ui-router.js")
               .Include("~/scripts/angular-animate.js")
               .Include("~/scripts/angular-messages.js")
               .Include("~/scripts/toaster.js")
               .Include("~/scripts/ui-grid.js")
               .Include("~/scripts/loading-bar.js")
               .Include("~/scripts/app/app.js")
               .Include("~/scripts/app/controllers.js")
               .Include("~/scripts/app/directives.js")
               .Include("~/scripts/app/factories.js")
               .Include("~/scripts/app/services.js")
               .Include("~/scripts/angular-ui/ui-bootstrap-tpls.js")
               .Include("~/scripts/angular-modal-service.js")
               .Include("~/scripts/angular-strap.js")
               .Include("~/scripts/angular-strap.tpl.js")
               );
        }

        private static void RegisterStyleSheets(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles/master")
              .Include("~/styles/Site.css")
              .Include("~/styles/bootstrap.css")
              .Include("~/styles/simple-sidebar.css")
              .Include("~/styles/toaster.css")
              .Include("~/styles/loading-bar.css")
              //.Include("~/styles/ng-table.css")
              .Include("~/Content/ui-grid.css")
              //.Include("~/Styles/jquery.FlowupLabels.css")
              ); 
        }
    }
}