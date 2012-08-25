
# CheckBoxList(For) - a missing MVC extension v.1.4.4.0 (development)

MVC3 source project for Visual Studio 2010 and .NET 4.0.

## What's new?

Something

## Installation

#### NuGet:

    Install-Package MvcCheckBoxList

#### Links:

NuGet package on [NuGet.org](https://nuget.org/packages/MvcCheckBoxList) and
full documentation on [CodeProject](http://www.codeproject.com/Articles/292050/CheckBoxList-For-a-missing-MVC-extension)

## Introduction

This plugin is just a simple extension of MVC class 'HtmlHelper',
which is used for all Html helpers on MVC views. Since there is
no supported CheckBoxList extension built into MVC, this plugin adds it.

## How to use

Given, we have a simple class 'City':

    public class City {
      public int Id { get; set; }
      public string Name { get; set; }
    }  

And another simple class 'Region' which has many instances of class 'City':
 
    public class Region {
      public IList<City> City { get; set; }
    } 
    
And you defined a similar view model:
 
    public class RegionViewModel {
      public Region Region { get; set; }
      public IList<City> Cities { get; set; }
    }
    
Then on a view which uses 'RegionViewModel' as its @model
to display a checkbox list of all tests and have some of them selected,
call in instance of 'CheckBoxList' or 'CheckBoxListFor' extension:

##### Option 1 - Manually set name:
 
    @Html.CheckBoxList("Cities",                // NAME of checkbox list (html 'name' property of each
                                                // checkbox in the list)
                       x => x.Cities,           // data source (list of 'Cities' in our case)
                       x => x.Id,               // field from data source to be used for checkbox VALUE
                       x => x.Name,             // field from data source to be used for checkbox TEXT
                       x => x.Region.Cities)    // selected data (list of selected 'Cities' in our case),
                                                // must be of same data type as source data or set to 'NULL'
                                            
##### Option 2 - Strongly typed name, based on the name of a view model property:
 
    @Html.CheckBoxListFor(x => x.Region,            // each checkbox name will be 'Region'. It can be
                                                    // set to any property in your view model and its name
                                                    // will be used as a NAME of each checkbox in the list
                          x => x.Cities,            // ...same as above...
                          x => x.Id,                // ...same as above...
                          x => x.Name,              // ...same as above...
                          x => x.Region.Cities)     // ...same as above...
                          
##### Full strongly typed name example:
 
    @Html.CheckBoxListFor(x => x.Cities,            // NAME of checkbox list (html 'name' property of
                                                    // each checkbox in the list)
                          x => x.Cities,            // data source (list of 'Cities' in our case)
                          x => x.Id,                // field from data source to be used for checkbox VALUE
                          x => x.Name,              // field from data source to be used for checkbox TEXT
                          x => x.Region.Cities,     // selected data (list of selected 'Cities' in our case),
                          new { htmlAttribute="somevalue" },  // htmlAttribute(s) of each checkbox
                          // creating custom layout of the list (see 'Advanced Usage Examples')
                          new HtmlListInfo(HtmlTag.vertical_columns, 3),
                          new[] {"7", "12", "14"})  // array represents disabled checkboxes
                                                    // (values will still POST!)
                                                    
##### In addition, you can use more advanced naming structure:
 
    @Html.CheckBoxListFor(x => x.Region.Cities,     // each checkbox's html 'name' property
                                                    // will be 'Region.Cities'
                          x => x.Cities,
                          x => x.Id,
                          x => x.Name,
                          x => x.Region.Cities)     
                      
Added in version 1.4.2.2, you can now send an object containing
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

Please note: adding custom tags is supported by all 'CheckBoxList' and 'CheckBoxListFor' 
overloads as the very last parameter.

Since version 1.4.3.0, you can flip checkbox and label to be used for 
right-to-left languages (e.g. Arabic, Hebrew, and others).
  
##### Basic usage:
 
    @Html.CheckBoxListFor(x => x.PostedCities.CityIDs,  // checkbox list name, 'PostedCities.CityIDs' in this case
                          x => x.AvailableCities,          
                          x => x.Id,               
                          x => x.Name,               
                          x => x.SelectedCities,
                          Position.Vertical_RightToLeft) // or 'Postion.Horizontal_RightToLeft'

##### Using advanced formatting:

    @Html.CheckBoxListFor(x => x.PostedCities.CityIDs,  // checkbox list name, 'PostedCities.CityIDs' in this case
                          x => x.AvailableCities,          
                          x => x.Id,               
                          x => x.Name,               
                          x => x.SelectedCities,
                          new HtmlListInfo(HtmlTag.vertical_columns, 0, null, TextLayout.RightToLeft))                    

## POSTing selected values back to the controller

To POST selected values back to the controller, it should accept a string array with the same name as CheckBoxList control name.                      

#### Simple scenario 

[HttpPost]
public ActionResult Edit(int id, string[] Cities) { // or whatever CheckBoxList name you've set manually
  // do your thing with that array
      
  return Edit(id);
}

#### Advanced scenario - POSTing View Model property 

Given we have a simple class 'Test':

    public class Test {
      public int Id { get; set; }
      public string Name { get; set; }
    }

And another simple class 'PostedTests' 

    public class PostedTests {
      // this array will be used to POST values from the form to the controller
      public string[] Tests { get; set; }
    } 

And we have a view model 'TestViewModel' that looks like this:

    public class TestViewModel {
      public IList<Test> AvailableTests { get; set; }
      public IList<Test> SelectedTests { get; set; }
      public PostedTests PostedTests { get; set; }
    } 

And you create checkbox list like that:                     

    @Html.CheckBoxListFor(x => x.PostedTests.Tests,    // each checkbox's html 'name' property will be
                                                       // named 'PostedTests.Tests'
                          x => x.AvailableTests,
                          x => x.Id,
                          x => x.Name,
                          x => x.SelectedTests)

then to capture list of selected checkboxes in a strongly typed manner, you can accept
an instance of 'PostedTests' class by controller. Remember, it should be named the same
as a first part of a checkbox name, in our case it is 'PostedTests'. This will load a
string list of selected checkbox values into the 'postedTests.Tests' variable. 

    [HttpPost]
    public ActionResult Edit(int id, PostedTests postedTests) {
      var list_of_selected_tests = postedTests.Tests;
      // do your thing with that array...
      return Edit(id);
    } 

## Advanced formatting examples

We'll create CheckBoxList which is arranged inside formatted list (given that you have created appropriate view model,
using strongly typed way, 'x' represents your model).

Create an instance of checkbox list formatting class 'HtmlListInfo' with parameters:

    @{ var putCheckBoxesIntoUnorderedList = //...select from variants below...
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

#### And that's all, Folks!

##### Join the discussion here:

[CheckBoxList(For) - a missing MVC extension](http://www.codeproject.com/Articles/292050/CheckBoxList-For-a-missing-MVC-extension)

Regards, 

[Mikhail](http://www.codeproject.com/Members/Mikhail-T) and 
[contributors] (http://www.codeproject.com/Articles/292050/CheckBoxList-For-a-missing-MVC-extension#Regards)