<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatusChangeSubmission.aspx.cs" Title="Status Change" Inherits="SimpleServings.UI.Page.SimpleServings.Setting.StatusChangeSubmission"  MasterPageFile="~/UI/Page/dashboardmain.Master"%>

<%@ Register src="../../../UDC/SimpleServings/Setting/StatusChangeSubmission.ascx" tagname="StatusChangeSubmission" tagprefix="uc1" %>
<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
 <form id="form1" runat="server">
 	<div class="themetitle2">
		<div class="themetitlewrapper">	
			<div class="titanictitle">Status Change</div>			
		</div>
	</div>
   
    <a class="linksright lnkCloseStyle hide"  href="JavaSCript: window.opener.location.href = window.opener.location;window.open('','_self','');self.close();">Close Window</a>        
    <uc1:StatusChangeSubmission ID="StatusChangeSubmission1" runat="server" />   
    </form>
</asp:Content>	