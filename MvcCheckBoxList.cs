/////////////////////////////////////////////////////////////////////////////
//
// MVC3 @Html.CheckBoxList() custom extension v.1.1
// by devnoob, 2011
// http://www.codeproject.com/KB/user-controls/MvcCheckBoxList_Extension.aspx
//
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;

public static class MvcCheckBoxList {
	// Html.CheckBoxList
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, null, null);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 Position position) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, null, null, position);
	}
	
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 Position position, object htmlAttributes) {
		return htmlHelper.CheckBoxList
			(name, dataList, htmlAttributes, null, null, position);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, wrapInfo, null);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo, string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, wrapInfo, disabledValues);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 object htmlAttributes, HtmlListInfo wrapInfo, string[] disabledValues,
		 Position position = Position.Horizontal) {
		// validation
		if (dataList == null || dataList.Count == 0) return MvcHtmlString.Empty;
		if (String.IsNullOrEmpty(name)) throw new ArgumentException("The argument must have a value", "name");
		var numberOfItems = dataList.Count;

		// set up table/list html wrapper, if applicable
		var wrap_open = String.Empty;
		var wrap_rowbreak = String.Empty;
		var wrap_close = String.Empty;
		var wrap_element = htmlElementTag.None;
		var append_to_element = String.Empty;
		var separator_max_counter = 0;

		if (wrapInfo != null) {
			// creating custom layouts
			switch (wrapInfo.htmlTag) {
					// creates user selected number of float sections with
					// vertically sorted checkboxes
				case HtmlTag.vertical_columns: {
					if (wrapInfo.Columns <= 0) wrapInfo.Columns = 1;
					var rows = Convert.ToDecimal(numberOfItems) / Convert.ToDecimal(wrapInfo.Columns);
					separator_max_counter = Convert.ToInt32(Math.Ceiling(rows));

					var wrapRow = htmlElementTag.div;
					var defaultSectionStyle = "float:left; margin-right:30px; line-height:25px;";
					var wrapHtml_builder = new TagBuilder(wrapRow.ToString());
					object style;
					wrapInfo.htmlAttributes.ToDictionary().TryGetValue("style", out style);
					if (style != null)
						wrapHtml_builder.MergeAttribute("style", defaultSectionStyle + " " + style);
					else
						wrapHtml_builder.MergeAttribute("style", defaultSectionStyle);

					wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag);
					wrap_rowbreak = "</" + wrapRow + "> " +
					                wrapHtml_builder.ToString(TagRenderMode.StartTag);
					wrap_close = wrapHtml_builder.ToString(TagRenderMode.EndTag) +
					             " <div style=\"clear:both;\" />";
					append_to_element = "<br/>";
				}
					break;
					// creates an html <table> with checkboxes sorted horizontally
				case HtmlTag.table: {
					if (wrapInfo.Columns <= 0) wrapInfo.Columns = 1;
					separator_max_counter = wrapInfo.Columns;

					var wrapHtml_builder = new TagBuilder(htmlElementTag.table.ToString());
					wrapHtml_builder.MergeAttributes(wrapInfo.htmlAttributes.ToDictionary());
					wrapHtml_builder.MergeAttribute("cellspacing", "0"); // for IE7 compatibility

					var wrapRow = htmlElementTag.tr;
					wrap_element = htmlElementTag.td;
					wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag) +
					            "<" + wrapRow + ">";
					wrap_rowbreak = "</" + wrapRow + "><" + wrapRow + ">";
					wrap_close = "</" + wrapRow + ">" +
					             wrapHtml_builder.ToString(TagRenderMode.EndTag);
				}
					break;
					// creates an html unordered (bulleted) list of checkboxes in one column
				case HtmlTag.ul: {
					var wrapHtml_builder = new TagBuilder(htmlElementTag.ul.ToString());
					wrapHtml_builder.MergeAttributes(wrapInfo.htmlAttributes.ToDictionary());
					wrapHtml_builder.MergeAttribute("cellspacing", "0"); // for IE7 compatibility

					wrap_element = htmlElementTag.li;
					wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag);
					wrap_close = wrapHtml_builder.ToString(TagRenderMode.EndTag);
				}
					break;
			}
		}
			// default setting creates vertical or horizontal column of checkboxes
		else {
			if (position == Position.Horizontal) append_to_element = " &nbsp; ";
			if (position == Position.Vertical) append_to_element = "<br/>";
		}

		// create checkbox list
		var sb = new StringBuilder();
		var counter = 0;

		sb.Append(wrap_open);

		foreach (var r in dataList) {
			// build checkbox html tag
			var builder = new TagBuilder("input");

			if (r.Selected) builder.MergeAttribute("checked", "checked");
			builder.MergeAttributes(htmlAttributes.ToDictionary());
			builder.InnerHtml = r.Text;
			builder.MergeAttribute("type", "checkbox");
			builder.MergeAttribute("value", r.Value);
			builder.MergeAttribute("name", name);

			// open checkbox tag wrapper
			sb.Append(wrap_element != htmlElementTag.None ? "<" + wrap_element + ">" : "");

			// build hidden tag for disabled checkbox (so the value will post)
			if (disabledValues != null && disabledValues.ToList().Any(x => x == r.Value)) {
				builder.MergeAttribute("disabled", "disabled");
				var hidden_builder = new TagBuilder("input");
				hidden_builder.MergeAttribute("type", "hidden");
				hidden_builder.MergeAttribute("value", r.Value);
				hidden_builder.MergeAttribute("name", name);
				sb.Append(hidden_builder.ToString(TagRenderMode.Normal));
			}

			// create checkbox tag
			sb.Append(builder.ToString(TagRenderMode.Normal));

			// close checkbox tag wrapper
			sb.Append(wrap_element != htmlElementTag.None ? "</" + wrap_element + ">" : "");

			// add element ending
			sb.Append(append_to_element);

			// add table column break, if applicable
			counter += 1;
			if (counter == separator_max_counter) {
				sb.Append(wrap_rowbreak);
				counter = 0;
			}
		}

		sb.Append(wrap_close);

		return MvcHtmlString.Create(sb.ToString());
	}


	// convert object to Dictionary<string, object>
	private static Dictionary<string, object> ToDictionary(this object @object) {
		if (@object == null) return new Dictionary<string, object>();
		var object_properties = TypeDescriptor.GetProperties(@object);
		var dictionary = new Dictionary<string, object>(object_properties.Count);
		foreach (PropertyDescriptor property in object_properties) {
			var name = property.Name;
			var value = property.GetValue(@object);
			dictionary.Add(name, value ?? "");
		}
		return dictionary;
	}


}
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