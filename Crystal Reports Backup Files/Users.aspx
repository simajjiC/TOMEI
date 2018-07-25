<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Users" MasterPageFile="../Standard.master" Codebehind="Users.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">    
    <dxe:ASPxLabel ID="lblRecordStatus" runat="server" Text="" ForeColor="#c00000">
    </dxe:ASPxLabel>
       <div style="width:100%;overflow:auto;overflow-x:scroll;"> 
    <dxwgv:ASPxGridView ID="gv_Users" runat="server" ClientInstanceName="gv_Users_c"
        AutoGenerateColumns="False" DataSourceID="ds_Users"
        KeyFieldName="UserID" Width="400px" 
        OnRowUpdating="gv_Users_RowUpdating" OnRowInserting="gv_Users_RowInserting" OnRowDeleting="gv_Users_RowDeleting"
        OnStartRowEditing="gv_Users_StartRowEditing" OnRowValidating="gv_Users_RowValidating" 
        OnRowInserted="gv_Users_RowInserted" OnRowUpdated="gv_Users_RowUpdated" OnCustomButtonCallback="gv_Users_CustomCallback">
        <SettingsEditing Mode="PopupEditForm" PopupEditFormModal="true"  />
        <Settings ShowStatusBar="Visible" />        
        <SettingsCustomizationWindow PopupHorizontalAlign="WindowCenter" 
            PopupVerticalAlign="WindowCenter" />
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
            <dxwgv:GridViewCommandColumn VisibleIndex="1">
                <CustomButtons>
                    <dxwgv:GridViewCommandColumnCustomButton ID="Activation" Text='Activate/Suspend'></dxwgv:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="UserID" VisibleIndex="2" 
                ReadOnly="True">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="UserName" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Password" VisibleIndex="4">
                <PropertiesTextEdit Password="True">
                </PropertiesTextEdit>
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Status" VisibleIndex="5">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="UserRole" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Templates>
            <EditForm>
            <table cellpadding="10">
            <tr>    
            <td>
                <dxe:ASPxLabel ID="lblUserID" runat="server" Text="User ID:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtUserID" runat="server" Width="170px" Text='<%# Eval("UserID") %>'></dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblUserName" runat="server" Text="User Name:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtUserName" runat="server" Width="170px" Text='<%# Eval("UserName") %>'>
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblPassword" runat="server" Text="Password:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtPassword" runat="server" Width="170px" Text='' Password="true">
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtConfirmPassword" runat="server" Width="170px" Text='' Password="true">
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblUserStatus" runat="server" Text="Status:"></dxe:ASPxLabel><br />
                <asp:DropDownList ID="ddlUserStatus" runat="server"   >
                    <Items>
                        <asp:ListItem Text="Suspend" Value="0" />
                        <asp:ListItem Text="Active" Value="1" />
                    </Items>
                </asp:DropDownList><br />
                <dxe:ASPxLabel ID="lblUserRole" runat="server" Text="Role:"></dxe:ASPxLabel><br />
                <asp:DropDownList ID="ddlUserRole" runat="server">                    
                        <asp:ListItem Text="Administrator" Value="1" />
                        <asp:ListItem Text="Power User" Value="2" />
                        <asp:ListItem Text="User" Value="3" />
                        <asp:ListItem Text="Limited" Value="4" />
                </asp:DropDownList>
                   </td>        
                </tr>
                </table>
                <div style="text-align:right; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                </div>
             
            </EditForm>
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_Users_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>             
    </dxwgv:ASPxGridView>
    </div>  
    <asp:SqlDataSource ID="ds_Users" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        SelectCommand="EXEC S_ListUser"                        
        UpdateCommand="EXEC S_UpdateUser @UserName, @Password, @Status, @UserRole, @adminuserid, @old_UserID"
        InsertCommand="EXEC S_InsertUser @UserName, @Password, @Status, @UserRole, @adminuserid, @UserID" 
        DeleteCommand="EXEC S_DeleteUser @adminuserid, @old_UserID">
        <DeleteParameters>
            <asp:Parameter Name="UserID" Type="String" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Status" Type="Int16" />
            <asp:Parameter Name="UserRole" Type="Int16" />
            <asp:Parameter Name="UserID" Type="String" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="UserID" Type="String" />
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Status" Type="Int16" />
            <asp:Parameter Name="UserRole" Type="Int16" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
