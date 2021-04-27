using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Handler.Exceptions
{
    public class DocumentsToolsException : System.Exception
    {
        public DocumentsToolsException()
        {
        }

        public DocumentsToolsException(string message)
            :base(message)
        {
        }
    }
}