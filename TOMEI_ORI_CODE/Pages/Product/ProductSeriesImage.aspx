<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_ProductSeriesImage" MasterPageFile="../Standard.master" Codebehind="ProductSeriesImage.aspx.cs" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPopupControl"
    TagPrefix="dxpc" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTabControl"
    TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer" TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">

    <script language="javascript" type="text/javascript">
    function OnUpdateClick() {
        uploader.UploadFile();
    }
</script>

    <dxpc:ASPxPopupControl ID="ASPxPopupControl1" runat="server">
    </dxpc:ASPxPopupControl>
       <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_ProductSeries" runat="server" ClientInstanceName="gv_ProductSeries_c"
        AutoGenerateColumns="False" DataSourceID="ds_ProductSeries"
        KeyFieldName="id" Width="400px"
        OnRowUpdating="gv_ProductSeries_RowUpdating" OnRowInserting="gv_ProductSeries_RowInserting" 
        OnStartRowEditing="gv_ProductSeries_StartRowEditing" OnRowValidating="gv_ProductSeries_RowValidating" 
        OnRowInserted="gv_ProductSeries_RowInserted" OnRowUpdated="gv_ProductSeries_RowUpdated" OnCustomJSProperties="gv_ProductSeries_CustomJSProperties" EnableRowsCache="false">
        <SettingsPager PageSize="20" />
        <SettingsEditing Mode="EditFormAndDisplayRow" PopupEditFormModal="true" />
        <Settings ShowStatusBar="Visible" />
        <Settings ShowFilterRow="True" />
        <ClientSideEvents CustomButtonClick="function(s, e) { if(e.buttonID == 'image') { var rowVisIdx = gv_ProductSeries_c.cpId[e.visibleIndex - gv_ProductSeries_c.visibleStartIndex]; window.showModalDialog('ImagePreview.aspx?id='+rowVisIdx);window.location.reload(); }}"/>
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <EditButton Visible="false">
                </EditButton>
                <CustomButtons>
                    <dxwgv:GridViewCommandColumnCustomButton ID="image" Text="Change"></dxwgv:GridViewCommandColumnCustomButton>                    
                </CustomButtons>
            </dxwgv:GridViewCommandColumn>            
            <dxwgv:GridViewDataTextColumn FieldName="id" VisibleIndex="1" 
                ReadOnly="True" Visible="false">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SeriesPrefix" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductCategory" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductSubCategory" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SeriesDescription" VisibleIndex="5" Caption="Series Description<br>(to be print on certificate)">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataBinaryImageColumn FieldName="SeriesImage" VisibleIndex="6">
            </dxwgv:GridViewDataBinaryImageColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dxe:ASPxLabel ID="lblSeriesImage" runat="server" Text="Series Image:"></dxe:ASPxLabel>
                <dxuc:ASPxUploadControl ID="ulcSeriesImage" runat="server" OnFileUploadComplete="ulcSeriesImage_FileUploadComplete" ClientInstanceName="uploader">
                    <ValidationSettings AllowedContentTypes="image/jpeg,image/pjpeg" MaxFileSize="4000000">
                    </ValidationSettings>
                    <%--<ClientSideEvents FileUploadComplete="function(s, e) { if (e.isValid) { imgPreview_c.src = '~/product_image/preview.jpg' }}" />--%>
                    <ClientSideEvents FileUploadComplete="function(s, e) { if (e.isValid) { gv_ProductSeries_c.UpdateEdit(); }}" />
                </dxuc:ASPxUploadControl>
                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Maximum Upload Size is 4MB"></dxe:ASPxLabel><br />
                <dxe:ASPxLabel ID="lblDescription" runat="server" Text="Image will resize to maximum width/height of 300px"></dxe:ASPxLabel>
                <br />
                <div style="text-align:right; padding:2px 2px 2px 2px">                    
                    <%--<dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>--%>
                    <a href="#" onclick="OnUpdateClick()">Save</a>
                    <%--<asp:HyperLink ID="hplSave" runat="server" Enabled="false" onclick="function(s, e) { if (e.isValid) { gv_ProductSeries_c.UpdateEdit(); }}">Preview</asp:HyperLink>--%>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
            <StatusBar>
<%--                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_ProductSeries_c.AddNewRow(); }">
                </dxe:ASPxHyperLink> --%>
                <%--<dxe:ASPxHyperLink ID="hplImgLib" NavigateUrl="~/product_image/" runat="server" Text="Previous Uploaded Image"></dxe:ASPxHyperLink>--%>
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div>
    <asp:SqlDataSource ID="ds_ProductSeries" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [T_ProductSeries].[id] AS [id], [SeriesPrefix], [T_ProductCategory].[CategoryCode] AS [ProductCategory], [T_ProductSubCategory].[SubCategoryCode] AS [ProductSubCategory], [SeriesDescription], case when [SeriesImageResized] is null then (select defaultimageresized from t_system where id = 1) else [SeriesImageResized] end as [SeriesImage] FROM [T_ProductSeries] INNER JOIN [T_ProductCategory] ON [T_ProductSeries].[ProductCategory] = [T_ProductCategory].[id] INNER JOIN [T_ProductSubCategory] ON [T_ProductSeries].[ProductSubCategory] = [T_ProductSubCategory].[id]"                        
        UpdateCommand=""
        InsertCommand="" 
        DeleteCommand="" 
        OnUpdating="ds_ProductSeries_Updating" OnInserting="ds_ProductSeries_Inserting">
        <DeleteParameters>
        </DeleteParameters>
        <UpdateParameters>
        </UpdateParameters>
        <InsertParameters>
        </InsertParameters>
    </asp:SqlDataSource>        
</asp:Content>
