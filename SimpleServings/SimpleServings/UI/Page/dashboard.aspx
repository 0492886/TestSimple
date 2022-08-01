<%@ Page language="c#" Inherits="SimpleServings.UI.Page.dashboard" Codebehind="dashboard.aspx.cs" %>
<%@ Register TagPrefix="uc1" TagName="navigationbar" Src="../UDC/Navigation/navigationbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../UDC/Navigation/header.ascx" %>

<%-- 
<%@ Reference Control="~/UI/UDC/SimpleServings/UserGroup/UserGroupList.ascx"%>
<%@ Reference Control="~/UI/UDC/SimpleServings/Setting/CodeList.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/MyProfile.ascx" %>
<%@ Reference Control="~/UI/UDC/SimpleServings/Staff/StaffSearchControl.ascx" %>
--%>

<%@ Register Src="../UDC/SimpleServings/Staff/AddEditAccountInfo.ascx" TagName="AddEditAccountInfo" TagPrefix="uc2" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
   <meta charset="utf-8" />
   <title>Simple Servings Admin</title>
   <meta content="width=device-width, initial-scale=1.0" name="viewport" />
   <meta content="" name="description" />
   <meta content="" name="author" />
   <!-- BEGIN GLOBAL MANDATORY STYLES -->
   <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/css/style-metro.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/css/style.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
   <link href="../assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
   <link href="../assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
   <!-- END GLOBAL MANDATORY STYLES -->
   <!-- BEGIN PAGE LEVEL STYLES -->
   <link rel="stylesheet" type="text/css" href="../assets/plugins/chosen-bootstrap/chosen/chosen.css" />
    
   <!-- END PAGE LEVEL STYLES -->
   <link rel="shortcut icon" href="" />
     <script type="text/javascript">
         window.onload = loaderFunct;
         function loaderFunct() {
             loginTxt();
             myZoneMenu();
         };
	      </script>
          
          <script type="text/javascript">
              function stopError() {
                  return true;
              }
              window.onerror = stopError;
          </script>       
   </head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body id="hasaweb2" class="fixed-top">
   <!-- BEGIN HEADER -->
   <div class="header navbar navbar-inverse navbar-fixed-top">
      <!-- BEGIN TOP NAVIGATION BAR -->
      <div class="navbar-inner">
         <div class="container-fluid">
            <!-- BEGIN LOGO -->
            <a class="brand" href="#">
            <img src="../assets/img/logo.png" alt="logo" />
            </a>
            <!-- END LOGO -->
            <!-- BEGIN RESPONSIVE MENU TOGGLER -->
            <a href="javascript:;" class="btn-navbar collapsed" data-toggle="collapse" data-target=".nav-collapse">
            <img src="../assets/img/menu-toggler.png" alt="" />
            </a>          
            <!-- END RESPONSIVE MENU TOGGLER -->            
            <!-- BEGIN TOP NAVIGATION MENU -->              
            <ul class="nav pull-right">
               <!-- BEGIN NOTIFICATION DROPDOWN -->   
               <li class="dropdown" id="header_notification_bar">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                  <i class="icon-warning-sign"></i>
                  <span class="badge">6</span>
                  </a>
                  <ul class="dropdown-menu extended notification">
                     <li>
                        <p>You have 14 new notifications</p>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-success"><i class="icon-plus"></i></span>
                        New user registered. 
                        <span class="time">Just now</span>
                        </a>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>
                        Server #12 overloaded. 
                        <span class="time">15 mins</span>
                        </a>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-warning"><i class="icon-bell"></i></span>
                        Server #2 not respoding.
                        <span class="time">22 mins</span>
                        </a>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-info"><i class="icon-bullhorn"></i></span>
                        Application error.
                        <span class="time">40 mins</span>
                        </a>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>
                        Database overloaded 68%. 
                        <span class="time">2 hrs</span>
                        </a>
                     </li>
                     <li>
                        <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>
                        2 user IP blocked.
                        <span class="time">5 hrs</span>
                        </a>
                     </li>
                     <li class="external">
                        <a href="#">See all notifications <i class="m-icon-swapright"></i></a>
                     </li>
                  </ul>
               </li>
               <!-- END NOTIFICATION DROPDOWN -->
       
               <!-- BEGIN USER LOGIN DROPDOWN -->
               <li class="dropdown user">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                  <img alt="" src="../assets/img/avatar1_small.jpg" />
                  <span class="username">John Doe</span>
                  <i class="icon-angle-down"></i>
                  </a>
                  <ul class="dropdown-menu">
                     <li><a href="#"><i class="icon-user"></i> My Profile</a></li>
                     <li><a href="#"><i class="icon-calendar"></i> My Calendar</a></li>
                     <li><a href="#"><i class="icon-envelope"></i> My Inbox(3)</a></li>
                     <li><a href="#"><i class="icon-tasks"></i> My Tasks</a></li>
                     <li class="divider"></li>
                     <li><a href="#"><i class="icon-key"></i> Log Out</a></li>
                  </ul>
               </li>
               <!-- END USER LOGIN DROPDOWN -->
            </ul>
            <!-- END TOP NAVIGATION MENU --> 
         </div>
      </div>
      <!-- END TOP NAVIGATION BAR -->
   </div>
   <!-- END HEADER -->
   <!-- BEGIN CONTAINER -->
   <div class="page-container row-fluid">
      <!-- BEGIN SIDEBAR -->
      <div class="page-sidebar nav-collapse collapse">
         <!-- BEGIN SIDEBAR MENU -->        	<ul>
				<li>
					<!-- BEGIN SIDEBAR TOGGLER BUTTON -->
					<div class="sidebar-toggler hidden-phone"></div>
					<!-- BEGIN SIDEBAR TOGGLER BUTTON -->
				</li>
				<li>
					<!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
					<form class="sidebar-search">
						<div class="input-box">
							<a href="javascript:;" class="remove"></a>
							<input type="text" placeholder="Search..." />				
							<input type="button" class="submit" value=" " />
						</div>
					</form>
					<!-- END RESPONSIVE QUICK SEARCH FORM -->
				</li>
				
                               	        		
        		<li class="start active">
        			<a href="#">
					<i class="icon-home"></i> 
					<span class="title">Dashboard</span>
					</a>

				</li>
				
		        	        		
        		<li class="">
        			<a href="javascript:;">
					<i class="icon-table"></i> 
					<span class="title">Recipes</span>
					
										<span class="selected"></span>
					
										<span class="arrow open"></span>
										</a>

							<ul class="sub-menu">                                
							<li><a href="SimpleServings/Recipe/addRecipe.aspx">Add Recipe</a></li>							
                            <li><a href="SimpleServings/Recipe/RecipeList.aspx">Recipe List</a></li>                               
							</ul>

					</li>

                    <li class="">
        			<a href="javascript:;">
					<i class="icon-table"></i> 
					<span class="title">Suppliers</span>
					
										<span class="selected"></span>
					
										<span class="arrow open"></span>
										</a>

							<ul class="sub-menu">                                
							<li><a href="SimpleServings/Supplier/Sponsor.aspx">Sponsors</a></li>							
                            <li><a href="SimpleServings/Supplier/Contract.aspx">Contracts</a></li>
                            <li><a href="SimpleServings/Supplier/Caterer.aspx">Caterers</a></li>                                
							</ul>

					</li>
				
					</ul>
		<!-- END SIDEBAR MENU -->
      </div>
      <!-- END SIDEBAR -->
      <!-- BEGIN PAGE -->  
      <div class="page-content" id="myzone">
 
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
                 <h3 class="page-title">
                     Dashboard	<small>Recipe and Menu Administration</small>
                     <small></small>
                  </h3>
               
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
               <div class="span12">
            <div class="portlet box">

                  <div class="row-fluid">

                   <div class="span6">
                     <!-- BEGIN PORTLET-->
                    <div class="portlet box grey">
                        <div class="portlet-title line">
                           <div class="caption"><i class="icon-bell"></i>What's New</div>
                           <div class="tools">                             
                              <a href="#portlet-config" data-toggle="modal" class="config"></a>
                              <a href="javascript:;" class="reload"></a>                              
                           </div>
                        </div>
                        <div class="portlet-body">
                           <!--BEGIN TABS-->
                           <div class="tabbable tabbable-custom">
                              <ul class="nav nav-tabs">
                                 <li class="active"><a href="#tab_1_1" data-toggle="tab">Inbox</a></li>
                                 <li><a href="#tab_1_2" data-toggle="tab">Activities</a></li>
                                 <li><a href="#tab_1_3" data-toggle="tab">Recent Users</a></li>
                              </ul>
                              <div class="tab-content">
                                 <div class="tab-pane active" id="tab_1_1">
                                    <div class="scroller" data-height="290px" data-always-visible="1" data-rail-visible="0">
                                       <ul class="feeds">
    
                                          <li>
                                             
                                                <div class="col1">
                                                   <div class="cont">
                                                      <div class="cont-col1">
                                                         <div class="label label-warning">                        
                                                            <i class="icon-plus"></i>
                                                         </div>
                                                      </div>
                                                      <div class="cont-col2">
                                                         <div class="desc">
                                                           Recently approved menus  
                                                         </div>
                                                      </div>
                                                   </div>
                                                </div>
                                                <div class="col2">
                                                   <div class="date">
                                                      20 mins
                                                   </div>
                                                </div>
                                          
                                          </li>                                   
                                    
                                          <li>
                                             <div class="col1">
                                                <div class="cont">
                                                   <div class="cont-col1">
                                                      <div class="label label-info">                        
                                                         <i class="icon-bullhorn"></i>
                                                      </div>
                                                   </div>
                                                   <div class="cont-col2">
                                                      <div class="desc">
                                                         You have 3 recipes for review              
                                                      </div>
                                                   </div>
                                                </div>
                                             </div>
                                             <div class="col2">
                                                <div class="date">
                                                   22 hours
                                                </div>
                                             </div>
                                          </li>

                                                                                <li>
                                             <div class="col1">
                                                <div class="cont">
                                                   <div class="cont-col1">
                                                      <div class="label label-success">                        
                                                         <i class="icon-bell"></i>
                                                      </div>
                                                   </div>
                                                   <div class="cont-col2">
                                                      <div class="desc">
                                                         You have 4 pending menus for review.                                                    
                                                      </div>
                                                   </div>
                                                </div>
                                             </div>
                                             <div class="col2">
                                                <div class="date">
                                                   3 days
                                                </div>
                                             </div>
                                          </li>
                                       </ul>
                                    </div>
                                 </div>
                                 <div class="tab-pane" id="tab_1_2">
                                    <div class="scroller" data-height="290px" data-always-visible="1" data-rail-visible1="1">
                                       <ul class="feeds">
                                          <li>
                                             <a href="#">
                                                <div class="col1">
                                                   <div class="cont">
                                                      <div class="cont-col1">
                                                         <div class="label label-success">                        
                                                            <i class="icon-bell"></i>
                                                         </div>
                                                      </div>
                                                      <div class="cont-col2">
                                                         <div class="desc">
                                                            New user registered
                                                         </div>
                                                      </div>
                                                   </div>
                                                </div>
                                                <div class="col2">
                                                   <div class="date">
                                                      Just now
                                                   </div>
                                                </div>
                                             </a>
                                          </li>
                                          <li>
                                             <a href="#">
                                                <div class="col1">
                                                   <div class="cont">
                                                      <div class="cont-col1">
                                                         <div class="label label-success">                        
                                                            <i class="icon-bell"></i>
                                                         </div>
                                                      </div>
                                                      <div class="cont-col2">
                                                         <div class="desc">
                                                            New order received 
                                                         </div>
                                                      </div>
                                                   </div>
                                                </div>
                                                <div class="col2">
                                                   <div class="date">
                                                      10 mins
                                                   </div>
                                                </div>
                                             </a>
                                          </li>
                                       </ul>
                                    </div>
                                 </div>
                                 <div class="tab-pane" id="tab_1_3">
                                    <div class="scroller" data-height="290px" data-always-visible="1" data-rail-visible1="1">
                                       <div class="row-fluid">
                                          <div class="span6 user-info">
                                             <img alt="" src="../assets/img/avatar.png" />
                                             <div class="details">
                                                <div>
                                                   <a href="#">Robert Nilson</a> 
                                                   <span class="label label-success">Approved</span>
                                                </div>
                                                <div>29 Jan 2013 10:45AM</div>
                                             </div>
                                          </div>
                                          <div class="span6 user-info">
                                             <img alt="" src="../assets/img/avatar.png" />
                                             <div class="details">
                                                <div>
                                                   <a href="#">Lisa Miller</a> 
                                                   <span class="label label-info">Pending</span>
                                                </div>
                                                <div>19 Jan 2013 10:45AM</div>
                                             </div>
                                          </div>
                                       </div>
                                       <div class="row-fluid">
                                          <div class="span6 user-info">
                                             <img alt="" src="../assets/img/avatar.png" />
                                             <div class="details">
                                                <div>
                                                   <a href="#">Eric Kim</a> 
                                                   <span class="label label-info">Pending</span>
                                                </div>
                                                <div>19 Jan 2013 12:45PM</div>
                                             </div>
                                          </div>
                                          <div class="span6 user-info">
                                             <img alt="" src="../assets/img/avatar.png" />
                                             <div class="details">
                                                <div>
                                                   <a href="#">Lisa Miller</a> 
                                                   <span class="label label-important">In progress</span>
                                                </div>
                                                <div>19 Jan 2013 11:55PM</div>
                                             </div>
                                          </div>
                                       </div>
                                  
                                    </div>
                                 </div>
                              </div>
                           </div>
                           <!--END TABS-->
                        </div>
                     </div>
                       </div>
                     <!-- END PORTLET-->
                      <div class="span6">
                     <div class="portlet box blue">
                        <div class="portlet-title">
                           <div class="caption"><i class="icon-dashboard"></i>Quick Links</div>
                        </div>
                        <div class="portlet-body">
                           <div class="row-fluid">
                        
                        
                        <ul class="unstyled margin-top-10 margin-bottom-10">
                          <li><i class="icon-caret-right"></i> <a href="#">Public Recipes</a></li>
                          <li><i class="icon-caret-right"></i> <a href="#">My Recipes</a></li>
                          <li><i class="icon-caret-right"></i> <a href="#">Save Menus</a></li>
                          <li><i class="icon-caret-right"></i> <a href="#">Menus Pending Approval</a></li>
                          <li><i class="icon-caret-right"></i> <a href="#">Activity Log</a></li>
                          <li><i class="icon-caret-right"></i> <a href="#">My Notes</a></li>  
                        </ul>
                      

                              <div class="span4 hide">
                                       <form id="form" runat="server" method="post">            
            <uc1:header id="Header1" runat="server" />            
            <div class="search_bar">
                <div class="search_bar">
                    <div id="dvLogIn" class="loginBox" runat="server">
                        <span class="inputFields">
                            <asp:textbox id="txtUserName" runat="server" Text="Username" />
                            <input type="text" id="txtPasswordF" value="Password" style="display:none;" />
                            <asp:textbox id="txtPassword" runat="server" TextMode="Password" />
                        </span>
                        
                        <asp:Button  CssClass="btnStyle" style="width:60px;" id="btnLogin" runat="server" Text="Login" onClick="btnLogin_Click" />
                        <br />                 
                        <asp:LinkButton ID="lnkPassword" runat="server" OnClick="lnkPassword_Click">Forgot your password?</asp:LinkButton>
                    </div>
                </div>
                    
                    
                <div class="search_bar" id="dvLoggedIn" runat="server">
                    <div class="search_input">
                        <div class="radioBtnsSeach">
                            <asp:RadioButton id="rbSSN" runat="server" GroupName="SearchBy"  />
                            <label>ssn</label>
                             <asp:RadioButton id="rbCaseNumber" runat="server" GroupName="SearchBy" />
	                        <label>Case #</label>
	                        
                            <asp:RadioButton id="rbFHNumber" runat="server" GroupName="SearchBy" />
	                        <label>F.H #</label>
                            <asp:RadioButton id="rbName" runat="server" GroupName="SearchBy" Checked="true"  />
                            <label>name</label>
                        </div> <%-- end radioBtnsSeach--%>
                        
                        <div class="searchBoxnBtn">
                            <asp:TextBox id="txtSearchKey" runat="server" CssClass="inputSearch" onfocus="ClearTxt()" onblur="RefillTxt()" Text="search"  />
                            <asp:Button CssClass="search_btn" Text="" id="btnSearch" runat="server" onclick="btnSearch_Click" />
                        </div>
                        
                        <script type="text/javascript">
                            function ClearTxt() {
                                if (document.getElementById('txtSearchKey').value == 'search') {
                                    document.getElementById('txtSearchKey').value = "";
                                }
                            }

                            function RefillTxt() {
                                if (document.getElementById('txtSearchKey').value === "") {
                                    document.getElementById('txtSearchKey').value = 'search';
                                }
                            }  
                        </script>
                        
                        <span class="logout">
                            <asp:Button id="btnLogout" runat="server" Text="Logout" onclick="btnLogout_Click" CausesValidation="False" />
                        </span>
                    </div><%-- end search_input--%>
                 </div><%-- end search_bar--%>
            </div>
        </form>  
                                
                              </div>
                            
                           
                             
                           </div>
                        </div>
                     </div>
                  </div>      
            

                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>
      <!-- END PAGE -->  
   </div>
   <!-- END CONTAINER -->
   <!-- BEGIN FOOTER -->
   <div class="footer">
      2013 &copy; Simple Servings
      <div class="span pull-right">
         <span class="go-top"><i class="icon-angle-up"></i></span>
      </div>
   </div> 
   <!-- END FOOTER -->
   <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
   <!-- BEGIN CORE PLUGINS -->
   <script src="../assets/plugins/jquery-1.8.3.min.js" type="text/javascript"></script>   
   <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->  
   <script src="../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>      
   <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
   <!--[if lt IE 9]>
   <script src="../assets/plugins/excanvas.js"></script>
   <script src="../assets/plugins/respond.js"></script>  
   <![endif]-->   
   <script src="../assets/plugins/breakpoints/breakpoints.js" type="text/javascript"></script>  
   <!-- IMPORTANT! jquery.slimscroll.min.js depends on jquery-ui-1.10.1.custom.min.js --> 
   <script src="../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
   <script src="../assets/plugins/jquery.blockui.js" type="text/javascript"></script>  
   <script src="../assets/plugins/jquery.cookie.js" type="text/javascript"></script>
   <script src="../assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script> 
   <!-- END CORE PLUGINS -->
   <!-- BEGIN PAGE LEVEL PLUGINS -->
 
   <!-- END PAGE LEVEL PLUGINS -->
   <!-- BEGIN PAGE LEVEL SCRIPTS -->
   <script src="../assets/scripts/app.js"></script>
   
   <!-- END PAGE LEVEL SCRIPTS -->
   <script>
       jQuery(document).ready(function () {
           // initiate layout and plugins
           App.init();
               
          
          
       });
   </script>
   <!-- END JAVASCRIPTS -->   
</body>
<!-- END BODY -->
</html>


