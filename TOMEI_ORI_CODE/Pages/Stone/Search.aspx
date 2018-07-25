<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Search"  MasterPageFile="../Standard.master" Codebehind="Search.aspx.cs" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.1" Namespace="DevExpress.Web.ASPxGridView"
    TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxTimer"
    TagPrefix="dxt" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxRoundPanel"
    TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxPanel"
    TagPrefix="dxp" %>    

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolderM" Runat="Server">    
     <div style="width:100%;overflow:auto;overflow-x:scroll;">
     <dxwgv:ASPxGridView ID="gv_Stone" runat="server" OnCommandButtonInitialize="gv_Stone_CommandButtonInitialize" ClientInstanceName="gv_Stone_c"
        OnStartRowEditing="gv_Stone_StartRowEditing" OnRowInserting="gv_Stone_RowInserting" OnRowUpdating="gv_Stone_RowUpdating" OnRowValidating="gv_Stone_RowValidating"
        AutoGenerateColumns="False" DataSourceID="ds_Stone" Width="100%" KeyFieldName="GUID" >
        <SettingsPager PageSize="20" />
        <Settings ShowStatusBar="Visible" ShowFilterRow="True" ShowFooter="True" />
        <SettingsEditing Mode="EditForm" />
        <SettingsBehavior ConfirmDelete="true" />
        <Columns>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
               
                <ClearFilterButton Visible="True">
                </ClearFilterButton>
                <EditButton Text="Edit" Visible="true">
                </EditButton>
            </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewCommandColumn VisibleIndex="0">
             <DeleteButton Visible="True">
                </DeleteButton>
                 </dxwgv:GridViewCommandColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CertificateNo" VisibleIndex="1" 
                Caption="Certificate" ReadOnly="true">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="CategoryCode" VisibleIndex="2" 
                Caption="Category" ReadOnly="true">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="SubCategoryCode" VisibleIndex="3" 
                Caption="Sub Category" ReadOnly="true">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>      
            <dxwgv:GridViewDataTextColumn FieldName="ProductNo" VisibleIndex="4" 
                Caption="Product Barcode" ReadOnly="true">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>      
            <dxwgv:GridViewDataTextColumn FieldName="StoneID" VisibleIndex="5" ReadOnly="true">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Weight" VisibleIndex="6">
            </dxwgv:GridViewDataTextColumn>            
            <dxwgv:GridViewDataTextColumn FieldName="Clarity" VisibleIndex="7">
