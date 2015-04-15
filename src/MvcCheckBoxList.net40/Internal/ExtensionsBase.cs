using MvcCheckBoxList.Library;

public static partial class Extensions {
  private static ListBuilder _listBuilder;
  static Extensions() {
    _listBuilder = new ListBuilder();
  }
}