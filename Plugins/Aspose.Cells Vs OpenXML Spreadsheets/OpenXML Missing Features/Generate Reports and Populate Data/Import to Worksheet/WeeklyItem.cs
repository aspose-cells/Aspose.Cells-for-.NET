// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Import_to_Worksheet
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
