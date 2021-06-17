namespace Aspose.Cells.Common.CloudHelper.Invoker
{
    using System;
    using System.IO;
    using System.Xml;
    using Newtonsoft.Json;
    /// <summary>
    ///     Internal serializers to serialize/deserialize data using JsonConvert
    /// </summary>
    internal class JsonSerializationHelper
    {
        /// <summary>
        ///     Serialize object
        /// </summary>
        /// <param name="obj">The object to serialize</param>
        public static string Serialize(object obj)
        {
            try
            {
                if (obj == null) return null;

                var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                return JsonConvert.SerializeObject(obj, settings);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }

        /// <summary>
        ///     Deserializes an object into specified type
        /// </summary>
        /// <param name="json">The object serialized</param>
        /// <param name="type">The type</param>
        public static object Deserialize(string json, Type type)
        {
            try
            {
                if (string.IsNullOrEmpty(json)) return null;

                if (json.StartsWith("{") || json.StartsWith("["))
                    return JsonConvert.DeserializeObject(json, type);

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(json);
                return JsonConvert.SerializeXmlNode(xmlDoc);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}