<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="Karate.mywork.member" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="first name"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="label"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="last name"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <asp:GridView ID="GridView1" runat="server" Height="175px" Width="532px">
    </asp:GridView>
    <p>
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
