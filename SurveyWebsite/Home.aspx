<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SurveyWebsite.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" style="text-align: center; font-weight: 700; font-style: italic; text-decoration: underline; font-size: x-large;" Text="Tshimologong Survey Application " ></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">
                    <asp:Image ID="Image1" runat="server" Height="355px" ImageUrl="~/photos/download.png" Width="412px" />
                </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Height="40px" style="border-color:aqua" Text="Fill Out Survey" Width="135px" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Height="40px" Text="View Survey Results" style="border-color:aqua" Width="135px" OnClick="Button2_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 333px">&nbsp;</td>
            <td style="width: 412px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
       
    </table>
</asp:Content>
