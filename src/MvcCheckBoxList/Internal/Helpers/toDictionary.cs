using System.Collections.Generic;
using System.ComponentModel;

namespace MvcCheckBoxList.Library {
  internal static class ToDictionary_Helper {
    /// <summary>
    /// Convert object to Dictionary of strings and objects
    /// </summary>
    /// <param name="_object">Object of Dictionary of strings and objects (e.g. 'new { name="value" }')</param>
    /// <returns>Dictionary of strings and objects</returns>
    internal static IDictionary<string, object> toDictionary(this object _object) {
      if (_object == null) return new Dictionary<string, object>();
      if (_object is IDictionary<string, object>) return (IDictionary<string, object>) _object;
      var object_properties = TypeDescriptor.GetProperties(_object);
      var dictionary = new Dictionary<string, object>(object_properties.Count);
      foreach (PropertyDescriptor property in object_properties) {
        var name = property.Name.Replace("_", "-");
        // JRR - Added the Replace call. This is the standard used by MVC http://www.asp.net/whitepapers/mvc3-release-notes#0.1__Toc274034227
        var value = property.GetValue(_object);
        dictionary.Add(name, value ?? "");
      }
      return dictionary;
    }
  }
}