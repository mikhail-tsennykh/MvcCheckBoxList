using System;
using System.Reflection;
using System.Diagnostics;

public static class CheckBoxListInfo {
  public static class AssemblyInfo {
    private static Assembly _assembly {
      get { return Assembly.GetExecutingAssembly(); }
    }

    public static string Title {
      get { return _getAssemblyAttribute<AssemblyTitleAttribute>().Title; }
    }
    public static string Description {
      get { return _getAssemblyAttribute<AssemblyDescriptionAttribute>().Description; }
    }
    public static string Company {
      get { return _getAssemblyAttribute<AssemblyCompanyAttribute>().Company; }
    }
    public static string Product {
      get { return _getAssemblyAttribute<AssemblyProductAttribute>().Product; }
    }
    public static string Copyright {
      get { return _getAssemblyAttribute<AssemblyCopyrightAttribute>().Copyright; }
    }
    public static string Trademark {
      get { return _getAssemblyAttribute<AssemblyTrademarkAttribute>().Trademark; }
    }
    public static string Version {
      get { return _assembly.GetName().Version.ToString(); }
    }
    public static string Guid {
      get { return _getAssemblyAttribute<System.Runtime.InteropServices.GuidAttribute>().Value; }
    }
    public static string FileVersion {
      get { return FileVersionInfo.GetVersionInfo(_assembly.Location).FileVersion; }
    }
    public static string FileName {
      get { return FileVersionInfo.GetVersionInfo(_assembly.Location).OriginalFilename; }
    }
    public static string FilePath {
      get { return FileVersionInfo.GetVersionInfo(_assembly.Location).FileName; }
    }

    private static T _getAssemblyAttribute<T>() where T : Attribute {
      return _getAssemblyAttribute<T>(_assembly);
    }
    private static T _getAssemblyAttribute<T>(Assembly assembly) where T : Attribute {
      if (assembly == null) return null;
      var attributes = assembly.GetCustomAttributes(typeof (T), true);
      if (attributes.Length == 0) return null;
      return (T) attributes[0];
    }

  }
}