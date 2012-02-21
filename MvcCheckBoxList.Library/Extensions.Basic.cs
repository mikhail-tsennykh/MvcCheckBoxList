using System.Collections.Generic;
using System.Web.Mvc;

/// <summary>
/// Regular CheckBoxList extensions
/// </summary>
public static class MvcCheckBoxList_Extensions_Basic {
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
	/// <returns>HTML string containing checkbox list</returns>	
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, null, null, position);
	}
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="htmlAttributes">Each checkbox HTML tag attributes (e.g. 'new { class="somename" }')</param>
	/// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
	/// <returns>HTML string containing checkbox list</returns>
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, htmlAttributes, null, null, position);
	}
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="htmlAttributes">Each checkbox HTML tag attributes (e.g. 'new { class="somename" }')</param>
	/// <param name="disabledValues">String array of values to disable</param>
	/// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
	/// <returns>HTML string containing checkbox list</returns>
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, string[] disabledValues, Position position = Position.Horizontal) {
		return htmlHelper.CheckBoxList
			(listName, dataList, htmlAttributes, null, disabledValues, position);
	}
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="wrapInfo">Settings for HTML wrapper of the list (e.g. 'new HtmlListInfo2(HtmlTag2.vertical_columns, 2, new { style="color:green;" })')</param>
	/// <returns>HTML string containing checkbox list</returns>
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, wrapInfo, null);
	}
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="wrapInfo">Settings for HTML wrapper of the list (e.g. 'new HtmlListInfo2(HtmlTag2.vertical_columns, 2, new { style="color:green;" })')</param>
	/// <param name="disabledValues">String array of values to disable</param>
	/// <returns>HTML string containing checkbox list</returns>
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 HtmlListInfo wrapInfo, string[] disabledValues) {
		return htmlHelper.CheckBoxList
			(listName, dataList, null, wrapInfo, disabledValues);
	}
	/// <summary>
	/// Model-Independent function
	/// </summary>
	/// <param name="htmlHelper">MVC Html helper class that is being extended</param>
	/// <param name="listName">Name of each checkbox in a list (use this name to POST list values array back to the controller)</param>
	/// <param name="dataList">List of name/value pairs to be used as source data for the list</param>
	/// <param name="htmlAttributes">Each checkbox HTML tag attributes (e.g. 'new { class="somename" }')</param>
	/// <param name="wrapInfo">Settings for HTML wrapper of the list (e.g. 'new HtmlListInfo2(HtmlTag2.vertical_columns, 2, new { style="color:green;" })')</param>
	/// <param name="disabledValues">String array of values to disable</param>
	/// <param name="position">Direction of the list (e.g. 'Position2.Horizontal' or 'Position2.Vertical')</param>
	/// <returns>HTML string containing checkbox list</returns>
	public static MvcHtmlString CheckBoxList
		(this HtmlHelper htmlHelper, string listName, List<SelectListItem> dataList,
		 object htmlAttributes, HtmlListInfo wrapInfo, string[] disabledValues,
		 Position position = Position.Horizontal) {
		return MvcCheckBoxList.CheckBoxList
			(htmlHelper, listName, dataList, htmlAttributes, wrapInfo, disabledValues, position);
	}
}