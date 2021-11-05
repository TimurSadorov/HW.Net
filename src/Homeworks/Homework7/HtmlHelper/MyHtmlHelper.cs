using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Homework7
{
    public static class MyHtmlHelper
    {
        public static HtmlString MyEditorForModel(this IHtmlHelper html)
        {
            var result = new StringBuilder();
            var typeModel = html.ViewData.Model.GetType();
            var properties = typeModel.GetProperties();
            foreach (var prop in properties)
                AddHtmlInputField(result, prop, html.ViewData.Model);
            return new HtmlString(result.ToString());
        }

        private static void AddHtmlInputField(StringBuilder htmlContent, PropertyInfo prop, object obj)
        {
            htmlContent.Append(GetHtmlLabel(prop));
            if (prop.PropertyType.IsEnum)
                htmlContent.Append(CreateDropDown(prop));
            else
            {
                htmlContent.Append(CreateHtmlInput(prop));
                htmlContent.Append(CreateHtmlSpan(prop, obj));
            }
        }

        private static string CreateHtmlSpan(PropertyInfo prop, object obj)
        {
            var result =
                $"<span class=\"field-validation-error\" data-valmsg-for=\"{prop.Name}\"" +
                $" data-valmsg-replace=\"true\">";
            var validateAttr = prop.GetCustomAttributes<ValidationAttribute>();
            if (validateAttr.Any())
                result = validateAttr.Aggregate(result, 
                    (current, attr) => current + (!attr.IsValid(prop.GetValue(obj))
                    ? attr.ErrorMessage ?? attr.FormatErrorMessage(prop.Name)
                    : string.Empty + "\n"));
            result += "</span>";
            return result;
        }

        private static string GetHtmlLabel(MemberInfo prop) =>
            $"<div><label for=\"{prop.Name}\">{GetDisplayName(prop)}</label></div>";

        private static string CreateDropDown(PropertyInfo prop)
        {
            return $"<select id=\"{prop.Name}\" name=\"{prop.Name}\">" +
                   prop.PropertyType.GetEnumNames()
                       .Zip(prop.PropertyType.GetEnumValues().Cast<int>(),
                           (name, value) => (name, value))
                       .Select(x => $"<option value=\"{x.value}\">{x.name}</option>")
                       .Aggregate(string.Concat)
                   + "</select>";
        }

        private static string CreateHtmlInput(PropertyInfo prop)
        {
            return "<input " + GetClassInput() + GetHtmlDataAttributes(prop) +
                      $"id=\"{prop.Name}\" name=\"{prop.Name}\" " + GetTypeInput(prop) 
                      + GetDefaultValue(prop) + ">";
        }

        private static string GetDefaultValue(PropertyInfo prop)
        {
            var attr = "value=";
            if (BuiltInTypes.IntegerTypes.Contains(prop.PropertyType) ||
                BuiltInTypes.NullableIntegerTypes.Contains(prop.PropertyType))
                return attr + "\"0\" ";
            if (BuiltInTypes.RealTypes.Contains(prop.PropertyType) ||
                BuiltInTypes.NullableRealTypes.Contains(prop.PropertyType))
                return attr + "\"0,00\" ";
            return attr + "\"\" ";
        }

        private static string GetHtmlDataAttributes(PropertyInfo prop)
        {
            var dataAttributes = "";
            var displayName = GetDisplayName(prop);
            if (BuiltInTypes.AllNumericTypes.Contains(prop.PropertyType))
                dataAttributes += "data-val=\"true\" ";
            if (!(BuiltInTypes.NullableNumericTypes.Contains(prop.PropertyType) || prop.PropertyType.IsClass))
                dataAttributes += $"data-val-required=\"The {displayName} field is required.\" ";
            if (BuiltInTypes.IntegerTypes.Contains(prop.PropertyType))
                dataAttributes += $"data-val-number=\"The field {displayName} must be a number.\" ";
            return dataAttributes;
        }

        private static string GetClassInput() => "class=\"text-box single-line\"";

        private static string GetTypeInput(PropertyInfo prop)
        {
            return BuiltInTypes.NullableIntegerTypes.Contains(prop.PropertyType) 
                ? "type=\"number\"" 
                : "type=\"text\"";
        }

        private static string GetDisplayName(MemberInfo prop)
        {
            var displayName = prop.GetCustomAttribute<DisplayNameAttribute>();
            return displayName is null ? SplitByCamelCase(prop.Name) : displayName.DisplayName;
        }

        private static string SplitByCamelCase(string str)
        {
            return str
                .Skip(1)
                .Aggregate($"{str.FirstOrDefault()}",
                    (current, symbol) => current + (char.IsUpper(symbol) ? $" {symbol}" : symbol));
        }
    }
}