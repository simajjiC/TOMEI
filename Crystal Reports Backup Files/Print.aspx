<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Print" MasterPageFile="../Standard.master" Codebehind="Print.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
    <asp:Panel ID="Panel1" runat="server">
<%--        <dxe:ASPxLabel ID="lblCertificateNo" runat="server" Text="Certificate No">
        </dxe:ASPxLabel>  --%>      
<%--        <dxe:ASPxComboBox ID="ddlCertificateNo" runat="server">
        </dxe:ASPxComboBox>--%>
           <div style="width:100%;overflow:auto;overflow-x:scroll;">
        <dxwgv:ASPxGridView ID="gv_Cert" runat="server"
        AutoGenerateColumns="False" DataSourceID="ds_Cert" Width="400px" KeyFieldName="CertificateNo">
        <SettingsPager PageSize="20" />
        <Settings ShowFilterRow="True" />
        <Columns>
            <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CertificateNo" VisibleIndex="1" 
                ReadOnly="True" Caption="Certificate No" CellStyle-HorizontalAlign="Left">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductNo" VisibleIndex="2" Caption="Product No">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CategoryCode" VisibleIndex="3" Caption="Category Code">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SubCategoryCode" VisibleIndex="4" Caption="Sub Category Code">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Printed" VisibleIndex="5" Caption="Printed">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CreatedBy" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn FieldName="CreatedDate" VisibleIndex="7">
            </dxwgv:GridViewDataDateColumn>
        </Columns>
        </dxwgv:ASPxGridView>
        </div> 
        <asp:RadioButtonList ID="rblReportType" runat="server">
            <%--<asp:ListItem Text="2 Fold Normal" Value="A2" Selected="True">
            </asp:ListItem>
            <asp:ListItem Text="3 Fold Normal" Value="A3">
            </asp:ListItem>--%>
            <asp:ListItem Text="2 Fold Pre Printed" Value="B2" Selected="True">
            </asp:ListItem>
            <asp:ListItem Text="3 Fold Pre Printed" Value="B3">
            </asp:ListItem>
        </asp:RadioButtonList>
        <dxe:ASPxButton ID="btnShow" runat="server" Text="Show" onclick="btnShow_Click">
        </dxe:ASPxButton>
        <asp:SqlDataSource ID="ds_Cert" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"            
    SelectCommand="SELECT T_Certificate.CertificateNo, T_Certificate.ProductNo, T_ProductCategory.CategoryCode, T_ProductSubCategory.SubCategoryCode, T_Certificate.CreatedDate, T_Certificate.CreatedBy ,Case when T_Certificate.PrintCount > 0 then 'Y' else 'N' end as Printed  FROM T_ProductSubCategory INNER JOIN T_Certificate INNER JOIN T_ProductSeries ON T_Certificate.ProductSeries = T_ProductSeries.id INNER JOIN T_ProductCategory ON T_ProductSeries.ProductCategory = T_ProductCategory.id ON T_ProductSubCategory.id = T_ProductSeries.ProductSubCategory where T_Certificate.Status = 1 order by T_Certificate.CertificateNo desc">
    </asp:SqlDataSource>
    </asp:Panel>

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
