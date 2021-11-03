<%@ OutputCache Location="None" %>

<%@ Page Language="c#" AutoEventWireup="false"
    MasterPageFile="~/Site.Master"
    Title="Aspose.Cells.GridWeb" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <link href="js/bootstrap/bootstrap-vertical-tabs/bootstrap.vertical-tabs.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="componentDescriptionTxt">
        <p><strong>Welcome to the Aspose.Cells.GridWeb Featured Examples!</strong></p>
    </div>
    <div class="col-xs-3">
        <ul class="nav nav-tabs tabs-left">
            <li class="active"><a href="#articles" data-toggle="tab">Articles</a></li>
            <li><a href="#basics" data-toggle="tab">GridWeb Basics</a></li>
            <li><a href="#WorkingWithGridWebClientSideScript" data-toggle="tab">Working with GridWeb Client Side Script</a></li>
            <li><a href="#worksheets" data-toggle="tab">Worksheets</a></li>
            <li><a href="#rowscolumns" data-toggle="tab">Rows and Columns</a></li>
            <li><a href="#cells" data-toggle="tab">Cells</a></li>
            <li><a href="#miscellaneous" data-toggle="tab">Miscellaneous</a></li>
        </ul>
    </div>
    <div class="col-xs-9">
        <div class="tab-content">
            <div class="tab-pane active" id="articles">
                <ul class="list-group">
                    <li class="list-group-item" title="Add/Remove Comments From Client Side">
                        <p class="productTitle">
                            <a href="Worksheets/AddRemoveCommentsFromClientSide.aspx">Add/Remove Comments From Client Side</a>
                        </p>
                        <p>
                            Add/Remove Comments From Client Side
                        </p>
                    </li>
                    <li class="list-group-item" title="Add/Remove Hyperlinks From Client Side">
                        <p class="productTitle">
                            <a href="Worksheets/AddRemoveHyperlinkFromClientSide.aspx">Add/Remove Hyperlinks From Client Side</a>
                        </p>
                        <p>
                            Add/Remove Hyperlinks From Client Side
                        </p>
                    </li>
                    <li class="list-group-item" title="Update Font Settings From Client Side">
                        <p class="productTitle">
                            <a href="Worksheets/UpdateFontFromClientSide.aspx">Update Font Settings From Client Side</a>
                        </p>
                        <p>
                            Update Font Settings From Client Side
                        </p>
                    </li>
                    <li class="list-group-item" title="Add Custom Server-Side Function Validation">
                        <p class="productTitle">
                            <a href="Cells/AddCustomServerSideFunctionValidation.aspx">Add Custom Server-Side Function Validation</a>
                        </p>
                        <p>
                            Sometimes, you might require to implement data validation on server-side. Aspose.Cells.GridWeb allows you to add custom server-side data validation. You have to specify the cell range or area. You can also set client-side validation functions for callbacks with custom server side validation.
                        </p>
                    </li>
                    <li class="list-group-item" title="Change the Decimal Separator from Numeric Keypad">
                        <p class="productTitle">
                            <a href="Worksheets/ChangeDecimalSeparatorFromNumericKeypad.aspx">Change the Decimal Separator from Numeric Keypad</a>
                        </p>
                        <p>
                            By default, Aspose.Cells.GridWeb displays numeric data accordingly based on the locale/regional settings on the machine. You can change the decimal separator from Numeric keypad programmatically using Aspose.Cells.GridWeb API. So, when a file is imported into GridWeb matrix or you input some numeric data (from the numeric keypad) into a new worksheet cell, it should have your desired decimal separator set visually. 
                        </p>
                    </li>
                    <li class="list-group-item" title="Using a Common Button to Submit Grid Data">
                        <p class="productTitle"><a href="Articles/UsingCommonSubmitButton.aspx">Using a Common Button to Submit Grid Data</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                Aspose.Cells.GridWeb provides some built-in command buttons like Submit and Save. Use these buttons to perform related tasks.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Using Show Formulas Feature of GridWeb">
                        <p class="productTitle"><a href="Articles/ShowFormulaFeature.aspx">Using Show Formulas Feature of GridWeb</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                Sometimes, you need to find an easy way for the cells containing formulas. You need to have an approach to quickly read through all formulas to check for errors. This can help you to trace the data being used in a formula.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Enter Cell Data of GridWeb Worksheet in Percentage Format">
                        <p class="productTitle"><a href="Articles/SetCellPercentageFormat.aspx">Enter Cell Data of GridWeb Worksheet in Percentage Format</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to display percentage format in grid cell.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Calculate Custom Functions in GridWeb">
                        <p class="productTitle"><a href="Articles/CalculateCustomFunction.aspx">Calculate Custom Functions in GridWeb</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to calculate custom function using GridWeb.CustomCalculationEngine property.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Read GridWeb Cell Values from Client Side">
                        <p class="productTitle"><a href="Articles/ReadCellsClientSide.aspx">Read GridWeb Cell Values from Client Side</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to read GridWeb cell values from client side.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Enable Async Mode">
                        <p class="productTitle"><a href="Articles/EnableAsyncMode.aspx">Enable Async Mode</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to read enable Async mode in GridWeb.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Specify Session store path">
                        <p class="productTitle"><a href="Articles/SpecifySessionStorePath.aspx">Specify Session store path</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to specify session store path in GridWeb.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Using Client Side Range Functions">
                        <p class="productTitle"><a href="Articles/UsingClientSideRangeFunctions.aspx">Using Client Side Range Functions</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to use client side range selection functions of GridWeb.
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="tab-pane" id="basics">
                <ul class="list-group">
                    <li class="list-group-item" title="Apply Preset Styles">
                        <p class="productTitle"><a href="GridWebBasics/ApplyPresetStyle.aspx">Apply Preset Styles</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of GridWeb control&rsquo;s preset styles. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Apply Custom Preset Styles">
                        <p class="productTitle"><a href="GridWebBasics/ApplyCustomPresetStyle.aspx">Apply Custom Preset Styles</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of loading and saving GridWeb control&rsquo;s custom styles. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Apply Header Bar Styles">
                        <p class="productTitle"><a href="GridWebBasics/ApplyHeaderBarStyle.aspx">Apply Header Bar Styles</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of GridWeb control&rsquo;s header bar styles. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Apply Tab Bar Styles">
                        <p class="productTitle"><a href="GridWebBasics/ApplyTabBarStyle.aspx">Apply Tab Bar Styles</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of GridWeb control&rsquo;s tab bar styles. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Resize GridWeb">
                        <p class="productTitle"><a href="GridWebBasics/ResizeGridWeb.aspx">Resize GridWeb</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how the GridWeb control&rsquo;s can be resized. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Resize Header Bar">
                        <p class="productTitle"><a href="GridWebBasics/ResizeHeaderBar.aspx">Resize Header Bar</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how the GridWeb control&rsquo;s header bar can be resized. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Import/Export Excel">
                        <p class="productTitle"><a href="GridWebBasics/ImportExportFile.aspx">Import/Export Excel</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example imports an Excel file from a source and saves it to your required destination.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Import/Export Excel Using Stream">
                        <p class="productTitle"><a href="GridWebBasics/ImportExportFileFromStream.aspx">Import/Export Excel Using Stream</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example imports an Excel file from a stream and saves it to your required destination using stream.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Edit/View Modes">
                        <p class="productTitle"><a href="GridWebBasics/ApplyEditModes.aspx">Edit/View Modes</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates the functioning of &quot;Edit&quot; and &quot;View&quot; Modes of GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Edit/View Modes">
                        <p class="productTitle"><a href="GridWebBasics/ApplySessionModes.aspx">Session Modes</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates the functioning of &quot;Session&quot; and &quot;Sessionless&quot; Modes of GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Handling Double Click Events">
                        <p class="productTitle"><a href="GridWebBasics/HandleDoubleClickEvents.aspx">Handling Double Click Events</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates handling double click events related to GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Write Client Side Script">
                        <p class="productTitle"><a href="GridWebBasics/WriteClientSideScript.aspx">Write Client Side Script</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how client side script can be written for the GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Print GridWeb">
                        <p class="productTitle"><a href="GridWebBasics/PrintGridWeb.aspx">Print GridWeb</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how the GridWeb Control can be printed. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Init Custom Command Button">
                        <p class="productTitle"><a href="GridWebBasics/InitCustomCommandButton.aspx">Init Custom Command Button</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how a custom command button can be instantiated for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Handle Custom Command Event">
                        <p class="productTitle"><a href="GridWebBasics/HandleCustomCommandEvent.aspx">Handle Custom Command Event</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how events can be handled for custom command button instantiated for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Display Cell Edit Box">
                        <p class="productTitle"><a href="GridWebBasics/DisplayCellEditBox.aspx">Display Cell Edit Box</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates how the cell edit box can be displayed for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Get GridWeb Version">
                        <p class="productTitle"><a href="GridWebBasics/GetGridWebVersion.aspx">Get GridWeb Version</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates how to display version for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Init Context Menu Item Command">
                        <p class="productTitle"><a href="GridWebBasics/InitContextMenuItem.aspx">Init Context Menu Item Command</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to initialize a custom context menu item command for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add/Remove Context Menu Item Command">
                        <p class="productTitle"><a href="GridWebBasics/AddRemoveContextMenuItem.aspx">Add/Remove Context Menu Item Command</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to add/remove a custom context menu item command for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Call Client-side Script for GridWeb Control">
                        <p class="productTitle"><a href="GridWebBasics/CallClientsideScriptforGridWeb.aspx">Call Client-side Script for GridWeb Control</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to call a client-side script for GridWeb control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Set Column Header Tip">
                        <p class="productTitle"><a href="GridWebBasics/SetColumnHeaderTip.aspx">Set Column Header Tip</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to Set Column Header Tip for GridWeb control. 
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="tab-pane" id="worksheets">
                <ul class="list-group">
                    <li class="list-group-item" title="Show Add/Delete buttons">
                        <p class="productTitle">
                            <a href="Worksheets/ShowAddButton.aspx">Show Add/Delete buttons to Add/Delete worksheet</a>
                        </p>
                        <p>
                            Show Add/Delete buttons to Add/Delete worksheet
                        </p>
                    </li>
                    <li class="list-group-item" title="Access Worksheets">
                        <p class="productTitle"><a href="Worksheets/AccessWorksheets.aspx">Access Worksheets</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to access worksheets for GridWeb Control using index or name. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Worksheets">
                        <p class="productTitle"><a href="Worksheets/AddWorksheets.aspx">Add Worksheets</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to add worksheets for GridWeb Control with or without specifying name. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Remove Worksheets">
                        <p class="productTitle"><a href="Worksheets/RemoveWorksheets.aspx">Remove Worksheets</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to remove worksheets for GridWeb Control using index or name. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Rename Worksheets">
                        <p class="productTitle"><a href="Worksheets/RenameWorksheets.aspx">Rename Worksheets</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how worksheets can be renamed for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Copy Worksheets">
                        <p class="productTitle"><a href="Worksheets/CopyWorksheets.aspx">Copy Worksheets</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how worksheets can be copied for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Import DataView">
                        <p class="productTitle"><a href="Worksheets/ImportDataView.aspx">Import DataView</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example imports data from a DataView Object, data stored in a database table is fetched to DataView Object and displayed in the GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Export DataTable">
                        <p class="productTitle"><a href="Worksheets/ExportDataTable.aspx">Export DataTable</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exports data from a GridWeb Control to a DataTable.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Sort Data">
                        <p class="productTitle"><a href="Worksheets/SortData.aspx">Sort Data</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example represents the sorting capabilities of GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Hyperlinks">
                        <p class="productTitle"><a href="Worksheets/AddHyperlinks.aspx">Add Hyperlinks</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to add hyperlinks in GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Manage Hyperlinks" style="display: none">
                        <p class="productTitle"><a href="Worksheets/ManageHyperlinks.aspx">Manage Hyperlinks</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to update and remove hyperlinks in GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Manage Comments">
                        <p class="productTitle"><a href="Worksheets/ManageComments.aspx">Manage Comments</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to add, update and remove comments in GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Working with Named Ranges">
                        <p class="productTitle"><a href="Worksheets/AccessNamedRanges.aspx">Working with Named Ranges</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to add or use Named Ranges in GridWeb Control.
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="tab-pane" id="rowscolumns">
                <ul class="list-group">
                    <li class="list-group-item" title="Add Rows/Columns">
                        <p class="productTitle"><a href="RowsAndColumns/AddRowsColumns.aspx">Add Rows/Columns</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example exhibits Insertion of rows/columns in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Delete Rows/Columns">
                        <p class="productTitle"><a href="RowsAndColumns/DeleteRowsColumns.aspx">Delete Rows/Columns</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example exhibits Deletion of rows/columns in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Resize Rows/Columns">
                        <p class="productTitle"><a href="RowsAndColumns/ResizeRowsColumns.aspx">Resize Rows/Columns</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how rows/columns can be resized in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Customize Row/Column Headers">
                        <p class="productTitle"><a href="RowsAndColumns/CustomizeHeaders.aspx">Customize Row/Column Headers</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how rows/columns headers can be customized in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Freeze/Unfreeze Panes">
                        <p class="productTitle"><a href="RowsAndColumns/FreezePanes.aspx">Freeze/Unfreeze Panes</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates Freezing and Unfreezing Panes in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Make Row/Column ReadOnly">
                        <p class="productTitle"><a href="RowsAndColumns/MakeRowsColumnsReadOnly.aspx">Make Row/Column ReadOnly</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how rows/columns can be made read only in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Restrict Context Menu">
                        <p class="productTitle"><a href="RowsAndColumns/RestrictContextMenu.aspx">Restrict Context Menu</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how row/column operations in context menu can be restricted for GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Group/Ungroup Rows" style="display: none">
                        <p class="productTitle"><a href="RowsAndColumns/GroupRows.aspx">Group/Ungroup Rows</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates how to use the GridWeb group/ungroup rows feature.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Create/Remove Subtotal" style="display: none;">
                        <p class="productTitle"><a href="RowsAndColumns/CreateSubtotal.aspx">Create/Remove Subtotal</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This examples demonstrates how to use the GridWeb create/remove subtotal feature.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Copy Rows/Columns">
                        <p class="productTitle"><a href="RowsAndColumns/CopyRowsColumns.aspx">Copy Rows/Columns</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how single or multiple rows/columns can be copied in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Handle Column Filter Events" style="display: none">
                        <p class="productTitle"><a href="RowsAndColumns/HandleColumnFilterEvents.aspx">Handle Column Filter Events</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example shows how server side events can be handled before or after a filter is applied in GridWeb Control. 
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="tab-pane" id="cells">
                <ul class="list-group">
                    <li class="list-group-item" title="Access Cells">
                        <p class="productTitle"><a href="Cells/AccessCells.aspx">Access Cells</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to access cells for GridWeb Control using name or row & column index. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Modify Cells">
                        <p class="productTitle"><a href="Cells/ModifyCells.aspx">Modify Cells</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to update GridWeb cells with different type of values. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Formulas">
                        <p class="productTitle"><a href="Cells/AddFormulas.aspx">Add Formulas</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits how to add formulas in GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Format Cells">
                        <p class="productTitle"><a href="Cells/FormatCells.aspx">Format Cells</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to format GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Protect Cells">
                        <p class="productTitle"><a href="Cells/ProtectCells.aspx">Protect Cells</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to make all or selected GridWeb cells as editable/readonly. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Merge/Unmerge Cells">
                        <p class="productTitle"><a href="Cells/MergeCells.aspx">Merge/Unmerge Cells</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to Merge/Unmerge GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add List Validation">
                        <p class="productTitle"><a href="Cells/AddListValidation.aspx">Add List Validation</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example illustrates how list validation can be added to GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Dropdown List Validation">
                        <p class="productTitle"><a href="Cells/AddDropdownListValidation.aspx">Add Dropdown List Validation</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example illustrates how dropdown list validation can be added to GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Custom Validation">
                        <p class="productTitle"><a href="Cells/AddCustomValidation.aspx">Add Custom Validation</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example illustrates how custom validation can be added to GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Auto-Filter">
                        <p class="productTitle"><a href="Cells/SetAutoFilter.aspx">Auto-Filter</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates how to enable auto-filter for GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Custom Filter">
                        <p class="productTitle"><a href="Cells/SetCustomFilter.aspx">Custom Filter</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example demonstrates how to add a custom filter for GridWeb cells. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Add Data Validation">
                        <p class="productTitle"><a href="Cells/AddDataValidation.aspx">Add Data Validation</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example illustrates how data validation can be added to GridWeb cells. 
                            </p>
                        </div>
                    </li>
                </ul>
            </div>
            <div class="tab-pane" id="miscellaneous">
                <ul class="list-group">
                    <li class="list-group-item" title="Creating Contents">
                        <p class="productTitle"><a href="Miscellaneous/Common/CreateInvoice.aspx">Creating Contents</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example creates a Worksheet from scratch. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Protection/Validation">
                        <p class="productTitle"><a href="Miscellaneous/common/DataValidation.aspx">Data Protection / Data Validation</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example introduces the Data Validation capabilities of GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Conditional Formating">
                        <p class="productTitle"><a href="Miscellaneous/Common/ConditionalFormatting.aspx">Conditional Formatting</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example imports an Excel File with conditional formatting. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="HeaderBar &amp; CommandButton">
                        <p class="productTitle"><a href="Miscellaneous/Common/ShowHeaderBarandCommandButton.aspx">HeaderBar &amp; CommandButton</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers how to toggle visibility for header bar and command buttons of GridWeb Control. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Paginating Sheet">
                        <p class="productTitle"><a href="Miscellaneous/Common/Pagination.aspx">Paginating Sheet</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example Imports an Excel File from a source and divides the contents of the sheet into different pages.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Math">
                        <p class="productTitle"><a href="Miscellaneous/Formula/ApplyMathematicalFormulas.aspx">Apply Mathematical Formulas</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This examples presents the use of Mathematical Functions in GridWeb.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Text &amp; Data">
                        <p class="productTitle"><a href="Miscellaneous/Formula/ApplyTextAndDataFormulas.aspx">Text &amp; Data</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the application of data and text functions in GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Statistical">
                        <p class="productTitle"><a href="Miscellaneous/Formula/ApplyStatisticalFormulas.aspx">Apply Statistical Formulas</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the application of Statistical functions in GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Date &amp; Time">
                        <p class="productTitle"><a href="Miscellaneous/Formula/ApplyDateTimeFormulas.aspx">Apply Date &amp; Time Formulas</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example exhibits the application of Date &amp; Time functions in GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Logical">
                        <p class="productTitle"><a href="Miscellaneous/Formula/ApplyLogicalFormulas.aspx">Apply Logical Formulas</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example presents the demonstration of Logical Functions. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Display Charts">
                        <p class="productTitle"><a href="/Miscellaneous/Common/DisplayCharts.aspx">Display Charts</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example Imports an Excel File with charts.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Number Format" style="display: none;">
                        <p class="productTitle"><a href="Miscellaneous/Format/ApplyNumberFormats.aspx">Apply Number Formats</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of applying built-in Number Formats in GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Date &amp; Time Format">
                        <p class="productTitle"><a href="Miscellaneous/Format/ApplyDateTimeFormats.aspx">Apply Date &amp; Time Formats</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example covers the demonstration of applying built-in Date &amp; Time Formats in GridWeb.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Custom Format">
                        <p class="productTitle"><a href="Miscellaneous/Format/ApplyCustomFormats.aspx">Apply Custom Formats</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows the application of custom formats in GridWeb.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Create a Report">
                        <p class="productTitle"><a href="Miscellaneous/PivotTable/CreatePivotTable.aspx">Create a Pivot Table</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example creates a PivotTable from Microsoft Excel source. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Data Sources">
                        <p class="productTitle"><a href="Miscellaneous/PivotTable/CreatePivotTableFromWorksheet.aspx">Create Pivot Table From Worksheet</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The example generates PivotTable based on a Worksheet of GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Custom Report">
                        <p class="productTitle"><a href="Miscellaneous/PivotTable/CreateCustomPivotTable.aspx">Create Custom Pivot Table</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example customizes a PivotTable in GridWeb. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Hierarchical View" style="display: none;">
                        <p class="productTitle"><a href="Miscellaneous/Databind/ExpandChildView.aspx">Hierarchical View</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to create a Hierarchical View database application with the Aspose.Cells.GridWeb databinding features.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="GridWeb Form View" style="display: none;">
                        <p class="productTitle"><a href="Miscellaneous/gridwebform/gridwebform1.aspx">GridWeb Form View</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example shows how to use the GridWeb FormView feature.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="XHTML Support">
                        <p class="productTitle"><a href="Miscellaneous/XHTML/EnableXHTMLMode.aspx">XHTML Support</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The GridWeb control fully supports XHTML 1.0 standard. 
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="AJAX Updating" style="display: none">
                        <p class="productTitle"><a href="Miscellaneous/Ajax/AjaxUpdating.aspx">AJAX Updating</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                This example introduces the AJAX capabilities of GridWeb Control.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="DataSourceControl (.NET 2.0)" style="display: none;">
                        <p class="productTitle"><a href="Miscellaneous/DataSourceControl/BindWithDataSourceControl.aspx">DataSourceControl (.NET 2.0)</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                Aspose.Cells.GridWeb for .NET 2.0 supports binding with DataSourceControl.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Browsers Capabilities">
                        <p class="productTitle"><a href="GridWebBasics/ViewBrowsersCapabilities.aspx">Browsers Capabilities</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                Browsers Capabilities Chart
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Worksheets Designer">
                        <p class="productTitle"><a href="GridWebBasics/AboutWorksheetDesigner.aspx">Worksheets Designer</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The Aspose.Cells.GridWeb is shipped with a built-in Worksheets Designer. You may activate the designer from the Visual Studio IDE.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Custom Command Buttons Designer">
                        <p class="productTitle"><a href="GridWebBasics/AboutCustomCommandButtonsDesigner.aspx">Custom Command Buttons Designer</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The Aspose.Cells.GridWeb is shipped with a built-in Custom Commad Buttons Designer. You may activate the designer from the Visual Studio IDE.
                            </p>
                        </div>
                    </li>
                    <li class="list-group-item" title="Control Designer">
                        <p class="productTitle"><a href="GridWebBasics/AboutGridWebDesigner.aspx">Aspose.Cells.GridWeb Designer</a></p>
                        <p class="componentDescriptionCaption">Description</p>
                        <div class="componentDescriptionTxt">
                            <p class="componentDescriptionTxt">
                                The Aspose.Cells.GridWeb is shipped with a built-in designer. You may activate the designer in two ways, from System Start menu or from the Visual Studio IDE. 
                            </p>
                        </div>
                    </li>
                </ul>
            </div>

            <div class="tab-pane active" id="WorkingWithGridWebClientSideScript">
                <ul class="list-group">
                    <li class="list-group-item" title="Resize GridWeb in the browser window - Using GridWeb’s resize method">
                        <p class="productTitle"><a href="WorkingWithGridWebClientSideScript/ResizeGridWebUsingResizeMethod.aspx">Resize GridWeb in the browser window - Using GridWeb’s resize method</a></p>
                        <p>
                            Sometimes you want Aspose.Cells.GridWeb should resize itself in accordance with browser window. Aspose.Cells.GridWeb provides client-side resize() function for this purpose.
                        </p>
                    </li>
                    <li class="list-group-item" title="Making GridWeb resizable using resizable jquery ui feature">
                        <p class="productTitle"><a href="WorkingWithGridWebClientSideScript/MakingGridWebResizableUsingResizablejQueryUiFeature.aspx">Making GridWeb resizable using resizable jquery ui feature</a></p>
                        <p>
                            Making GridWeb resizable using resizable jquery ui feature.
                        </p>
                    </li>
                </ul>
            </div>

        </div>
    </div>
</asp:Content>
