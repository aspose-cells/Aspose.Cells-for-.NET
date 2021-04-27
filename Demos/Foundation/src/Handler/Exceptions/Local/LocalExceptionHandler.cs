using Tools.Foundation.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Handler.Exceptions.Local
{
    //Implements the IException interface
    public class LocalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        ///Get error message
        /// </summary>
        /// <param name="string locale">Locale to use - Example: en-us</param>
        /// <param name="IExceptionHandler exceptionHandler">Exception handler - if null default will be used</param>
        /// <returns>String</returns>
        public string getException(string locale, string exceptionId)
        {
            string message = "";
            //Check if the locale is set and set to default if not
            if (String.IsNullOrEmpty(locale))
            {
                locale = "en-us";
            }
            //Get path where to fin the transltions files
            string localesPath = new InternalConfigurations().localesFolderPath;
            //Get Configuration file path
            string configPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            //Combine the locale file path
            string path = configPath + localesPath + locale + ".txt";
            //Get all translations
            string allTranslations = File.ReadAllText(new Uri(path).LocalPath);
            //Select required translation
            var translationsDictionary = allTranslations.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => split[1]);
            message = translationsDictionary[exceptionId];
            //Return error message
            return message;
        }
    }
}