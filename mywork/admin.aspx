<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Karate.mywork.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Members:"></asp:Label>
        </td>
        <td>Insert Member or Instructor:</td>
        <td>&nbsp;</td>
        <td>Assign Member to Section:</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="memberGridView" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Height="139px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="406px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="First Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="firstNameText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Last Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lastNameText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Password:"></asp:Label>
            &nbsp;&nbsp;&nbsp; &nbsp;
            <asp:TextBox ID="passwordText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Section ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="sectionMemberText" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="Phone Number:"></asp:Label>
&nbsp;
            <asp:TextBox ID="phoneText" runat="server" Width="101px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="addMemberButton" runat="server" Height="66px" OnClick="Button1_Click" Text="Add Member" Width="125px" />
            <br />
            <br />
            <asp:Button ID="addInstructorButton" runat="server" Height="66px" OnClick="Button2_Click" Text="Add Instructor" Width="125px" />
        </td>
        <td>
            <asp:Label ID="Label10" runat="server" Text="User ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="assignUserIDText" runat="server" Width="129px"></asp:TextBox>
            <br />
            <br />
            Section ID:&nbsp;&nbsp;
            <asp:TextBox ID="assignSectionText" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="assignButton" runat="server" Text="Assign Section" Width="207px" OnClick="assignButton_Click" />
            <br />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" style="font-size: x-large" Text="Instructors:"></asp:Label>
        </td>
        <td>Member Only:</td>
        <td>Delete Member or Instructor:</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="instructorGridView" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="instructorGridView_SelectedIndexChanged" Width="404px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
        </td>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="emailText" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
        </td>
        <td>
            <asp:Label ID="Label9" runat="server" Text="User ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="deleteUserIDText" runat="server" Width="81px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="deleteButton" runat="server" Text="Delete User" Width="181px" OnClick="deleteButton_Click" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
