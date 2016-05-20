// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    class WeeklyItem
    {
        public int AtYarnStage;
        public int InWIPStage;
        public int Payment;
        public int Shipment;
        public int Shipment2;
        private DateTime dateTime;

        public WeeklyItem(DateTime dateTime)
        {
            // TODO: Complete member initialization
            this.dateTime = dateTime;

        }

        public WeeklyItem()
        {
        }
    }
}
