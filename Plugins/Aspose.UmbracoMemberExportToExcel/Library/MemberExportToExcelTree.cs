using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.presentation.Trees;
using umbraco.BusinessLogic.Actions;

namespace Aspose.UmbracoMemberExportToExcel.Library
{
    public class MemberExportToExcelTree : BaseTree
    {
        public MemberExportToExcelTree(string application) : base(application) { }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.NodeID = System.Guid.NewGuid().ToString();
            rootNode.Action = "javascript:openExportToExcelPage()";
            rootNode.Menu.Clear();
            rootNode.Menu.Add(ActionRefresh.Instance);
            rootNode.Icon = "../../plugins/AsposeMemberExport/Images/aspose.ico";
            rootNode.OpenIcon = "../../plugins/AsposeMemberExport/Images/aspose.ico";
        }

        public override void Render(ref XmlTree tree)
        {
        }

        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
               @"function openExportToExcelPage() {
                 UmbClientMgr.contentFrame('/umbraco/plugins/AsposeMemberExport/ExportToExcel.aspx');
                }");
        }
    }
}