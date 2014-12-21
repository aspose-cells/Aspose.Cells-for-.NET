using System;
using System.Collections.Generic;
using System.Text;

namespace GroupingData
{
    class OleDbCommand
    {
        private string p;
        private OleDbConnection con;

        public OleDbCommand(string p, OleDbConnection con)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.con = con;
        }
    }
}
