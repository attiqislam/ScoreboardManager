<%@ Page Title="Match List" Language="C#" AutoEventWireup="true" CodeBehind="MatchList.aspx.cs" Inherits="ScoreboardManager.WebForms.AdminPages.MatchList" MasterPageFile="~/Site.Master" %>

<asp:Content ID="cntHead" runat="server" ContentPlaceHolderID="cphHead">
    <link href="//cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ctnMain" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <div class="content-area">
            <div class="title text-center">
                <h2><%: Title %></h2>
                <h4>List of all matchs</h4>
                <hr />
            </div>
            <table id="matchs" class="display" style="width: 100%">
                <thead>
                    <tr>
                        <th data-field="MatchName">Match Name</th>
                        <th data-field="MatchVenue">Match Venue</th>
                        <th data-field="MatchDateTime">Match Date Time</th>
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
                    "url": "http://localhost:53530/Matchs/GetAll",
                    "type": "POST",
                    "dataType": 'json',
                    "dataSrc": function (json) {
                        return json;
                    }
                },
                "columns": [
                    { "data": "MatchName" },
                    { "data": "MatchVenue" },
                    { "data": "MatchDateTime" },
                    { "data": "Action" }
                ],
                "columnDefs": [{
                    "targets": 3,
                    "render": function (data, type, row, meta) {
                        return '<a href="/AdminPages/MatchAdd?rid=' + row.MatchID + '">Edit</a>';
                    }
                }]
            });
        });

    </script>

</asp:Content>
