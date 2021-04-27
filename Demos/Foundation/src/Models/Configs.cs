using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools.Foundation.Models
{
    public class Configs
    {
        public string workingdirectory { get; set; }
        public string inputdirname { get; set; }
        public string outputdirname { get; set; }
        public string outputdirectory { get; set; }
        public int scheduler { get; set; }
        public int maxfilesize { get; set; }
        public int numberofoperations { get; set; }
        public string clientIp { get; set; }
        public List<string> allowedUrl { get; set; }
        public string corsUrl { get; set; }
        public int threadsnumber { get; set; }
    }
}