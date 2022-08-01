<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRecipeStatus.aspx.cs" Inherits="SimpleServings.UI.Page.SimpleServings.Recipe.EditRecipeStatus" %>

<%@ Register src="../../../UDC/SimpleServings/Recipe/EditRecipeStatus.ascx" tagname="EditRecipeStatus" tagprefix="uc1" %>

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
   <link href="../../../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/css/style-metro.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/css/style.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
   <link href="../../../assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
   <link href="../../../assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
   <!-- END GLOBAL MANDATORY STYLES -->
   <!-- BEGIN PAGE LEVEL STYLES -->
   <link rel="stylesheet" type="text/css" href="../../../assets/plugins/chosen-bootstrap/chosen/chosen.css" />
   <link href="../../../assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css"/>   
   <!-- END PAGE LEVEL STYLES -->
   <link rel="shortcut icon" href="ss" />
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
<body id="homepage" class="fixed-top">
   <!-- BEGIN HEADER -->
   <div class="header navbar navbar-inverse navbar-fixed-top">
      <!-- BEGIN TOP NAVIGATION BAR -->
      <div class="navbar-inner">
         <div class="container-fluid">
            <!-- BEGIN LOGO -->
            <a class="brand" href="#">
            <img src="../../../assets/img/logo.png" alt="logo" />
            </a>
            <!-- END LOGO -->
            <!-- BEGIN RESPONSIVE MENU TOGGLER -->
            <a href="javascript:;" class="btn-navbar collapsed" data-toggle="collapse" data-target=".nav-collapse">
            <img src="../../../assets/img/menu-toggler.png" alt="" />
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
               <!-- BEGIN INBOX DROPDOWN -->

               <!-- END INBOX DROPDOWN -->
               <!-- BEGIN TODO DROPDOWN -->
               
               <!-- END TODO DROPDOWN -->
               <!-- BEGIN USER LOGIN DROPDOWN -->
               <li class="dropdown user">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                  <img alt="" src="../../../assets/img/avatar1_small.jpg" />
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
				
                	        		
        		<li class="start ">
        			<a href="../../dashboard.aspx">
					<i class="icon-home"></i> 
					<span class="title">Dashboard</span>
					</a>

				</li>
				
		        	        		
        		<li class="active ">
        			<a href="javascript:;">
					<i class="icon-table"></i> 
					<span class="title">Recipes</span>
					
										<span class="selected"></span>
					
										<span class="arrow open"></span>
										</a>

							<ul class="sub-menu">                                
							<li><a href="addRecipe.aspx">Add Recipe</a></li>							
                            <li class="active"><a href="RecipeList.aspx">Recipe List</a></li>   
                       
							</ul>
					</li>
                     <li>
        			<a href="javascript:;">
					<i class="icon-table"></i> 
					<span class="title">Suppliers</span>
					
										<span class="selected"></span>
					
										<span class="arrow open"></span>
										</a>

							<ul class="sub-menu">                                
							<li><a href="../Supplier/Sponsor.aspx">Sponsors</a></li>							
                            <li><a href="../Supplier/Contract.aspx">Contract</a></li>
                            <li><a href="../Supplier/Caterer.aspx">Caterers</a></li>                                
							</ul>

					</li>
				
					</ul>
		<!-- END SIDEBAR MENU -->
      </div>
      <!-- END SIDEBAR -->
      <!-- BEGIN PAGE -->  
      <div class="page-content">
 
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
                 <h3 class="page-title">
                    
                     <small></small>
                  </h3>
                  <ul class="breadcrumb">
                     <li>
                        <i class="icon-home"></i>
                        <a href="#">Home</a> 
                        <span class="icon-angle-right"></span>
                     </li>
                     <li>
                        <a href="#">Recipes</a>
                        <span class="icon-angle-right"></span>
                     </li>
                     <li><a href="#">Recipe Status</a></li>
                  </ul>
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
               <div class="span12">
            <div class="portlet box red">
                  <div class="portlet-title">
                        <div class="caption">
                           <i class="icon-reorder"></i>Recipe Status<span class="step-title"></span>
                        </div>
                        <div class="tools hidden-phone">
                           <a href="javascript:;" class="collapse"></a>
                           <a href="javascript:;" class="reload"></a>
                           <a href="#portlet-config" data-toggle="modal" class="config"></a>
                        
                        </div>
                     </div>
            <div class="portlet-body form">
    <form id="form1" runat="server">
    <div>
    
        <uc1:EditRecipeStatus ID="EditRecipeStatus1" runat="server" />
    
    </div>
    </form>
</div>
                        </div>



                     </div>
                   
                  </div>
               </div>
            </div>
            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
     
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
   <script src="../../../assets/plugins/jquery-1.8.3.min.js" type="text/javascript"></script>   
   <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->  
   <script src="../../../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>      
   <script src="../../../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
   <!--[if lt IE 9]>
   <script src="../../../assets/plugins/excanvas.js"></script>
   <script src="../../../assets/plugins/respond.js"></script>  
   <![endif]-->   
   <script src="../../../assets/plugins/breakpoints/breakpoints.js" type="text/javascript"></script>  
   <!-- IMPORTANT! jquery.slimscroll.min.js depends on jquery-ui-1.10.1.custom.min.js --> 
   <script src="../../../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
   <script src="../../../assets/plugins/jquery.blockui.js" type="text/javascript"></script>  
   <script src="../../../assets/plugins/jquery.cookie.js" type="text/javascript"></script>
   <script src="../../../assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script> 
   <!-- END CORE PLUGINS -->
   <!-- BEGIN PAGE LEVEL PLUGINS -->
   <script type="text/javascript" src="../../../assets/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js"></script>
   <script type="text/javascript" src="../../../assets/plugins/chosen-bootstrap/chosen/chosen.jquery.min.js"></script>
   <script type="text/javascript" src="../../../assets/plugins/gritter/js/jquery.gritter.js"></script>
   <!-- END PAGE LEVEL PLUGINS -->
   <!-- BEGIN PAGE LEVEL SCRIPTS -->
   <script src="../../../assets/scripts/app.js"></script>
   <script src="../../../assets/scripts/form-wizard.js"></script>   
   <script src="../../../assets/scripts/ui-general.js"></script>       
   <!-- END PAGE LEVEL SCRIPTS -->
   <script>
       jQuery(document).ready(function () {
           // initiate layout and plugins
           App.init();
           UIGeneral.init();

       });
   </script>
   <!-- END JAVASCRIPTS -->   
</body>
<!-- END BODY -->
</html>


