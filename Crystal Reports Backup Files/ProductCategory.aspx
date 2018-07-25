<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_ProductCategory" MasterPageFile="../Standard.master" Codebehind="ProductCategory.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer" TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
    <dxe:ASPxLabel ID="lblRecordStatus" runat="server" Text="" ForeColor="#c00000">
    </dxe:ASPxLabel>
       <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_ProductCategory" runat="server" ClientInstanceName="gv_ProductCategory_c"
        AutoGenerateColumns="False" DataSourceID="ds_ProductCategory"
        KeyFieldName="id" Width="400px"
        OnRowUpdating="gv_ProductCategory_RowUpdating" OnRowInserting="gv_ProductCategory_RowInserting" 
        OnStartRowEditing="gv_ProductCategory_StartRowEditing" OnRowValidating="gv_ProductCategory_RowValidating" 
        OnRowInserted="gv_ProductCategory_RowInserted" OnRowUpdated="gv_ProductCategory_RowUpdated">
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
            <dxwgv:GridViewDataTextColumn FieldName="id" VisibleIndex="0" 
                ReadOnly="True" Visible="false">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CategoryCode" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dxe:ASPxLabel ID="lblCategoryCode" runat="server" Text="Category Code:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtCategoryCode" runat="server" Width="170px" Text='<%# Eval("CategoryCode") %>' MaxLength="32">
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblCategoryName" runat="server" Text="Description:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtCategoryName" runat="server" Width="170px" Text='<%# Eval("CategoryName") %>' MaxLength="64">
                </dxe:ASPxTextBox>
                <div style="text-align:right; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_ProductCategory_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div> 
    <asp:SqlDataSource ID="ds_ProductCategory" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [id], [CategoryCode], [CategoryName] FROM [T_ProductCategory]"                        
        UpdateCommand="UPDATE [T_ProductCategory] SET [CategoryCode] = @CategoryCode, [CategoryName] = @CategoryName, [UpdatedBy] = @userid, [UpdatedDate] = getdate() WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Product Category', 'Updated Existing Product Category for ' + '(' + ') to ' + @CategoryCode + '(' + @CategoryName + ')');"
        InsertCommand="INSERT INTO [T_ProductCategory] ([CategoryCode], [CategoryName], [CreatedBy]) VALUES (@CategoryCode, @CategoryName, @userid);INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Product Category', 'Inserted new Product Category for ' + @CategoryCode + '(' + @CategoryName + ')');" 
        DeleteCommand="EXEC S_DeleteProductCategory @old_id, @userid">
        <DeleteParameters>
            <asp:Parameter Name="old_id" Type="Int16" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="CategoryCode" Type="String" />
            <asp:Parameter Name="CategoryName" Type="String" />
            <asp:Parameter Name="old_id" Type="Int16" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int16" />
            <asp:Parameter Name="CategoryCode" Type="String" />
            <asp:Parameter Name="CategoryName" Type="String" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>        
</asp:Content>
