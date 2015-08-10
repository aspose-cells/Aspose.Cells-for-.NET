'////////////////////////////////////////////////////////////////////////
' Copyright 2001-2014 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Cells. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
'////////////////////////////////////////////////////////////////////////

Imports Microsoft.VisualBasic
Imports System.IO

Imports Aspose.Cells
Imports System.Drawing
Imports System

Namespace Aspose.Cells.Examples.Formatting
    Public Class ConditionalFormatting
        Private _sheet As Worksheet = Nothing
        Public Shared Sub Main()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            Dim obj As New ConditionalFormatting()
            obj.DoTest()
        End Sub
        'The custom DoTest method
        Public Sub DoTest()
            ' The path to the documents directory.
            Dim dataDir As String = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)
            'Instantiate a workbook object
            Dim book As New Workbook()
            'Create a worksheet object and get the first worksheet
            Dim sheet1 As Worksheet = book.Worksheets(0)
            'Set the first worksheet to _sheet object
            _sheet = sheet1

            'Call different custom methods
            'These methods exhibits different conditional formatting types with their custom
            'formattings attributes for MS Excel 2007 .xlsx file format
            AddDefaultIconSet()
            AddIconSet2()
            AddIconSet3()
            AddIconSet4()
            AddIconSet5()
            AddIconSet6()
            AddIconSet7()
            AddIconSet8()
            AddIconSet9()
            AddIconSet10()
            AddIconSet11()
            AddIconSet12()
            AddIconSet13()
            AddIconSet14()
            AddIconSet15()
            AddIconSet16()
            AddIconSet17()
            AddIconSet18()
            AddDefaultColorScale()
            Add3ColorScale()
            Add2ColorScale()
            AddAboveAverage()
            AddAboveAverage2()
            AddAboveAverage3()
            AddTop10_1()
            AddTop10_2()
            AddTop10_3()
            AddTop10_4()
            AddDataBar1()
            AddDataBar2()
            AddContainsText()
            AddNotContainsText()
            AddContainsBlank()
            AddNotContainsBlank()
            AddBeginWith()
            AddEndWith()
            AddContainsError()
            AddNotContainsError()
            AddDuplicate()
            AddUnique()
            AddTimePeriod_1()
            AddTimePeriod_2()
            AddTimePeriod_3()
            AddTimePeriod_4()
            AddTimePeriod_5()
            AddTimePeriod_6()
            AddTimePeriod_7()
            AddTimePeriod_8()
            AddTimePeriod_9()
            AddTimePeriod_10()

            'AutoFit M Column in the worksheet
            _sheet.AutoFitColumn(12)
            'Specify the output file path
            Dim outfn As String = dataDir & "Testoutput.xlsx"
            'Save the excel file
            book.Save(outfn, SaveFormat.Xlsx)
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Arrows Colored attribute.
        Private Sub AddIconSet2()
            Dim conds As FormatConditionCollection = GetFormatCondition("M1:O2", Color.AliceBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Arrows3
            Dim c As Cell = _sheet.Cells("M1")
            c.PutValue("Arrows3")
        End Sub
        'This method implements the IconSet conditional formatting type with 4 Arrows Colored attribute.
        Private Sub AddIconSet3()
            Dim conds As FormatConditionCollection = GetFormatCondition("M3:O4", Color.AntiqueWhite)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Arrows4
            Dim c As Cell = _sheet.Cells("M3")
            c.PutValue("Arrows4")
        End Sub
        'This method implements the IconSet conditional formatting type with 5 Arrows Colored attribute.
        Private Sub AddIconSet4()
            Dim conds As FormatConditionCollection = GetFormatCondition("M5:O6", Color.Aqua)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Arrows5
            Dim c As Cell = _sheet.Cells("M5")
            c.PutValue("Arrows5")
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Arrows Gray attribute.
        Private Sub AddIconSet5()
            Dim conds As FormatConditionCollection = GetFormatCondition("M7:O8", Color.Aquamarine)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.ArrowsGray3
            Dim c As Cell = _sheet.Cells("M7")
            c.PutValue("ArrowsGray3")
        End Sub
        'This method implements the IconSet conditional formatting type with 4 Arrows Gray attribute.
        Private Sub AddIconSet6()
            Dim conds As FormatConditionCollection = GetFormatCondition("M9:O10", Color.Azure)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.ArrowsGray4
            Dim c As Cell = _sheet.Cells("M9")
            c.PutValue("ArrowsGray4")
        End Sub
        'This method implements the IconSet conditional formatting type with 5 Arrows Gray attribute.
        Private Sub AddIconSet7()
            Dim conds As FormatConditionCollection = GetFormatCondition("M11:O12", Color.Beige)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.ArrowsGray5
            Dim c As Cell = _sheet.Cells("M11")
            c.PutValue("ArrowsGray5")
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Flags attribute.
        Private Sub AddIconSet8()
            Dim conds As FormatConditionCollection = GetFormatCondition("M13:O14", Color.Bisque)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Flags3
            Dim c As Cell = _sheet.Cells("M13")
            c.PutValue("Flags3")
        End Sub
        'This method implements the IconSet conditional formatting type with 5 Quarters attribute.
        Private Sub AddIconSet9()
            Dim conds As FormatConditionCollection = GetFormatCondition("M15:O16", Color.BlanchedAlmond)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Quarters5
            Dim c As Cell = _sheet.Cells("M15")
            c.PutValue("Quarters5")
        End Sub
        'This method implements the IconSet conditional formatting type with 4 Ratings attribute.
        Private Sub AddIconSet10()
            Dim conds As FormatConditionCollection = GetFormatCondition("M17:O18", Color.Blue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Rating4
            Dim c As Cell = _sheet.Cells("M17")
            c.PutValue("Rating4")
        End Sub
        'This method implements the IconSet conditional formatting type with 5 Ratings attribute.
        Private Sub AddIconSet11()
            Dim conds As FormatConditionCollection = GetFormatCondition("M19:O20", Color.BlueViolet)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Rating5
            Dim c As Cell = _sheet.Cells("M19")
            c.PutValue("Rating5")
        End Sub
        'This method implements the IconSet conditional formatting type with 4 Red To Black attribute.
        Private Sub AddIconSet12()
            Dim conds As FormatConditionCollection = GetFormatCondition("M21:O22", Color.Brown)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.RedToBlack4
            Dim c As Cell = _sheet.Cells("M21")
            c.PutValue("RedToBlack4")
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Signs attribute.
        Private Sub AddIconSet13()
            Dim conds As FormatConditionCollection = GetFormatCondition("M23:O24", Color.BurlyWood)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Signs3
            Dim c As Cell = _sheet.Cells("M23")
            c.PutValue("Signs3")
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Symbols attribute.
        Private Sub AddIconSet14()
            Dim conds As FormatConditionCollection = GetFormatCondition("M25:O26", Color.CadetBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Symbols3
            Dim c As Cell = _sheet.Cells("M25")
            c.PutValue("Symbols3")
        End Sub
        'This method implements the IconSet conditional formatting type with another 3 Symbols attribute.
        Private Sub AddIconSet15()
            Dim conds As FormatConditionCollection = GetFormatCondition("M27:O28", Color.Chartreuse)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.Symbols32
            Dim c As Cell = _sheet.Cells("M27")
            c.PutValue("Symbols32")
        End Sub
        'This method implements the IconSet conditional formatting type with 3 Traffic Lights attribute.
        Private Sub AddIconSet16()
            Dim conds As FormatConditionCollection = GetFormatCondition("M29:O30", Color.Chocolate)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.TrafficLights31
            Dim c As Cell = _sheet.Cells("M29")
            c.PutValue("TrafficLights31")
        End Sub
        'This method implements the IconSet conditional formatting type with another 3 Traffic Lights attribute.
        Private Sub AddIconSet17()
            Dim conds As FormatConditionCollection = GetFormatCondition("M31:O32", Color.Coral)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.TrafficLights32
            Dim c As Cell = _sheet.Cells("M31")
            c.PutValue("TrafficLights32")
        End Sub
        'This method implements the IconSet conditional formatting type with 4 Traffic Lights attribute.
        Private Sub AddIconSet18()
            Dim conds As FormatConditionCollection = GetFormatCondition("M33:O35", Color.CornflowerBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
            Dim cond As FormatCondition = conds(idx)
            cond.IconSet.Type = IconSetType.TrafficLights4
            Dim c As Cell = _sheet.Cells("M33")
            c.PutValue("TrafficLights4")
        End Sub
        'This method implements the TimePeriod conditional formatting type with Yesterday attribute.
        Private Sub AddTimePeriod_10()
            Dim conds As FormatConditionCollection = GetFormatCondition("I19:K20", Color.MediumSeaGreen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.Yesterday
            Dim c As Cell = _sheet.Cells("I19")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/07/30"))
            c = _sheet.Cells("K20")
            c.PutValue(DateTime.Parse("2008/08/03"))

            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I20")
            c.PutValue("Yesterday")
        End Sub
        'This method implements the TimePeriod conditional formatting type with Tomorrow attribute.
        Private Sub AddTimePeriod_9()
            Dim conds As FormatConditionCollection = GetFormatCondition("I17:K18", Color.MediumPurple)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.Tomorrow
            Dim c As Cell = _sheet.Cells("I17")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/08/01"))
            c = _sheet.Cells("K18")
            c.PutValue(DateTime.Parse("2008/08/03"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I18")
            c.PutValue("Tomorrow")

        End Sub
        'This method implements the TimePeriod conditional formatting type with ThisWeek attribute.
        Private Sub AddTimePeriod_8()
            Dim conds As FormatConditionCollection = GetFormatCondition("I15:K16", Color.MediumOrchid)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.ThisWeek
            Dim c As Cell = _sheet.Cells("I15")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/07/28"))
            c = _sheet.Cells("K16")
            c.PutValue(DateTime.Parse("2008/08/03"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I16")
            c.PutValue("ThisWeek")
        End Sub
        'This method implements the TimePeriod conditional formatting type with ThisMonth attribute.
        Private Sub AddTimePeriod_7()
            Dim conds As FormatConditionCollection = GetFormatCondition("I13:K14", Color.MediumBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.ThisMonth
            Dim c As Cell = _sheet.Cells("I13")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/07/5"))
            c = _sheet.Cells("K14")
            c.PutValue(DateTime.Parse("2008/05/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I14")
            c.PutValue("ThisMonth")
        End Sub

        'This method implements the TimePeriod conditional formatting type with NextWeek attribute.
        Private Sub AddTimePeriod_6()
            Dim conds As FormatConditionCollection = GetFormatCondition("I11:K12", Color.MediumAquamarine)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.NextWeek
            Dim c As Cell = _sheet.Cells("I11")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/08/5"))
            c = _sheet.Cells("K12")
            c.PutValue(DateTime.Parse("2008/07/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I12")
            c.PutValue("NextWeek")
        End Sub

        'This method implements the TimePeriod conditional formatting type with NextMonth attribute.
        Private Sub AddTimePeriod_5()
            Dim conds As FormatConditionCollection = GetFormatCondition("I9:K10", Color.Maroon)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.NextMonth
            Dim c As Cell = _sheet.Cells("I9")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/08/25"))
            c = _sheet.Cells("K10")
            c.PutValue(DateTime.Parse("2008/07/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c = _sheet.Cells("I10")
            c.PutValue("NextMonth")
        End Sub
        'This method implements the TimePeriod conditional formatting type with LastWeek attribute.
        Private Sub AddTimePeriod_4()
            Dim conds As FormatConditionCollection = GetFormatCondition("I7:K8", Color.Linen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.LastWeek
            Dim c As Cell = _sheet.Cells("I7")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/07/25"))
            c = _sheet.Cells("K8")
            c.PutValue(DateTime.Parse("2008/07/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I8")
            c.PutValue("LastWeek")
        End Sub
        'This method implements the TimePeriod conditional formatting type with LastMonth attribute.
        Private Sub AddTimePeriod_3()
            Dim conds As FormatConditionCollection = GetFormatCondition("I5:K6", Color.Linen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.LastMonth
            Dim c As Cell = _sheet.Cells("I5")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/06/26"))
            c = _sheet.Cells("K6")
            c.PutValue(DateTime.Parse("2008/07/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I6")
            c.PutValue("LastMonth")
        End Sub
        'This method implements the TimePeriod conditional formatting type with Last7Days attribute.
        Private Sub AddTimePeriod_2()
            Dim conds As FormatConditionCollection = GetFormatCondition("I3:K4", Color.LightSteelBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.Last7Days
            Dim c As Cell = _sheet.Cells("I3")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Parse("2008/07/26"))
            c = _sheet.Cells("K4")
            c.PutValue(DateTime.Parse("2008/08/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)

            c = _sheet.Cells("I4")
            c.PutValue("Last7Days")
        End Sub
        'This method implements the TimePeriod conditional formatting type with Today attribute.
        Private Sub AddTimePeriod_1()
            Dim conds As FormatConditionCollection = GetFormatCondition("I1:K2", Color.LightSlateGray)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.TimePeriod)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.TimePeriod = TimePeriodType.Today
            Dim c As Cell = _sheet.Cells("I1")
            Dim style As Style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c.PutValue(DateTime.Today)
            c = _sheet.Cells("K2")
            c.PutValue(DateTime.Parse("2008/07/30"))
            style = c.GetStyle()
            style.Number = 30
            c.SetStyle(style)
            c = _sheet.Cells("I2")
            c.PutValue("Today")
        End Sub

        'This method implements the DuplicateValues conditional formatting type.
        Private Sub AddDuplicate()
            Dim conds As FormatConditionCollection = GetFormatCondition("E23:G24", Color.LightSlateGray)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.DuplicateValues)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E23")
            c.PutValue("bb")
            c = _sheet.Cells("G24")
            c.PutValue("bb")
        End Sub
        'This method implements the UniqueValues conditional formatting type.
        Private Sub AddUnique()
            Dim conds As FormatConditionCollection = GetFormatCondition("E21:G22", Color.LightSalmon)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.UniqueValues)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E21")
            c.PutValue("aa")
            c = _sheet.Cells("G22")
            c.PutValue("aa")
        End Sub

        'This method implements the NotContainsErrors conditional formatting type.
        Private Sub AddNotContainsError()
            Dim conds As FormatConditionCollection = GetFormatCondition("E19:G20", Color.LightSeaGreen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.NotContainsErrors)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E19")
            c.PutValue("  ")
            c = _sheet.Cells("G20")
            c.PutValue("  ")
        End Sub
        'This method implements the ContainsErrors conditional formatting type.
        Private Sub AddContainsError()
            Dim conds As FormatConditionCollection = GetFormatCondition("E17:G18", Color.LightSkyBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ContainsErrors)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E17")
            c.PutValue("  ")
            c = _sheet.Cells("G18")
            c.PutValue("  ")
        End Sub
        'This method implements the BeginsWith conditional formatting type.
        Private Sub AddBeginWith()
            Dim conds As FormatConditionCollection = GetFormatCondition("E15:G16", Color.LightGoldenrodYellow)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.BeginsWith)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.Text = "ab"
            Dim c As Cell = _sheet.Cells("E15")
            c.PutValue("abc")
            c = _sheet.Cells("G16")
            c.PutValue("babx")
        End Sub
        'This method implements the EndsWith conditional formatting type.
        Private Sub AddEndWith()
            Dim conds As FormatConditionCollection = GetFormatCondition("E13:G14", Color.LightGray)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.EndsWith)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
            cond.Text = "ab"
            Dim c As Cell = _sheet.Cells("E13")
            c.PutValue("nnnab")
            c = _sheet.Cells("G14")
            c.PutValue("mmmabc")
        End Sub
        'This method implements the NotContainsBlank conditional formatting type.
        Private Sub AddNotContainsBlank()
            Dim conds As FormatConditionCollection = GetFormatCondition("E11:G12", Color.LightCoral)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.NotContainsBlanks)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E11")
            c.PutValue("abc")
            c = _sheet.Cells("G12")
            c.PutValue("  ")
        End Sub
        'This method implements the ContainsBlank conditional formatting type.
        Private Sub AddContainsBlank()
            Dim conds As FormatConditionCollection = GetFormatCondition("E9:G10", Color.LightBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ContainsBlanks)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
            Dim c As Cell = _sheet.Cells("E9")
            c.PutValue("  ")
            c = _sheet.Cells("G10")
            c.PutValue("  ")
        End Sub
        'This method implements the NotContainsText conditional formatting type.
        Private Sub AddNotContainsText()
            Dim conds As FormatConditionCollection = GetFormatCondition("E7:G8", Color.LightCoral)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.NotContainsText)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
            cond.Text = "3"
        End Sub
        'This method implements the ContainsText conditional formatting type.
        Private Sub AddContainsText()
            Dim conds As FormatConditionCollection = GetFormatCondition("E5:G6", Color.LightBlue)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ContainsText)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
            cond.Text = "1"
        End Sub
        'This method implements the DataBars conditional formatting type with Percentile attribute.
        Private Sub AddDataBar2()
            Dim conds As FormatConditionCollection = GetFormatCondition("E3:G4", Color.LightGreen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.DataBar)
            Dim cond As FormatCondition = conds(idx)
            cond.DataBar.Color = Color.Orange
            cond.DataBar.MinCfvo.Type = FormatConditionValueType.Percentile
            cond.DataBar.MinCfvo.Value = 30.78
            cond.DataBar.ShowValue = False
        End Sub
        'This method implements the DataBars conditional formatting type.
        Private Sub AddDataBar1()
            Dim conds As FormatConditionCollection = GetFormatCondition("E1:G2", Color.YellowGreen)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.DataBar)
            Dim cond As FormatCondition = conds(idx)
        End Sub

        'This method adds formatted conditions.
        Private Function GetFormatCondition(ByVal cellAreaName As String, ByVal color As Color) As FormatConditionCollection
            'Adds an empty conditional formattings
            Dim index As Integer = _sheet.ConditionalFormattings.Add()
            'Get the formatted conditions
            Dim formatConditions As FormatConditionCollection = _sheet.ConditionalFormattings(index)
            'Get the cell area calling the custom GetCellAreaByName method
            Dim area As CellArea = GetCellAreaByName(cellAreaName)
            'Add the formatted conditions cell area.
            formatConditions.AddArea(area)
            'Call the custom FillCell method
            FillCell(cellAreaName, color)
            'Return the formatted conditions
            Return formatConditions
        End Function

        'This method specifies the cell shading color for the conditional formattings cellarea range.
        Private Sub FillCell(ByVal cellAreaName As String, ByVal color As Color)
            Dim area As CellArea = GetCellAreaByName(cellAreaName)
            Dim k As Integer = 0
            For i As Integer = area.StartColumn To area.EndColumn
                For j As Integer = area.StartRow To area.EndRow
                    Dim c As Cell = _sheet.Cells(j, i)
                    If (Not color.IsEmpty) Then
                        Dim s As Style = c.GetStyle()
                        s.ForegroundColor = color
                        s.Pattern = BackgroundType.Solid
                        c.SetStyle(s)
                    End If
                    'Set some random values to the cells in the cellarea range
                    Dim value As Integer = j + i + k
                    c.PutValue(value)
                    k += 1
                Next j
            Next i

        End Sub
        'This method specifies the CellArea range (start row, start col, end row, end col etc.)
        'for the conditional formatting
        Friend Shared Function GetCellAreaByName(ByVal s As String) As CellArea
            Dim area As New CellArea()
            Dim strCellRange() As String = s.Replace("$", "").Split(":"c)
            Dim column As Integer
            CellsHelper.CellNameToIndex(strCellRange(0), area.StartRow, column)
            area.StartColumn = column
            If strCellRange.Length = 1 Then
                area.EndRow = area.StartRow
                area.EndColumn = area.StartColumn
            Else
                CellsHelper.CellNameToIndex(strCellRange(1), area.EndRow, column)
                area.EndColumn = column
            End If
            Return area
        End Function
        'This method implements the IconSet conditional formatting type.
        Private Sub AddDefaultIconSet()
            Dim conds As FormatConditionCollection = GetFormatCondition("A1:C2", Color.Yellow)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.IconSet)
        End Sub
        'This method implements the ColorScale conditional formatting type.
        Private Sub AddDefaultColorScale()
            Dim conds As FormatConditionCollection = GetFormatCondition("A5:C6", Color.Pink)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ColorScale)
            Dim cond As FormatCondition = conds(idx)
        End Sub
        'This method implements the ColorScale conditional formatting type with some color scale attributes.
        Private Sub Add3ColorScale()
            Dim conds As FormatConditionCollection = GetFormatCondition("A7:C8", Color.Green)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ColorScale)
            Dim cond As FormatCondition = conds(idx)
            cond.ColorScale.MinCfvo.Type = FormatConditionValueType.Number
            cond.ColorScale.MinCfvo.Value = 9
            cond.ColorScale.MinColor = Color.Purple
        End Sub
        'This method implements the ColorScale conditional formatting type with some color scale attributes.
        Private Sub Add2ColorScale()
            Dim conds As FormatConditionCollection = GetFormatCondition("A9:C10", Color.White)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.ColorScale)
            Dim cond As FormatCondition = conds(idx)
            'cond.ColorScale.MidCfvo = null;
            cond.ColorScale.MinColor = Color.Gold
            cond.ColorScale.MaxColor = Color.SkyBlue
        End Sub
        'This method implements the AboveAverage conditional formatting type.
        Private Sub AddAboveAverage()
            Dim conds As FormatConditionCollection = GetFormatCondition("A11:C12", Color.Tomato)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.AboveAverage)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
        End Sub
        'This method implements an AboveAverage conditional formatting type with some custom attributes.
        Private Sub AddAboveAverage2()
            Dim conds As FormatConditionCollection = GetFormatCondition("A13:C14", Color.Empty)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.AboveAverage)
            Dim cond As FormatCondition = conds(idx)
            cond.AboveAverage.IsAboveAverage = False
            cond.AboveAverage.IsEqualAverage = True
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
        End Sub
        'This method implements an AboveAverage conditional formatting type with some custom attributes.
        Private Sub AddAboveAverage3()
            Dim conds As FormatConditionCollection = GetFormatCondition("A15:C16", Color.Empty)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.AboveAverage)
            Dim cond As FormatCondition = conds(idx)
            cond.AboveAverage.IsAboveAverage = False
            cond.AboveAverage.IsEqualAverage = True
            cond.AboveAverage.StdDev = 3
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid
        End Sub
        'This method implements a simple Top10 conditional formatting type.
        Private Sub AddTop10_1()
            Dim conds As FormatConditionCollection = GetFormatCondition("A17:C20", Color.Gray)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.Top10)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Yellow
            cond.Style.Pattern = BackgroundType.Solid
        End Sub
        'This method implements another Top10 conditional formatting type.
        Private Sub AddTop10_2()
            Dim conds As FormatConditionCollection = GetFormatCondition("A21:C24", Color.Green)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.Top10)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Pink
            cond.Style.Pattern = BackgroundType.Solid

            cond.Top10.IsBottom = True
        End Sub
        'This method implements another Top10 conditional formatting type with some custom attributes.
        Private Sub AddTop10_3()
            Dim conds As FormatConditionCollection = GetFormatCondition("A25:C28", Color.Orange)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.Top10)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Blue
            cond.Style.Pattern = BackgroundType.Solid

            cond.Top10.IsPercent = True
        End Sub
        'This method implements another Top10 conditional formatting type with some custom attributes.
        Private Sub AddTop10_4()
            Dim conds As FormatConditionCollection = GetFormatCondition("A29:C32", Color.Gold)
            Dim idx As Integer = conds.AddCondition(FormatConditionType.Top10)
            Dim cond As FormatCondition = conds(idx)
            cond.Style.BackgroundColor = Color.Green
            cond.Style.Pattern = BackgroundType.Solid

            cond.Top10.Rank = 3
        End Sub

    End Class
End Namespace
