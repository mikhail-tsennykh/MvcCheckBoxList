using System.Web;
using System.Web.Optimization;

namespace MvcCheckBoxList.Web.Mvc4 {
  public class BundleConfig {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles) {

      // Scripts

      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
        "~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
        "~/Scripts/jquery-ui-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
        "~/Scripts/jquery.unobtrusive*",
        "~/Scripts/jquery.validate*"));

      bundles.Add(new ScriptBundle("~/bundles/kickstart").Include(
        "~/Scripts/kickstart.js",
        "~/Scripts/prettify.js"));


      // Styles

      bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/style*"));
      bundles.Add(new StyleBundle("~/Content/kickstart").Include("~/Content/kickstart/kickstart.css"));

      // jQuery UI styles
      bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
        "~/Content/themes/base/jquery.ui.core.css",
        "~/Content/themes/base/jquery.ui.resizable.css",
        "~/Content/themes/base/jquery.ui.selectable.css",
        "~/Content/themes/base/jquery.ui.accordion.css",
        "~/Content/themes/base/jquery.ui.autocomplete.css",
        "~/Content/themes/base/jquery.ui.button.css",
        "~/Content/themes/base/jquery.ui.dialog.css",
        "~/Content/themes/base/jquery.ui.slider.css",
        "~/Content/themes/base/jquery.ui.tabs.css",
        "~/Content/themes/base/jquery.ui.datepicker.css",
        "~/Content/themes/base/jquery.ui.progressbar.css",
        "~/Content/themes/base/jquery.ui.theme.css"));
    }
  }
}