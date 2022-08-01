<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="SimpleServings.UI.testPage.navigation.header" %>
<header>
    <div class="logo">
        <h1><a href="#">Simple Servings</a></h1>
    </div>
    <nav>
        <ul class="menu">
	        <li class="navBtn"><a href="~/UI/testPage/dashboard.aspx" runat="server">Home</a></li>
	        <li class="navBtn">
                <a href="#" class="dropdown-toggle">Recipes <b>&#8897;</b></a>
                <ul class="sub-menu">                                
				    <li><a href="~/UI/testPage/SimpleServings/Recipe/AddRecipe.aspx" runat="server">Add Recipe</a></li>							
                    <li><a href="~/UI/testPage/SimpleServings/Recipe/RecipeList.aspx" runat="server">Recipe List</a></li>                               
				</ul>
            </li>
	        <li class="navBtn">
                <a href="#" class="dropdown-toggle">Suppliers <b>&#8897;</b></a>
                <ul class="sub-menu">                                
                    <li><a href="~/UI/testPage/SimpleServings/Supplier/Sponsor.aspx" runat="server">Sponsors</a></li>
                    <li><a href="~/UI/testPage/SimpleServings/Supplier/Contract.aspx" runat="server">Contracts</a></li>
                    <li><a href="~/UI/testPage/SimpleServings/Supplier/Caterer.aspx" runat="server">Caterers</a></li>                                
                </ul>
            </li>
	        <li class="navBtn"><a href="#">Menus</a></li>
	        <li class="navBtn"><a href="#">Contact</a></li>
        </ul>
    </nav>
    <div class="userArea">
        <div class="notification" id="header_notification_bar">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <span class="badge">06</span>
                <span class="newUp">Updates</span>
                <span class="btn_dropdown">&#8897;</span>
            </a>
            <ul class="sub-menu">
                <li class="noteCount"><p>You have 14 new notifications</p></li>
                <li>
                    <a href="#">
                        <span class="label label-success"><i class="icon-plus"></i></span>New user registered.
                        <span class="time">Just now</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>Server #12 overloaded. 
                        <span class="time">15 mins</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="label label-warning"><i class="icon-bell"></i></span>Server #2 not respoding.
                        <span class="time">22 mins</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="label label-info"><i class="icon-bullhorn"></i></span>Application error.
                        <span class="time">40 mins</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>Database overloaded 68%. 
                        <span class="time">2 hrs</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="label label-important"><i class="icon-bolt"></i></span>2 user IP blocked.
                        <span class="time">5 hrs</span>
                    </a>
                </li>
                <li class="external"><a href="#">See all notifications<i class="m-icon-swapright"></i></a></li>
            </ul>
        </div>
        <div class="user">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <img src="~/UI/testPage/assets/img/avatar1_small.jpg" runat="server" alt="" />
                <span class="username">Jonh Doe</span>
                <span class="btn_dropdown">&#8897;</span>
            </a>
            <ul class="sub-menu">
                <li><a href="#"><i class="icon-user"></i> My Profile</a></li>
                <li><a href="#"><i class="icon-calendar"></i> My Calendar</a></li>
                <li><a href="#"><i class="icon-envelope"></i> My Inbox(3)</a></li>
                <li><a href="#"><i class="icon-tasks"></i> My Tasks</a></li>
                <li><a href="#"><i class="icon-key"></i> Log Out</a></li>
            </ul>
        </div>
    </div>
<%--    <script>
        $(document).ready(function () {
            $('.sub-menu').hide();

            $('.dropdown-toggle').mouseenter(function () {
                $(this).next('.sub-menu').stop(true, true).show();
            });
            $('.dropdown-toggle').mouseleave(function () {
                $(this).next('.sub-menu').stop(true, true).fadeOut(300);
            });

            $('.sub-menu').mouseenter(function () {
                $(this).stop(true, true).show();
            });
            $('.sub-menu').mouseleave(function () {
                $(this).stop(true, true).hide();
            });
        });
   </script>--%>
</header>