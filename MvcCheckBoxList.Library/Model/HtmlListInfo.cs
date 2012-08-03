/// <summary>
/// Sets settings of an HTML wrapper that is used on a checkbox list
/// </summary>
public class HtmlListInfo {
	public HtmlListInfo(
    HtmlTag htmlTag, 
    int columns = 0, 
    object htmlAttributes = null, 
    TextLayout textLayout = TextLayout.Default) {

		this.htmlTag = htmlTag;
		Columns = columns;
		this.htmlAttributes = htmlAttributes;
	  TextLayout = textLayout;
	}

	public HtmlTag htmlTag { get; set; }
	public int Columns { get; set; }
	public object htmlAttributes { get; set; }
  public TextLayout TextLayout { get; set; }
}