<%--                 <PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Clarity">                     
                 </PropertiesComboBox>  --%>          
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Colour" VisibleIndex="8">
                <%-- <PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Colour">                     
                 </PropertiesComboBox>--%>            
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Fluorescence" VisibleIndex="9">
                 <%--<PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Fluorescence">                     
                 </PropertiesComboBox> --%>           
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Girdle" VisibleIndex="10">
                 <%--<PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Girdle">                     
                 </PropertiesComboBox> --%>           
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Polish" VisibleIndex="11">
                <%-- <PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Polish">                     
                 </PropertiesComboBox> --%>           
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn FieldName="Symmetry" VisibleIndex="12">
                 <%--<PropertiesComboBox TextField="value" ValueField="id" EnableSynchronization="False"
                     EnableIncrementalFiltering="True" DataSourceID="ds_Symmetry">                     
                 </PropertiesComboBox> --%>           
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Depth %" FieldName="Depth" VisibleIndex="13">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Table" FieldName="Size" 
                VisibleIndex="14">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Min" FieldName="Measurement_1" 
                VisibleIndex="15">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Max" FieldName="Measurement_2" 
                VisibleIndex="16">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="T.D" FieldName="Measurement_3" 
                VisibleIndex="17">
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataTextColumn Caption="Created By" FieldName="CreatedBy" 
                VisibleIndex="18" ReadOnly="true">
                <EditFormSettings Visible="False" />
            </dxwgv:GridViewDataTextColumn>
            <dxwgv:GridViewDataDateColumn Caption="Created Date" FieldName="CreatedDate" 
                VisibleIndex="19" ReadOnly="true">
                <EditFormSettings Visible="False" />
                <PropertiesDateEdit DisplayFormatString="">
                </PropertiesDateEdit>
            </dxwgv:GridViewDataDateColumn>
            <%--<dxwgv:GridViewDataTextColumn Caption="Multiple Create" FieldName="MultipleCreate" 
                VisibleIndex="20">
            </dxwgv:GridViewDataTextColumn>--%>
        </Columns>
        <Templates>
            <EditForm>
               <dxe:ASPxLabel ID="lblStoneID" runat="server" Text="StoneID:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtStoneID" runat="server" Width="170px" Text='<%# Eval("StoneID") %>'>
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblWeight" runat="server" Text="Weight:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtWeight" runat="server" Width="170px" Text='<%# Eval("Weight") %>'>
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblClarity" runat="server" Text="Clarity:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlClarity" runat="server" OnLoad="ddlClarity_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                
                </dxe:ASPxComboBox>
                <dxe:ASPxLabel ID="lblColour" runat="server" Text="Colour:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlColour" runat="server" OnLoad="ddlColour_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                
                </dxe:ASPxComboBox>
                <dxe:ASPxLabel ID="lblFluorescence" runat="server" Text="Fluorescence:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlFluorescence" runat="server" OnLoad="ddlFluorescence_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                
                </dxe:ASPxComboBox>
                <dxe:ASPxLabel ID="lblGirdle" runat="server" Text="Girdle:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlGirdle" runat="server" OnLoad="ddlGirdle_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                 
                </dxe:ASPxComboBox>     
                <dxe:ASPxLabel ID="lblPolish" runat="server" Text="Polish:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlPolish" runat="server" OnLoad="ddlPolish_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                
                </dxe:ASPxComboBox>    
                <dxe:ASPxLabel ID="lblSymmetry" runat="server" Text="Symmetry:"></dxe:ASPxLabel>
                <dxe:ASPxComboBox ID="ddlSymmetry" runat="server" OnLoad="ddlSymmetry_OnLoad" PopupVerticalAlign="BottomSides" PopupHorizontalAlign="OutsideRight" EnableIncrementalFiltering="True">                
                </dxe:ASPxComboBox>
                <dxe:ASPxLabel ID="lblDepth" runat="server" Text="Depth %:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtDepth" runat="server" Width="170px" Text='<%# Eval("Depth")%>'>
                </dxe:ASPxTextBox>
                <dxe:ASPxLabel ID="lblSize" runat="server" Text="Table:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtSize" runat="server" Width="170px" Text='<%# Eval("Size") %>'>
                </dxe:ASPxTextBox>    
                <dxe:ASPxLabel ID="lblMin" runat="server" Text="Min:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtMin" runat="server" Width="170px" Text='<%# Eval("Measurement_1") %>'>
                </dxe:ASPxTextBox>                                                    
                <dxe:ASPxLabel ID="lblMax" runat="server" Text="Max:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtMax" runat="server" Width="170px" Text='<%# Eval("Measurement_2") %>'>
                </dxe:ASPxTextBox>                                                    
                <dxe:ASPxLabel ID="lblTable" runat="server" Text="T.D:"></dxe:ASPxLabel>
                <dxe:ASPxTextBox ID="txtTable" runat="server" Width="170px" Text='<%# Eval("Measurement_3") %>'>
                </dxe:ASPxTextBox>                                                                                    
                <div style="text-align:left; padding:2px 2px 2px 2px">
                    <dxwgv:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    <dxwgv:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dxwgv:ASPxGridViewTemplateReplacement>
                    
                    
                </div>
                <br/>
                <div style="text-align:left; padding:2px 2px 2px 2px">
                    <dxe:ASPxLabel ID="lblMultipleCreate" runat="server" Text="Multiple Create:"></dxe:ASPxLabel>
                    

                    <dxe:ASPxTextBox ID="txtMultipleCreate" runat="server" Width="170px" >
                        </dxe:ASPxTextBox>
                    <dxe:ASPxButton ID="btnMultipleCreate" runat="server" Text="Multiple Create" 
                        onclick="btnMultipleCreate_Click" >
                    </dxe:ASPxButton>
                    

                </div>
            </EditForm>
            <StatusBar>
                <dxe:ASPxHyperLink ID="hplAddNew" NavigateUrl="#" runat="server" Text="Add New" ClientSideEvents-Click="function(s, e) { gv_Stone_c.AddNewRow(); }">
                </dxe:ASPxHyperLink>            
            </StatusBar>
        </Templates>
        
    </dxwgv:ASPxGridView>
         <dxe:ASPxLabel ID="lblEmptyMsg" runat="server" ForeColor="Red"  Text=""></dxe:ASPxLabel>
                    <%--<dxe:ASPxLabel ID="lblMessage" runat="server" Width="170px"   ></dxe:ASPxLabel>--%>
                    <%--<asp:CustomValidator ID="BarcodeCheck2" runat="server" OnServerValidate="NullValidate" 
        ControlToValidate="txtMultipleCreate" ErrorMessage="Please key in the value2!"></asp:CustomValidator>--%>
