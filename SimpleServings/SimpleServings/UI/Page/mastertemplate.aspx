<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mastertemplate.aspx.cs" Inherits="SimpleServings.UI.Page.mastertemplate" MasterPageFile="~/UI/Page/dashboardmain.Master" %>


<%@ Register src="../UDC/SimpleServings/Recipe/ViewRecipe.ascx" tagname="ViewRecipe" tagprefix="uc1" %>


<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <form id="form1" runat="server">
   	
	<div class="themetitle2">
		<div class="themetitlewrapper">	
			<div class="titanictitle">View Recipe</div>			
		</div>
	</div>


	
<!--
###########
CONTENT
###########
-->

        			 
	<!--left blog content-->

                          <uc1:ViewRecipe ID="ViewRecipe1" runat="server" />
	
	
	<!--right blog content-->
<div class="blogright hide"> 
		<span class="title2">Actions Available</span>
		<div class="catline"></div>
		<div class="bloglistcontainer">
			<ul class="blogmenu" > 
				<li class="li11"><a href="#">Approved</a></li>
				<li class="li11"><a href="#">Denied</a></li>
				<li class="li11"><a href="#">Returned</a></li>		
			</ul>
		</div>
		<br/><br/>

        <div class="row1a smallfix">
	                  <div class="contactbox">
						  <span class="title2">Requirements</span><br>
						  <div class="line8"></div><br>
						  <ol class="listnumbers">
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						
						  </ol>
					  </div>
				</div>
		   <div class="clearfix"></div><br/>
		   <br/>
                <div class="row1a smallfix">
	                  <div class="contactbox">
						  <span class="title2">Recommendations</span><br>
						  <div class="line8"></div><br>
						  <ol class="listnumbers">
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						  	<li class="darklinkList">In a nonmetallic bowl, stir together the vegetable oil and flower</li>
						
						  </ol>
					  </div>
				</div>		
</div>	

<div class="clearfix"></div>

<!-- END OF PAGE Class-->
</div>
 </form>
	</asp:Content>	