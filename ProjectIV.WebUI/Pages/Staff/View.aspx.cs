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

namespace ProjectIV.WebUI.Pages.Staff
{
    public partial class View : System.Web.UI.Page
    {
        private HttpHelper _httpHelper = null;
        private StaffVM CurrentUser = null;
        public View()
        {
            _httpHelper = new HttpHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CurrentUser = (StaffVM)Session["CurrentUser"];

            };

            var url = $"{appConfig.apiBaseUrl}/api/staff";
            var headers = new Dictionary<string, string>();
            headers.Add("companyId", CurrentUser.CompanyId.ToString());

            var strResponse = _httpHelper.GetString(url);
            var oStaffList = SerializationServices.DeserializeJson<List<StaffVM>>(strResponse);

            gdvClientList.DataSource = oStaffList;
            gdvClientList.DataBind();
        }
    }
}