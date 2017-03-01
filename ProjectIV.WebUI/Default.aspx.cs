using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using ProjectIV.WebUI.Models;
using ProjectIV.Core.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;
using MyAppTools.Services;
using ProjectIV.Core.Services;
using MyAppTools.Helpers;
using Byaxiom.Logger;
using System.Collections.Generic;

namespace ProjectIV.WebUI
{
    public partial class Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            LogHelper.Info("here");
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var userName = Email.Text;
                var password = Password.Text;

                var CurrentUser = AuthenticateUser(userName, password);

                Session.Remove("CurrentUser");

                if (CurrentUser.CompanyId != "0")
                {
                    Session.Add("CurrentUser", CurrentUser);
                    Response.Redirect("/Dashboard.aspx");
                }
                else
                {
                    FailureText.Text = "Invalid login attempt";
                    ErrorMessage.Visible = true;
                }
            }
        }

        private StaffVM AuthenticateUser(string emailaddress, string password)
        {

            StaffVM oStaffObj = null;
            var _httpHelper = new HttpHelper();
            string url = $"{appConfig.apiBaseUrl}/api/staff/authenticate";

            var headers = new Dictionary<string, string>();
            headers.Add("emailaddress", emailaddress);
            headers.Add("password", password);

            var httpResponse = _httpHelper.Get(url, headers);
            if (httpResponse.IsSuccessStatusCode)
            {
                var strResponse = httpResponse.Content.ReadAsStringAsync().Result;
                oStaffObj = SerializationServices.DeserializeJson<StaffVM>(strResponse);
            }
            return oStaffObj;

        }
    }
}
