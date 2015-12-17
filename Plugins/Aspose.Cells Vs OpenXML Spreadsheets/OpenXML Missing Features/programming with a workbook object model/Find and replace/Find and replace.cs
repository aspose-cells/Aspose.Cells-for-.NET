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

namespace Find_and_replace
{
    public partial class Form1 : Form
    {
        Workbook workbook;
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_SelectFile_Click(object sender, EventArgs e)
        {
            DialogResult result = FOD_OpenFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                LBL_SelectedFile.Text = FOD_OpenFile.FileName;
            }
        }

        private void BTN_Find_Click(object sender, EventArgs e)
        {
            if (TXBX_Find.Text != "")
            {
                 workbook = new Workbook(FOD_OpenFile.FileName);
                FindOptions Opts = new FindOptions();
                Opts.LookInType = LookInType.Values;
                Opts.LookAtType = LookAtType.Contains;
                string found = "";
                Cell cell = null;
                foreach (Worksheet sheet in workbook.Worksheets)
                {
                    found += Environment.NewLine + "Sheet: " + sheet.Name + ":";
                    do
                    {
                        cell = sheet.Cells.Find(TXBX_Find.Text, cell, Opts);
                        if (cell != null)
                            found += cell.Name + ",";
                    }
                    while (cell != null);
                }
                LBL_FindResults.Text = found;
            }
        }

        private void BTN_Replace_Click(object sender, EventArgs e)
        {
            if (TXBX_Find.Text != "" && TXBX_Replace.Text!="")
            {
                workbook = new Workbook(FOD_OpenFile.FileName);
                FindOptions Opts = new FindOptions();
                Opts.LookInType = LookInType.Values;
                Opts.LookAtType = LookAtType.Contains;
                string found = "";
                Cell cell = null;
                foreach (Worksheet sheet in workbook.Worksheets)
                {
                    do
                    {
                        cell = sheet.Cells.Find(TXBX_Find.Text, cell, Opts);
                        if (cell != null)
                        {
                            string celltext = cell.Value.ToString();
                            celltext = celltext.Replace(TXBX_Find.Text, TXBX_Replace.Text);
                            cell.PutValue(celltext);
                        }
                    }
                    while (cell != null);
                }
                LBL_FindResults.Text = "Replaced All Existing Values, Save the file now";
            }
        }

        private void BTN_SaveFile_Click(object sender, EventArgs e)
        {
            FSD_SaveFile.DefaultExt = ".xlsx";
            FSD_SaveFile.FileName="Updated find and replace";
            DialogResult result = FSD_SaveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                workbook.Save(FSD_SaveFile.FileName,SaveFormat.Xlsx);
            }
        }
    }
}
