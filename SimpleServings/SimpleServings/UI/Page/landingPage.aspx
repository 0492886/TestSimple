<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="SimpleServings.UI.Page.landingPage" MaintainScrollPositionOnPostback="true" MasterPageFile="~/UI/Page/dashboardmain.Master" %>

<%-- 
<%@ Reference Control="~/UI/UDC/SimpleServings/UserGroup/UserGroupList.ascx"%>
<%@ Reference Control="~/UI/UDC/SimpleServings/Setting/CodeList.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/MyProfile.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/StaffSearchControl.ascx" %>
--%>


<%@ Register TagPrefix="uc1" TagName="navigationbar" Src="~/UI/UDC/Navigation/navigationbar.ascx" %>
<%--@Register TagPrefix="uc1" TagName="quicklinks" Src="../UDC/v2/quicklinks.ascx"--%>

<%@ Register TagPrefix="uc1" TagName="header" Src="~/UI/UDC/Navigation/header.ascx" %>


<%@ Register Src="~/UI/UDC/Navigation/AccordionMenu.ascx" TagName="SideBar" TagPrefix="uc2"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <script type="text/javascript">
        //function pageLoad(sender, args) {
        //    debugger;
        //    if (document.location.toString().indexOf("LogInOut") > -1 || document.location.toString().indexOf("ForcePasswordChange") > -1) {
        //        newSession();
        //    }
        //}

        //function newSession() {
        //    jQuery.ajax({
        //        type: "POST",
        //        url: "landingPage.aspx/ClearSession",
        //        data: "{}",
        //        dataType: "json",
        //        contentType: "application/json; charset=utf-8",
        //        success: function () {
        //            jQuery.ajax({
        //                type: "POST",
        //                url: "landingPage.aspx/NewSession",
        //                data: "{}",
        //                dataType: "json",
        //                contentType: "application/json; charset=utf-8",
        //                success: function () { console.log("Success!"); },
        //                error: function (x, y, z) {
        //                    console.log("Failure!");
        //                }
        //            });
        //        },
        //        error: function (x, y, z) {
        //            console.log("Failure!");
        //        }
        //    });
        //}
</script>

		    <form id="test2" runat="server">
    <div class="themetitle2">
	<div class="themetitlewrapper">	
	<h1 class="titanictitle">Welcome</h1>			
	</div>
	</div>
    	
			    <div id="v2main">
				    <div class="main_body">
                      
					    <div class="contentBox">
    					<div class="title2">Test</div>
    <div class="dataList">
    This recipe uses canned beans that contain 130-240 mg of sodium per serving. Using canned beans that contain higher amounts of sodium may change the nutrient content of the recipe, and therefore may not meet the nutritional guidelines.
						<div class="rowLanding">
						                <div class="line4first"></div>
										<div class="circleftLanding">
											<div class="circle1thumb"><img src="../../UI/images/spacer.png" alt=""></div>
											<div class="circle1Landing"><img src="../../UI/images/spacer.png" alt="" class="invizible">
												<h2>Amazing Recipes</h2><br/>
												<h4>Tofu Spinach Cheese Quiche
This recipe may count toward the entrée and vegetable (1 serving)
component of the menu and is a good source of protein and high
source of fiber. Search for recipe #273 or filter and search on “vegetarian”.
<br /><br />
This recipe uses canned beans that contain 130-240 mg of sodium per serving. 
</h4>
											</div>
										</div>
										<div class="line4"></div>
										<div class="circrightLanding">
											<div class="circle2thumb"><img src="../../UI/images/spacer.png" alt=""></div>
											<div class="circle2Landing"><img src="../../UI/images/spacer.png" alt="" class="invizible">
												<h2>Tips for Menu Pairing </h2><br/>
												<h4>


<ul>
<li class="liCheck">When choosing a starchy vegetable pair with a non-starchy vegetable</li><br />
<li class="liCheck">Offer a variety of texture with each dish prepared (ex: crunchy, soft, chewy)</li><br />
<li class="liCheck">Avoid repeating entrees more than once to keep seniors happy</li><br />
<li class="liCheck">Take color into consideration when preparing a meal. The more colorful it is, The more nutritious it is</li>
</ul>

                                                </h4>
											</div>
										</div>
										<div class="line4"></div>
										<div class="circleftLanding">
											<div class="circle3thumb"><img src="../../UI/images/spacer.png" alt=""></div>
											<div class="circle3Landing"><img src="../../UI/images/spacer.png" alt="" class="invizible">
												<h2>Seasonal Recipes</h2><br/>
												<h4>This recipe uses canned beans that contain 130-240 mg of sodium per serving. Using canned beans that contain higher amounts of sodium may change the nutrient content of the recipe, and therefore may not meet the nutritional guidelines.</h4>
											</div>
										</div>
										<div class="line4"></div>
										<div class="circrightLanding">
											<div class="circle4thumb"><img src="../../UI/images/spacer.png" alt=""></div>
											<div class="circle4Landing"><img src="../../UI/images/spacer.png" alt="" class="invizible">
												<h2>Vegan Options</h2><br/>
												<h4>This recipe uses canned beans that contain 130-240 mg of sodium per serving. Using canned beans that contain higher amounts of sodium may change the nutrient content of the recipe, and therefore may not meet the nutritional guidelines.</h4>
											</div>
										</div>

						</div>
                        <div class="clear"></div>
						
				</div>
			</div>
			</div>		    
    					           
					    </div>
    					<br class="easyClear" />
			
    				
			   
		    </form>
 </asp:Content>	
