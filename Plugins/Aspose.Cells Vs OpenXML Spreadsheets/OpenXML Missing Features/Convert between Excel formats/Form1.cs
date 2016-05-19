// Copyright (c) Aspose 2002-2014. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Cells;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Cells for .NET API reference when the project is build. Please check https://docs.nuget.org/consume/nuget-faq for more information. If you do not wish to use NuGet, you can manually download Aspose.Cells for .NET API from http://www.aspose.com/downloads, install it and then add its reference to this project. For any issues, questions or suggestions please feel free to contact us using http://www.aspose.com/community/forums/default.aspx
*/

namespace Aspose.Plugins.AsposeVSOpenXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_FileBrowse_Click(object sender, EventArgs e)
        {
          DialogResult result=  openFileDialog1.ShowDialog();
          if (result == DialogResult.OK)
          {
              string File = openFileDialog1.FileName;

              LBL_FileName.Text = File;

          }
        }

        private void BTN_Convert_Click(object sender, EventArgs e)
        {
            if (TXBX_OutputFileName.Text != "")
            {
                try
                {
                    saveFileDialog1.DefaultExt = "."+CB_Formats.SelectedItem.ToString().ToLower();
                    saveFileDialog1.FileName = TXBX_OutputFileName.Text;
                   DialogResult result= saveFileDialog1.ShowDialog();
                   if (result == DialogResult.OK)
                   {
                       Workbook workbook = new Workbook(openFileDialog1.FileName);
                       switch (CB_Formats.SelectedItem.ToString())
                       {
                           case "CSV":
                               workbook.Save(saveFileDialog1.FileName, SaveFormat.CSV);
                               break;
                           case "PDF":
                               workbook.Save(saveFileDialog1.FileName, SaveFormat.Pdf);
                               break;
                           case "MHTML":
                               
                           //Specify the HTML Saving Options
                               HtmlSaveOptions sv = new HtmlSaveOptions(SaveFormat.MHtml);
                               workbook.Save(saveFileDialog1.FileName, sv);
                               break;
                           default:
                               break;
                       }
                   }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
