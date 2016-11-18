using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.Cells.GridDesktop;

namespace GridDesktop.Examples.WorkingWithCells
{
    public partial class UndoRedoFeature : Form
    {
        public UndoRedoFeature()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ExStart:Undo
            // Enable the Undo operation
            gridDesktop1.EnableUndo = true;

            // Create the UndoManager object
            UndoManager um = gridDesktop1.UndoManager;

            // Perform Undo operation
            um.Undo();
            // ExEnd:Undo
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ExStart:Redo
            // Create the UndoManager object
            UndoManager um = gridDesktop1.UndoManager;

            // Perform Redo operation
            um.Redo();
            // ExEnd:Redo
        }
    }
}
