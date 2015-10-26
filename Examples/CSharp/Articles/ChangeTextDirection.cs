//////////////////////////////////////////////////////////////////////////
// Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
//
// This file is part of Aspose.Cells. The source code in this file
// is only intended as a supplement to the documentation, and is provided
// "as is", without warranty of any kind, either expressed or implied.
//////////////////////////////////////////////////////////////////////////
using System.IO;

using Aspose.Cells;

namespace Aspose.Cells.Examples.Articles
{
    public class ChangeTextDirection
    {
        public static void Main(string[] args)
        {
            // The path to the documents directory.
            string dataDir = Aspose.Cells.Examples.Utils.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            // Create directory if it is not already present.
            bool IsExists = System.IO.Directory.Exists(dataDir);
            if (!IsExists)
                System.IO.Directory.CreateDirectory(dataDir);

            //Instantiate a new Workbook
            var wb = new Workbook();
            //Get the first worksheet
            var sheet = wb.Worksheets[0];

            //Add a comment to A1 cell
            var comment = sheet.Comments[sheet.Comments.Add("A1")];
            //Set its vertical alignment setting            
            comment.CommentShape.TextVerticalAlignment = TextAlignmentType.Center;
            //Set its horizontal alignment setting
            comment.CommentShape.TextHorizontalAlignment = TextAlignmentType.Right;
            //Set the Text Direction - Right-to-Left
            comment.CommentShape.TextDirection = TextDirectionType.RightToLeft;
            //Set the Comment note
            comment.Note = "This is my Comment Text. This is test";

            //Save the Excel file
            wb.Save(dataDir+ "OutCommentShape.xlsx");

            
            
        }
    }
}