using System.Web.Optimization;
using System.Web.UI;

namespace Aspose.Cells.UI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
                "~/cells/scripts/WebForms/WebForms.js",
                "~/cells/scripts/WebForms/WebUIValidation.js",
                "~/cells/scripts/WebForms/MenuStandards.js",
                "~/cells/scripts/WebForms/Focus.js",
                "~/cells/scripts/WebForms/GridView.js",
                "~/cells/scripts/WebForms/DetailsView.js",
                "~/cells/scripts/WebForms/TreeView.js",
                "~/cells/scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/cells/scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/cells/scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/cells/scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/cells/scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/cells/scripts/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include(
                    //"~/Scripts/jquery-{version}.js",
                    "~/cells/scripts/jquery.form.min.js",
                    "~/cells/scripts/jquery.unobtrusive-ajax.min.js"
                )
            );

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond",
                new ScriptResourceDefinition
                {
                    Path = "~/cells/scripts/respond.min.js",
                    DebugPath = "~/cells/scripts/respond.js",
                });


            bundles.Add(
                new ScriptBundle("~/bundles/AsposeShared")
                    .Include(
                        "~/cells/scripts/Shared/SEO.js",
                        "~/cells/scripts/Shared/Alert.js",
                        "~/cells/scripts/Shared/Resources.js",
                        "~/cells/scripts/Shared/DownloadResult.js",
                        "~/cells/scripts/Shared/Loader.js",
                        "~/cells/scripts/Shared/Metadata.js",
                        "~/cells/scripts/Shared/UploadFile.js",
                        "~/cells/scripts/Shared/MultiFileUploader.js",
                        "~/cells/scripts/Shared/Work.js"
                    )
            );

        }
    }
}