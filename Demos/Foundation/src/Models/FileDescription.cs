using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Models
{
    public abstract class FileDescription
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string OperationId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }
    }
}