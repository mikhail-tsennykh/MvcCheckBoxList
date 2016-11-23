
## CheckBoxList(For) - a missing .NET MVC extension

Extension source code and MVC source project for Visual Studio 2012+, .NET framework 4.0 and 4.5.

#### Introduction

This plugin is just a simple extension of MVC class 'HtmlHelper',
which is used for all Html helpers on MVC views. Since there is
no supported CheckBoxList extension built into MVC (including MVC4),
this plugin adds it.

#### Install via NuGet:

    Install-Package MvcCheckBoxList
    
#### Insert into your Razor view:

    @Html.CheckBoxListFor(model => model.CheckBoxListName,                  // Checkbox name value, can be inline string
                          model => model.ListOfYourData,                    // List<YourDataObject>() of checkboxlist options
                            entity => entity.FieldToUseAsCheckBoxValue,     // Each option value field (from 'YourDataObject')
                            entity => entity.FieldToUseAsCheckBoxName,      // Each option text field (from 'YourDataObject')
                          model => model.ListOfYourSelectedData)            // List<YourDataObject>() of selected checkboxlist options
                          
#### This will render input:checkbox and label pairs, e.g.:

    <input checked="checked" id="CheckBoxListName123" name="CheckBoxListName" type="checkbox" value="1">
    <label for="CheckBoxListName123">Text 1</label>
    
    <input id="CheckBoxListName124" name="CheckBoxListName" type="checkbox" value="2">
    <label for="CheckBoxListName124">Text 2</label>
    
    <input id="CheckBoxListName125" name="CheckBoxListName" type="checkbox" value="3">
    <label for="CheckBoxListName125">Text 3</label>
    
#### How to use:

See Examples and Documentation on [Extension's Site](https://mikhail-tsennykh.github.io/MvcCheckBoxList/)
