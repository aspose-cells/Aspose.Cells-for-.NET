import os
import aspose.cells as cells
from aspose.pydrawing import Color
from aspose.cells.drawing import GradientStyleType, TextureType
from aspose.cells.charts import (
    ChartType,
    LabelPositionType,
    LegendPositionType,
    FormattingType,
    PlotArea
)
from aspose.cells import Workbook, SheetType
from aspose.cells.charts import PlotArea

def get_output_directory():
    return os.path.abspath(
        os.path.join(".", "..", "..", "..", "Data", "02_OutputDirectory")
    )


def run_how_to_create_pie_chart():
    output_dir = get_output_directory()

    # Create a new workbook.
    workbook = Workbook()

    # ----- Data worksheet -----
    data_sheet = workbook.worksheets[0]
    data_sheet.name = "Data"
    data_cells = data_sheet.cells

    data_cells.get("A1").put_value("Region")
    data_cells.get("A2").put_value("France")
    data_cells.get("A3").put_value("Germany")
    data_cells.get("A4").put_value("England")
    data_cells.get("A5").put_value("Sweden")
    data_cells.get("A6").put_value("Italy")
    data_cells.get("A7").put_value("Spain")
    data_cells.get("A8").put_value("Portugal")
    data_cells.get("B1").put_value("Sale")
    data_cells.get("B2").put_value(70000)
    data_cells.get("B3").put_value(55000)
    data_cells.get("B4").put_value(30000)
    data_cells.get("B5").put_value(40000)
    data_cells.get("B6").put_value(35000)
    data_cells.get("B7").put_value(32000)
    data_cells.get("B8").put_value(10000)

    # ----- Chart worksheet -----
    chart_sheet_index = workbook.worksheets.add(SheetType.CHART)
    chart_sheet = workbook.worksheets[chart_sheet_index]
    chart_sheet.name = "Chart"

    # Create a pie chart.
    chartIdx = chart_sheet.charts.add(ChartType.PIE, 5, 0, 25, 10)
    chart = chart_sheet.charts[chartIdx]

    # Plot area formatting.
    chart.plot_area.area.foreground_color = Color.coral
    chart.plot_area.area.fill_format.set_two_color_gradient(
        Color.yellow, Color.white, GradientStyleType.VERTICAL, 2
    )
    chart.plot_area.border.is_visible = False

    # Chart title.
    chart.title.text = "Sales By Region"
    chart.title.font.color = Color.blue
    chart.title.font.is_bold = True
    chart.title.font.size = 12

    # NSeries.
    chart.n_series.add("Data!B2:B8", True)
    chart.n_series.category_data = "Data!A2:A8"
    chart.n_series.is_color_varied = True

    # Data labels (single series).
    series = chart.n_series[0]
    data_labels = series.data_labels
    data_labels.position = LabelPositionType.INSIDE_BASE
    data_labels.show_category_name = True
    data_labels.show_value = True
    data_labels.show_percentage = False
    data_labels.show_legend_key = False

    # Chart area.
    chart_area = chart.chart_area
    chart_area.area.formatting = FormattingType.CUSTOM
    chart_area.area.fill_format.texture = TextureType.BLUE_TISSUE_PAPER

    # Legend.
    legend = chart.legend
    legend.position = LegendPositionType.LEFT
    legend.height = 100
    legend.width = 130
    legend.y = 1500
    legend.font.is_bold = True
    legend.border.color = Color.blue
    legend.area.formatting = FormattingType.CUSTOM
    legend.area.fill_format.texture = TextureType.BOUQUET

    # Save the workbook.
    output_path = os.path.join(output_dir, "outputHowToCreatePieChart.xlsx")
    workbook.save(output_path)


if __name__ == "__main__":
    run_how_to_create_pie_chart()
