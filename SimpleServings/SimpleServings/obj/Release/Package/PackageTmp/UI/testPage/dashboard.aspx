<%@ Page Language="C#" CodeBehind="dashboard.aspx.cs" Inherits="SimpleServings.UI.testPage.dashboard" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="~/UI/testPage/navigation/header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="~/UI/testPage/navigation/footer.ascx" %>
<%@ Register TagPrefix="uc2" TagName="AddEditAccountInfo" Src="../UDC/SimpleServings/Staff/AddEditAccountInfo.ascx" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Simple Servings Admin</title>
    <link rel="Stylesheet" type="text/css" href="assets/css/style.css" />
    <script type="text/javascript" src="assets/js/jquery-1.10.1.min.js"></script>
    <script type="text/javascript">
        window.onload = loaderFunct;
        function loaderFunct() {
            loginTxt();
            myZoneMenu();
        };

        function stopError() {
            return true;
        }
        window.onerror = stopError;
    </script>
</head>
<body>
    <form id="form1" runat="server">

<!-- // HEADER // Contains main navigation and userarea. -->
    <uc1:header ID="header1" runat="server" />
<!-- // HEADER end //-->

<!-- // CONTENT // Contains page content. -->
    <div class="content">

        <!-- PAGETITLE -->
        <div class="pageTitle greyGrad">
            <h2>Dashboard</h2>
        </div>
        <!-- PAGETITLE end -->

        <!-- SEARCH -->
        <div class="searchBox">
		    <form class="search">
			    <div class="input-box">
				    <input type="text" placeholder=" " />				
				    <input id="searchbtn" class="greyGrad" type="button" value="Search" />
			    </div>
		    </form>
        </div>
		<!-- SEARCH end-->

        <!-- HEADLINE -->
        <div class="contentTop greyGrad">
            <h1>Recipe and Menu Administration</h1>
        </div>
        <!-- HEADLINE end -->

        <!-- INFO  -->
        <div class="recipeInfo clearfix">
        </div>
        <!-- INFO end -->

        <!-- CONTENT MAIN LEFT -->
        <div class="contentMain">

            <div class="moduleBox floatL">
                <h3>What's New</h3>


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
                    </div>
                </div>
<!--END TABS-->

            </div>

            <div class="moduleBox floatL">
                <h3>User Info</h3>
                <ul>
                    <li class="user-info">
                        <img alt="" src="../assets/img/avatar.png" />
                        <a href="#">Robert Nilson</a>
                        <span class="label label-success">Approved</span>
                        <div>29 Jan 2013 10:45AM</div>
                    </li>
                    <li class="user-info">
                        <img alt="" src="../assets/img/avatar.png" />
                        <a href="#">Lisa Miller</a>
                        <span class="label label-success">Pending</span>
                        <div>19 Jan 2013 10:45AM</div>
                    </li>
                    <li class="user-info">
                        <img alt="" src="../assets/img/avatar.png" />
                        <a href="#">Eric Kim</a>
                        <span class="label label-success">Pending</span>
                        <div>19 Jan 2013 12:45PM</div>
                    </li>
                    <li class="user-info">
                        <img alt="" src="../assets/img/avatar.png" />
                        <a href="#">Lisa Miller</a>
                        <span class="label label-success">In progress</span>
                        <div>19 Jan 2013 11:55PM</div>
                    </li>
                </ul>
            </div>
        </div>
        <!-- CONTENT MAIN LEFT end -->

        <!-- CONTENT SIDE RIGHT -->
        <div class="contentSide">

            <div class="moduleBox floatL">
	            <h3>Quick Links</h3>
                <ul class="unstyled margin-top-10 margin-bottom-10">
                    <li><i class="icon-caret-right"></i> <a href="#">Public Recipes</a></li>
                    <li><i class="icon-caret-right"></i> <a href="#">My Recipes</a></li>
                    <li><i class="icon-caret-right"></i> <a href="#">Save Menus</a></li>
                    <li><i class="icon-caret-right"></i> <a href="#">Menus Pending Approval</a></li>
                    <li><i class="icon-caret-right"></i> <a href="#">Activity Log</a></li>
                    <li><i class="icon-caret-right"></i> <a href="#">My Notes</a></li>  
                </ul>
	        </div>

        </div>
        <!-- CONTENT SIDE RIGHT end-->

    </div>
<!-- // CONTENT End //-->

<!-- // FOOTER // Contains copyrights. -->
    <uc1:footer ID="footer1" runat="server" />
<!-- // FOOTER end //-->
    </form>
</body>
</html>