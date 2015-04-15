namespace MvcCheckBoxList.Library {
  internal class BuilderBase {
    public BuilderBase() {
      linked_label_counter = 0;
      htmlwrap_rowbreak_counter = 0;
    }

    // counter to count when to insert HTML code that breakes checkbox list
    internal int htmlwrap_rowbreak_counter { get; set; }
    // counter to be used on a label linked to each checkbox in the list
    internal int linked_label_counter { get; set; }
    // properties
    internal string no_data_message = "No Records...";
    internal string empty_model_message =
      "View Model cannot be null! Please make sure your View Model is created and passed to this View";
    internal string empty_name_message = "Name of the CheckBoxList cannot be null or empty";
  }
}