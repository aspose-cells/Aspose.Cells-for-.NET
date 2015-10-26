//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class CustomizingRibbonXML
    {
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            Workbook wb = new Workbook(dataDir+ "aspose-sample.xlsx");
            FileInfo fi = new FileInfo(dataDir+ "CustomUI.xml");
            StreamReader sr = fi.OpenText();
            wb.RibbonXml = sr.ReadToEnd();
            sr.Close();
            
            
        }
    }
}