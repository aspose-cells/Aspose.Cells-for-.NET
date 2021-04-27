using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Handler.Exceptions
{
    public interface IExceptionHandler
    {
        string getException(string locale, string exceptionId);
    }
}