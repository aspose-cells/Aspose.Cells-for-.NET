import os
import aspose.cells as cells
from aspose.pydrawing import Color
from aspose.cells.drawing import MsoLineDashStyle

def get_source_directory():
    return os.path.abspath(os.path.join(".", "..", "..", "..", "Data", "01_SourceDirectory"))

def get_output_directory():
    return os.path.abspath(os.path.join(".", "..", "..", "..", "Data", "02_OutputDirectory"))

def run_adding_text_box_control_in_chart():
    source_dir = get_source_directory()
    output_dir = get_output_directory()

    input_path = os.path.join(source_dir, "sampleAddingTextBoxControlInChart.xls")
    workbook = cells.Workbook(input_path)

    sheet = workbook.worksheets[0]
    chart = sheet.charts[0]

    # Add a new textbox to the chart (position and size expect float values)
    textbox = chart.shapes.add_text_box_in_chart(400.0, 1100.0, 350.0, 2550.0)
    textbox.text = "Sales By Region"

    # Font properties
    textbox.font.color = Color.maroon
    textbox.font.is_bold = True
    textbox.font.is_italic = True
    textbox.font.size = 14.0

    # Line format (weight expects integer)
    lineformat = textbox.line
    lineformat.weight = 2
    lineformat.dash_style = MsoLineDashStyle.SOLID

    output_path = os.path.join(output_dir, "outputAddingTextBoxControlInChart.xls")
    workbook.save(output_path)

if __name__ == "__main__":
    run_adding_text_box_control_in_chart()
