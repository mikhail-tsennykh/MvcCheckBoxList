/// <summary>
/// Sets settings of an HTML wrapper that is used on a checkbox list
/// </summary>
public class HtmlListInfo {
  public HtmlListInfo(
    HtmlTag htmlTag,
    int columns = 0,
    object htmlAttributes = null,
    TextLayout textLayout = TextLayout.Default,
    TemplateIsUsed templateIsUsed = TemplateIsUsed.No) {

    this.htmlTag = htmlTag;
    Columns = columns;
    this.htmlAttributes = htmlAttributes;
    TextLayout = textLayout;
    TemplateIsUsed = templateIsUsed;
  }

  public HtmlTag htmlTag { get; set; }
	public int Columns { get; set; }
	public object htmlAttributes { get; set; }
  public TextLayout TextLayout { get; set; }

  /// <summary>
  /// Allows to use user-defined html template for checkbox text.
  /// How-To:
  /// If your checkbox list uses class 'City' -
  /// 1) Create 'Views\Shared\DisplayTemplates\City.cshtml' including all directories
  /// 2) Set 'City.cshtml' @model to inherit from class 'City'
  /// 
  /// E.g. 'City.cshtml' may look like:
  /// @model YourNamespace.City
  /// <strong>@Model.Name</strong> - template text
  /// </summary>
  public TemplateIsUsed TemplateIsUsed { get; set; }

}