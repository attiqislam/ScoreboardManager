<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ScoreboardManager.WebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>About this project.</h3>
    <p>
        This project is an example of n-tier architecture based on C#, ASP.Net Web Forms. 
        For the sake of smiplicity, I haven't use any security feature in this project, so please implement your own security technologies.
        Moreover, I haven't use any modern UI and caching technologies for the same as well. 
    </p>
    <p> This project is licensed under Apache License 2.0 and permitted for Commercial use, Modification, Distribution, and Private use</p>
    <p>
        If you need any help, you can reach me through <a href='https://www.linkedin.com/in/attiq-ul-islam-31846034' target="_blank">LinkedIn</a>, I will try to answer your queries.
    </p>
</asp:Content>
