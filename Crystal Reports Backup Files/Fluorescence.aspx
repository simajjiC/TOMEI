<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Fluorescence" MasterPageFile="../Standard.master" Codebehind="Fluorescence.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">
   <div style="width:100%;overflow:auto;overflow-x:scroll;">
    <dxwgv:ASPxGridView ID="gv_Fluorescence" runat="server" ClientInstanceName="gv_Fluorescence_c"
        AutoGenerateColumns="False" DataSourceID="ds_Fluorescence"
        KeyFieldName="id" Width="400px" 
        OnRowUpdating="gv_Fluorescence_RowUpdating" OnRowInserting="gv_Fluorescence_RowInserting"
        OnStartRowEditing="gv_Fluorescence_StartRowEditing" OnRowValidating="gv_Fluorescence_RowValidating"
        OnRowInserted="gv_Fluorescence_RowInserted" OnRowUpdated="gv_Fluorescence_RowUpdated">
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="true"/>
        <SettingsPager PageSize="20" />
        <Settings ShowStatusBar="Visible" />
        <SettingsBehavior ConfirmDelete="true" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <EditButton Visible="True">
                </EditButton>
                
            </dxwgv:GridViewCommandColumn>
             <dxwgv:GridViewCommandColumn VisibleIndex="0">
             <DeleteButton Visible="True">
                </DeleteButton>
                 </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="id" VisibleIndex="1" 
                ReadOnly="True" Visible="false">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="value" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="description" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
            <table cellpadding="10"><tr><td>
                <dxe:ASPxLabel ID="lblFluorescence" runat="server" Text="Fluorescence:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtFluorescence" runat="server" Width="170px" Text='<%# Eval("value") %>'>
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblDescription" runat="server" Text="Description:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtDescription" runat="server" Width="170px" Text='<%# Eval("description") %>'>
                </dxe:ASPxTextBox>
                </td></tr></table>
                <div style="text-align:right; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_Fluorescence_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div> 
    <asp:SqlDataSource ID="ds_Fluorescence" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [id], [value], [description] FROM [T_Fluorescence]"                        
        UpdateCommand="UPDATE [T_Fluorescence] SET [value] = @value, [description] = @description WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Updated Existing Fluorescence for ' + @old_value + '(' + case when @old_description is null then '' else @old_description end + ') to ' + @value + '(' + case when @description is null then '' else @description end + ')');"
        InsertCommand="INSERT INTO [T_Fluorescence] ([value], [description]) VALUES (@value, @description);INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Inserted new Fluorescence for ' + @value + '(' + case when @description is null then '' else @description end + ')');" 
        DeleteCommand="INSERT INTO [T_Attributes_Deleted] SELECT [id], 'Fluorescence', [value], [description] FROM [T_Fluorescence] WHERE [id] = @old_id; DELETE FROM [T_Fluorescence] WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Deleted Fluorescence for ID ' + CAST(@old_id AS varchar(12)));"
        ConflictDetection="CompareAllValues">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Byte" />
             <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="id" Type="Byte" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />            
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="value" Type="String" />
            <asp:Parameter Name="description" Type="String" />
            <asp:SessionParameter Name="userid" SessionField="UserID" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
