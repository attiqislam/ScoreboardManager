<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScoreboardManager.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Scoreboard Manager</h1>
        <p class="lead">See scores of world famous players.</p>
    </div>

    <asp:UpdatePanel ID="upScoreboard" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">

                        <asp:GridView ID="gvScoreboard" runat="server" AllowSorting="true"
                            CurrentSortField="TotalPoints" CurrentSortDirection="ASC"
                            AutoGenerateColumns="true" CssClass="table table-bordered table-condensed" OnSorting="gvScoreboard_Sorting" OnRowDataBound="gvScoreboard_RowDataBound">
                            <Columns>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    Add new score:
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlPlayers" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlMatchs" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtNewPoint" runat="server" CssClass="form-control" placeholder="New Point"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:LinkButton ID="lbtnAddPoint" runat="server" Text="Add" CssClass="btn btn-success" OnClick="lbtnAddPoint_Click"></asp:LinkButton>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lbtnAddPoint" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="ctnScript" runat="server" ContentPlaceHolderID="ScriptContainer">
</asp:Content>
