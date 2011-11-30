Introduction

This is a somewhat advanced extension of MVC class 'HtmlHelper'.
Since there is no supported CheckBoxList extension built into MVC, it fixes that.
Using the code 

To use this extension, just copy file from archive anywhere in your MVC project.
Or create a new class and copy and paste there source code from below.

All examples shown are for MVC3 using Razor view engine. It may also work fine in MVC 1 and 2. But honestly,
If you haven't upgraded to MVC3 yet, it's about time))


Sample usage (MVC Razor view): 


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



Usage examples:
Collapse | Copy Code



// Base
@Html.CheckBoxList("Cities", dataList)

// With vertical layout
@Html.CheckBoxList("Cities", dataList, Position.Vertical)

// Arranged inside 3 columned table with increased font size
@{ var putCheckBoxesIntoTable = new HtmlListInfo(HtmlTag.table, 3, new { style = "font-size: 130%;" }); }
@Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoTable)

// Arranged inside of an unordered list with increased font size
@{ var putCheckBoxesIntoUnorderedList = new HtmlListInfo(HtmlTag.ul); }
@Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoUnorderedList)

// With some values disabled (disabled checkboxes will still POST)
@{ var disabledValues = new[] {"1", "4"}; }
@Html.CheckBoxList("Cities", dataList, null, disabledValues)

// Full control call
@{ var checkBoxHtmlAttributes = new { @class = "checkbox_class" };  }
@Html.CheckBoxList("Cities", dataList, checkBoxHtmlAttributes, putCheckBoxesIntoTable, disabledValues)