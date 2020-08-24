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
            <table id="matchs" class="display" style="width: 100%">
                <thead>
                    <tr>
                        <th data-field="FirstName">First Name</th>
                        <th data-field="LastName">Last Name</th>
                        <th data-field="Email">Email</th>
                        <th data-field="Action">Edit</th>
                    </tr>
                </thead>

            </table>
        </div>
    </div>

</asp:Content>

<asp:Content ID="ctnScript" runat="server" ContentPlaceHolderID="ScriptContainer">
    <script src="//cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#matchs').DataTable({
                "processing": true,
                "ajax": {
                    "url": "http://localhost:53530/Players/GetAll",
                    "type": "POST",
                    "dataType": 'json',
                    "dataSrc": function (json) {
                        return json;
                    }
                },
                "columns": [
                    { "data": "FirstName" },
                    { "data": "LastName" },
                    { "data": "Email" }
                ],
                "columnDefs": [{
                    "targets": 3,
                    "render": function (data, type, row, meta) {
                        return '<a href="/AdminPages/PlayerAdd?rid=' + row.PlayerID + '">Edit</a>';
                    }
                }]
            });
        });

    </script>

</asp:Content>

