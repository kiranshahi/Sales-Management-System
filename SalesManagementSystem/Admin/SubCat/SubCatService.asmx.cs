using BLL;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace SalesManagementSystem
{
    /// <summary>
    /// Summary description for SubCatService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SubCatService : System.Web.Services.WebService
    {

        BLLSubCategory subCatObj = new BLLSubCategory();
        [WebMethod]
        public void InsertSubCat(BLLSubCategory subCat)
        {
            int insertResult = subCatObj.InsertSubCategory(subCat);
        }
        [WebMethod]
        public void DeleteSubCat(int subCatId)
        {
            int updateResult = subCatObj.DeleteSubCategory(subCatId);
        }
        [WebMethod]
        public void GetAllSubCat()
        {
            List<BLLSubCategory> subCatList = subCatObj.SelectSubCategories();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(subCatList));
        }
        [WebMethod]
        public void GetSubCatById(int subCatId)
        {
            BLLSubCategory subCat = subCatObj.GetSubCatById(subCatId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(subCat));
        }
        [WebMethod]
        public void GetCategories()
        {
            List<BLLCategory> catList = subCatObj.LoadCatName();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(catList));
        }
        [WebMethod]
        public void UpdateSubCat(BLLSubCategory subCat)
        {
            int insertResult = subCatObj.UpdateSubCategory(subCat);
        }
    }
}
