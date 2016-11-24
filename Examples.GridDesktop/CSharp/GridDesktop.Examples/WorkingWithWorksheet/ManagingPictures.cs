using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithWorksheet
{
    public partial class ManagingPictures : Form
    {
        public ManagingPictures()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ExStart:AddingPictures
                // The path to the documents directory.
                string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

                // Accessing first worksheet of the Grid
                Worksheet sheet = gridDesktop1.GetActiveWorksheet();

                // Adding picture to "b2" cell from file
                sheet.Pictures.Add("b2", dataDir + "AsposeGrid.jpg");

                // Creating a stream contain picture
                FileStream fs = new FileStream(dataDir + "AsposeLogo.jpg", FileMode.Open);

                try
                {
                    // Adding picture to "b3" cell from stream
                    sheet.Pictures.Add(2, 1, fs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Closing stream
                    fs.Close();
                }
                // ExEnd:AddingPictures
                MessageBox.Show("Pictures have been added.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:AccessAndModifyPicture
            // The path to the documents directory.
            string dataDir = Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Accessing a picture added to "c3" cell (specified using its row & column number)
            Aspose.Cells.GridDesktop.Data.GridPicture picture1 = sheet.Pictures[1];

            // Modifying the image
            picture1.Image = Image.FromFile(dataDir + "Aspose.Grid.jpg");
            // ExEnd:AccessAndModifyPicture
            MessageBox.Show("Picture has been modified.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // ExStart:RemovePicture
            // Accessing first worksheet of the Grid
            Worksheet sheet = gridDesktop1.Worksheets[0];

            // Removing picture from "c3" cell
            sheet.Pictures.Remove(2, 2);
            // ExEnd:RemovePicture
            MessageBox.Show("Picture has been removed.");
        }

        private void gridDesktop1_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
