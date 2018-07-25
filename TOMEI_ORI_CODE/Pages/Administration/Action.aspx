<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Action" MasterPageFile="../Standard.master" Codebehind="Action.aspx.cs" %>
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
    <dxwgv:ASPxGridView ID="gv_Activity" runat="server" ClientInstanceName="gv_Activity_c"
        AutoGenerateColumns="False" DataSourceID="ds_Activity" Width="800px">
        <SettingsPager PageSize="20" />
        <Settings ShowStatusBar="Visible" showfilterrow="True" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="category" VisibleIndex="1">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="userid" VisibleIndex="2">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="action" VisibleIndex="3">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn FieldName="action_datetime" VisibleIndex="4">
            </dxwgv:GridViewDataDateColumn>
        </Columns>
        <Templates>
            <StatusBar>            
            </StatusBar>
        </Templates>      
    </dxwgv:ASPxGridView>   
    </div>    
    <asp:SqlDataSource ID="ds_Activity" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>" 
        OldValuesParameterFormatString="old_{0}"
        
    SelectCommand="SELECT [category], [userid], [action], [action_datetime] FROM [T_Action] ORDER BY [action_datetime] DESC">
    </asp:SqlDataSource>
</asp:Content>
