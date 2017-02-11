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

namespace ProjectIV.WebUI.Clients
{
    public partial class Add : System.Web.UI.Page
    {
        private  static StaffVM currentUser;

        public Add()
        {
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                currentUser = (StaffVM)Session["CurrentUser"];

                if (currentUser == null)
                    Response.Redirect("/default.aspx");

                txtClientNumber.Text = $"ICL-{DateTime.Now.ToString("yyMMddHHmmss")}";
                mvClientype.SetActiveView(vwIndv);
                loadContacts();
            }
        }

        private void loadContacts()
        {
            //List<ClientContactVM> ClientContactList = null;
            //if (Session["ClientContactList"] != null)
            //    ClientContactList = (List<ClientContactVM>)Session["ClientContactList"];
            //else
            gdvContactList.DataSource = null;
            gdvContactList.DataBind();
        }

        public void AddClientContact(object sender, EventArgs e)
        {
            var oClientContact = new ClientContactVM
            {
                EmailAddress = txtCtpEmail.Text,
                HomeAddress = txtCtpAddress.Text,
                Name = txtCtpName.Text,
                PhoneNumber = txtCtpPhone.Text
            };

            List<ClientContactVM> ClientContactList = null;

            if (Session["ClientContactList"] != null)
            {
                ClientContactList = (List<ClientContactVM>)Session["ClientContactList"];
                ClientContactList.Add(oClientContact);
            }
            else
            {
                ClientContactList = new List<ClientContactVM>();
                ClientContactList.Add(oClientContact);
            }
            gdvContactList.DataSource = ClientContactList;
            gdvContactList.DataBind();

            Session.Remove("ClientContactList");
            Session.Add("ClientContactList", ClientContactList);
            clearModal();
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            try
            {
                ClientVM oClientModel;

                if (ddlClientType.SelectedValue == "1")
                {
                    oClientModel = new ClientVM
                    {
                        ClientNumber = txtClientNumber.Text,
                        ClientType = ddlClientType.SelectedItem.Text,
                        ClientEmailAddress = txtEmail.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        PaymentCurrency = ddlPaymentCurrency.SelectedValue,
                        ClientPhoneNumber = txtPhoneNumber.Text,
                        ClientAddress = txtAddress.Text,
                        OfficeAddress = txtOfficeAddress.Text,
                        OfficeEmailAddress = txtOfficeEmail.Text,
                        OfficePhoneNumber = txtOfficePhone.Text,
                        OtherDetails = txtOtherDetails.Text
                    };
                    oClientModel.ClientName = oClientModel.FullName;
                }
                else
                {
                    oClientModel = new ClientVM
                    {
                        ClientNumber = txtClientNumber.Text,
                        ClientType = ddlClientType.SelectedItem.Text,
                        ClientEmailAddress = txtOrgEmail.Text,
                        PaymentCurrency = ddlOrgCurrency.SelectedValue,
                        ClientPhoneNumber = txtOrgPhone.Text,
                        ClientAddress = txtOrgAddress.Text,
                        ClientName = txtOrgName.Text,
                        OtherDetails = txtOrgOtherDetails.Text
                    };
                  
                    if (Session["ClientContactList"] != null)
                    {
                        var ClientContactList = (List<ClientContactVM>)Session["ClientContactList"];
                        oClientModel.ClientContacts = ClientContactList;
                    }
                }

                oClientModel.CompanyId = currentUser.CompanyId;
                oClientModel.ClientId = rnd.Next(100, 50000);
                
                string controller = $"/api/Client";
                string url = appConfig.apiBaseUrl + controller;


                var strResponse = string.Empty;
                var _httpHelper = new HttpHelper();
                var response = _httpHelper.Post(oClientModel, url);

                if (response.IsSuccessStatusCode)
                {
                    strResponse = _httpHelper.ReadString(response);
                    Server.Transfer("/Pages/Clients/View.aspx");
                }
                else
                {
                    txtAddress.Text = response.ToString();
                }
            }
            catch (Exception ex)
            {
                txtAddress.Text = ex.Message;
                LogHelper.Log(ex);
            }
        }

        //private ClientVM AddClient<T>(T oClientModel)
        //    where T : class
        //{
        //    var strResponse = string.Empty;
        //    ClientVM jsonObj = null;
        //    string url = $"http://projectiv.azurewebsites.net/api/Client";
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = client.PostAsJsonAsync(url, oClientModel).Result;

        //        strResponse = response.Content.ReadAsStringAsync().Result;

        //        jsonObj = SerializationServices.DeserializeJson<ClientVM>(strResponse);

        //    }
        //    return jsonObj;
        //}


        private void onSucess()
        {
            ClearMainPage();


        }
        private void ClearMainPage()
        {
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            ddlClientType.SelectedIndex = 0;
            ddlPaymentCurrency.SelectedIndex = 0;
        }

        private void clearModal()
        {
            txtCtpAddress.Text = string.Empty;
            txtCtpEmail.Text = string.Empty;
            txtCtpName.Text = string.Empty;
            txtCtpPhone.Text = string.Empty;
        }
        protected void ddlClientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClientType.SelectedValue == "1")
                mvClientype.SetActiveView(vwIndv);
            else
                mvClientype.SetActiveView(vwOrg);
        }
    }
}