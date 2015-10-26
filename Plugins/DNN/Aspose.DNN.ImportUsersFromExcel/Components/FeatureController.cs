/*
' Copyright (c) 2015 Aspose.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace Aspose.DotNetNuke.Modules.Aspose.DNN.ImportUsersFromExcel.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Aspose.DNN.ImportUsersFromExcel
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<Aspose.DNN.ImportUsersFromExcelInfo> colAspose.DNN.ImportUsersFromExcels = GetAspose.DNN.ImportUsersFromExcels(ModuleID);
        //if (colAspose.DNN.ImportUsersFromExcels.Count != 0)
        //{
        //    strXML += "<Aspose.DNN.ImportUsersFromExcels>";

        //    foreach (Aspose.DNN.ImportUsersFromExcelInfo objAspose.DNN.ImportUsersFromExcel in colAspose.DNN.ImportUsersFromExcels)
        //    {
        //        strXML += "<Aspose.DNN.ImportUsersFromExcel>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objAspose.DNN.ImportUsersFromExcel.Content) + "</content>";
        //        strXML += "</Aspose.DNN.ImportUsersFromExcel>";
        //    }
        //    strXML += "</Aspose.DNN.ImportUsersFromExcels>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlAspose.DNN.ImportUsersFromExcels = DotNetNuke.Common.Globals.GetContent(Content, "Aspose.DNN.ImportUsersFromExcels");
        //foreach (XmlNode xmlAspose.DNN.ImportUsersFromExcel in xmlAspose.DNN.ImportUsersFromExcels.SelectNodes("Aspose.DNN.ImportUsersFromExcel"))
        //{
        //    Aspose.DNN.ImportUsersFromExcelInfo objAspose.DNN.ImportUsersFromExcel = new Aspose.DNN.ImportUsersFromExcelInfo();
        //    objAspose.DNN.ImportUsersFromExcel.ModuleId = ModuleID;
        //    objAspose.DNN.ImportUsersFromExcel.Content = xmlAspose.DNN.ImportUsersFromExcel.SelectSingleNode("content").InnerText;
        //    objAspose.DNN.ImportUsersFromExcel.CreatedByUser = UserID;
        //    AddAspose.DNN.ImportUsersFromExcel(objAspose.DNN.ImportUsersFromExcel);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<Aspose.DNN.ImportUsersFromExcelInfo> colAspose.DNN.ImportUsersFromExcels = GetAspose.DNN.ImportUsersFromExcels(ModInfo.ModuleID);

        //foreach (Aspose.DNN.ImportUsersFromExcelInfo objAspose.DNN.ImportUsersFromExcel in colAspose.DNN.ImportUsersFromExcels)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objAspose.DNN.ImportUsersFromExcel.Content, objAspose.DNN.ImportUsersFromExcel.CreatedByUser, objAspose.DNN.ImportUsersFromExcel.CreatedDate, ModInfo.ModuleID, objAspose.DNN.ImportUsersFromExcel.ItemId.ToString(), objAspose.DNN.ImportUsersFromExcel.Content, "ItemId=" + objAspose.DNN.ImportUsersFromExcel.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
