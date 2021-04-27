using Tools.Foundation.Config;
using Tools.Foundation.Handler.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Handler.Exceptions
{
    public class GdtFileNotFoundException : DocumentsToolsException
    {
        public GdtFileNotFoundException(string locale, IExceptionHandler exceptionHandler)
            : base(GetMessage(locale, exceptionHandler))
        {
            
        }

        private static string GetMessage(string locale, IExceptionHandler exceptionHandler)
        {
            if (exceptionHandler == null)
            {
                exceptionHandler = new Tools.Foundation.Handler.Exceptions.Local.LocalExceptionHandler();
            }
            return exceptionHandler.getException(locale, "fileNotFound");
        }
    }
}