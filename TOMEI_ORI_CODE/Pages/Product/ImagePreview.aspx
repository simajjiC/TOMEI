<%@ Page Language="C#" AutoEventWireup="true" Inherits="Pages_Product_ImagePreview" Codebehind="ImagePreview.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="DevExpress.Web.v9.1" Namespace="DevExpress.Web.ASPxCallbackPanel"
	TagPrefix="dxwcp" %>
<%@ Register Assembly="DevExpress.Web.v9.1"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v9.1"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v9.1"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v9.1"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v9.1"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dxuc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<script type="text/javascript">
    function uploadCompleteHandler(s, e){
//        	var txtPhoto = oASPxTextBox_ImageURL; //GetElementById('oASPxTextBox_ImageURL');
//	        var imgPhoto = oASPxImage1; //GetElementById('oASPxImage1');	
//	if (e.isValid)
//    	{
////        	txtPhoto.SetValue(e.callbackData);        	
////          	imgPhoto.SetValue(e.callbackData);
//     	}
        //	alert('upload complete!');
        Panel.PerformCallback();
}
function refreshParent() {  
  window.close();
}
</script>
<body>
    <form id="form1" runat="server">
        <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0">
            <TabPages>
                <dxtc:TabPage Text="Upload">
                    <ContentCollection>
                        <dxw:ContentControl ID="ContentControl1" runat="server">
                            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="200px" HeaderText="Upload File">
                                <PanelCollection>
                                    <dxp:PanelContent ID="PanelContent1" runat="server">
                                        <dxuc:ASPxUploadControl ID="ASPxUploadControl1" runat="server" ShowProgressPanel="True"
                                            ShowUploadButton="True" OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                            <ClientSideEvents FileUploadComplete="function(s, e) {
                                                uploadCompleteHandler(s, e);
}" />
                                        </dxuc:ASPxUploadControl>
                                    </dxp:PanelContent>
                                </PanelCollection>
                            </dxrp:ASPxRoundPanel>
                            <br />
                            <br />
<dxwcp:ASPxCallbackPanel runat="server" ID="Panel" ClientInstanceName="Panel" 
		oncallback="Panel_Callback">
		<PanelCollection>
			<dxp:PanelContent ID="PanelContent2" runat="server">
                                        <dxe:ASPxBinaryImage ID="ASPxImage1" runat="server" Height="200px" ClientInstanceName="oASPxImage1" IsPng="True" Visible="false">
                                        </dxe:ASPxBinaryImage>
                                            <dxe:ASPxButton ID="btn_Save" runat="server" AutoPostBack="false" Text="Save" 
                Width="100px" Enabled="false">
        <ClientSideEvents Click="function (s, e) {Panel2.PerformCallback();}"/>
    </dxe:ASPxButton>
    <dxe:ASPxButton ID="btn_Close" runat="server" AutoPostBack="false" Text="Close" 
                Width="100px">
        <ClientSideEvents Click="function (s, e) {refreshParent();}" />
    </dxe:ASPxButton>
</dxp:PanelContent>
		</PanelCollection>
	</dxwcp:ASPxCallbackPanel>
                        </dxw:ContentControl>
                    </ContentCollection>
                </dxtc:TabPage>                
            </TabPages>
        </dxtc:ASPxPageControl>
        <dxwcp:ASPxCallbackPanel runat="server" ID="Panel2" ClientInstanceName="Panel2" OnCallback="Panel2_Callback">
            <PanelCollection>
                <dxp:PanelContent ID="PanelContent3" runat="server">
                    <dxe:ASPxLabel ID="lblStatus" runat="server" Text=""></dxe:ASPxLabel>
                </dxp:PanelContent>
            </PanelCollection>
        </dxwcp:ASPxCallbackPanel>        
        <div>
&nbsp;
        </div>
    </form>
</body>
</html>
