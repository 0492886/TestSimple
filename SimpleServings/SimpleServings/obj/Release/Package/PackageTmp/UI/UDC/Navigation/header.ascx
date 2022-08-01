<%@ Control Language="c#" Inherits="SimpleServings.UI.UDC.Navigation.header" Codebehind="header.ascx.cs" %>

<div class="header orangeGrad" >
    <div class="logo"><asp:HyperLink ID="hlHome" runat="server"></asp:HyperLink></div>
    <div id="menu">
        <ul id="nav">
            <li>
                <a class="nodrop" href='<%= ResolveUrl("~/UI/Page/Home.aspx") %>' >Home</a>
            </li>

            <li>
                <a class="dropdown" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/Recipe.aspx") %>' >Recipe</a>
                <ul>
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/AddRecipe.aspx") %>' >Add Recipe</a></li>	
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx") %>' >Recipe List</a></li>   
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/MyFavoriteRecipeList.aspx") %>'>My Favorites</a></li>             
                </ul>
            </li>

            <li>
                <a class="dropdown" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Contracts=All") %>' >Providers</a>
                <ul>
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx") %>' >Sponsors</a></li>
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Contract.aspx?Contracts=All") %>' >Contracts</a></li>
                   <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Caterer.aspx") %>' >Caterers</a></li>
                </ul>
            </li>

            <li>
                <a class="dropdown" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus") %>'>Menus</a>
                <ul>
                    <li><a>Add New</a>
                        <ul>
                            <li class="dropdown"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/AddMenu.aspx?MenuType=AddMenu") %>'> Blank Menu </a> </li>
                            <li class="dropdown"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/AddMenu.aspx?MenuType=AddMenuUsingSample") %>'> From Sample Menu</a> </li>
                            <%--<li class="dropdown"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/AddMenuUsingSampleMenu.aspx") %>'> Sample Menu</a> </li> --%>
                        </ul>

                    </li>
                    
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus") %>' >View Menus</a></li>
                   <%-- <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyDrafts") %>' >View Drafts</a></li>--%>
                    <li class="dropdown"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=ViewSamples") %>'>View Samples</a></li>
                </ul>
            </li>

            <li>
                <a class="dropdown" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=SettingsLinks") %>' >Settings</a>
                <ul>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=Setting") %>' >Code Management</a></li>
                    <%--<li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=ManageLinks") %>' >Manage Link</a></li>--%>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=UserGroup") %>' >User Groups</a></li>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=ManageStaff") %>' >Manage Staff</a></li>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=MenuCycle") %>' >Menu Cycle</a></li>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=NutritionalAnalysis") %>' >Nutritional Analysis</a></li>
                    <li><a href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=EditSiteContent") %>' >Site Content</a></li>
                </ul>
            </li>
            <li>
                <a class="dropdown" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Reports/reports.aspx") %>' >Reports</a>
                <ul>
                    <li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Reports/reports.aspx") %>' >Reports</a></li>                   
                </ul>
            </li>

            <li>
                <a class="nodrop" href="#">Support</a>
                 <ul>                     
                 <!--<li><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Help/index.html")  %>' onclick="window.open(this.href);return false;">Help</a></li>-->  
                 <li><a href='<%= ResolveUrl("~/UI/PDF/SimpleServingsHelpPage.pdf")  %>' target="_blank" >Help</a></li>                   
                 <li><a href='<%= ResolveUrl("~/UI/Page/contact.aspx")  %>'>Contact</a></li>
                 <li><a href='<%= ResolveUrl("~/UI/Page/resources.aspx")  %>'>Resources</a></li>
                 <li><a href='<%= ResolveUrl("~/UI/PDF/simple_servings_form_2018_fillable.pdf")  %>' target="_blank" >User Authorization Form</a></li> 
                 </ul>
            </li>

            <li>
                <%--<asp:LinkButton CssClass="nodrop" ID="lnkBLogInOut" runat="server" Text="Log Out" OnClick="lnkBLogOff_Click" />--%>
                <asp:HyperLink CssClass="nodrop" ID="hlkLogInOut" runat="server" Text="Log Out" />
                <%--<a class="nodrop" href='<%= ResolveUrl("~/UI/Page/Login.aspx") %>' >'<%# (Session["UserObject"] != null && Session["UserObject"].GetType() == typeof(SimpleServingsLibrary.Shared.Staff) ? "Log Off" : "Log In" %></a>--%>
            </li>
            

    <%--<li><asp:LinkButton ID="lnkBLogOff" runat="server" Text="Log Off" 
            onclick="lnkBLogOff_Click"></asp:LinkButton></li>--%>
        </ul>
    </div>
</div>
