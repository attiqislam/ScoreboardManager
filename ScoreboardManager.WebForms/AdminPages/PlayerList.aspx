<%@ Page Title="Player List" Language="C#" AutoEventWireup="true" CodeBehind="PlayerList.aspx.cs" Inherits="ScoreboardManager.WebForms.AdminPages.PlayerList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="cntHead" runat="server" ContentPlaceHolderID="cphHead">
    <link href="//cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ctnMain" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <div class="content-area">
            <div class="title text-center">
                <h2><%: Title %></h2>
                <h4>List of all players</h4>
                <hr />
            </div>
            <table id="players" class="table table-responsive" style="width: 100%" data-toggle="table" data-pagination="true" data-search="true" data-show-columns="true" data-show-pagination-switch="true"
                data-show-refresh="true" data-key-events="true" data-show-toggle="true" data-resizable="true" data-cookie="true"
                data-cookie-id-table="saveId" data-show-export="false" data-click-to-select="true" data-toolbar="#toolbar">
                <thead>
                    <tr>
                        <th data-field="FirstName">First Name</th>
                        <th data-field="LastName">Last Name</th>
                        <th data-field="Email">Email</th>
                        <th data-field="Action">Edit</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptPlayers" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("FirstName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Eval("LastName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>' />
                                </td>
                                <td class="td-align-center">
                                    <a href="PlayerAdd.aspx?rid=<%#Eval("PlayerID") %>">Edit</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>

<asp:Content ID="ctnScript" runat="server" ContentPlaceHolderID="ScriptContainer">
    <script src="//cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>
</asp:Content>

