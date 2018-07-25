<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Polish" MasterPageFile="../Standard.master" Codebehind="Polish.aspx.cs" %>
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
    <dxwgv:ASPxGridView ID="gv_Polish" runat="server" ClientInstanceName="gv_Polish_c"
        AutoGenerateColumns="False" DataSourceID="ds_Polish"
        KeyFieldName="id" Width="400px" 
        OnRowUpdating="gv_Polish_RowUpdating" OnRowInserting="gv_Polish_RowInserting" 
        OnStartRowEditing="gv_Polish_StartRowEditing" OnRowValidating="gv_Polish_RowValidating"
        OnRowInserted="gv_Polish_RowInserted" OnRowUpdated="gv_Polish_RowUpdated">
        <SettingsPager PageSize="20" />
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="true"/>
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
                <dxe:ASPxLabel ID="lblPolish" runat="server" Text="Polish:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtPolish" runat="server" Width="170px" Text='<%# Eval("value") %>'>
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
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_Polish_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div>
    <asp:SqlDataSource ID="ds_Polish" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="SELECT [id], [value], [description] FROM [T_Polish]"                        
        UpdateCommand="UPDATE [T_Polish] SET [value] = @value, [description] = @description WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Updated Existing Polish for ' + @old_value + '(' + case when @old_description is null then '' else @old_description end + ') to ' + @value + '(' + case when @description is null then '' else @description end + ')');"
        InsertCommand="INSERT INTO [T_Polish] ([value], [description]) VALUES (@value, @description);INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Inserted new Polish for ' + @value + '(' + case when @description is null then '' else @description end + ')');" 
        DeleteCommand="INSERT INTO [T_Attributes_Deleted] SELECT [id], 'Polish', [value], [description] FROM [T_Polish] WHERE [id] = @old_id; DELETE FROM [T_Polish] WHERE [id] = @old_id;INSERT INTO [T_Action] ([userid], [category], [action]) VALUES (@userid, 'Attributes', 'Deleted Polish for ID ' + CAST(@old_id AS varchar(12)));"
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
