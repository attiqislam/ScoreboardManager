<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ScoreboardManager.WebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Scoreboard Manager</h1>
        <p class="lead">See scores of world famous players.</p>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="table-responsive">
                <asp:UpdatePanel ID="upScoreboard" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvScoreboard" runat="server" AllowSorting="true" 
                            CurrentSortField="TotalPoints" CurrentSortDirection="ASC"
                            AutoGenerateColumns="true" CssClass="table table-bordered table-condensed" OnSorting="gvScoreboard_Sorting" OnRowDataBound="gvScoreboard_RowDataBound">
                            <Columns>
                              <%--  <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="true" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="true" />
                                <asp:BoundField DataField="TotalPoints" HeaderText="Total Points" ReadOnly="true" />--%>

                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="ctnScript" runat="server" ContentPlaceHolderID="ScriptContainer">
</asp:Content>
