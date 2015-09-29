using Aspose.Plugins.UpdateImportTool.LoginWindow;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Aspose.Plugins.UpdateImportTool
{
    /// <summary>
    /// Interaction logic for AttributesSelection.xaml
    /// </summary>
    public partial class AttributesSelection : Window
    {
        public string EntityName = "";
        public CrmLogin ctrl = new CrmLogin();
        public List<string> SelectedAttributes = new List<string>();

        public AttributesSelection()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (ctrl.CrmConnectionMgr != null && ctrl.CrmConnectionMgr.CrmSvc != null && ctrl.CrmConnectionMgr.CrmSvc.IsReady)
            {
                CrmServiceClient svcClient = ctrl.CrmConnectionMgr.CrmSvc;
                if (svcClient.IsReady)
                {
                    List<AttributeMetadata> entitiesList = svcClient.GetAllAttributesForEntity(EntityName);
                    List<string> MyAttributes = new List<string>();
                    foreach (AttributeMetadata entityinlist in entitiesList)
                    {
                        if (entityinlist.IsCustomizable.Value)
                        {
                            MyAttributes.Add(entityinlist.LogicalName);
                        }
                    }
                    MyAttributes.Sort();
                    foreach (string item in MyAttributes)
                    {
                        CheckBox chk = new CheckBox();
                        chk.Content = item;
                        LB_AttributesList.Items.Add(chk);
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectedAttributes.Clear();
            foreach (CheckBox chk in LB_AttributesList.Items)
            {
                if (chk.IsChecked.Value)
                    SelectedAttributes.Add(chk.Content.ToString());
            }
            Close();
        }
    }
}
