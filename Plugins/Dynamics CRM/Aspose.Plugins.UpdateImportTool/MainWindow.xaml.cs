using Aspose.Cells;
using Aspose.Plugins.UpdateImportTool.LoginWindow;
using Microsoft.Win32;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aspose.Plugins.UpdateImportTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Establish the Login control
        public CrmLogin ctrl = new CrmLogin();
        string SelectedEntity = "";
        List<string> SelectedAttributes = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to login to CRM and create a CrmService Client 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            #region Login Control
            // Wire Event to login response. 
            ctrl.ConnectionToCrmCompleted += ctrl_ConnectionToCrmCompleted;
            // Show the dialog. 
            ctrl.ShowDialog();

            // Handel return. 
            if (ctrl.CrmConnectionMgr != null && ctrl.CrmConnectionMgr.CrmSvc != null && ctrl.CrmConnectionMgr.CrmSvc.IsReady)
                //MessageBox.Show("Good Connect");
                LBL_Status.Content = "Connected to CRM";
            else
                LBL_Status.Content = "Connection to CRM Failed";
            //MessageBox.Show("BadConnect");

            #endregion

            #region CRMServiceClient
            if (ctrl.CrmConnectionMgr != null && ctrl.CrmConnectionMgr.CrmSvc != null && ctrl.CrmConnectionMgr.CrmSvc.IsReady)
            {
                CrmServiceClient svcClient = ctrl.CrmConnectionMgr.CrmSvc;
                if (svcClient.IsReady)
                {
                    List<EntityMetadata> entitiesList = svcClient.GetAllEntityMetadata();
                    List<string> MyEntities = new List<string>();
                    foreach (EntityMetadata entityinlist in entitiesList)
                    {
                        if (entityinlist.IsCustomizable.Value)
                        {
                            MyEntities.Add(entityinlist.LogicalName);
                            //CB_Entities.Items.Add(entityinlist.LogicalName);
                        }
                    }
                    MyEntities.Sort();
                    foreach (string item in MyEntities)
                        CB_Entities.Items.Add(item);

                    //                    // Get data from CRM . 
                    //                    string FetchXML =
                    //                        @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                    //                        <entity name='account'>
                    //                            <attribute name='name' />
                    //                            <attribute name='primarycontactid' />
                    //                            <attribute name='telephone1' />
                    //                            <attribute name='accountid' />
                    //                            <order attribute='name' descending='false' />
                    //                          </entity>
                    //                        </fetch>";

                    //                    var Result = svcClient.GetEntityDataByFetchSearchEC(FetchXML);
                    //                    if (Result != null)
                    //                    {
                    //                        MessageBox.Show(string.Format("Found {0} records\nFirst Record name is {1}", Result.Entities.Count, Result.Entities.FirstOrDefault().GetAttributeValue<string>("name")));
                    //                    }


                    //                    // Core API using SDK OOTB 
                    //                    CreateRequest req = new CreateRequest();
                    //                    Entity accENt = new Entity("account");
                    //                    accENt.Attributes.Add("name", "TESTFOO");
                    //                    req.Target = accENt;
                    //                    CreateResponse res = (CreateResponse)svcClient.OrganizationServiceProxy.Execute(req);
                    //                    //CreateResponse res = (CreateResponse)svcClient.ExecuteCrmOrganizationRequest(req, "MyAccountCreate");
                    //                    MessageBox.Show(res.id.ToString());



                    //                    // Using Xrm.Tooling helpers. 
                    //                    Dictionary<string, CrmDataTypeWrapper> newFields = new Dictionary<string, CrmDataTypeWrapper>();
                    //                    // Create a new Record. - Account 
                    //                    newFields.Add("name", new CrmDataTypeWrapper("CrudTestAccount", CrmFieldType.String));
                    //                    Guid guAcctId = svcClient.CreateNewRecord("account", newFields);

                    //                    MessageBox.Show(string.Format("New Record Created {0}", guAcctId));
                }
            }
            #endregion


        }

        /// <summary>
        /// Raised when the login form process is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrl_ConnectionToCrmCompleted(object sender, EventArgs e)
        {
            if (sender is CrmLogin)
            {
                this.Dispatcher.Invoke(() =>
                {
                    ((CrmLogin)sender).Close();
                });
            }
        }

        private void CB_Entities_Selected(object sender, RoutedEventArgs e)
        {
            SelectedEntity = CB_Entities.SelectedValue.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AttributesSelection Attributes = new AttributesSelection();
            Attributes.EntityName = SelectedEntity;
            Attributes.ctrl = ctrl;
            Attributes.ShowDialog();
            SelectedAttributes = Attributes.SelectedAttributes;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Get data from CRM . 
            string FetchXML =
                "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
                                   "<entity name='" + SelectedEntity + "'>";
            foreach (string attributename in SelectedAttributes)
                FetchXML += "<attribute name='" + attributename + "' />";
            //<attribute name='name' />
            //<attribute name='primarycontactid' />
            //<attribute name='telephone1' />
            //<attribute name='accountid' />
            //<order attribute='name' descending='false' />
            FetchXML += " </entity></fetch>";
            CrmServiceClient svcClient = ctrl.CrmConnectionMgr.CrmSvc;

            var Result = svcClient.GetEntityDataByFetchSearchEC(FetchXML);
            if (Result != null)
            {
                BindDataWithGrid(Result);
                // MessageBox.Show(string.Format("Found {0} records\nFirst Record name is {1}", Result.Entities.Count, Result.Entities.FirstOrDefault().GetAttributeValue<string>("name")));
            }

        }

        private void BindDataWithGrid(EntityCollection Result)
        {
            DataTable dt = new DataTable();
            foreach (string attrib in SelectedAttributes)
                dt.Columns.Add(attrib);
            foreach (Entity record in Result.Entities)
            {
                DataRow dr = dt.NewRow();
                foreach (string attribute in SelectedAttributes)
                {
                    if (record.Contains(attribute))
                    {
                        dr[attribute] = record[attribute].ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            GV_Data.ItemsSource = dt.DefaultView;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Get data from CRM . 
            string FetchXML =
                "<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>" +
                                   "<entity name='" + SelectedEntity + "'>";
            foreach (string attributename in SelectedAttributes)
                FetchXML += "<attribute name='" + attributename + "' />";
            FetchXML += " </entity></fetch>";
            CrmServiceClient svcClient = ctrl.CrmConnectionMgr.CrmSvc;

            var Result = svcClient.GetEntityDataByFetchSearchEC(FetchXML);
            if (Result != null)
            {
                ExportToCSV(Result);
            }
        }

        private void ExportToCSV(EntityCollection Result)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.DefaultExt = ".xlsx";
            fileDialog.FileName = "Aspose ImportTool Export.xlsx";
            if (fileDialog.ShowDialog().Value)
            {
                string FileName = fileDialog.FileName;
                Workbook workbook = new Workbook();
                workbook.Worksheets.Add("Aspose Export");

                Worksheet MyWorksheet = workbook.Worksheets["Aspose Export"];
                int i = 0;
                foreach (string attrib in SelectedAttributes)
                    MyWorksheet.Cells[0, i++].Value = attrib;
                int Row = 1,cell=0;
                foreach (Entity record in Result.Entities)
                {
                    cell = 0;
                    foreach (string attribute in SelectedAttributes)
                    {
                        if (record.Contains(attribute))
                        {
                            MyWorksheet.Cells[Row,cell].Value = record[attribute].ToString();
                        }
                        cell++;
                    }
                    Row++;
                }

                workbook.Save(FileName, SaveFormat.Xlsx);

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".xlsx";
            if (fileDialog.ShowDialog().Value)
            {
                string FileName = fileDialog.FileName;
                Workbook workbook = new Workbook(FileName);

                Worksheet MyWorksheet = workbook.Worksheets["Aspose Export"];

                DataTable dt = MyWorksheet.Cells.ExportDataTable(0, 0, MyWorksheet.Cells.Rows.Count, MyWorksheet.Cells.Columns.Count, true);
                GV_Data.ItemsSource = dt.DefaultView;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (ctrl.CrmConnectionMgr != null && ctrl.CrmConnectionMgr.CrmSvc != null && ctrl.CrmConnectionMgr.CrmSvc.IsReady)
            {
                CrmServiceClient svcClient = ctrl.CrmConnectionMgr.CrmSvc;
                if (svcClient.IsReady)
                {
                    OpenFileDialog fileDialog = new OpenFileDialog();
                    fileDialog.DefaultExt = ".xlsx";
                    if (fileDialog.ShowDialog().Value)
                    {
                        string FileName = fileDialog.FileName;
                        Workbook workbook = new Workbook(FileName);

                        Worksheet MyWorksheet = workbook.Worksheets["Aspose Export"];

                        DataTable dt = MyWorksheet.Cells.ExportDataTable(0, 0, MyWorksheet.Cells.Rows.Count, MyWorksheet.Cells.Columns.Count, true);
                        foreach (DataRow dr in dt.Rows)
                        {
                            Entity CrmRecord = new Entity(SelectedEntity);
                            foreach (DataColumn th in dt.Columns)
                            {
                                CrmRecord.Attributes.Add(th.ColumnName, dr[th.ColumnName].ToString());
                            }
                            CreateRequest req = new CreateRequest();
                            req.Target = CrmRecord;
                            CreateResponse res = (CreateResponse)svcClient.OrganizationServiceProxy.Execute(req);
                        }
                    }
                }
            }
        }

    }
}
