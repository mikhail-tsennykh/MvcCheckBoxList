/////////////////////////////////////////////////////////////////////////////
//
// MVC3 @Html.CheckBoxList() custom extension v.1.3a
// by devnoob, 2011-2012
// http://www.codeproject.com/KB/user-controls/MvcCheckBoxList_Extension.aspx
//
// Since version 1.2, contains portions of code from article:
// 'Better ASP MVC Select HtmlHelper'
// by Sacha Barber, 2011
// http://sachabarber.net/?p=1007
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

// @Html.CheckBoxList(...)
public static class MvcCheckBoxList {
	/// model-independent functions (older way, depends on 'SelectListItem' system class)
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, null, null, position);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, htmlAttributes, null, null, position);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, string[] disabledValues, Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, htmlAttributes, null, disabledValues, position);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, wrapInfo, null);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo, string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, wrapInfo, disabledValues);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, HtmlListInfo wrapInfo, string[] disabledValues,
		 Position position = Position.Horizontal) {
		// validation
		if (dataList == null || dataList.Count == 0) return MvcHtmlString.Empty;
		if (String.IsNullOrEmpty(listName)) throw new ArgumentException("The argument must have a value", "listName");
		var numberOfItems = dataList.Count;

		// set up table/list html wrapper, if applicable
		var htmlWrapper = createHtmlWrapper(wrapInfo, numberOfItems, position);

		// create checkbox list
		var sb = new StringBuilder();
		sb.Append(htmlWrapper.wrap_open);
		htmlwrap_rowbreak_counter = 0;

		foreach (var r in dataList) {
			// create list of selected values
			var selectedValues = dataList.Where(x => x.Selected).Select(s => s.Value);

			// create checkbox element
			sb = createCheckBoxListElement(sb, htmlWrapper, htmlAttributes, selectedValues,
			                               disabledValues, listName, r.Value, r.Text);
		}

		sb.Append(htmlWrapper.wrap_close);

		return MvcHtmlString.Create(sb.ToString());
	}

	/// model-specific functions
	// 1
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr,
			 textToDisplayExpr, selectedValuesExpr, null, null, null, position);
	}
	// 1.1
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr, null, null, null, position);
	}

	// 2
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr, htmlAttributes,
			 null, null, position);
	}
	// 2.1
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr, htmlAttributes, null, null, position);
	}

	// 3
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 string[] disabledValues,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr, htmlAttributes,
			 null, disabledValues, position);
	}
	// 3.1
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 string[] disabledValues,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr, htmlAttributes, null, disabledValues,
			 position);
	}

	// 4
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr, textToDisplayExpr,
			 selectedValuesExpr, null, wrapInfo, null);
	}
	// 4.1
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(listName, sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr,
			null, wrapInfo, null);
	}

	// 5
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 HtmlListInfo wrapInfo,
		 string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr, textToDisplayExpr,
			 selectedValuesExpr, null, wrapInfo, disabledValues);
	}
	// 5.1
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 HtmlListInfo wrapInfo,
		 string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(listName, sourceDataExpr, valueExpr, textToDisplayExpr, selectedValuesExpr,
			null, wrapInfo, disabledValues);
	}

	// main for
	public static MvcHtmlString CheckBoxListFor<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 Expression<Func<TModel, object>> listNameExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 HtmlListInfo wrapInfo,
		 string[] disabledValues,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listNameExpr.toProperty(), sourceDataExpr, valueExpr, textToDisplayExpr,
			 selectedValuesExpr, htmlAttributes, wrapInfo, disabledValues);
	}
	// main
	public static MvcHtmlString CheckBoxList<TModel, TItem, TValue, TKey>
		(this HtmlHelper<TModel> htmlHelper,
		 string listName,
		 Expression<Func<TModel, IEnumerable<TItem>>> sourceDataExpr,
		 Expression<Func<TItem, TValue>> valueExpr,
		 Expression<Func<TItem, TKey>> textToDisplayExpr,
		 Expression<Func<TModel, IEnumerable<TItem>>> selectedValuesExpr,
		 object htmlAttributes,
		 HtmlListInfo wrapInfo,
		 string[] disabledValues,
		 Position position = Position.Horizontal) {
		var model = htmlHelper.ViewData.Model;
		var sourceData = sourceDataExpr.Compile()(model).ToList();
		var valueFunc = valueExpr.Compile();
		var textToDisplayFunc = textToDisplayExpr.Compile();
		var selectedItems = new List<TItem>();
		if (selectedValuesExpr != null)
			selectedItems = selectedValuesExpr.Compile()(model).ToList();

		// validation
		if (!sourceData.Any()) return MvcHtmlString.Empty;
		if (string.IsNullOrEmpty(listName)) throw new ArgumentException("The argument must have a value", "listName");
		var numberOfItems = sourceData.Count;

		// set up table/list html wrapper, if applicable
		var htmlWrapper = createHtmlWrapper(wrapInfo, numberOfItems, position);

		// create checkbox list
		var sb = new StringBuilder();
		sb.Append(htmlWrapper.wrap_open);
		htmlwrap_rowbreak_counter = 0;

		foreach (var item in sourceData) {
			// get checkbox value and text
			var itemValue = valueFunc(item).ToString();
			var itemText = textToDisplayFunc(item).ToString();

			// create list of selected values
			var selectedValues = selectedItems.Select(s => valueFunc(s).ToString()).ToList();

			// create checkbox element
			sb = createCheckBoxListElement(sb, htmlWrapper, htmlAttributes, selectedValues,
			                               disabledValues, listName, itemValue, itemText);
		}

		sb.Append(htmlWrapper.wrap_close);

		return MvcHtmlString.Create(sb.ToString());
	}


	// Creates an HTML wrapper for the checkbox list
	private static htmlWrapperInfo createHtmlWrapper
		(HtmlListInfo wrapInfo, int numberOfItems, Position position) {
		var w = new htmlWrapperInfo();

		if (wrapInfo != null) {
			// creating custom layouts
			switch (wrapInfo.htmlTag) {
					// creates user selected number of float sections with
					// vertically sorted checkboxes
				case HtmlTag.vertical_columns: {
					if (wrapInfo.Columns <= 0) wrapInfo.Columns = 1;

					var rows = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(numberOfItems)
					                                        / Convert.ToDecimal(wrapInfo.Columns)));
					if (numberOfItems <= 4 &&
						(numberOfItems <= wrapInfo.Columns || numberOfItems - wrapInfo.Columns == 1))
						rows = numberOfItems;
					
					w.separator_max_counter = rows;
					
					var wrapRow = htmlElementTag.div;
					var defaultSectionStyle = "float:left; margin-right:30px; line-height:25px;";
					var wrapHtml_builder = new TagBuilder(wrapRow.ToString());
					object style;
					wrapInfo.htmlAttributes.toDictionary().TryGetValue("style", out style);
					if (style != null)
						wrapHtml_builder.MergeAttribute("style", defaultSectionStyle + " " + style);
					else
						wrapHtml_builder.MergeAttribute("style", defaultSectionStyle);

					w.wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag);
					w.wrap_rowbreak = "</" + wrapRow + "> " +
					                  wrapHtml_builder.ToString(TagRenderMode.StartTag);
					w.wrap_close = wrapHtml_builder.ToString(TagRenderMode.EndTag) +
					               " <div style=\"clear:both;\"></div>";
					w.append_to_element = "<br/>";
				}
					break;
					// creates an html <table> with checkboxes sorted horizontally
				case HtmlTag.table: {
					if (wrapInfo.Columns <= 0) wrapInfo.Columns = 1;
					w.separator_max_counter = wrapInfo.Columns;

					var wrapHtml_builder = new TagBuilder(htmlElementTag.table.ToString());
					wrapHtml_builder.MergeAttributes(wrapInfo.htmlAttributes.toDictionary());
					wrapHtml_builder.MergeAttribute("cellspacing", "0"); // for IE7 compatibility

					var wrapRow = htmlElementTag.tr;
					w.wrap_element = htmlElementTag.td;
					w.wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag) +
					              "<" + wrapRow + ">";
					w.wrap_rowbreak = "</" + wrapRow + "><" + wrapRow + ">";
					w.wrap_close = "</" + wrapRow + ">" +
					               wrapHtml_builder.ToString(TagRenderMode.EndTag);
				}
					break;
					// creates an html unordered (bulleted) list of checkboxes in one column
				case HtmlTag.ul: {
					var wrapHtml_builder = new TagBuilder(htmlElementTag.ul.ToString());
					wrapHtml_builder.MergeAttributes(wrapInfo.htmlAttributes.toDictionary());
					wrapHtml_builder.MergeAttribute("cellspacing", "0"); // for IE7 compatibility

					w.wrap_element = htmlElementTag.li;
					w.wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag);
					w.wrap_close = wrapHtml_builder.ToString(TagRenderMode.EndTag);
				}
					break;
			}
		}
			// default setting creates vertical or horizontal column of checkboxes
		else {
			if (position == Position.Horizontal) w.append_to_element = " &nbsp; ";
			if (position == Position.Vertical) w.append_to_element = "<br/>";
		}

		return w;
	}
	// Creates an an individual checkbox
	private static int htmlwrap_rowbreak_counter { get; set; }
	private static int linked_label_counter { get; set; }
	private static StringBuilder createCheckBoxListElement
		(StringBuilder sb, htmlWrapperInfo htmlWrapper, object htmlAttributesForCheckBox,
		 IEnumerable<string> selectedValues, IEnumerable<string> disabledValues,
		 string name, string itemValue, string itemText) {
		// create checkbox tag
		var builder = new TagBuilder("input");
		if (selectedValues.Any(x => x == itemValue)) builder.MergeAttribute("checked", "checked");
		builder.MergeAttributes(htmlAttributesForCheckBox.toDictionary());
		builder.MergeAttribute("type", "checkbox");
		builder.MergeAttribute("value", itemValue);
		builder.MergeAttribute("name", name);

		// create linked label tag
		var link_name = name + linked_label_counter++;
		builder.MergeAttribute("id", link_name);
		var linked_label_builder = new TagBuilder("label");
		linked_label_builder.MergeAttribute("for", link_name);
		linked_label_builder.InnerHtml = itemText;

		// open checkbox tag wrapper
		sb.Append(htmlWrapper.wrap_element != htmlElementTag.None ? "<" + htmlWrapper.wrap_element + ">" : "");

		// build hidden tag for disabled checkbox (so the value will post)
		if (disabledValues != null && disabledValues.ToList().Any(x => x == itemValue)) {
			builder.MergeAttribute("disabled", "disabled");
			var hidden_builder = new TagBuilder("input");
			hidden_builder.MergeAttribute("type", "hidden");
			hidden_builder.MergeAttribute("value", itemValue);
			hidden_builder.MergeAttribute("name", name);
			sb.Append(hidden_builder.ToString(TagRenderMode.Normal));
		}

		// create checkbox tag
		sb.Append(builder.ToString(TagRenderMode.Normal));
		sb.Append(linked_label_builder.ToString(TagRenderMode.Normal));

		// close checkbox tag wrapper
		sb.Append(htmlWrapper.wrap_element != htmlElementTag.None ? "</" + htmlWrapper.wrap_element + ">" : "");

		// add element ending
		sb.Append(htmlWrapper.append_to_element);

		// add table column break, if applicable
		htmlwrap_rowbreak_counter += 1;
		if (htmlwrap_rowbreak_counter == htmlWrapper.separator_max_counter) {
			sb.Append(htmlWrapper.wrap_rowbreak);
			htmlwrap_rowbreak_counter = 0;
		}

		return sb;
	}


	// convert object to Dictionary<string, object>
	private static Dictionary<string, object> toDictionary(this object _object) {
		if (_object == null) return new Dictionary<string, object>();
		var object_properties = TypeDescriptor.GetProperties(_object);
		var dictionary = new Dictionary<string, object>(object_properties.Count);
		foreach (PropertyDescriptor property in object_properties) {
			var name = property.Name;
			var value = property.GetValue(_object);
			dictionary.Add(name, value ?? "");
		}
		return dictionary;
	}
	private static string toProperty<TModel, TItem>
		(this Expression<Func<TModel, TItem>> propertyExpression) {
		var lambda = propertyExpression as LambdaExpression;
		var expression = lambda.Body.ToString();
		return expression.Substring(expression.IndexOf('.') + 1);
	}


}


// support classes and enums
public enum HtmlTag {
	ul,
	table,
	vertical_columns
}
internal enum htmlElementTag {
	None,
	tr,
	td,
	li,
	div,
	table,
	ul
}
public enum Position {
	Horizontal,
	Vertical
}
public class HtmlListInfo {
	public HtmlListInfo(HtmlTag htmlTag, int columns = 0, object htmlAttributes = null) {
		this.htmlTag = htmlTag;
		Columns = columns;
		this.htmlAttributes = htmlAttributes;
	}

	public HtmlTag htmlTag { get; set; }
	public int Columns { get; set; }
	public object htmlAttributes { get; set; }
}
internal class htmlWrapperInfo {
	public string wrap_open = String.Empty;
	public string wrap_rowbreak = String.Empty;
	public string wrap_close = String.Empty;
	public htmlElementTag wrap_element = htmlElementTag.None;
	public string append_to_element = String.Empty;
	public int separator_max_counter;
}