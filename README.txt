
MVC3 @Html.CheckBoxList() custom extension

Introduction

This plugin is just a simple extension of MVC class 'HtmlHelper', which is used for all Html helpers on MVC views. Since there is no supported CheckBoxList extension built into MVC, this plugin adds it.



Using the code 

To use this extension, just copy file from archive anywhere in your MVC project. Or create a new class and copy and paste there source code from below.

All examples shown are for MVC3 using Razor view engine. It may also work fine in MVC 1 and 2. But honestly, If you haven't upgraded to MVC3 yet, it's about time)) 



Quick start:  


Method 1: Using strongly typed, based on view model:

// given you have a similar view model:
public class QuotationEditViewModel {
  public Quotation Quotation { get; set; } // entity 'Quatation' has many 'Tests'
  public IList<Test> Tests { get; set; }   // list of all 'Tests'
}
	
// to display a checkbox list of all tests and have some of them selected:
// manually setting name
@Html.CheckBoxList("Tests",                 // NAME of checkbox list
		   x => x.Tests,            // data source (list of 'Tests' in our case)
		   x => x.Id,               // field from data source to be used for checkbox VALUE
		   x => x.Name,             // field from data source to be used for checkbox TEXT
		   x => x.Quotation.Tests   // selected data (list of selected 'Tests' in our case),
		                            // must be of same data type as source data or set to 'NULL'
		   )	
// OR creating strongly typed list for particular property
@Html.CheckBoxListFor(x => x.Quotation,         // in this case name will be 'Quotation'. It can be set to any
                                                // property in your view model and its name will be used as
                                                // a NAME of checkbox list
	              x => x.Tests,             // ...same as above...
                      x => x.Id,                // ...same as above... 
                      x => x.Name,              // ...same as above...
                      x => x.Quotation.Tests)   // ...same as above...
	
// full example
@Html.CheckBoxListFor(x => x.Tests,             // NAME of checkbox list
                      x => x.Tests,             // data source (list of 'Tests' in our case)
                      x => x.Id,                // field from data source to be used for checkbox VALUE
                      x => x.Name,              // field from data source to be used for checkbox TEXT
                      x => x.Quotation.Tests,   // selected data (list of selected 'Tests' in our case),
                      new { htmlAttribute="somevalue" },  // htmlAttribute(s) of each checkbox
                      // creating custom layout of the list (see 'Advanced Usage Examples')
                      new HtmlListInfo(HtmlTag.vertical_columns, 3),
                      new[] {"7", "12", "14"})  // array represents disabled checkboxes
                                                // (values will still POST!)

For more examples see 'Advanced Usage Examples' section below.


Method 2: Independent from view model:
                                                
@{ 

  // given we have some list of names with ids:
  var sourceData = new[] {
                     new {Name = "Monroe", Id = 1},
	                   new {Name = "Moscow", Id = 2},
	                   new {Name = "New Orleans", Id = 3},
	                   new {Name = "Ottawa", Id = 4},
	                   new {Name = "Mumbai", Id = 5}
	                 };

  // first, we need to convert it to the list of class 'SelectListItems' (part of MVC):
  var dataList = sourceData.ToSelectListItems
    (x => x.Name, y => y.Id.ToString(), "").ToList();

  // OR if we want to have some values selected, first create a string array
  // of selected ids:
  var selectedValues = new[] { "1", "4" };

  // then create list of class 'SelectListItems' with some values selected:
  var dataListSelected = sourcedata.ToMultiSelectListItems
    (x => x.Name, y => y.Id.ToString(), s => selectedValues.Any(x => x.Id == s.Id)).ToList();

} 

// finally, just call CheckBoxList extension on your MVC view or partial:
@Html.CheckBoxList("Cities", dataList)

// OR
@Html.CheckBoxList("MoreCities", dataListSelected)

To POST selected values back to the controller, it should accept a string array with the same name as CheckBoxList control name: 
Collapse | Copy Code

[HttpPost]
public ActionResult Edit(int id, string[] Cities) { // or 'MoreCities'
  // do your thing with that array
      
  return Edit(id);
}



Advanced usage examples:

// Base
@Html.CheckBoxList("Cities", dataList)

// With vertical layout
@Html.CheckBoxList("Cities", dataList, Position.Vertical)

// Arranged inside of an unordered list
@{ var putCheckBoxesIntoUnorderedList = new HtmlListInfo(HtmlTag.ul); }
@Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoUnorderedList)
// OR (given that you have created appropriate view model, use strongly typed way, 'x' represents your model)
@Html.CheckBoxList("MyCitiesCheckBoxList",
		   x => x.Cities,
		   x => x.Id, 
		   x => x.Name,
		   x => x.SelectedCities,
                   putCheckBoxesIntoUnorderedList)
// OR use 'CheckBoxListFor' method
@Html.CheckBoxListFor(x => x.Cities,  // in that case name would be 'Cities'
		      x => x.Cities,
		      x => x.Id, 
		      x => x.Name,
		      x => x.SelectedCities,
                      putCheckBoxesIntoUnorderedList)
// You can use similar strongly typed approach for all examples below -

// Arranged inside 3 columned table with increased font size
@{ var putCheckBoxesIntoTable = new HtmlListInfo(HtmlTag.table, 3, new { style = "font-size: 130%;" }); }
@Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoTable)

// Arranged inside 4 vertically sorted floating sections
@{ var putCheckBoxesIntoTable = new HtmlListInfo(HtmlTag.vertical_columns, 4); }
@Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoTable)

// With some values disabled (disabled checkboxes will still POST)
@{ var disabledValues = new[] {"1", "4"}; }
@Html.CheckBoxList("Cities", dataList, null, disabledValues)

// Full control call
@{ var checkBoxHtmlAttributes = new { @class = "checkbox_class" };  }
@Html.CheckBoxList("Cities", dataList, checkBoxHtmlAttributes,
                   putCheckBoxesIntoTable, disabledValues, Position.Vertical)