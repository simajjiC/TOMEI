<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Create"  MasterPageFile="../Standard.master" Codebehind="Create.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
  
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
    <dxe:ASPxLabel ID="lblStatus" runat="server" Text="">
    </dxe:ASPxLabel>
    <dxe:ASPxLabel ID="lblProductNo" runat="server" Text="Product Barcode No" >
    </dxe:ASPxLabel>
    <dxe:ASPxTextBox ID="txtProductNo" runat="server" Width="170px"   >

    </dxe:ASPxTextBox>
<%--  <asp:RequiredFieldValidator ID="rfvProductNo" runat="server"   ErrorMessage="Product No is blank!"  ControlToValidate="txtProductNo" ></asp:RequiredFieldValidator>
--%>      <asp:CustomValidator ID="BarcodeCheck" runat="server" OnServerValidate="BarcodeValidate" 
        ControlToValidate="txtProductNo" ErrorMessage="Product Barcode No is Not required!"></asp:CustomValidator>
    <br />
    <asp:CustomValidator ID="BarcodeCheckProductGroupCode" runat="server" OnServerValidate="BarcodeMatchValidate" 
        ControlToValidate="txtProductNo" ErrorMessage="Product Group Code not Existed! Please add ProductGroupCode in Product Group Page first!"></asp:CustomValidator>
    &nbsp;<br /><dxe:ASPxLabel ID="lblEmptyMsg" runat="server" ForeColor="Red"  Text=""></dxe:ASPxLabel>
    <br />
    <asp:RegularExpressionValidator ID="validatorBarcodeNumber" runat="server" 
            ControlToValidate="txtProductNo" Display="Dynamic" 
            ErrorMessage="Product Barcode format is invalid" ValidationExpression="[a-zA-Z]{1}[a-zA-Z0-9]{1}\d{7}">Invalid Barcode Format Entered,e.g DD1234567 or D31234567,Please try again!</asp:RegularExpressionValidator><br />
    <asp:CustomValidator ID="ctvProductNo" runat="server" OnServerValidate="ProductNoValidate"
        ControlToValidate="txtProductNo" ErrorMessage="Duplicate record found,please enter the correct Barcode No." ></asp:CustomValidator>
    <br />
    <dxe:ASPxLabel ID="lblProductSeries" runat="server" Text="Product Series">
    </dxe:ASPxLabel><br />
 <%--   <asp:DropDownList ID="ddlProductSeries" runat="server" 
       EnableViewState="True" EnableIncrementalFiltering="True"  onselectedindexchanged="ddlProductSeries_SelectedIndexChanged"   AutoPostBack="true"
       >
    </asp:DropDownList>--%>
&nbsp;<dxe:ASPxComboBox ID="ddlProductSeries" runat="server" 
       EnableViewState="True" EnableIncrementalFiltering="True"  onselectedindexchanged="ddlProductSeries_SelectedIndexChanged"   AutoPostBack="true"  PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight"
       >
    </dxe:ASPxComboBox>
       <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_Stone" runat="server"  
        AutoGenerateColumns="False" DataSourceID="ds_Stone" Width="400px" 
    KeyFieldName="StoneID">
        <SettingsPager PageSize="20" />
        <SettingsEditing Mode="PopupEditForm" />
        <Columns>
            <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="StoneID" VisibleIndex="1" 
                ReadOnly="True">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Weight" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Clarity" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Colour" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Fluorescence" VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Girdle" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Polish" VisibleIndex="7">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Symmetry" VisibleIndex="8">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Depth" VisibleIndex="9" 
                Caption="Depth %">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Size" 
                VisibleIndex="10" Caption="Table">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Measurement_1" Caption="Min"
                VisibleIndex="11">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Measurement_2" Caption="Max"
                VisibleIndex="12">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Measurement_3" Caption="T.D"
                VisibleIndex="13">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CreatedBy" 
                VisibleIndex="14">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn FieldName="CreatedDate" 
                VisibleIndex="15">
            </dxwgv:GridViewDataDateColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CertificateNo" VisibleIndex="16" Visible="false">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings ShowFilterRow="True" />
    </dxwgv:ASPxGridView>
    </div> 
    <dxe:ASPxButton ID="btnCreate" runat="server" Text="Create Certificate" Width="200"
        onclick="btnCreate_Click" >
    </dxe:ASPxButton>
    <%--<asp:SqlDataSource ID="ds_Stone" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"        
    
    SelectCommand="SELECT [StoneID],  Cast(Round(Weight,2) as Numeric(10,2)) as [Weight] , [Clarity], [Colour], [Fluorescence], [Girdle], [Polish], [Symmetry], Cast(Cast(Depth as Numeric(10,1)) as varchar(12))+ '%' as [Depth], CAST(Round(Size,0) AS varchar(12))+ '%' as [Size],  Cast(Measurement_1 as Numeric(10,2)) as [Measurement_1], Cast(Measurement_2 as Numeric(10,2)) as [Measurement_2], Cast(Measurement_3 as Numeric(10,2)) as [Measurement_3], [CreatedBy], [CreatedDate], [CertificateNo] FROM [Normal_View] WHERE [status] = 0;">
    </asp:SqlDataSource>--%>

    <asp:SqlDataSource ID="ds_Stone" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"        
    
    SelectCommand="SELECT [StoneID],   case stoneid when 'NIL' then CAST([Weight] AS char(20)) else convert(char(20),Cast(Round(Weight,2) as float) ) end as [Weight] , [Clarity], [Colour], [Fluorescence], [Girdle], [Polish], [Symmetry], Cast(Cast(Depth as Numeric(10,2)) as varchar(12))+ '%' as [Depth], CAST(Round(Size,0) AS varchar(12))+ '%' as [Size],  Cast(Measurement_1 as Numeric(10,2)) as [Measurement_1], Cast(Measurement_2 as Numeric(10,2)) as [Measurement_2], Cast(Measurement_3 as Numeric(10,2)) as [Measurement_3], [CreatedBy], [CreatedDate], [CertificateNo],[GUID] FROM [Normal_View] WHERE [status] = 0;">
    </asp:SqlDataSource>
</asp:Content>