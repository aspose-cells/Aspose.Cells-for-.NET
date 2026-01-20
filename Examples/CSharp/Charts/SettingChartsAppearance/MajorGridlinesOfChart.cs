import os
import aspose.cells as cells
from aspose.pydrawing import Color
from aspose.cells.charts import ChartType
from aspose.cells.drawing import GradientStyleType


def get_output_directory():
    return os.path.abspath(
        os.path.join(".", "..", "..", "..", "Data", "02_OutputDirectory")
    )


def run_setting_chart_area():
    out_dir = get_output_directory()
    if not os.path.isdir(out_dir):
        os.makedirs(out_dir, exist_ok=True)

    workbook = cells.Workbook()
    worksheet = workbook.worksheets[0]

    # Populate sample data
    worksheet.cells.get("A1").put_value(50)
    worksheet.cells.get("A2").put_value(100)
    worksheet.cells.get("A3").put_value(150)
    worksheet.cells.get("B1").put_value(60)
    worksheet.cells.get("B2").put_value(32)
    worksheet.cells.get("B3").put_value(50)

    # Add a column chart
    chart_index = worksheet.charts.add(ChartType.COLUMN, 5, 0, 25, 10)
    chart = worksheet.charts[chart_index]

    # Set chart data source
    chart.n_series.add("A1:B3", True)

    # Set foreground colors
    chart.plot_area.area.foreground_color = Color.blue
    chart.chart_area.area.foreground_color = Color.yellow
    chart.n_series[0].area.foreground_color = Color.red
    chart.n_series[0].points[0].area.foreground_color = Color.cyan

    # Apply one‑color gradient to the second series area
    chart.n_series[1].area.fill_format.set_one_color_gradient(
        Color.lime,
        1.0,
        GradientStyleType.HORIZONTAL,
        1,
    )

    # Save the workbook
    output_path = os.path.join(out_dir, "outputSettingChartArea.xlsx")
    workbook.save(output_path)


if __name__ == "__main__":
    run_setting_chart_area()
