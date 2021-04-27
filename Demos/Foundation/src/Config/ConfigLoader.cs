using Tools.Foundation.Handler.Exceptions;
using Tools.Foundation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Tools.Foundation.Config
{
    public class ConfigLoader
    {
        //Path of the Config.xml file
        public string path = "";

        //Construct the class and set the path value
        public ConfigLoader(string path)
        {
            this.path = path;
        }

        /// <summary>
        ///Open and parse the Config.xml file
        /// </summary>
        /// <returns>Configs object</returns>
        public void LoadConfigs(Configs c)
        {
            //Initialize the result object of the Configs model
            Configs settings = new Configs();
            try
            {
                XDocument xDoc = XDocument.Load(path);
                var props = c.GetType().GetProperties();
                foreach (var prop in props)
                {
                    var settingName = Char.ToLowerInvariant(prop.Name[0]) + prop.Name.Substring(1);
                    var xmlSettingNode = xDoc.Descendants().FirstOrDefault(d => d.Name == settingName);
                    if (xmlSettingNode != null)
                    {
                        switch (prop.PropertyType.Name)
                        {
                            case "Int32":
                                int intValue = Convert.ToInt32(xmlSettingNode.Value);
                                prop.SetValue(c, intValue);
                                break;
                            case "String":
                                string stringValue = xmlSettingNode.Value;
                                prop.SetValue(c, stringValue);
                                break;
                            case "List`1":
                                List<string> urls = xmlSettingNode.Value.Split(',').ToList();
                                prop.SetValue(c, urls);
                                break;
                        }
                    }
                }
            }
            catch (DocumentsToolsException)
            {
                throw new GdtFileNotFoundException("en-us", null);
            }
        }
    }
}