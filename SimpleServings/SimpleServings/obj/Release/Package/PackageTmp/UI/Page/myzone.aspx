<%@ Page language="C#" Inherits="SimpleServings.UI.Page.MyZone" Codebehind="MyZone.aspx.cs" MaintainScrollPositionOnPostback="true" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%@ Register TagPrefix="uc1" TagName="navigationbar" Src="~/UI/UDC/Navigation/navigationbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="~/UI/UDC/Navigation/header.ascx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
		    <form id="test2" runat="server">
                <div class="themetitle2">
	<div class="themetitlewrapper">	
	<h1 class="titanictitle">Settings</h1>			
	</div>
	</div>
    		    <div class="hide"><uc1:navigationbar id="Navigationbar1" runat="server" />
    		   <uc1:header id="Header1" runat="server" />
    		    </div>
			    <div id="v2main">
				    <div class="main_body">
                      
					    <div class="ContentWrap">
    					
    					
					    
                            <asp:PlaceHolder ID="test" runat="server"></asp:PlaceHolder>

					      
    			            
    			            
    			                       <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackErrorMessage="script manager in myZone!"></asp:ScriptManager>

                              
                     
    			            
					        <div class="LeftSection">
                                <cc1:ModalPopupExtender ID="modalPopup" TargetControlID="hide" PopupControlID="pnlAnnouncement" CancelControlID="btnClose" BackgroundCssClass="modalBackground" runat="server" y="50"></cc1:ModalPopupExtender>
                                
           
                                <asp:HiddenField ID="hide" runat="server" />
                                
                                <asp:Panel ID="pnlAnnouncement" runat="server" Width="680" style="display:none;">
                                    <asp:LinkButton ID="btnClose" CssClass="popUpCloseBtn" runat="server" style="visibility:hidden;">CLOSE</asp:LinkButton>
                                    <asp:PlaceHolder ID="holder" runat="server"></asp:PlaceHolder>
                                </asp:Panel>
                               
                                
				                <asp:PlaceHolder id="PHMyZone" runat="server"></asp:PlaceHolder>
						     </div>
    					           
					    </div>
    					<br class="easyClear" />
				    </div>
    			
    			</div>	
    				
			   
		    </form>
 </asp:Content>	
