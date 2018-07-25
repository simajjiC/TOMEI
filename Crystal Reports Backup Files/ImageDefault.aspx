<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_ImageDefault" MasterPageFile="../Standard.master" Codebehind="ImageDefault.aspx.cs" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">    
    <dxe:ASPxBinaryImage ID="ASPxBinaryImage1" runat="server">
    </dxe:ASPxBinaryImage>
    <dxe:ASPxButton ID="ASPxButton1" runat="server" Text="Change">
        <ClientSideEvents Click="function (s, e){window.showModalDialog('ImagePreviewDefault.aspx');window.location.reload();}" />
    </dxe:ASPxButton>
</asp:Content>
