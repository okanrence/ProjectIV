﻿using Byaxiom.Logger;
using MyAppTools.Helpers;
using MyAppTools.Services;
using ProjectIV.Core.ViewModels;
using ProjectIV.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIV.WebUI.Admin
{
    public partial class AddCompanyUser : System.Web.UI.Page
    {
        private readonly IHttpHelper _httpHelper;
        private static StaffVM CurrentUser;
        public AddCompanyUser()
        {
            _httpHelper = new HttpHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser = (StaffVM)Session["CurrentUser"];
                loadClients(CurrentUser.CompanyId);
            }

        }

        private void loadClients(string companyId)
        {
            try
            {
                //string controller = $"/api/Client?Companyid={companyId}";
                //string url = appConfig.apiBaseUrl + controller;
                //var oClientList = _httpHelper.Get<List<ClientVM>>(url);
                //ddlClients.DataSource = oClientList;
                //ddlClients.DataTextField = "ClientDisplayName";
                //ddlClients.DataValueField = "ClientId";
                //ddlClients.DataBind();
            }
            catch (Exception)
            {

            }
        }
        private void AddStaff()
        {
            try
            {
                var NewStaff = new StaffVM
                {
                    Designation = ddlDesignation.SelectedItem.Text,
                    EmailAddress = txtEmailAddress.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    StaffNumber = txtStaffNumber.Text,
                    StaffId = new Random().Next(1000, 100000),
                    CompanyId = CurrentUser.CompanyId
                };

                var response = _httpHelper.Post(NewStaff, appConfig.apiBaseUrl + "/api/Staff");

                if (response.IsSuccessStatusCode)
                {
                    Server.Transfer("/Pages/Staff/View.aspx");
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
            AddStaff();
        }
    }
}