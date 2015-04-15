using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcCheckBoxList.Library {
  internal static class getHtmlAttributes_Helper {
    internal static IDictionary<string, object> getHtmlAttributes<TItem>
      (this TItem item, object htmlAttributes, Expression<Func<TItem, object>> htmlAttributesExpr) {

      // setup empty base dictionary
      var mainDict = new List<KeyValuePair<string, object>>();

      // get html attributes for each checkbox/label combo
      var attrDict = htmlAttributes.toDictionary();

      // get unique html attributes for given combo, if coming from database field,
      // or for all combos, if defined on a view
      if (htmlAttributesExpr != null) {
        var valueHtmlAttributesFunc = htmlAttributesExpr.Compile();
        var extendedAttrDict = valueHtmlAttributesFunc(item).toDictionary();
        mainDict = attrDict.Concat(extendedAttrDict).ToList();
      }

      // create final dictionary
      var result = new ExpandoObject();
      var d = result as IDictionary<string, object>;
      foreach (var pair in mainDict) d[pair.Key] = pair.Value;
      return result;
    }

  }
}