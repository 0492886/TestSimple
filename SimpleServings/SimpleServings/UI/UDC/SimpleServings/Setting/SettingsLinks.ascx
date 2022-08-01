<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SettingsLinks.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.SettingsLinks" %>


<asp:Label ID="lblMsg" runat="server" />

<asp:Panel ID="pnPage" runat="server" CssClass="contentBox iconSpecMenu">
 <h2 class="title2">Management</h2>

 <div class="white borderTop">
  <div style="height:11px; width:100%"></div>
    <table>
        <tr>
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=Setting">
                         <img src="../../UI/Imgs/setting/cm.gif" height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=Setting">Code Management</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=Setting">
                    Manage all  dropdown settings in Simple Servings including code security and 
                    cascading dropdowns</a></span>
                </div>
                </div>


            </td>
             
        
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=Links">
                        <img src="../../UI/Imgs/setting/manage-_links.gif"  height="43" alt="" /></a>
                    <div class="cont">
                       <h4> <a href="../../UI/Page/myzone.aspx?Control=ManageLinks">Manage Links</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=ManageLinks">
                    Manage all side bar links that appear on the right column of MyZone. Change the URL of links or change the link title

                    </a></span>
                </div>
             </div>  
            </td>
        </tr>
        
        <tr>
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=UserGroup">
                        <img src="../../UI/Imgs/setting/ug.gif"  height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=UserGroup">User Groups</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=UserGroup">
                    Add new user groups and set module level security. 
                    Manage all permissions of assessments and MyZone links</a></span>
                </div>
                </div>
            </td>
        
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=ManageStaff">
                        <img src="../../UI/Imgs/setting/ms.gif"  height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=ManageStaff">Manage Staff</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=ManageStaff">
                   Search all staff. Edit profiles, reset passwords, set staff level permissions</a></span>
                </div>
            </div>
            </td>
            </tr>
            <!-- newly added -->
            <tr>
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=MenuCycle">
                        <img src="../../UI/Imgs/setting/mc.gif"  height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=MenuCycle">Menu Cycle</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=MenuCycle">
                    The definition of a cycle menu is a menu which cycles through the food items for a set period of time.</a></span>
                </div>
                </div>
            </td>
        
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=NutritionalAnalysis">
                        <img src="../../UI/Imgs/setting/HouseSP.gif"  height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=NutritionalAnalysis">Nutritional analysis</a></h4>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=NutritionalAnalysis">
                   Nutrition analysis refers to the process of determining the nutritional content of foods and food products</a></span>
                </div>
            </div>
            </td>
            </tr>


                <!-- newly added -->
            <tr>
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=MenuCycle">
                        <img src="../../UI/Imgs/updateIcon.png"  height="43" alt="" /></a>
                         <asp:Button CssClass="btn btn_save" ID="btnUpdateRecipes" runat="server" Text="Update Recipes" onclick="btnUpdateRecipes_Click" />
                    <div class="cont">
                        <h4><a href="../../UI/Page/myzone.aspx?Control=MenuCycle">Update Recipe</a></h4>
                    </div>                   
                    <span class="dco">
                    <span class="settingsFont">Clicking this button will update the tags of all recipes. This will reflect those recipes rich in Vitamin C, Fiber, etc.</span>
                    </span>
                </div>
                </div>
            </td>
        
            <td>
             <div class="managementBox">		
                <div class="iconSpecMenuSection">
                    <a class="iconSpecMenuImgLnk" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Reports/reports.aspx") %>'>
                        <img src="../../UI/Imgs/reportsIcon.png"  height="43" alt="" /></a>
                    <div class="cont">
                        <h4><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Reports/reports.aspx") %>' >Reports</a></h4>
                    </div>
                    
                    <span class="dco"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Reports/reports.aspx") %>' >
                   Add, Edit, Modify list of reports and set viewing permissions.</a></span><br /><br />
                </div>
            </div>
            </td>
            </tr>
        
        <tr>
            <td>
                <div class="managementBox">
                    <div class="iconSpecMenuSection">
                        <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=EditSiteContent">
                        <%--<img src="../../UI/Imgs/reportsIcon.png"  height="43" alt="" />--%>
                        </a>
                        <div class="cont">
                            <h4><a href="../../UI/Page/myzone.aspx?Control=EditSiteContent">Site Content</a></h4>
                        </div>
                    
                        <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=EditSiteContent" >
                        Manage featured recipe, welcome message and nutritional message content.</a></span><br /><br />
                    </div>
                </div>
            </td>

           <td>
                <div class="managementBox">
                    <div class="iconSpecMenuSection" > 
                        <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=ManageCategoriesandTags">
                        </a>
                        <div class="cont">
                            <h4><a href="../../UI/Page/myzone.aspx?Control=ManageCategoriesandTags">Manage Recipe Categories</a></h4>
                        </div>
                    
                        <span class="dco"><a>
                        Manage Relationship between Recipe Categories and Recipe tags.</a></span><br /><br />
                    </div>
                </div>
            </td>
       </tr> 
          
        <tr>
        
        
            <td>
                <div class="iconSpecMenuSection" style="visibility:hidden">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=ManageSites">
                        <img src="../../UI/Imgs/setting/HouseSP.GIF"  height="43" alt="" /></a>
                    <div class="cont">
                        <a href="../../UI/Page/myzone.aspx?Control=ManageSites">Manage Sites</a>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=ManageSites">
                   Add new sites, edit address and phone numbers of deactivate a closed site</a></span>
                </div>
            </td>
            </tr>
            
        <tr>
            <td>
                <div class="iconSpecMenuSection" style="visibility:hidden">
                    <a class="iconSpecMenuImgLnk" href="../../UI/Page/myzone.aspx?Control=ManageCase">
                        <img src="../../UI/Imgs/setting/mc.gif"  height="43" alt="" /></a>
                    <div class="cont">
                        <a href="../../UI/Page/myzone.aspx?Control=ManageCase">Manage Cases</a>
                    </div>
                    
                    <span class="dco"><a href="../../UI/Page/myzone.aspx?Control=ManageCase">a process in 
                    which you make a judgment about a person or situation, or the judgment 
                    you make</a></span>
                </div>
            </td>
        </tr> 


    </table>
     
    </div>  
<div class="clearfix"></div>   
</asp:Panel>
