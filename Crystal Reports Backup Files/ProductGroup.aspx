<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_ProductGroup" MasterPageFile="../Standard.master" Codebehind="ProductGroup.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer" TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
    <dxe:ASPxLabel ID="lblRecordStatus" runat="server" Text="" ForeColor="#c00000">
    </dxe:ASPxLabel>

   
       <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_ProductGroup" runat="server" ClientInstanceName="gv_ProductGroup_c"
        AutoGenerateColumns="False" DataSourceID="ds_ProductGroup"
        KeyFieldName="id" Width="400px"
        OnRowUpdating="gv_ProductGroup_RowUpdating" OnRowInserting="gv_ProductGroup_RowInserting" 
        OnStartRowEditing="gv_ProductGroup_StartRowEditing" OnRowValidating="gv_ProductGroup_RowValidating" 
        OnRowInserted="gv_ProductGroup_RowInserted" OnRowUpdated="gv_ProductGroup_RowUpdated">
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
            <dxwgv:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" 
                ReadOnly="True" Visible="false">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductGroupCode" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="ProductGroupDescription" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
                <dxe:ASPxLabel ID="lblProductGroupCode" runat="server" Text="Product Group Code:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtProductGroupCode" runat="server" Width="170px" Text='<%# Eval("ProductGroupCode") %>' MaxLength="32">
                </dxe:ASPxTextBox>
                 

                <dxe:ASPxLabel ID="lblProductGroupDescription" runat="server" Text="Product Group Description:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtProductGroupDescription" runat="server" Width="170px" Text='<%# Eval("ProductGroupDescription") %>' MaxLength="64">
                </dxe:ASPxTextBox>
                <div style="text-align:right; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_ProductGroup_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div> 
    <asp:SqlDataSource ID="ds_ProductGroup" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [id], [ProductGroupCode], [ProductGroupDescription] FROM [T_ProductGroup]"                        
        UpdateCommand="UPDATE [T_ProductGroup] SET [ProductGroupCode] = @ProductGroupCode, [ProductGroupDescription] = @ProductGroupDescription, [UpdatedBy] = @userid, [UpdatedDate] = getdate() WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action], [action_datetime]) VALUES (@userid, 'Product Group', 'Updated Existing Product Group for ' + '(' + ') to ' + @ProductGroupCode + '(' + @ProductGroupDescription + ')', getdate());"
        InsertCommand="INSERT INTO [T_ProductGroup] ([ProductGroupCode], [ProductGroupDescription], [CreatedBy], [CreatedDate]) VALUES (@ProductGroupCode, @ProductGroupDescription, @userid, getdate());INSERT INTO [T_Action] ([userid], [category], [action], [action_datetime]) VALUES (@userid, 'Product Group', 'Inserted new Product Group for ' + @ProductGroupCode + '(' + @ProductGroupDescription + ')',getdate());" 
        DeleteCommand="EXEC S_DeleteProductGroup @old_id, @userid">
        <DeleteParameters>
            <asp:Parameter Name="old_id" Type="Int16" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="ProductGroupCode" Type="String" />
            <asp:Parameter Name="ProductGroupDescription" Type="String" />
            <asp:Parameter Name="old_id" Type="Int16" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int16" />
            <asp:Parameter Name="ProductGroupCode" Type="String" />
            <asp:Parameter Name="ProductGroupDescription" Type="String" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>        
</asp:Content>
