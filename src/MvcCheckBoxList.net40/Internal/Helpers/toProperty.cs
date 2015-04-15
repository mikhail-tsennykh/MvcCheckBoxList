using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MvcCheckBoxList.Library {
  internal static class ToProperty_Helper {
    /// <summary>
    /// Convert lambda expression to property name
    /// </summary>
    /// <typeparam name="TModel">Current ViewModel</typeparam>
    /// <typeparam name="TItem">ViewModel Item</typeparam>
    /// <param name="propertyExpression">Lambda expression of property value</param>
    /// <returns>Property value string</returns>
    internal static string toProperty<TModel, TItem>
      (this Expression<Func<TModel, TItem>> propertyExpression) {
      // v.1.4
      return ExpressionHelper.GetExpressionText(propertyExpression);

      // v.1.3c
      //var lambda = propertyExpression as LambdaExpression;
      //var expression = lambda.Body.ToString();
      //return expression.Substring(expression.IndexOf('.') + 1);

      // v.1.2
      //// return property name only
      //var lambda = propertyExpression as LambdaExpression;
      //MemberExpression memberExpression;
      //if (lambda.Body is UnaryExpression) {
      //  var unaryExpression = lambda.Body as UnaryExpression;
      //  memberExpression = unaryExpression.Operand as MemberExpression;
      //}
      //else
      //  memberExpression = lambda.Body as MemberExpression;
      //var propertyInfo = memberExpression.Member as PropertyInfo;
      //return propertyInfo.Name;
    }
  }
}