using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MvcCheckBoxList.Library;

public static partial class Extensions {

  // Level 1

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
  /// <param name="selectedValuesExpr">Data list of selected items (should be of same data type as a source list)</param>
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
     Position position) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           selectedValuesExpr = selectedValuesExpr,
           position = position
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
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TItem, bool>> selectedValueExpr,
     Position position) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           selectedValueExpr = selectedValueExpr,
           position = position
         });
  }

  // Level 2

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
  /// <param name="selectedValuesExpr">Data list of selected items (should be of same data type as a source list)</param>
  /// <param name="htmlAttributesExpr">Data list HTML tag attributes for each checkbox</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
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
  /// <param name="htmlAttributesExpr">Data list HTML tag attributes for each checkbox</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TItem, bool>> selectedValueExpr,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
           selectedValueExpr = selectedValueExpr,
         });
  }

  // Level 3

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
  /// <param name="selectedValuesExpr">Data list of selected items (should be of same data type as a source list)</param>
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <param name="htmlAttributesExpr">Applies custom HTML tag attributes to each checkbox/label combo if defined locally (e.g.: entity => new { tagName = "tagValue" }), or to particular combos, if defined in the database (e.g.: entity => entity.TagsDbObject)</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
     Position position,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
           selectedValuesExpr = selectedValuesExpr,
           position = position
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
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <param name="htmlAttributesExpr">Applies custom HTML tag attributes to each checkbox/label combo if defined locally (e.g.: entity => new { tagName = "tagValue" }), or to particular combos, if defined in the database (e.g.: entity => entity.TagsDbObject)</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TItem, bool>> selectedValueExpr,
     Position position,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
           selectedValueExpr = selectedValueExpr,
           position = position
         });
  }

  // Level 4 - Full

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
  /// <param name="selectedValuesExpr">Data list of selected items (should be of same data type as a source list)</param>
  /// <param name="htmlAttributes">Applies custom HTML tag attributes to each checkbox/label combo</param>
  /// <param name="disabledValues">String array of values to disable</param>
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <param name="htmlAttributesExpr">Applies custom HTML tag attributes to each checkbox/label combo if defined locally (e.g.: entity => new { tagName = "tagValue" }), or to particular combos, if defined in the database (e.g.: entity => entity.TagsDbObject)</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
     object htmlAttributes,
     string[] disabledValues,
     Position position,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
           selectedValuesExpr = selectedValuesExpr,
           htmlAttributes = htmlAttributes,
           disabledValues = disabledValues,
           position = position
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
  /// <param name="htmlAttributes">Applies custom HTML tag attributes to each checkbox/label combo</param>
  /// <param name="disabledValues">String array of values to disable</param>
  /// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
  /// <param name="htmlAttributesExpr">Applies custom HTML tag attributes to each checkbox/label combo if defined locally (e.g.: entity => new { tagName = "tagValue" }), or to particular combos, if defined in the database (e.g.: entity => entity.TagsDbObject)</param>
  /// <returns>HTML string containing checkbox list</returns>
  public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
    (this HtmlHelper<TModel> htmlHelper,
     string listName,
     Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
     Expression<Func<TItem, TValue>> valueExpr,
     Expression<Func<TItem, TKey>> textToDisplayExpr,
     Expression<Func<TItem, bool>> selectedValueExpr,
     object htmlAttributes,
     string[] disabledValues,
     Position position,
     Expression<Func<TItem, object>> htmlAttributesExpr) {
    return _listBuilder.CheckBoxList
      (new listConstructor
         <TModel, TItem, TValue, TKey> {
           htmlHelper = htmlHelper,
           listName = listName,
           sourceDataExpr = sourceDataExpr,
           valueExpr = valueExpr,
           textToDisplayExpr = textToDisplayExpr,
           htmlAttributesExpr = htmlAttributesExpr,
           selectedValueExpr = selectedValueExpr,
           htmlAttributes = htmlAttributes,
           disabledValues = disabledValues,
           position = position
         });
  }
}