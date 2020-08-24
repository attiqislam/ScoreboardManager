<%@ Page Title="Player Add" Language="C#" AutoEventWireup="true" CodeBehind="PlayerAdd.aspx.cs" Inherits="ScoreboardManager.WebForms.AdminPages.PlayerAdd" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ctnMain" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upContainer" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="content-area">
                    <div class="title text-center">
                        <h2><%: Title %></h2>
                        <h4>Add a new player or update an existing player</h4>
                        <hr />
                    </div>
                    <div class="form-horizontal">

                        <div class="form-group">
                            <asp:Label runat="server" Text="First Name" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFirstName" CssClass="" ErrorMessage="First Name is required." ForeColor="Red" ValidationGroup="Player"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Last Name" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLastName" CssClass="" ErrorMessage="Last Name is required." ForeColor="Red" ValidationGroup="Player"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Email" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" CssClass="" ErrorMessage="Email is required." ForeColor="Red" ValidationGroup="Player"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:LinkButton ID="lbtnSave" runat="server" CssClass="btn btn-success" OnClick="lbtnSave_Click" ValidationGroup="Player" ToolTip="Save" data-toggle="tooltip">
					                   <span class="glyphicon glyphicon-floppy-disk"></span> Save
                                </asp:LinkButton>

                                <asp:LinkButton ID="lbtnReset" runat="server" CssClass="btn btn-default" OnClick="lbtnReset_Click" CausesValidation="false" ToolTip="Reset" data-toggle="tooltip">
					                    <span class="glyphicon glyphicon-file"></span> Reset 
                                </asp:LinkButton>

                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-default" OnClick="lbtnDelete_Click" CausesValidation="false" ToolTip="Delete" data-toggle="tooltip">
					                     <span class="glyphicon glyphicon-trash"></span> Delete 
                                </asp:LinkButton>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="ctnScript" runat="server" ContentPlaceHolderID="ScriptContainer">
</asp:Content>
