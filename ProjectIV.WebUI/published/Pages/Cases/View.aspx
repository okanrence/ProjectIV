<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ProjectIV.WebUI.Pages.Cases.View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>View Clients</h4>
        <hr />

        <div class="row top-buffer">
            <%--<asp:Button runat="server" Text="Add New Client" CssClass="btn btn-primary" />--%>
            <a href="Add.aspx" class="btn btn-primary">Add New Case</a>
        </div>
        
        <br />
    <div class="row">
        <div class="form-group">
            <div class="col-lg-12">
                <div class="bs-component">
                    <asp:GridView ID="gdvCasesList" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CaseName" HeaderText="Case Name" />
                            <asp:BoundField DataField="CaseTypeName" HeaderText="Case Type" />
                            <asp:BoundField DataField="CaseNumber" HeaderText="Case Number" />
                            <asp:BoundField DataField="CaseStatusName" HeaderText="Case Status" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%--<asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" Height="21px" ImageUrl="~/Content/Images/edit-icon.png" ToolTip="edit client details" Width="23px" />--%>
                                   <a id="A1" href="#" runat="server" class="fa fa-pencil-square-o" aria-hidden="true" tooltip="edit case details"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-md-offset-2 col-md-10">
            <%--<asp:Button runat="server" OnClick="CreateUser_Click" Text="Add Client" CssClass="btn btn-default" />--%>
        </div>
    </div>
    </div>
</asp:Content>
