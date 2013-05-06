using System.Web;
using System.Web.Mvc;

namespace MvcCheckBoxList.Web.Mvc4 {
  public class FilterConfig {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
      filters.Add(new HandleErrorAttribute());
    }
  }
}