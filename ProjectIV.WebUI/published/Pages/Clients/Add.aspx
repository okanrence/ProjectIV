<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="ProjectIV.WebUI.Clients.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h4>Create a new Client</h4>
    <hr />
    <div class="container">

        <div class="row">
            <div class="col-md-4 form-group">
                <asp:Label runat="server" AssociatedControlID="txtClientNumber">Client Number</asp:Label>

                <asp:TextBox runat="server" ID="txtClientNumber" CssClass="form-control" Enabled="false" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtClientNumber"
                    CssClass="text-danger" ErrorMessage="The Client Number field is required." />
            </div>

            <div class="col-md-4 form-group">
                <asp:Label runat="server" AssociatedControlID="ddlClientType">Client Type:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlClientType" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClientType_SelectedIndexChanged">
                    <asp:ListItem Value="1">Individual</asp:ListItem>
                    <asp:ListItem Value="2">Organization</asp:ListItem>
                    <asp:ListItem Value="3">Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlClientType"
                    CssClass="text-danger" ErrorMessage="The Client Type field is required." />
            </div>
        </div>

        <asp:MultiView ID="mvClientype" runat="server">
            <asp:View ID="vwIndv" runat="server">

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtFirstName">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" />
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtLastName">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtPhoneNumber">Phone</asp:Label>
                        <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control" TextMode="Phone" />
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtEmail">Email</asp:Label>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtAddress">Home Address</asp:Label>
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOfficePhone">Office Phone</asp:Label>
                        <asp:TextBox runat="server" ID="txtOfficePhone" CssClass="form-control" TextMode="Phone" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOfficeEmail">Office Email</asp:Label>
                        <asp:TextBox runat="server" ID="txtOfficeEmail" CssClass="form-control" TextMode="Email" />
                    </div>

                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOfficeAddress">Office Address</asp:Label>
                        <asp:TextBox runat="server" ID="txtOfficeAddress" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <label>Other Details</label>
                        <asp:TextBox runat="server" ID="txtOrgOtherDetails" CssClass="form-control" TextMode="MultiLine" />

                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlOrgCurrency">Billing Currency</asp:Label>

                        <asp:DropDownList runat="server" ID="ddlOrgCurrency" CssClass="form-control">
                            <asp:ListItem>NGN</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                            <asp:ListItem>EUR</asp:ListItem>
                            <asp:ListItem>GBP</asp:ListItem>
                        </asp:DropDownList>
                    </div>


                </div>
            </asp:View>

            <asp:View ID="vwOrg" runat="server">

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOrgName">Organization Name</asp:Label>

                        <asp:TextBox runat="server" ID="txtOrgName" CssClass="form-control" />

                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOrgPhone">Phone</asp:Label>
                        <asp:TextBox runat="server" ID="txtOrgPhone" CssClass="form-control" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOrgEmail">Email</asp:Label>
                        <asp:TextBox runat="server" ID="txtOrgEmail" CssClass="form-control" />
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOrgAddress">Address</asp:Label>
                        <asp:TextBox runat="server" ID="txtOrgAddress" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="txtOtherDetails">Other Details</asp:Label>
                        <asp:TextBox runat="server" ID="txtOtherDetails" CssClass="form-control" TextMode="MultiLine" />
                    </div>
                    <div class="col-md-4 form-group">
                        <asp:Label runat="server" AssociatedControlID="ddlPaymentCurrency">Billing Currency   :</asp:Label>
                        <asp:DropDownList runat="server" ID="ddlPaymentCurrency" CssClass="form-control">
                            <asp:ListItem>NGN</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                            <asp:ListItem>EUR</asp:ListItem>
                            <asp:ListItem>GBP</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="form-group">
                    <a id="lnkAddClients" href="#" class="btn btn-link " data-toggle="modal" data-target="#myModal">Add Contacts</a>
                    <div class="col-lg-8">
                        <div class="bs-component">
                            <asp:GridView ID="gdvContactList" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" EmptyDataText="No Contacts Yet">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" />
                                    <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" />
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a id="lnkEdit" href="#" runat="server" class="fa fa-pencil-square-o" aria-hidden="true" tooltip="edit client details"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>


                <div class="modal fade" id="myModal">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Add Contacts</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-4 form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtCtpName">Contact Name:</asp:Label>
                                            <asp:TextBox runat="server" ID="txtCtpName" CssClass="form-control" />
                                            </div>
                                        <div class="col-md-4 form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtCtpEmail">Email:</asp:Label>
                                            <asp:TextBox runat="server" ID="txtCtpEmail" CssClass="form-control" />
                                            
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtCtpPhone">Phone Number:</asp:Label>
                                            <asp:TextBox runat="server" ID="txtCtpPhone" CssClass="form-control" />
                                            
                                        </div>
                                        <div class="col-md-4 form-group">
                                            <asp:Label runat="server" AssociatedControlID="txtCtpAddress">Home Address</asp:Label>
                                            <asp:TextBox runat="server" ID="txtCtpAddress" CssClass="form-control" TextMode="MultiLine" />
                                          
                                        </div>
                                    </div>

                                    <div class="row">
                                        

                                    </div>

                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        <asp:Button runat="server" OnClick="AddClientContact" Text="Add" CssClass="btn btn-primary" CausesValidation="False" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>

        </asp:MultiView>


        <div class="form-group">
            <div class="col-md-offset-6 col-md-4">
                <asp:Button runat="server"  Text="Close" CssClass="btn btn-default" />
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Save" CssClass="btn btn-primary" />
            </div>
        </div>

    </div>
</asp:Content>