</div>
    <%--SELECT [CertificateNo], [ProductNo], [CategoryCode], [SubCategoryCode], [StoneID], case stoneid when 'NIL' then CAST([Weight] AS char(20)) else convert(char(20),Cast(Round(Weight,2) as float) ) end as [Weight]  , [Clarity], [Colour], [Fluorescence], [Girdle], [Polish], [Symmetry], Cast(Cast(Depth as Numeric(10,1)) as varchar(12))+ '%' as [Depth], CAST(Round(Size,0) AS varchar(12))+ '%' as [Size], Cast(Measurement_1 as Numeric(10,2)) as [Measurement_1], Cast(Measurement_2 as Numeric(10,2)) as [Measurement_2], Cast(Measurement_3 as Numeric(10,2)) as [Measurement_3], [CreatedBy], [CreatedDate],[GUID] FROM [Normal_View]--%>
    <asp:SqlDataSource ID="ds_Stone" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="SELECT [CertificateNo], [ProductNo], [CategoryCode], [SubCategoryCode], [StoneID], case stoneid when 'NIL' then CAST([Weight] AS char(20)) else CAST([Weight] AS char(20)) end as [Weight]  , [Clarity], [Colour], [Fluorescence], [Girdle], [Polish], [Symmetry], Cast(Cast(Depth as Numeric(10,1)) as varchar(12))+ '%' as [Depth], CAST(Round(Size,0) AS varchar(12))+ '%' as [Size], Cast(Measurement_1 as Numeric(10,2)) as [Measurement_1], Cast(Measurement_2 as Numeric(10,2)) as [Measurement_2], Cast(Measurement_3 as Numeric(10,2)) as [Measurement_3], [CreatedBy], [CreatedDate],[GUID] FROM [Normal_View]" 
        InsertCommand="INSERT INTO [T_Stone] ([StoneID], [Weight], [Clarity], [Colour], [Fluorescence], [Girdle], [Polish], [Symmetry], [Depth], [Size], [Measurement_1], [Measurement_2], [Measurement_3], [CreatedBy]) VALUES (@StoneID, @Weight, @Clarity, @Colour, @Fluorescence, @Girdle, @Polish, @Symmetry, @Depth, @Size, @Measurement_1, @Measurement_2, @Measurement_3, @adminuserid);INSERT INTO T_Action (category, userid, action) VALUES ('Stone', @adminuserid, 'Inserted Stone for Stone: ' + @StoneID)"
        UpdateCommand="UPDATE [T_Stone] SET [Weight] = @Weight, [Clarity] = @Clarity, [Colour] = @Colour, [Fluorescence] = @Fluorescence, [Girdle] = @Girdle, [Polish] = @Polish, [Symmetry] = @Symmetry, [Depth] = @Depth, [Size] = @Size, [Measurement_1] = @Measurement_1, [Measurement_2] = @Measurement_2, [Measurement_3] = @Measurement_3, UpdatedDate = getdate(), UpdatedBy = @adminuserid WHERE GUID = @GUID AND StoneID = @StoneID;INSERT INTO T_Action (category, userid, action) VALUES ('Stone', @adminuserid, 'Updated Stone for Stone: ' + @StoneID )"
        DeleteCommand="INSERT INTO [T_Stone_Backup] SELECT * FROM [T_Stone] WHERE GUID = @GUID AND StoneID = @StoneID; DELETE FROM [T_Stone] WHERE GUID = @GUID AND StoneID = @StoneID; INSERT INTO T_Action (category, userid, action) VALUES ('Stone', @adminuserid, 'Deleted Stone for Stone: ' + @StoneID + ' (' + @GUID + ')')">
        <InsertParameters>
            <asp:Parameter Name="Weight" />
            <asp:Parameter Name="Clarity" />
            <asp:Parameter Name="Colour" />
            <asp:Parameter Name="Fluorescence" />
            <asp:Parameter Name="Girdle" />
            <asp:Parameter Name="Polish" />
            <asp:Parameter Name="Symmetry" />
            <asp:Parameter Name="Depth" />
            <asp:Parameter Name="Size" />
            <asp:Parameter Name="Measurement_1" />
            <asp:Parameter Name="Measurement_2" />
            <asp:Parameter Name="Measurement_3" />
            <asp:Parameter Name="StoneID" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Weight" />
            <asp:Parameter Name="Clarity" />
            <asp:Parameter Name="Colour" />
            <asp:Parameter Name="Fluorescence" />
            <asp:Parameter Name="Girdle" />
            <asp:Parameter Name="Polish" />
            <asp:Parameter Name="Symmetry" />
            <asp:Parameter Name="Depth" />
            <asp:Parameter Name="Size" />
            <asp:Parameter Name="Measurement_1" />
            <asp:Parameter Name="Measurement_2" />
            <asp:Parameter Name="Measurement_3" />
            <asp:Parameter Name="StoneID" />
            <asp:Parameter Name="GUID" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </UpdateParameters>
        <DeleteParameters>
            <asp:Parameter Name="StoneID" />
            <asp:Parameter Name="GUID" />
            <asp:SessionParameter Name="adminuserid" SessionField="UserID" Type="String" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ds_Clarity" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListClarity" 
        ></asp:SqlDataSource>
    <asp:SqlDataSource ID="ds_Colour" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListColour" 
        ></asp:SqlDataSource>  
    <asp:SqlDataSource ID="ds_Fluorescence" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListFluorescence" 
        ></asp:SqlDataSource> 
    <asp:SqlDataSource ID="ds_Girdle" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListGirdle" 
        ></asp:SqlDataSource>                     
    <asp:SqlDataSource ID="ds_Polish" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListPolish" 
        ></asp:SqlDataSource> 
    <asp:SqlDataSource ID="ds_Symmetry" runat="server"
        ConnectionString="<%$ ConnectionStrings:SiteConnString %>"                            
        SelectCommand="EXEC S_ListSymmetry" 
        ></asp:SqlDataSource>               
</asp:Content>