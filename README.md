
# MVC3 @Html.CheckBoxList() custom extension v.1.4.2.3

MVC3 source project for Visual Studio 2010 and .NET 4.0.

By [Mikhail Tsennykh, 2011-2012](http://www.codeproject.com/KB/user-controls/MvcCheckBoxList_Extension.aspx)

Alternatively, you can simply install a NuGet package of this extension:

    Install-Package MvcCheckBoxList

####Links:

NuGet package on [NuGet.org](https://nuget.org/packages/MvcCheckBoxList) and
full documentation on [CodeProject](http://www.codeproject.com/KB/user-controls/MvcCheckBoxList_Extension.aspx)

##Introduction

This plugin is just a simple extension of MVC class 'HtmlHelper',
which is used for all Html helpers on MVC views. Since there is
no supported CheckBoxList extension built into MVC, this plugin adds it.

##Method 1: Using strongly typed, based on view model

Given you have a similar view model:

    public class QuotationEditViewModel {
      public Quotation Quotation { get; set; } // entity 'Quatation' has many 'Tests'
      public IList<Test> Tests { get; set; }   // list of all 'Tests'
    }
	
To display a checkbox list of all tests and have some of them selected:

Manually set name:

    @Html.CheckBoxList("Tests",                 // NAME of checkbox list (html 'name' property of each checkbox in the list)
           x => x.Tests,            // data source (list of 'Tests' in our case)
           x => x.Id,               // field from data source to be used for checkbox VALUE
           x => x.Name,             // field from data source to be used for checkbox TEXT
           x => x.Quotation.Tests   // selected data (list of selected 'Tests' in our case),
                                    // must be of same data type as source data or set to 'NULL'
           )	
           
OR creating strongly typed list for particular property:

    @Html.CheckBoxListFor(x => x.Quotation,         // each checkbox name will be 'Quotation'. It can be set to any
                                                    // property in your view model and its name will be used as
                                                    // a NAME of each checkbox in the list
                          x => x.Tests,             // ...same as above...
                          x => x.Id,                // ...same as above... 
                          x => x.Name,              // ...same as above...
                          x => x.Quotation.Tests)   // ...same as above...
	
Full example:

    @Html.CheckBoxListFor(x => x.Tests,             // NAME of checkbox list (html 'name' property of each checkbox in the list)
                          x => x.Tests,             // data source (list of 'Tests' in our case)
                          x => x.Id,                // field from data source to be used for checkbox VALUE
                          x => x.Name,              // field from data source to be used for checkbox TEXT
                          x => x.Quotation.Tests,   // selected data (list of selected 'Tests' in our case),
                          new { htmlAttribute="somevalue" },  // htmlAttribute(s) of each checkbox
                          // creating custom layout of the list (see 'Advanced Usage Examples')
                          new HtmlListInfo(HtmlTag.vertical_columns, 3),
                          new[] {"7", "12", "14"})  // array represents disabled checkboxes
                                                    // (values will still POST!)

Also, you can use more advanced naming structure:

    @Html.CheckBoxListFor(x => x.Quotation.Tests,   // each checkbox's html 'name' property will be 'Quotation.Tests'
                          x => x.Tests,             
                          x => x.Id,                
                          x => x.Name,              
                          x => x.Quotation.Tests)   
                      
                      
Added in version 1.4, you can now send an object containing
html tag which would be applied to an individual checkbox
Here, 'Tags' is a variable of type 'object' and equals e.g. 'new {htmlTag = "Value"}'
(this means you can pass something like 'new {what = "smallCity}', and apply some
jquery code to it: '$('[what="smallCity"]').css("color", "blue")'):

    @Html.CheckBoxListFor(x => x.PostedCities.CityIDs,
                          x => x.AvailableCities,
                          x => x.Id,
                          x => x.Name,
                          x => x.SelectedCities,
                          x => x.Tags)               // tags stored in the data source as an object e.g.: 'new {what = "smallCity"}'
                                                     // they will be merged with other tags and applied to checkbox and its label                      
                      

###POSTing selected values back to the controller

To POST selected values back to the controller, it should accept a string array with the same name as CheckBoxList control name.                      

Given we have a view model that looks like this:

    public class QuotationListViewModel {
      public IList<Test> AvailableTests { get; set; }
      public IList<Test> SelectedTests { get; set; }
      public QuotationSearch QuotationSearch { get; set; }
    }

And implements similar class:

    public class QuotationSearch {
      // this array will be used to POST values from the form to the controller
      public string[] Tests { get; set; }
    }

And you create checkbox list like that:

    @Html.CheckBoxListFor(x => x.QuotationSearch.Tests,    // each checkbox's html 'name' property will be
                                                           // named 'Quotation.Tests'
                          x => x.AvailableTests,             
                          x => x.Id,                
                          x => x.Name,              
                          x => x.SelectedTests)

Then to capture list of selected checkboxes in a strongly typed manner, you can accept
an instance of 'QuotationSearch' by controller. Remember, it should be named the same as
a first part of a checkbox name, in our case it is 'QuotationSearch'. This will load
a string list of selected checkbox values into the 'quotationSearch.Tests' variable:

    [HttpPost]
    public ActionResult Edit(int id, QuotationSearch quotationSearch) { // or 'MoreCities'
     
      var list_of_selected_tests = quotationSearch.Tests;

      // do your thing with that array...

      return Edit(id);
    }                      

 
                     
##Method 2: Independent from view model

Given you have the following code on your view:
                                                
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

Finally, just call CheckBoxList extension on your MVC view or partial:

    @Html.CheckBoxList("Cities", dataList)

OR to have some values checked:

    @Html.CheckBoxList("MoreCities", dataListSelected)

###POSTing selected values back to the controller

To POST selected values back to the controller, it should accept a string array with the
same name as CheckBoxList control name: 

    [HttpPost]
    public ActionResult Edit(int id, string[] Cities) { // or 'MoreCities'
      // do your thing with that array
          
      return Edit(id);
    }



##Advanced examples (for Model-based approach):

We'll create CheckBoxList which is arranged inside formatted list (given that you have created appropriate view model,
using strongly typed way, 'x' represents your model).

Create an instance of checkbox list formatting class 'HtmlListInfo' with parameters:

    @{ var putCheckBoxesIntoUnorderedList = //...select from variants below...
      // arranged inside of the html 'unordered list'
      new HtmlListInfo(HtmlTag.ul); 
      // OR arranged inside of the html 'table' with three columns
      new HtmlListInfo(HtmlTag.table, 3); 
      // OR arranged inside of vertical columns (div's which float left) containing three columns
      new HtmlListInfo(HtmlTag.vertical_columns, 3);
      // OR any of above plus object representing custom html tags (e.g. 'new { htmlTag = "Value" }')
      // html tag will be applied to container holding checkbox list (ul, table, etc.)
      new HtmlListInfo(HtmlTag.SELECT, NUMBER_OF_COLUMNS, new { htmlTag1 = "Value1", htmlTag2 = "Value2" });
    }

Apply an instance of 'HtmlListInfo' class to your checkbox list call:

    @Html.CheckBoxList("MyCitiesCheckBoxList",
                       x => x.Cities,
                       x => x.Id, 
                       x => x.Name,
                       x => x.SelectedCities,
                       putCheckBoxesIntoUnorderedList)

OR use 'CheckBoxListFor' method:

    @Html.CheckBoxListFor(x => x.Cities,  // in that case name of the checkbox list would be 'Cities'
                          x => x.Cities,
                          x => x.Id, 
                          x => x.Name,
                          x => x.SelectedCities,
                          putCheckBoxesIntoUnorderedList)


##Advanced examples (for Model-independent approach):

Note: You can use display customizations below (using HtmlListInfo class and others) for Model-based approach too!

Base:

    @Html.CheckBoxList("Cities", dataList)

With vertical layout:

    @Html.CheckBoxList("Cities", dataList, Position.Vertical)

Arranged inside of an unordered list:

    @{ var putCheckBoxesIntoUnorderedList = new HtmlListInfo(HtmlTag.ul); }
    @Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoUnorderedList)

Arranged inside 3 columned table with increased font size:

    @{ var putCheckBoxesIntoTable = new HtmlListInfo(HtmlTag.table, 3); }
    @Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoTable)

Arranged inside 4 vertically sorted floating sections:

    @{ 
      var putCheckBoxesIntoTable = 
        new HtmlListInfo(HtmlTag.vertical_columns, 4, new { style = "width:100px;" }); 
    }
    @Html.CheckBoxList("Cities", dataList, putCheckBoxesIntoTable)

With some values disabled (disabled checkboxes will still POST):

    @{ var disabledValues = new[] {"1", "4"}; }
    @Html.CheckBoxList("Cities", dataList, null, disabledValues)

Full control call:

    @{ var checkBoxHtmlAttributes = new { @class = "checkbox_class" };  }
    @Html.CheckBoxList("Cities", dataList, checkBoxHtmlAttributes,
                       putCheckBoxesIntoTable, disabledValues, Position.Vertical)

####And that's all, Folks!


