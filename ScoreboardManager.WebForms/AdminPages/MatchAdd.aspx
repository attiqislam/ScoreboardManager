<%@ Page Title="Match Add" Language="C#" AutoEventWireup="true" CodeBehind="MatchAdd.aspx.cs" Inherits="ScoreboardManager.WebForms.AdminPages.MatchAdd" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ctnMain" runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel ID="upContainer" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="content-area">
                    <div class="title text-center">
                        <h2><%: Title %></h2>
                        <h4>Add a new match or update an existing match</h4>
                        <hr />
                    </div>
                    <div class="form-horizontal">

                        <div class="form-group">
                            <asp:Label runat="server" Text="Match Name" AssociatedControlID="txtMatchName" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMatchName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMatchName" CssClass="" ErrorMessage="Match Name is required." ForeColor="Red" ValidationGroup="Match"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Match Venue" AssociatedControlID="txtMatchVenue" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMatchVenue" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMatchVenue" CssClass="" ErrorMessage="Match Venue is required." ForeColor="Red" ValidationGroup="Match"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Match Date Time" AssociatedControlID="txtMatchDateTime" CssClass="col-md-2 control-label"></asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMatchDateTime" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtMatchDateTime" CssClass="" ErrorMessage="Match Date Time is required." ForeColor="Red" ValidationGroup="Match"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:LinkButton ID="lbtnSave" runat="server" CssClass="btn btn-success" OnClick="lbtnSave_Click" ValidationGroup="Match" ToolTip="Save" data-toggle="tooltip">
					                   <span class="glyphicon glyphicon-floppy-disk"></span> Save
                                </asp:LinkButton>

                                <asp:LinkButton ID="lbtnReset" runat="server" CssClass="btn btn-default" OnClick="lbtnReset_Click" CausesValidation="false" ToolTip="Reset" data-toggle="tooltip">
					                    <span class="glyphicon glyphicon-file"></span> Reset 
                                </asp:LinkButton>

                                <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-danger" OnClick="lbtnDelete_Click" CausesValidation="false" ToolTip="Delete" data-toggle="tooltip">
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
