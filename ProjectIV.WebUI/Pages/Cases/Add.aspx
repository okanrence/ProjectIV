<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProjectIV.WebUI.Cases.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(function () {
            alert("here")
            $("#MainContent_txtDate").datepicker();
        });
    </script>
    <h4>Log New Case</h4>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-md-4 form-group">
                <label>Client</label>
                <asp:DropDownList runat="server" ID="ddlClients" CssClass="form-control">
                </asp:DropDownList>

            </div>

            <div class="col-md-4 form-group">
                <label>Case Type:</label>
                <asp:DropDownList runat="server" ID="ddlCaseType" CssClass="form-control">
                    <asp:ListItem Value="1">Litigation</asp:ListItem>
                    <asp:ListItem Value="2">Criminal Law</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCaseType"
                    CssClass="text-danger" ErrorMessage="The Case Type field is required." />
            </div>
        </div>

        <div class="row">
            <div class="col-md-4 form-group">
                <label>Case Name</label>
                <asp:TextBox ID="txtCaseName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCaseName"
                    CssClass="text-danger" ErrorMessage="The Case Type field is required." />

            </div>

            <div class="col-md-4 form-group">
                <label>Case Number:</label>
                <asp:TextBox ID="txtCaseNumer" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCaseNumer"
                    CssClass="text-danger" ErrorMessage="The Case Type field is required." />
            </div>
        </div>

        <div class="row">
            <div class="col-md-4 form-group">
                <label>Case Description</label>
                <asp:TextBox ID="txtCaseDesc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCaseDesc"
                    CssClass="text-danger" ErrorMessage="The Case Type field is required." />
            </div>

            <div class="col-md-4 form-group">
                <label>Date Opened:</label>
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" TextMode="DateTime"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDate"
                    CssClass="text-danger" ErrorMessage="required" />
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
