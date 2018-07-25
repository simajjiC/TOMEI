<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Login" MasterPageFile="Standard.master" Codebehind="Login.aspx.cs" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
<table style="WIDTH: 100%">
    <tr align="center">
        <td runat="server" id="Td12" style="WIDTH: 15%; HEIGHT: 24px; TEXT-ALIGN: left">
            &nbsp;
        </td>
        <td runat="server" id="Td2" style="WIDTH: 57%; HEIGHT: 24px; TEXT-ALIGN: left" colspan="1">
            <asp:Label runat="server" ForeColor="#C00000" id="lblStatus"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="TEXT-ALIGN: left">
            <asp:Label runat="server" id="lblUserID">User ID</asp:Label>
        </td>
        <td style="TEXT-ALIGN: left">
            <asp:TextBox runat="server" Width="232px" id="txtUserID"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvUserID" runat="server" ErrorMessage="User ID is blank!" ControlToValidate="txtUserID" ForeColor="#C00000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="TEXT-ALIGN: left">
            <asp:Label runat="server" id="lblPassword">Password</asp:Label>
        </td>
        <td style="TEXT-ALIGN: left">
            <asp:TextBox runat="server" Width="232px" id="txtPassword" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator id="rfvPassword" runat="server" ErrorMessage="Password is blank!" ControlToValidate="txtPassword" ForeColor="#C00000"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            <dxe:ASPxButton ID="btnLogin" runat="server" Text="Login"></dxe:ASPxButton>
        </td>
    </tr>
</table>
</asp:Content>
