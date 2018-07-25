<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_DataUpload" MasterPageFile="../Standard.master" Codebehind="DataUpload.aspx.cs" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v9.1" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
    
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">

<table style="WIDTH: 100%">
<tr>
    <td>
        <asp:FileUpload ID="ulcExcel" runat="server" />
        <dxe:ASPxButton ID="btnUpload" runat="server" Text="Upload" 
            onclick="btnUpload_Click">
        </dxe:ASPxButton>
        <dxe:ASPxLabel ID="lblStatus" runat="server"></dxe:ASPxLabel>
        <dxe:ASPxMemo ID="txtLog" runat="server" Height="200px" Width="300px">
        </dxe:ASPxMemo>
        
    </td>
</tr>
</table>             
</asp:Content>
