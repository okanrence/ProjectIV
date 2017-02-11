using Byaxiom.Logger;
using MyAppTools.Helpers;
using MyAppTools.Services;
using ProjectIV.Core.Models;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIV.WebUI.Cases
{
    public partial class Add : System.Web.UI.Page
    {
        private readonly IHttpHelper _httpHelper;
        private static StaffVM CurrentUser;
        public Add()
        {
            _httpHelper = new HttpHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser = (StaffVM)Session["CurrentUser"];
                if (CurrentUser == null)
                    Server.Transfer("./default.aspx");

                loadClients(CurrentUser.CompanyId);
            }

        }

        private void loadClients(string companyId)
        {
            try
            {
                string controller = $"/api/Client?Companyid={companyId}";
                string url = appConfig.apiBaseUrl + controller;
                var oClientList = _httpHelper.Get<List<ClientVM>>(url);
                ddlClients.DataSource = oClientList;
                ddlClients.DataTextField = "ClientDisplayName";
                ddlClients.DataValueField = "ClientId";
                ddlClients.DataBind();
            }
            catch (Exception)
            {

            }
        }
        private void AddCase()
        {
            try
            {
                var NewCase = new CaseVM
                {
                    CaseDescription = txtCaseDesc.Text,
                    CaseName = txtCaseName.Text,
                    CaseNumber = txtCaseNumer.Text,
                    CaseTypeId = int.Parse(ddlCaseType.SelectedValue),
                    CaseTypeName = ddlCaseType.SelectedItem.Text,
                    CreatedBy = "logged On User",
                    CaseStatusId = (int)Enums.CaseStatus.Open,
                    CaseStatusName = Enums.CaseStatus.Open.ToString(),
                    ClientId = int.Parse(ddlClients.SelectedValue),
                    DateOpened = DateTime.Parse(txtDate.Text),
                    CompanyId = CurrentUser.CompanyId
                };
                var response = _httpHelper.Post(NewCase, appConfig.apiBaseUrl + "/api/Case");

                if (response.IsSuccessStatusCode)
                {
                  // var strresponse = _httpHelper.ReadString(response);
                    Server.Transfer("/Pages/Cases/View.aspx");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(ex);
            }
        }

        private void onSucess()
        {
            ClearPage();


        }
        private void ClearPage()
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddCase();
        }
    }
}