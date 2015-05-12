//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;
using System.Drawing;
using System;

namespace ConditionalFormattingExample
{
    public class Program
    {
        Worksheet _sheet = null;
        public static void Main()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            Program obj = new Program();
            obj.DoTest();
        }
        //The custom DoTest method
        public void DoTest()
        {
            // The path to the documents directory.
            string dataDir = Path.GetFullPath("../../../Data/");
            //Instantiate a workbook object
            Workbook book = new Workbook();
            //Create a worksheet object and get the first worksheet
            Worksheet sheet1 = book.Worksheets[0];
            //Set the first worksheet to _sheet object
              _sheet = sheet1;

            //Call different custom methods
            //These methods exhibits different conditional formatting types with their custom
            //formattings attributes for MS Excel 2007 .xlsx file format
            AddDefaultIconSet();
            AddIconSet2();
            AddIconSet3();
            AddIconSet4();
            AddIconSet5();
            AddIconSet6();
            AddIconSet7();
            AddIconSet8();
            AddIconSet9();
            AddIconSet10();
            AddIconSet11();
            AddIconSet12();
            AddIconSet13();
            AddIconSet14();
            AddIconSet15();
            AddIconSet16();
            AddIconSet17();
            AddIconSet18();
            AddDefaultColorScale();
            Add3ColorScale();
            Add2ColorScale();
            AddAboveAverage();
            AddAboveAverage2();
            AddAboveAverage3();
            AddTop10_1();
            AddTop10_2();
            AddTop10_3();
            AddTop10_4();
            AddDataBar1();
            AddDataBar2();
            AddContainsText();
            AddNotContainsText();
            AddContainsBlank();
            AddNotContainsBlank();
            AddBeginWith();
            AddEndWith();
            AddContainsError();
            AddNotContainsError();
            AddDuplicate();
            AddUnique();
            AddTimePeriod_1();
            AddTimePeriod_2();
            AddTimePeriod_3();
            AddTimePeriod_4();
            AddTimePeriod_5();
            AddTimePeriod_6();
            AddTimePeriod_7();
            AddTimePeriod_8();
            AddTimePeriod_9();
            AddTimePeriod_10();

            //AutoFit M Column in the worksheet
            _sheet.AutoFitColumn(12);
            //Specify the output file path
            string outfn = dataDir+ "Testoutput.xlsx";
            //Save the excel file
            book.Save(outfn, SaveFormat.Xlsx);
        }
        //This method implements the IconSet conditional formatting type with 3 Arrows Colored attribute.
        private void AddIconSet2()
        {
            FormatConditionCollection conds = GetFormatCondition("M1:O2", Color.AliceBlue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows3;
            Cell c = _sheet.Cells["M1"];
            c.PutValue("Arrows3");
        }
        //This method implements the IconSet conditional formatting type with 4 Arrows Colored attribute.
        private void AddIconSet3()
        {
            FormatConditionCollection conds = GetFormatCondition("M3:O4", Color.AntiqueWhite);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows4;
            Cell c = _sheet.Cells["M3"];
            c.PutValue("Arrows4");
        }
        //This method implements the IconSet conditional formatting type with 5 Arrows Colored attribute.
        private void AddIconSet4()
        {
            FormatConditionCollection conds = GetFormatCondition("M5:O6", Color.Aqua);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Arrows5;
            Cell c = _sheet.Cells["M5"];
            c.PutValue("Arrows5");
        }
        //This method implements the IconSet conditional formatting type with 3 Arrows Gray attribute.
        private void AddIconSet5()
        {
            FormatConditionCollection conds = GetFormatCondition("M7:O8", Color.Aquamarine);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.ArrowsGray3;
            Cell c = _sheet.Cells["M7"];
            c.PutValue("ArrowsGray3");
        }
        //This method implements the IconSet conditional formatting type with 4 Arrows Gray attribute.
        private void AddIconSet6()
        {
            FormatConditionCollection conds = GetFormatCondition("M9:O10", Color.Azure);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.ArrowsGray4;
            Cell c = _sheet.Cells["M9"];
            c.PutValue("ArrowsGray4");
        }
        //This method implements the IconSet conditional formatting type with 5 Arrows Gray attribute.
        private void AddIconSet7()
        {
            FormatConditionCollection conds = GetFormatCondition("M11:O12", Color.Beige);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.ArrowsGray5;
            Cell c = _sheet.Cells["M11"];
            c.PutValue("ArrowsGray5");
        }
        //This method implements the IconSet conditional formatting type with 3 Flags attribute.
        private void AddIconSet8()
        {
            FormatConditionCollection conds = GetFormatCondition("M13:O14", Color.Bisque);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Flags3;
            Cell c = _sheet.Cells["M13"];
            c.PutValue("Flags3");
        }
        //This method implements the IconSet conditional formatting type with 5 Quarters attribute.
        private void AddIconSet9()
        {
            FormatConditionCollection conds = GetFormatCondition("M15:O16", Color.BlanchedAlmond);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Quarters5;
            Cell c = _sheet.Cells["M15"];
            c.PutValue("Quarters5");
        }
        //This method implements the IconSet conditional formatting type with 4 Ratings attribute.
        private void AddIconSet10()
        {
            FormatConditionCollection conds = GetFormatCondition("M17:O18", Color.Blue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Rating4;
            Cell c = _sheet.Cells["M17"];
            c.PutValue("Rating4");
        }
        //This method implements the IconSet conditional formatting type with 5 Ratings attribute.
        private void AddIconSet11()
        {
            FormatConditionCollection conds = GetFormatCondition("M19:O20", Color.BlueViolet);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Rating5;
            Cell c = _sheet.Cells["M19"];
            c.PutValue("Rating5");
        }
        //This method implements the IconSet conditional formatting type with 4 Red To Black attribute.
        private void AddIconSet12()
        {
            FormatConditionCollection conds = GetFormatCondition("M21:O22", Color.Brown);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.RedToBlack4;
            Cell c = _sheet.Cells["M21"];
            c.PutValue("RedToBlack4");
        }
        //This method implements the IconSet conditional formatting type with 3 Signs attribute.
        private void AddIconSet13()
        {
            FormatConditionCollection conds = GetFormatCondition("M23:O24", Color.BurlyWood);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Signs3;
            Cell c = _sheet.Cells["M23"];
            c.PutValue("Signs3");
        }
        //This method implements the IconSet conditional formatting type with 3 Symbols attribute.
        private void AddIconSet14()
        {
            FormatConditionCollection conds = GetFormatCondition("M25:O26", Color.CadetBlue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Symbols3;
            Cell c = _sheet.Cells["M25"];
            c.PutValue("Symbols3");
        }
        //This method implements the IconSet conditional formatting type with another 3 Symbols attribute.
        private void AddIconSet15()
        {
            FormatConditionCollection conds = GetFormatCondition("M27:O28", Color.Chartreuse);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.Symbols32;
            Cell c = _sheet.Cells["M27"];
            c.PutValue("Symbols32");
        }
        //This method implements the IconSet conditional formatting type with 3 Traffic Lights attribute.
        private void AddIconSet16()
        {
            FormatConditionCollection conds = GetFormatCondition("M29:O30", Color.Chocolate);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.TrafficLights31;
            Cell c = _sheet.Cells["M29"];
            c.PutValue("TrafficLights31");
        }
        //This method implements the IconSet conditional formatting type with another 3 Traffic Lights attribute.
        private void AddIconSet17()
        {
            FormatConditionCollection conds = GetFormatCondition("M31:O32", Color.Coral);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.TrafficLights32;
            Cell c = _sheet.Cells["M31"];
            c.PutValue("TrafficLights32");
        }
        //This method implements the IconSet conditional formatting type with 4 Traffic Lights attribute.
        private void AddIconSet18()
        {
            FormatConditionCollection conds = GetFormatCondition("M33:O35", Color.CornflowerBlue);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
            FormatCondition cond = conds[idx];
            cond.IconSet.Type = IconSetType.TrafficLights4;
            Cell c = _sheet.Cells["M33"];
            c.PutValue("TrafficLights4");
        }
        //This method implements the TimePeriod conditional formatting type with Yesterday attribute.
        private void AddTimePeriod_10()
        {
            FormatConditionCollection conds = GetFormatCondition("I19:K20", Color.MediumSeaGreen);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Yesterday;
            Cell c = _sheet.Cells["I19"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/30"));
            c = _sheet.Cells["K20"];
            c.PutValue(DateTime.Parse("2008/08/03"));

            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I20"];
            c.PutValue("Yesterday");
        }
        //This method implements the TimePeriod conditional formatting type with Tomorrow attribute.
        private void AddTimePeriod_9()
        {
            FormatConditionCollection conds = GetFormatCondition("I17:K18", Color.MediumPurple);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Tomorrow;
            Cell c = _sheet.Cells["I17"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/08/01"));
            c = _sheet.Cells["K18"];
            c.PutValue(DateTime.Parse("2008/08/03"));
            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I18"];
            c.PutValue("Tomorrow");

        }
        //This method implements the TimePeriod conditional formatting type with ThisWeek attribute.
        private void AddTimePeriod_8()
        {
            FormatConditionCollection conds = GetFormatCondition("I15:K16", Color.MediumOrchid);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.ThisWeek;
            Cell c = _sheet.Cells["I15"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/28"));
            c = _sheet.Cells["K16"];
            c.PutValue(DateTime.Parse("2008/08/03"));
             style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I16"];
            c.PutValue("ThisWeek");
        }
        //This method implements the TimePeriod conditional formatting type with ThisMonth attribute.
        private void AddTimePeriod_7()
        {
            FormatConditionCollection conds = GetFormatCondition("I13:K14", Color.MediumBlue);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.ThisMonth;
            Cell c = _sheet.Cells["I13"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/5"));
            c = _sheet.Cells["K14"];
            c.PutValue(DateTime.Parse("2008/05/30"));
             style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I14"];
            c.PutValue("ThisMonth");
        }

        //This method implements the TimePeriod conditional formatting type with NextWeek attribute.
        private void AddTimePeriod_6()
        {
            FormatConditionCollection conds = GetFormatCondition("I11:K12", Color.MediumAquamarine);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.NextWeek;
            Cell c = _sheet.Cells["I11"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/08/5"));
            c = _sheet.Cells["K12"];
            c.PutValue(DateTime.Parse("2008/07/30"));
            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I12"];
            c.PutValue("NextWeek");
        }

        //This method implements the TimePeriod conditional formatting type with NextMonth attribute.
        private void AddTimePeriod_5()
        {
            FormatConditionCollection conds = GetFormatCondition("I9:K10", Color.Maroon);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.NextMonth;
            Cell c = _sheet.Cells["I9"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/08/25"));
            c = _sheet.Cells["K10"];
            c.PutValue(DateTime.Parse("2008/07/30"));
            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c = _sheet.Cells["I10"];
            c.PutValue("NextMonth");
        }
        //This method implements the TimePeriod conditional formatting type with LastWeek attribute.
        private void AddTimePeriod_4()
        {
            FormatConditionCollection conds = GetFormatCondition("I7:K8", Color.Linen);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.LastWeek;
            Cell c = _sheet.Cells["I7"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/25"));
            c = _sheet.Cells["K8"];
            c.PutValue(DateTime.Parse("2008/07/30"));
             style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I8"];
            c.PutValue("LastWeek");
        }
        //This method implements the TimePeriod conditional formatting type with LastMonth attribute.
        private void AddTimePeriod_3()
        {
            FormatConditionCollection conds = GetFormatCondition("I5:K6", Color.Linen);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.LastMonth;
            Cell c = _sheet.Cells["I5"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/06/26"));
            c = _sheet.Cells["K6"];
            c.PutValue(DateTime.Parse("2008/07/30"));
            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I6"];
            c.PutValue("LastMonth");
        }
        //This method implements the TimePeriod conditional formatting type with Last7Days attribute.
        private void AddTimePeriod_2()
        {
            FormatConditionCollection conds = GetFormatCondition("I3:K4", Color.LightSteelBlue);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Last7Days;
            Cell c = _sheet.Cells["I3"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Parse("2008/07/26"));
            c = _sheet.Cells["K4"];
            c.PutValue(DateTime.Parse("2008/08/30"));
            style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);

            c = _sheet.Cells["I4"];
            c.PutValue("Last7Days");
        }
        //This method implements the TimePeriod conditional formatting type with Today attribute.
        private void AddTimePeriod_1()
        {
            FormatConditionCollection conds = GetFormatCondition("I1:K2", Color.LightSlateGray);
            int idx = conds.AddCondition(FormatConditionType.TimePeriod);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.TimePeriod = TimePeriodType.Today;
            Cell c = _sheet.Cells["I1"];
            Style style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c.PutValue(DateTime.Today);
            c = _sheet.Cells["K2"];
            c.PutValue(DateTime.Parse("2008/07/30"));
             style = c.GetStyle();
            style.Number = 30;
            c.SetStyle(style);
            c = _sheet.Cells["I2"];
            c.PutValue("Today");
        }

        //This method implements the DuplicateValues conditional formatting type.
        private void AddDuplicate()
        {
            FormatConditionCollection conds = GetFormatCondition("E23:G24", Color.LightSlateGray);
            int idx = conds.AddCondition(FormatConditionType.DuplicateValues);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E23"];
            c.PutValue("bb");
            c = _sheet.Cells["G24"];
            c.PutValue("bb");
        }
        //This method implements the UniqueValues conditional formatting type.
        private void AddUnique()
        {
            FormatConditionCollection conds = GetFormatCondition("E21:G22", Color.LightSalmon);
            int idx = conds.AddCondition(FormatConditionType.UniqueValues);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E21"];
            c.PutValue("aa");
            c = _sheet.Cells["G22"];
            c.PutValue("aa");
        }

        //This method implements the NotContainsErrors conditional formatting type.
        private void AddNotContainsError()
        {
            FormatConditionCollection conds = GetFormatCondition("E19:G20", Color.LightSeaGreen);
            int idx = conds.AddCondition(FormatConditionType.NotContainsErrors);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E19"];
            c.PutValue("  ");
            c = _sheet.Cells["G20"];
            c.PutValue("  ");
        }
        //This method implements the ContainsErrors conditional formatting type.
        private void AddContainsError()
        {
            FormatConditionCollection conds = GetFormatCondition("E17:G18", Color.LightSkyBlue);
            int idx = conds.AddCondition(FormatConditionType.ContainsErrors);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E17"];
            c.PutValue("  ");
            c = _sheet.Cells["G18"];
            c.PutValue("  ");
        }
        //This method implements the BeginsWith conditional formatting type.
        private void AddBeginWith()
        {
            FormatConditionCollection conds = GetFormatCondition("E15:G16", Color.LightGoldenrodYellow);
            int idx = conds.AddCondition(FormatConditionType.BeginsWith);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.Text = "ab";
            Cell c = _sheet.Cells["E15"];
            c.PutValue("abc");
            c = _sheet.Cells["G16"];
            c.PutValue("babx");
        }
        //This method implements the EndsWith conditional formatting type.
        private void AddEndWith()
        {
            FormatConditionCollection conds = GetFormatCondition("E13:G14", Color.LightGray);
            int idx = conds.AddCondition(FormatConditionType.EndsWith);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.Text = "ab";
            Cell c = _sheet.Cells["E13"];
            c.PutValue("nnnab");
            c = _sheet.Cells["G14"];
            c.PutValue("mmmabc");
        }
        //This method implements the NotContainsBlank conditional formatting type.
        private void AddNotContainsBlank()
        {
            FormatConditionCollection conds = GetFormatCondition("E11:G12", Color.LightCoral);
            int idx = conds.AddCondition(FormatConditionType.NotContainsBlanks);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E11"];
            c.PutValue("abc");
            c = _sheet.Cells["G12"];
            c.PutValue("  ");
        }
        //This method implements the ContainsBlank conditional formatting type.
        private void AddContainsBlank()
        {
            FormatConditionCollection conds = GetFormatCondition("E9:G10", Color.LightBlue);
            int idx = conds.AddCondition(FormatConditionType.ContainsBlanks);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
            Cell c = _sheet.Cells["E9"];
            c.PutValue("  ");
            c = _sheet.Cells["G10"];
            c.PutValue("  ");
        }
        //This method implements the NotContainsText conditional formatting type.
        private void AddNotContainsText()
        {
            FormatConditionCollection conds = GetFormatCondition("E7:G8", Color.LightCoral);
            int idx = conds.AddCondition(FormatConditionType.NotContainsText);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.Text = "3";
        }
        //This method implements the ContainsText conditional formatting type.
        private void AddContainsText()
        {
            FormatConditionCollection conds = GetFormatCondition("E5:G6", Color.LightBlue);
            int idx = conds.AddCondition(FormatConditionType.ContainsText);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
            cond.Text = "1";
        }
        //This method implements the DataBars conditional formatting type with Percentile attribute.
        private void AddDataBar2()
        {
            FormatConditionCollection conds = GetFormatCondition("E3:G4", Color.LightGreen);
            int idx = conds.AddCondition(FormatConditionType.DataBar);
            FormatCondition cond = conds[idx];
            cond.DataBar.Color = Color.Orange;
            cond.DataBar.MinCfvo.Type = FormatConditionValueType.Percentile;
            cond.DataBar.MinCfvo.Value = 30.78;
            cond.DataBar.ShowValue = false;
        }
        //This method implements the DataBars conditional formatting type.
        private void AddDataBar1()
        {
            FormatConditionCollection conds = GetFormatCondition("E1:G2", Color.YellowGreen);
            int idx = conds.AddCondition(FormatConditionType.DataBar);
            FormatCondition cond = conds[idx];
        }

        //This method adds formatted conditions.
        private FormatConditionCollection GetFormatCondition(string cellAreaName, Color color)
        {
            //Adds an empty conditional formattings
            int index = _sheet.ConditionalFormattings.Add();
            //Get the formatted conditions
            FormatConditionCollection formatConditions = _sheet.ConditionalFormattings[index];
            //Get the cell area calling the custom GetCellAreaByName method
            CellArea area = GetCellAreaByName(cellAreaName);
            //Add the formatted conditions cell area.
            formatConditions.AddArea(area);
            //Call the custom FillCell method
            FillCell(cellAreaName, color);
            //Return the formatted conditions
            return formatConditions;
        }

        //This method specifies the cell shading color for the conditional formattings cellarea range.
        private void FillCell(string cellAreaName, Color color)
        {
            CellArea area = GetCellAreaByName(cellAreaName);
            int k = 0;
            for (int i = area.StartColumn; i <= area.EndColumn; i++)
            {
                for (int j = area.StartRow; j <= area.EndRow; j++)
                {
                    Cell c = _sheet.Cells[j, i];
                    if (!color.IsEmpty)
                    {
                        Style s = c.GetStyle();
                        s.ForegroundColor = color;
                        s.Pattern = BackgroundType.Solid;
                        c.SetStyle(s);
                    }
                    //Set some random values to the cells in the cellarea range
                    int value = j + i + k;
                    c.PutValue(value);
                    k++;
                }
            }

        }
        //This method specifies the CellArea range (start row, start col, end row, end col etc.)
        //for the conditional formatting
        internal static CellArea GetCellAreaByName(string s)
        {
            CellArea area = new CellArea();
            string[] strCellRange = s.Replace("$", "").Split(':');
            int column;
            CellsHelper.CellNameToIndex(strCellRange[0], out area.StartRow, out column);
            area.StartColumn = column;
            if (strCellRange.Length == 1)
            {
                area.EndRow = area.StartRow;
                area.EndColumn = area.StartColumn;
            }
            else
            {
                CellsHelper.CellNameToIndex(strCellRange[1], out area.EndRow, out column);
                area.EndColumn = column;
            }
            return area;
        }
        //This method implements the IconSet conditional formatting type.
        private void AddDefaultIconSet()
        {
            FormatConditionCollection conds = GetFormatCondition("A1:C2", Color.Yellow);
            int idx = conds.AddCondition(FormatConditionType.IconSet);
        }
        //This method implements the ColorScale conditional formatting type.
        private void AddDefaultColorScale()
        {
            FormatConditionCollection conds = GetFormatCondition("A5:C6", Color.Pink);
            int idx = conds.AddCondition(FormatConditionType.ColorScale);
            FormatCondition cond = conds[idx];
        }
        //This method implements the ColorScale conditional formatting type with some color scale attributes.
        private void Add3ColorScale()
        {
            FormatConditionCollection conds = GetFormatCondition("A7:C8", Color.Green);
            int idx = conds.AddCondition(FormatConditionType.ColorScale);
            FormatCondition cond = conds[idx];
            cond.ColorScale.MinCfvo.Type = FormatConditionValueType.Number;
            cond.ColorScale.MinCfvo.Value = 9;
            cond.ColorScale.MinColor = Color.Purple;
        }
        //This method implements the ColorScale conditional formatting type with some color scale attributes.
        private void Add2ColorScale()
        {
            FormatConditionCollection conds = GetFormatCondition("A9:C10", Color.White);
            int idx = conds.AddCondition(FormatConditionType.ColorScale);
            FormatCondition cond = conds[idx];
            //cond.ColorScale.MidCfvo = null;
            cond.ColorScale.MinColor = Color.Gold;
            cond.ColorScale.MaxColor = Color.SkyBlue;
        }
        //This method implements the AboveAverage conditional formatting type.
        private void AddAboveAverage()
        {
            FormatConditionCollection conds = GetFormatCondition("A11:C12", Color.Tomato);
            int idx = conds.AddCondition(FormatConditionType.AboveAverage);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
        }
        //This method implements an AboveAverage conditional formatting type with some custom attributes.
        private void AddAboveAverage2()
        {
            FormatConditionCollection conds = GetFormatCondition("A13:C14", Color.Empty);
            int idx = conds.AddCondition(FormatConditionType.AboveAverage);
            FormatCondition cond = conds[idx];
            cond.AboveAverage.IsAboveAverage = false;
            cond.AboveAverage.IsEqualAverage = true;
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
        }
        //This method implements an AboveAverage conditional formatting type with some custom attributes.
        private void AddAboveAverage3()
        {
            FormatConditionCollection conds = GetFormatCondition("A15:C16", Color.Empty);
            int idx = conds.AddCondition(FormatConditionType.AboveAverage);
            FormatCondition cond = conds[idx];
            cond.AboveAverage.IsAboveAverage = false;
            cond.AboveAverage.IsEqualAverage = true;
            cond.AboveAverage.StdDev = 3;
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;
        }
        //This method implements a simple Top10 conditional formatting type.
        private void AddTop10_1()
        {
            FormatConditionCollection conds = GetFormatCondition("A17:C20", Color.Gray);
            int idx = conds.AddCondition(FormatConditionType.Top10);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Yellow;
            cond.Style.Pattern = BackgroundType.Solid;
        }
        //This method implements another Top10 conditional formatting type.
        private void AddTop10_2()
        {
            FormatConditionCollection conds = GetFormatCondition("A21:C24", Color.Green);
            int idx = conds.AddCondition(FormatConditionType.Top10);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Pink;
            cond.Style.Pattern = BackgroundType.Solid;

            cond.Top10.IsBottom = true;
        }
        //This method implements another Top10 conditional formatting type with some custom attributes.
        private void AddTop10_3()
        {
            FormatConditionCollection conds = GetFormatCondition("A25:C28", Color.Orange);
            int idx = conds.AddCondition(FormatConditionType.Top10);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Blue;
            cond.Style.Pattern = BackgroundType.Solid;

            cond.Top10.IsPercent = true;
        }
        //This method implements another Top10 conditional formatting type with some custom attributes.
        private void AddTop10_4()
        {
            FormatConditionCollection conds = GetFormatCondition("A29:C32", Color.Gold);
            int idx = conds.AddCondition(FormatConditionType.Top10);
            FormatCondition cond = conds[idx];
            cond.Style.BackgroundColor = Color.Green;
            cond.Style.Pattern = BackgroundType.Solid;

            cond.Top10.Rank = 3;
        }

    }
}
