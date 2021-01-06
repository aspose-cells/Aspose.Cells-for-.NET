using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tools.Foundation.Helpers
{
    public static class ObjectExtensions
    {
        public static string ToJson(
            this object obj,
            bool indented = true,
            bool ignoreNulls = true,
            bool ignoreDefault = true,
            bool enumAsStrings = true,
            bool ignoreReferenceLoop = false
        )
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = ignoreNulls ? NullValueHandling.Ignore : NullValueHandling.Include,
                DefaultValueHandling = ignoreDefault ? DefaultValueHandling.Ignore : DefaultValueHandling.Include,
                ReferenceLoopHandling = ignoreReferenceLoop ? ReferenceLoopHandling.Ignore : ReferenceLoopHandling.Error
            };

            if (enumAsStrings)
                settings.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(
                obj,
                indented ? Formatting.Indented : Formatting.None,
                settings
            );
        }
    }
}