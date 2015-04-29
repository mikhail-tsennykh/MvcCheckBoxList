using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MvcCheckBoxList.Library {
  internal class listConstructor<TModel, TItem, TValue, TKey> {
    public HtmlHelper<TModel> htmlHelper { get; set; }
    public ModelMetadata modelMetadata { get; set; }
    public string listName { get; set; }
    public Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr { get; set; }
    public Expression<Func<TItem, TValue>> valueExpr { get; set; }
    public Expression<Func<TItem, TKey>> textToDisplayExpr { get; set; }
    public Expression<Func<TItem, object>> htmlAttributesExpr { get; set; }
    public Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr { get; set; }
    public Expression<Func<TItem, bool>> selectedValueExpr { get; set; }
    public object htmlAttributes { get; set; }
    public HtmlListInfo htmlListInfo { get; set; }
    public string[] disabledValues { get; set; }
    public Position position { get; set; }
  }
}