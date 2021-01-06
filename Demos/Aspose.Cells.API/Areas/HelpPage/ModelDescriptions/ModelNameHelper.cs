using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Aspose.Cells.API.Areas.HelpPage.ModelDescriptions
{
    internal static class ModelNameHelper
    {
        // Modify this to provide custom model name mapping.
        public static string GetModelName(Type type)
        {
            var modelNameAttribute = type.GetCustomAttribute<ModelNameAttribute>();
            if (modelNameAttribute != null && !string.IsNullOrEmpty(modelNameAttribute.Name))
            {
                return modelNameAttribute.Name;
            }

            var modelName = type.Name;
            if (!type.IsGenericType) return modelName;
            // Format the generic type name to something like: GenericOfAgurment1AndArgument2
            var genericType = type.GetGenericTypeDefinition();
            var genericArguments = type.GetGenericArguments();
            var genericTypeName = genericType.Name;

            // Trim the generic parameter counts from the name
            genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
            var argumentTypeNames = genericArguments.Select(t => GetModelName(t)).ToArray();
            modelName = string.Format(CultureInfo.InvariantCulture, "{0}Of{1}", genericTypeName, string.Join("And", argumentTypeNames));

            return modelName;
        }
    }
}