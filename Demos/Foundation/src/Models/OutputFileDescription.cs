using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Models
{
    public class OutputFileDescription : FileDescription
    {
        public Stream stream { get; set; }
    }
}