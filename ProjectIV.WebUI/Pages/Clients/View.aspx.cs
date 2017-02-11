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

namespace ProjectIV.WebUI.Pages.Clients
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _httpHelper = new HttpHelper();
            
            var url = $"{appConfig.apiBaseUrl}/api/client?companyid=1";
            var strResponse = _httpHelper.GetString(url);
            var oClientList = SerializationServices.DeserializeJson <List<ClientVM>>(strResponse);
            
            gdvClientList.DataSource = oClientList;
            gdvClientList.DataBind();
        }
    }
}