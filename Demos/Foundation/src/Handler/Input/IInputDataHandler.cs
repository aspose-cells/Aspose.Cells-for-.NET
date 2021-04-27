using Tools.Foundation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Foundation.Handler.Input
{
    public interface IInputDataHandler
    {
        //The methods which should be implemented in the descendant class
        InputFileDescription getFileDescription(FileDescription fileDesc);
        Stream getFile(FileDescription fileDesc);
        InputFileDescription saveFile(Stream st, InputFileDescription inputFileDesc);
        bool removeFile(InputFileDescription inputFileDesc);
    }
}
