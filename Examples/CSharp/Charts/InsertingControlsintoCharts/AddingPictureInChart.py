import os
import clr
clr.AddReference("System")
from System.IO import File
import aspose.cells as cells
from aspose.cells.drawing import MsoLineDashStyle

def get_source_directory():
    return os.path.abspath(os.path.join(".", "..", "..", "..", "Data", "01_SourceDirectory"))

def get_output_directory():
    return os.path.abspath(os.path.join(".", "..", "..", "..", "Data", "02_OutputDirectory"))

def run_adding_picture_in_chart():
    source_dir = get_source_directory()
    output_dir = get_output_directory()

    workbook_path = os.path.join(source_dir, "sampleAddingPictureInChart.xls")
    workbook = cells.Workbook(workbook_path)

    image_path = os.path.join(source_dir, "sampleAddingPictureInChart.png")
    stream = File.OpenRead(image_path)

    sheet = workbook.worksheets[0]
    chart = sheet.charts[0]

    picture = chart.shapes.add_picture_in_chart(50, 50, stream, 200, 200)

    line_format = picture.line
    line_format.dash_style = MsoLineDashStyle.SOLID
    line_format.weight = 4

    stream.Close()

    output_path = os.path.join(output_dir, "outputAddingPictureInChart.xls")
    workbook.save(output_path)

    print("AddingPictureInChart executed successfully.")

if __name__ == "__main__":
    run_adding_picture_in_chart()
