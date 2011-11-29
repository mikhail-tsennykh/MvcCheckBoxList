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
			(name, dataList, null, Position.Horizontal, null, null);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 Position position) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, position, null, null);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, Position.Horizontal, null, wrapInfo);
	}
	
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo, string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(name, dataList, null, Position.Horizontal, disabledValues, wrapInfo);
	}

	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string name, List<SelectListItem> dataList,
		 object htmlAttributes, Position position,
		 string[] disabledValues, HtmlListInfo wrapInfo) {
		// validation
		if (dataList == null || dataList.Count == 0) return MvcHtmlString.Empty;
		if (String.IsNullOrEmpty(name)) throw new ArgumentException("The argument must have a value", "name");

		// set up table/list html wrapper, if applicable
		var wrap_open = String.Empty;
		var wrap_columnbreak = String.Empty;
		var wrap_close = String.Empty;
		var wrapElement = HtmlTag.None;
		if (wrapInfo != null) {
			var wrapHtml_builder = new TagBuilder(wrapInfo.htmlTag.ToString());
			wrapHtml_builder.MergeAttributes(wrapInfo.htmlAttributes.ToDictionary());
			wrapHtml_builder.MergeAttribute("cellspacing", "0"); // for IE7 compatibility

			if (wrapInfo.htmlTag == HtmlTag.table) {
				var wrapRow = HtmlTag.tr;
				wrapElement = HtmlTag.td;
				wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag) +
				            "<" + wrapRow + ">";
				wrap_columnbreak = "</" + wrapRow + "><" + wrapRow + ">";
				wrap_close = "</" + wrapRow + ">" +
				             wrapHtml_builder.ToString(TagRenderMode.EndTag);
			}
			if (wrapInfo.htmlTag == HtmlTag.ul) {
				wrapElement = HtmlTag.li;
				wrap_open = wrapHtml_builder.ToString(TagRenderMode.StartTag);
				wrap_close = wrapHtml_builder.ToString(TagRenderMode.EndTag);
			}
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

			// build hidden tag for disabled checkbox (so the value will post)
			var hidden_tag = String.Empty;
			if (disabledValues != null && disabledValues.ToList().Any(x => x == r.Value)) {
				builder.MergeAttribute("disabled", "disabled");
				var hidden_builder = new TagBuilder("input");
				hidden_builder.MergeAttribute("type", "hidden");
				hidden_builder.MergeAttribute("value", r.Value);
				hidden_builder.MergeAttribute("name", name);
				hidden_tag = hidden_builder.ToString(TagRenderMode.Normal);
			}

			// create checkbox tag
			sb.Append(wrapElement != HtmlTag.None ? "<" + wrapElement + ">" : "");

			sb.Append(builder.ToString(TagRenderMode.Normal));
			sb.Append(hidden_tag);

			sb.Append(wrapElement != HtmlTag.None ? "</" + wrapElement + ">" : "");

			// add table column break, if applicable
			counter += 1;
			if (wrapInfo != null && counter == wrapInfo.Columns) {
				sb.Append(wrap_columnbreak);
				counter = 0;
			}

			// if tag is not wrapped into some html, add ending
			if (wrapElement != HtmlTag.None) continue;
			if (position == Position.Horizontal) sb.Append(" &nbsp; ");
			if (position == Position.Vertical) sb.Append("<br/>");
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
	None,
	table,
	tr,
	td,
	ul,
	li
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