<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Void" MasterPageFile="../Standard.master" Codebehind="Void.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
<%--        <dxe:ASPxLabel ID="lblCertificateNo" runat="server" Text="Certificate No">
        </dxe:ASPxLabel>    --%>    
<%--        <dxe:ASPxComboBox ID="ddlCertificateNo" runat="server">
        </dxe:ASPxComboBox>--%>
           <div style="width:100%;overflow:auto;overflow-x:scroll;">
        <dxwgv:ASPxGridView ID="gv_Cert" runat="server"
        AutoGenerateColumns="False" DataSourceID="ds_Cert" Width="400px" KeyFieldName="CertificateNo">
        <SettingsPager PageSize="20" />
        <Settings ShowFilterRow="True" />
        <SettingsBehavior ConfirmDelete="true" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <DeleteButton Visible="true" Text="Void"></DeleteButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CertificateNo" VisibleIndex="1" 
                ReadOnly="True" CellStyle-HorizontalAlign="Left">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductNo" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CategoryCode" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SubCategoryCode" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn FieldName="CreatedDate" VisibleIndex="5">
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        </dxwgv:ASPxGridView> 
        </div>        
        <asp:SqlDataSource ID="ds_Cert" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"
        OldValuesParameterFormatString="old_{0}"            
        SelectCommand="SELECT T_Certificate.CertificateNo, T_Certificate.ProductNo, T_ProductCategory.CategoryCode, T_ProductSubCategory.SubCategoryCode, T_Certificate.CreatedDate, T_Certificate.CreatedBy FROM T_ProductSubCategory INNER JOIN T_Certificate INNER JOIN T_ProductSeries ON T_Certificate.ProductSeries = T_ProductSeries.id INNER JOIN T_ProductCategory ON T_ProductSeries.ProductCategory = T_ProductCategory.id ON T_ProductSubCategory.id = T_ProductSeries.ProductSubCategory where T_Certificate.Status = 1 order by T_Certificate.CertificateNo desc" 
        DeleteCommand="EXEC S_VoidCertificate @old_CertificateNo, @VoidBy">
        <DeleteParameters>
                <asp:Parameter Name="old_CertificateNo" Type="String" />
                <asp:SessionParameter Name="VoidBy" SessionField="UserID" Type="String" />
        </DeleteParameters>
        </asp:SqlDataSource>
    </asp:Panel>

    <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" Visible="false" HasToggleGroupTreeButton="False" HasDrillUpButton="False" DisplayGroupTree="False"/>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
