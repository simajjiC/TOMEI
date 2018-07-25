<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_ProductSeries" MasterPageFile="../Standard.master" Codebehind="ProductSeries.aspx.cs" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
    TagPrefix="dxcp" %>

<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTabControl"
    TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer" TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
<%--<script language="javascript" type="text/javascript">
    function OnUpdateClick() {
        uploader.UploadFile();
    }
</script>--%>
   <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_ProductSeries" runat="server" ClientInstanceName="gv_ProductSeries_c"
        AutoGenerateColumns="False" DataSourceID="ds_ProductSeries"
        KeyFieldName="id" Width="400px"
        OnRowUpdating="gv_ProductSeries_RowUpdating" OnRowInserting="gv_ProductSeries_RowInserting" 
        OnStartRowEditing="gv_ProductSeries_StartRowEditing" OnRowValidating="gv_ProductSeries_RowValidating" 
        OnRowInserted="gv_ProductSeries_RowInserted" OnRowUpdated="gv_ProductSeries_RowUpdated" EnableRowsCache="false">
        <SettingsPager PageSize="20" />
        <SettingsEditing Mode="EditFormAndDisplayRow" PopupEditFormModal="true" />
        <Settings ShowStatusBar="Visible" />
        <SettingsBehavior ConfirmDelete="true" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <EditButton Visible="True"> 
                </EditButton>

            </dxwgv:GridViewCommandColumn>
                        <dxwgv:GridViewCommandColumn VisibleIndex="0">

                <DeleteButton Visible="true">
                </DeleteButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="id" VisibleIndex="1" 
                ReadOnly="True" Visible="false">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SeriesPrefix" VisibleIndex="2" 
                Caption="Remarks">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductCategory" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductSubCategory" VisibleIndex="4">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SeriesDescription" VisibleIndex="5" 
                Caption="Series Code&lt;br&gt;(to be print on certificate)">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataBinaryImageColumn FieldName="SeriesImage" VisibleIndex="6">
                <PropertiesBinaryImage ImageWidth="100px" IsPng="True">
                </PropertiesBinaryImage>
            </dxwgv:GridViewDataBinaryImageColumn>
             <dxwgv:GridViewDataTextColumn FieldName="BarcodeFlag" VisibleIndex="7"  
                Caption="Barcode Flag">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dxe:ASPxLabel ID="lblProductCategory" runat="server" Text="Product Category:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlProductCategory"   runat="server" OnLoad="ddlProductCategory_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">
                <ClientSideEvents SelectedIndexChanged="function(s, e) {PanelDescription.PerformCallback();}"/>                   
                </dxe:ASPxComboBox>
                <dxe:ASPxLabel ID="lblProductSubCategory"  runat="server" Text="Product Sub Category:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlProductSubCategory" runat="server" OnLoad="ddlProductSubCategory_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                    
                <ClientSideEvents SelectedIndexChanged="function(s, e) {PanelDescription.PerformCallback();}"/>
                </dxe:ASPxComboBox>                
                <dxe:ASPxLabel ID="lblSeriesPrefix" runat="server" Text="Remarks:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtSeriesPrefix" runat="server" Width="170px" Text='<%# Eval("SeriesPrefix") %>' MaxLength="255">
                </dxe:ASPxTextBox>
                <dxcp:ASPxCallbackPanel ID="PanelDescription" runat="server" Width="200px" ClientInstanceName="PanelDescription" OnCallback="PanelDescription_Callback">
                <PanelCollection>
                    <dxrp:PanelContent>
                <dxe:ASPxLabel ID="lblSeriesDescription" runat="server" Text="Series Code:"></dxe:ASPxLabel>
                <dxe:ASPxMemo ID="txtSeriesDescription" runat="server" Width="170px" MaxLength="255" Text='<%# Eval("SeriesDescription") %>' >
                </dxe:ASPxMemo>                                    
                    </dxrp:PanelContent>
                </PanelCollection>
                </dxcp:ASPxCallbackPanel>
                <dxe:ASPxLabel ID="lblBarcode" runat="server" Text="Barcode:"></dxe:ASPxLabel>
                <dxe:ASPxCheckBox ID="ASPxCheckBoxBarcode" runat="server"  Width="170px"   Checked='<%# GenerateBindString(Container.DataItem) %>'    >
 
                </dxe:ASPxCheckBox>
