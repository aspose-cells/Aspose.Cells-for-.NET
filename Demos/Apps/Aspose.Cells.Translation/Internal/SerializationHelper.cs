using System;
using System.IO;
using Aspose.Cells.Translation.Api;
using Newtonsoft.Json;

namespace Aspose.Cells.Translation.Internal
{
    internal class SerializationHelper
    {
        public static string Serialize(object obj)
        {
            try
            {
                return obj != null ? JsonConvert.SerializeObject(obj, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}) : null;
            }
            catch (Exception e)
            {
                throw new ApiException(500, e.Message);
            }
        }

        public static object Deserialize(string json, Type type)
        {
            try
            {
                if (json.StartsWith("{") || json.StartsWith("["))
                {
                    return JsonConvert.DeserializeObject(json, type);
                }

                var xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(json);
                return JsonConvert.SerializeXmlNode(xmlDoc);
            }
            catch (IOException e)
            {
                throw new ApiException(500, e.Message);
            }
            catch (JsonSerializationException jse)
            {
                throw new ApiException(500, jse.Message);
            }
            catch (System.Xml.XmlException xmlException)
            {
                throw new ApiException(500, xmlException.Message);
            }
        }
    }
}