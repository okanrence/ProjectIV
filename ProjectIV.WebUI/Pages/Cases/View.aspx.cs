using MyAppTools.Helpers;
using MyAppTools.Services;
using ProjectIV.Core.Models;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIV.WebUI.Pages.Cases
{
    public partial class View : System.Web.UI.Page
    {
        private static StaffVM currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            currentUser = (StaffVM)Session["CurrentUser"];
            var _httpHelper = new HttpHelper();
            
            var url = $"{appConfig.apiBaseUrl}/api/case?companyid={currentUser.CompanyId}";
            var strResponse = _httpHelper.GetString(url);
            var oCaseList = SerializationServices.DeserializeJson <List<CaseVM>>(strResponse);
            
            gdvCasesList.DataSource = oCaseList;
            gdvCasesList.DataBind();
        }
    }
}