<%--                <dxe:ASPxLabel ID="lblSeriesImage" runat="server" Text="Series Image:"></dxe:ASPxLabel>
                <dxuc:ASPxUploadControl ID="ulcSeriesImage" runat="server" OnFileUploadComplete="ulcSeriesImage_FileUploadComplete" ClientInstanceName="uploader">
                    <ValidationSettings AllowedContentTypes="image/jpeg,image/pjpeg" MaxFileSize="4000000">
                    </ValidationSettings>
                </dxuc:ASPxUploadControl>--%>
                <div style="text-align:right; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
            
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_ProductSeries_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div> 
    <asp:SqlDataSource ID="ds_ProductSeries" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [T_ProductSeries].[id] AS [id], [SeriesPrefix], [T_ProductCategory].[CategoryCode] AS [ProductCategory], [T_ProductSubCategory].[SubCategoryCode] AS [ProductSubCategory], [SeriesDescription], case when [SeriesImageResized] is null then (select defaultimageresized from t_system where id = 1) else [SeriesImageResized] end as [SeriesImage],case when [BarcodeFlag] = 1 then 'True' else 'False' end as [BarcodeFlag] FROM [T_ProductSeries] INNER JOIN [T_ProductCategory] ON [T_ProductSeries].[ProductCategory] = [T_ProductCategory].[id] INNER JOIN [T_ProductSubCategory] ON [T_ProductSeries].[ProductSubCategory] = [T_ProductSubCategory].[id]"                        
        UpdateCommand="UPDATE [T_ProductSeries] SET [SeriesDescription] = @SeriesDescription, [ProductSubCategory] = @ProductSubCategory, [ProductCategory] = @ProductCategory, [SeriesPrefix] = @SeriesPrefix, [UpdatedBy] = @UserID, [BarcodeFlag] = @BarcodeFlag ,[UpdatedDate] = getdate() WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Product Series', 'Updated Product Series for ' + @SeriesDescription + '(' + @SeriesPrefix + ')');"
        InsertCommand="INSERT INTO [T_ProductSeries] ([SeriesDescription], [ProductSubCategory], [ProductCategory], [SeriesPrefix], [CreatedBy],[BarcodeFlag]) VALUES (@SeriesDescription, @ProductSubCategory, @ProductCategory, @SeriesPrefix, @UserID,@BarcodeFlag);INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Product Series', 'Inserted new Product Series for ' + @SeriesDescription + '(' + @SeriesPrefix + ')');" 
        DeleteCommand="EXEC S_DeleteProductSeries @old_id, @userid" 
        OnUpdating="ds_ProductSeries_Updating" OnInserting="ds_ProductSeries_Inserting">
        <DeleteParameters>
            <asp:Parameter Name="old_id" Type="Int32" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="SeriesDescription" Type="String" />
            <asp:Parameter Name="ProductSubCategory" Type="Int16" />
            <asp:Parameter Name="ProductCategory" Type="Int16" />
            <asp:Parameter Name="SeriesPrefix" Type="String" />
            <asp:Parameter Name="BarcodeFlag" Type="boolean" />
            <asp:Parameter Name="old_id" Type="Int32" />
            <asp:SessionParameter Name="UserID" SessionField="UserID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="SeriesDescription" Type="String" />
            <asp:Parameter Name="ProductSubCategory" Type="Int16" />
            <asp:Parameter Name="ProductCategory" Type="Int16" />
            <asp:Parameter Name="SeriesPrefix" Type="String" />
            <asp:Parameter Name="BarcodeFlag" Type="boolean" />
            <asp:SessionParameter Name="UserID" SessionField="UserID" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>        
</asp:Content>
