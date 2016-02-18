// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AsposeVisualStudioPluginCells.Core
{
    public class AsposeComponents
    {
        public static Dictionary<String, AsposeComponent> list = new Dictionary<string, AsposeComponent>();
        public AsposeComponents()
        {
            list.Clear();
            
            AsposeComponent asposeCells = new AsposeComponent();
            asposeCells.set_downloadUrl("");
            asposeCells.set_downloadFileName("aspose.Cells.zip");
            asposeCells.set_name(Constants.ASPOSE_COMPONENT);
            asposeCells.set_remoteExamplesRepository("https://github.com/AamirWaseem/Aspose_Cells_NET.git");
            list.Add(Constants.ASPOSE_COMPONENT, asposeCells);
        }
    }
}
