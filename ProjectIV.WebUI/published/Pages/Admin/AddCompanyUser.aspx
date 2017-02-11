<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCompanyUser.aspx.cs" Inherits="ProjectIV.WebUI.Admin.AddCompanyUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Add New User</h4>
    <hr />
    <div class="container">
        <div class="row">
            

        
        </div>

        <div class="row">
            <div class="col-md-4 form-group">
                <label>First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName"
                    CssClass="text-danger" ErrorMessage="required." />

            </div>

            <div class="col-md-4 form-group">
                <label>Last Name:</label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName"
                    CssClass="text-danger" ErrorMessage="Required." />
            </div>
        </div>
         <%-- public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }--%>
        <div class="row">
            <div class="col-md-4 form-group">
                <label>Email Address</label>
                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddress"
                    CssClass="text-danger" ErrorMessage="Required" />
            </div>

            <div class="col-md-4 form-group">
                <label>Phone Number </label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNumber"
                    CssClass="text-danger" ErrorMessage="Required" />
            </div>
        </div>
         <div class="row">
             
            <div class="col-md-4 form-group">
                <label>Staff Number </label>
                <asp:TextBox ID="txtStaffNumber" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStaffNumber"
                    CssClass="text-danger" ErrorMessage="Required" />
            </div>

             <div class="col-md-4 form-group">
                <label >Designation</label>
                 <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control">
                     <asp:ListItem Value="0">--Select--</asp:ListItem>
                     <asp:ListItem Value="1">Paralegal</asp:ListItem>
                     <asp:ListItem Value="2">Attorrney</asp:ListItem>
                 </asp:DropDownList>

            </div>
         </div>
        <div class="form-group">
            <div class="col-md-offset-6 col-md-4">
                <asp:Button ID="btnClear" runat="server" Text="Close" CssClass="btn btn-default" />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
