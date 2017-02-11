<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="ProjectIV.WebUI.Cases.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Manage Cases</h4>
    <hr />
    <div class="container">
        <div class="row">
            <div class="col-md-4 form-group">
                <label>Client</label>
                <asp:DropDownList runat="server" ID="ddlClients" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClients_SelectedIndexChanged">
                </asp:DropDownList>

            </div>

            <div class="col-md-4 form-group">
                <label>Case</label>
                <asp:DropDownList runat="server" ID="ddlCase" CssClass="form-control" OnSelectedIndexChanged="ddlCase_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCase"
                    CssClass="text-danger" ErrorMessage="The Case Type field is required." />
            </div>
        </div>

        <div class="row">
            <div class="col-md-8 form-group">
                <label>Lawyers</label>
                <asp:GridView ID="gdvLawyers" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" EmptyDataText="No Lawyers Assigned Yet" DataKeyNames="StaffId">
                    <Columns>
                        <asp:BoundField DataField="StaffNumber" HeaderText="Staff Number" />
                        <asp:BoundField DataField="FullName" HeaderText="Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAdd" runat="server" Checked='<%# Eval("IsAssigned") %>' />
                                <%--<a id="lnkEdit" href="#" runat="server" class="fa fa-pencil-square-o" aria-hidden="true" tooltip="edit client details"></a>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>



        <div class="row">
            <div class="col-md-offset-8 col-md-4">

                <asp:Button ID="btnClear" runat="server" Text="Close" CssClass="btn btn-default" />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
