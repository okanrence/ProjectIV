using Byaxiom.Logger;
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

namespace ProjectIV.WebUI.Cases
{
    public partial class Manage : System.Web.UI.Page
    {
        private readonly IHttpHelper _httpHelper;
        public Manage()
        {
            _httpHelper = new HttpHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadClients("1");
                loadStaffForAssignment(1, 1);
            }
        }
        private void loadCases(int clientId, int companyId)
        {
            try
            {
                string controller = $"/api/case/client?clientId={clientId}&companyid={companyId}";
                string url = appConfig.apiBaseUrl + controller;
                var oCaseList = _httpHelper.Get<List<CaseVM>>(url);
                ddlCase.DataSource = oCaseList;
                ddlCase.DataTextField = "CaseName";
                ddlCase.DataValueField = "CaseNumber";
                ddlCase.DataBind();
            }
            catch (Exception)
            {

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


        private void onSucess()
        {
            ClearPage();


        }
        private void ClearPage()
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newMappingList = new List<CaseMappingVM>();
            var AlreadyAssignedList = new List<StaffVM>();
            //read data off grid
            foreach (GridViewRow row in gdvLawyers.Rows)
            {
                bool isSelected = (row.FindControl("chkAdd") as CheckBox).Checked;
                var staffID = Convert.ToInt32(gdvLawyers.DataKeys[row.RowIndex].Values[0]);

                if (Session["AlreadyMappedStaff"] != null)
                {
                    AlreadyAssignedList = (List<StaffVM>)Session["AlreadyMappedStaff"];
                    if (isSelected)
                    {
                        bool containsItem = AlreadyAssignedList.Any(item => item.StaffId == staffID);
                        if (!containsItem)
                        {
                            var newAssignedStaff = new StaffVM
                            {
                                StaffId = staffID
                            };
                            AlreadyAssignedList.Add(newAssignedStaff);
                        }
                    }
                    else
                    {
                        bool containsItem = AlreadyAssignedList.Any(item => item.StaffId == staffID);
                        if (containsItem)
                        {
                            AlreadyAssignedList.Remove(AlreadyAssignedList.Where(x => x.StaffId == staffID).FirstOrDefault());
                        }

                    }
                }
                else
                {
                    var newAssignedStaff = new StaffVM
                    {
                        StaffId = staffID
                    };

                    AlreadyAssignedList.Add(newAssignedStaff);
                }
            }
        }

        protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            var clientId = int.Parse(ddlClients.SelectedValue);
            loadCases(clientId, 1);
        }

        protected void ddlCase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadStaffForAssignment(int companyId, int caseId)
        {

            //string staffListCtrl = $"/api/staff/assignment/list?Companyid={companyId}";
            //string url = appConfig.apiBaseUrl + staffListCtrl;
            //var oAssignmentList = _httpHelper.Get<List<AssignStaffVM>>(url);
            var oAssignmentList = new List<AssignStaffVM>
            {
                new AssignStaffVM { FullName = "Okanrende Olanrewaju", staffId=1, StaffNumber="02482" },
                new AssignStaffVM { FullName = "Olanrewaju", staffId=2, StaffNumber="02382" },
                new AssignStaffVM { FullName = "Oanrende", staffId=4, StaffNumber="52325" },
                new AssignStaffVM { FullName = "Opeyemi Olanrewaju", staffId=3, StaffNumber="552482" }
            };



            //string staffCaseAssignedCtrl = $"/api/case/assigned/list?caseId={caseId}";
            //url = appConfig.apiBaseUrl + staffCaseAssignedCtrl;

            //var oAlreadyAssignedList = _httpHelper.Get<List<StaffVM>>(url);

            var oAlreadyAssignedList = new List<StaffVM>
            {
                new StaffVM { StaffId = 1 },
                new StaffVM { StaffId = 2 },
            };

            Session.Remove("AlreadyMappedStaff");
            Session.Add("AlreadyMappedStaff", oAlreadyAssignedList);


            if (oAlreadyAssignedList.Count > 0)
            {

                foreach (var notAssignedStaff in oAssignmentList)
                {
                    foreach (var alreadyAssignedStaff in oAlreadyAssignedList)
                    {
                        if (notAssignedStaff.staffId == alreadyAssignedStaff.StaffId)
                        {
                            notAssignedStaff.IsAssigned = true;
                        }
                    }
                }
            }

            gdvLawyers.DataSource = oAssignmentList;
            gdvLawyers.DataBind();
        }
    }
}