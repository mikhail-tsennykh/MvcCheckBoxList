using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcCheckBoxList.Library;

public static partial class Extensions {

  // Base extension

  /// <summary>
  /// Generates Model-based list of checkboxes (For...)
  /// </summary>
  /// <typeparam name="TModel">Current ViewModel</typeparam>
  /// <typeparam name="TItem">ViewModel Item</typeparam>
  /// <typeparam name="TValue">ViewModel Item type of the value</typeparam>
  /// <typeparam name="TKey">ViewModel Item type of the key</typeparam>
  /// <param name="htmlHelper">MVC Html helper class that is being extended</param>
  /// <param name="listName">ViewModel Item type to serve as a name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
  /// <param name="sourceDataExpr">Data list to be used as a source for the list (set in viewmodel)</param>
  /// <param name="valueExpr">Data list value type to be used as checkbox 'Value'</param>
  /// <param name="textToDisplayExpr">Data list value type to be used as checkbox 'Text'</param>
  /// <param name="selectedValuesExpr">Data list of selected items (should be of same data type as a source list)</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           selectedValuesExpr = selectedValuesExpr,
         });
  }
  /// <summary>
  /// Generates Model-based list of checkboxes (For...)
  /// </summary>
  /// <typeparam name="TModel">Current ViewModel</typeparam>
  /// <typeparam name="TItem">ViewModel Item</typeparam>
  /// <typeparam name="TValue">ViewModel Item type of the value</typeparam>
  /// <typeparam name="TKey">ViewModel Item type of the key</typeparam>
  /// <param name="htmlHelper">MVC Html helper class that is being extended</param>
  /// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
  /// <param name="sourceDataExpr">Data list to be used as a source for the list (set in viewmodel)</param>
  /// <param name="valueExpr">Data list value type to be used as checkbox 'Value'</param>
  /// <param name="textToDisplayExpr">Data list value type to be used as checkbox 'Text'</param>
  /// <param name="selectedValueExpr">Boolean value from db or selector corresponding to each item to be selected</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TItem, bool>> selectedValueExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           selectedValueExpr = selectedValueExpr,
         });
  }
}