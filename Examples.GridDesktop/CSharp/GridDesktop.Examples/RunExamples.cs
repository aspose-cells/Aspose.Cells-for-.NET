using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GridDesktop.Examples.WorkingWithGrid;
using GridDesktop.Examples.Articles;
using GridDesktop.Examples.WorkingWithWorksheet;

namespace GridDesktop.Examples
{
    public partial class RunExamples : Form
    {
        public RunExamples()
        {
            InitializeComponent();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != this)
                {
                    frm.Close();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyAndPasteRowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyAndPasteRows frmCopyPasteRows = new CopyAndPasteRows();
            frmCopyPasteRows.MdiParent = this;
            frmCopyPasteRows.Show();
        }

        private void dataBindingFeaturesInWorksheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBindingFeature frmDataBindingFeatures = new DataBindingFeature();
            frmDataBindingFeatures.MdiParent = this;
            frmDataBindingFeatures.Show();
        }

        private void managingContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagingContextMenu frmManagingContextMenu = new ManagingContextMenu();
            frmManagingContextMenu.MdiParent = this;
            frmManagingContextMenu.Show();
        }

        private void openingExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpeningExcelFile frmOpeningExcelFile = new OpeningExcelFile();
            frmOpeningExcelFile.MdiParent = this;
            frmOpeningExcelFile.Show();
        }

        private void savingExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingExcelFile frmSavingExcelFile = new SavingExcelFile();
            frmSavingExcelFile.MdiParent = this;
            frmSavingExcelFile.Show();
        }

        private void gridDesktopEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridDesktopEvents frmGridDesktopEvents = new GridDesktopEvents();
            frmGridDesktopEvents.MdiParent = this;
            frmGridDesktopEvents.Show();
        }

        private void accessingWorksheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccessingWorksheets frmAccessingWorksheets = new AccessingWorksheets();
            frmAccessingWorksheets.MdiParent = this;
            frmAccessingWorksheets.Show();
        }

        private void addORInsertWorksheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInsertWorksheet frmAddInsertWorksheet = new AddInsertWorksheet();
            frmAddInsertWorksheet.MdiParent = this;
            frmAddInsertWorksheet.Show();
        }

        private void removeAWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveWorksheet frmRemoveWorksheet = new RemoveWorksheet();
            frmRemoveWorksheet.MdiParent = this;
            frmRemoveWorksheet.Show();
        }

        private void renameAWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameWorksheet frmRenameWorksheet = new RenameWorksheet();
            frmRenameWorksheet.MdiParent = this;
            frmRenameWorksheet.Show();
        }

        private void importDataFromDataTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportDataFromDataTable frmImportData = new ImportDataFromDataTable();
            frmImportData.MdiParent = this;
            frmImportData.Show();
        }
    }
}