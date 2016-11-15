using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridDesktop.Examples.Articles
{
    public partial class CopyAndPasteRows : Form
    {
        public CopyAndPasteRows()
        {
            InitializeComponent();
        }

        private void CopyAndPasteRows_Load(object sender, EventArgs e)
        {
            // ExStart:1
            /*
             * Indicates whether to copy/paste based on clipboard, so that it can copy/paste with MS-EXCEL.
             * It will only copy/paste cell value and will not copy any other setting of the cell like format, border style and so on.
             * The default value is false. 
            */
            gridDesktop1.EnableClipboardCopyPaste = true;
            // ExEnd:1
        }
    }
}
