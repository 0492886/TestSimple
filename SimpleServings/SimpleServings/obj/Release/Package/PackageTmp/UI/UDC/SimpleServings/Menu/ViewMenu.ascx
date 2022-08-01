<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewMenu.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.ViewMenu" %>

<%@ Register src="MenuItemGrid.ascx" tagname="MenuItemGrid" tagprefix="uc2" %>
<%@ Register src="MenuStatusChangeActionPanel.ascx" tagname="MenuStatusChangeActionPanel" tagprefix="uc1" %>
<%@ Register src="ViewMenuWeekStatus.ascx" tagname="ViewMenuWeekStatus" tagprefix="uc3" %>
<%@ Register src="MenuStatusHistoryGrid.ascx" tagname="MenuStatusHistoryGrid" tagprefix="uc4" %>
<%@ Register Src="~/UI/UDC/SimpleServings/Menu/MenuItemGridChangeHistory.ascx" TagName="MenuItemGridChangeHistory" TagPrefix="uc5" %>


<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
<asp:Panel ID="pnPage" runat="server">
   
    <asp:Panel runat="server" ID="pnActionsPanel"> 
        <div class="recipeViewR mb0">

                <h2 class="title2">Actions Available</h2>
                <div class="dataList">                    
                    <uc1:MenuStatusChangeActionPanel ID="MenuStatusChangeActionPanel1" runat="server" />                    
                </div>

            </div>
    </asp:Panel>
    <div class="contentBox recipeViewL">
     <div class="title2 h2Size"><asp:Label ID="lblViewMenu" runat="server" Text="View Menu"></asp:Label>
        <%--<a class="back floatR" href="JavaScript:history.back();">Back</a>--%>
         <%--<a class="back floatR" href="MenuList.aspx?MenuType=MyMenus">Back</a>--%>
         <a class="back floatR" href="javascript:history.go(-1)">Back</a>

        <asp:LinkButton ID="lnkBAddMenuItem" CssClass="add floatR" runat="server" 
            Text ="Edit Menu" 
            onclick="lnkBAddMenuItem_Click">
        </asp:LinkButton>
         <asp:LinkButton ID="lnkBReplicate" CssClass="add floatR" runat="server" 
            Text ="Replicate Menu " 
            onclick="lnkBReplicate_Click" Visible="false">
        </asp:LinkButton>
         <asp:LinkButton ID="lnkBEditMenu" CssClass="add floatR" runat="server" 
            Text ="Edit Header Info " 
            onclick="lnkBEditMenu_Click" Visible="false">
        </asp:LinkButton>
            <asp:LinkButton ID="lnkBEditMenuName" CssClass="add floatR" runat="server"  
            Text ="Edit Menu Name" ToolTip="Edit Menu Name" 
            onclick="lnkBEditMenuName_Click">
        </asp:LinkButton>
        <asp:HyperLink ID="lnkBtnCreateNewMenuUsingSample" CssClass="add floatR" ToolTip="Create new menu using this sample" Text ="Create New Menu" runat="server" Visible="false"/>

    </div>
    <div class="dataList">
        <asp:Label ID="lblMsg" runat="server"></asp:Label> 

        <div class="dataRow">            
            <div class="dataLabel w501"><span class="wtitle">Menu ID :</span> <asp:Label CssClass="dataInput" ID="lblMenuID" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">                               
            </div>
        </div>


       <div class="dataRow">            
            <div class="dataLabel w501"><span class="wtitle">Menu Name :</span> <asp:Label CssClass="dataInput" ID="lblMenuName" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">                                              
                               
            </div>
        </div>
        <div class="dataRow">
            
            <div class="dataLabel w501"><span class="wtitle">Program Type :</span> <asp:Label CssClass="dataInput" ID="lblContract" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">                                              
                               
            </div>
        </div>
         <div class="clearfix"></div>   
        <div class="dataRow">
            <div class="dataLabel w501"><span class="wtitle">Meal Type :</span> <asp:Label  CssClass="dataInput" ID="lblMealType" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">                     
                                
            </div>
        </div>
         <div class="dataRow" style="display:none" >
            <div class="dataLabel w501"><span class="wtitle">Diet Type :</span> <asp:Label  CssClass="dataInput" ID="lblDietType" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">                     
                                
            </div>
        </div>
        <div class="clearfix"></div> 
        <div class="datarow">
            <div class="dataLabel w501"><span class="wtitle">Menu Format :</span> <asp:Label  CssClass="dataInput" ID="lblMealTypeFormat" runat="server"></asp:Label>     </div>                    
            <div class="dataInput">  
                </div>
        </div>


         <div class="clearfix"></div>  
        <div runat="server" id="divCycleSection">
        <div class="dataRow">
            <div class="dataLabel w501"><span class="wtitle">Cycle :</span> <asp:Label   CssClass="dataInput" ID="lblCycle" runat="server"></asp:Label> </div>                    
            <div class="dataInput">                     
                  
            </div>
        </div>
          <div class="clearfix"></div>          
        <div class="dataRow">
            <div class="dataLabel w501"><span class="wtitle">Start Date :</span> <asp:Label  CssClass="dataInput"  ID="lblStartDate" runat="server"></asp:Label></div>                    
             <div class="dataInput">                     
                
            </div>
        </div>
         <div class="clearfix"></div>   
        <div class="dataRow">
            <div class="dataLabel w501"><span class="wtitle">End Date :</span> <asp:Label  CssClass="dataInput"  ID="lblEndDate" runat="server"></asp:Label> </div>                    
            <div class="dataInput">                     
                                    
            </div>
        </div>
        </div>         
         <div class="clearfix"></div>   
        <div class="dataRow">
            <div class="dataLabel w501"><span class="wtitle">Days of service :</span> <asp:Repeater runat="server" id="rptDays">
                    <ItemTemplate>
                        <i class="icon-tags"></i> <span class="dataInput"><%# DataBinder.Eval(Container.DataItem, "DayName") %></span>
                    </ItemTemplate> 
                </asp:Repeater>  </div>                    
            <div class="dataInput">
                        
            </div>
        </div>
        <div class="clearfix"></div> 
        <div class="dataRow" runat="server" id="divContractName">
             
            <div class="dataLabel w501">
                <span class="wtitle" id="spanContractName">Contract Name :</span> <asp:DataList CssClass="dataInput tdSpacing"  ID="dlContracts" runat="server" Visible="false">
                    <ItemTemplate>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &#9679;
                        <asp:Label ID="lblContractNames" runat="server" Text='<%# Container.DataItem.ToString() %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>

                <asp:Label CssClass="dataInput" ID="lblContractName" runat="server"></asp:Label>
                
<%--                <div>--%>
                
<%--                </div>--%>
            </div>                    
            <div class="dataInput"></div>
        </div>

       <div class="dataRow" id="divSampleMenuName" runat="server" visible="false">
            <div class="dataLabel w501"><span class="wtitleLarge">Original Sample Menu :</span> <asp:Label  CssClass="dataInput" Font-Bold="true"  ID="lblSampleMenuName" runat="server" Visible="false"></asp:Label> </div>                    
            <div class="dataInput">                                    
            </div>
        </div>



    </div>  
    </div>
     <div class="clearfix"></div>   
    <div class="contentBox marginTophack">
     <div class="title2 h2Size">Menu Information
      <%--<a class="print floatR" href="#" id="lnkPrintMenu" target="_blank" runat="server">View/Print Entire Menu</a>--%>

           <asp:LinkButton ID="lnkMenuPrint" runat="server" OnClick="lnkMenuPrint_Click"  class="print floatR" >View/Print Entire Menu</asp:LinkButton>
      
      
     </div>
    <div class="dataList">
            <div class="dataRow">
            <div class="dataLabel">Menu Status : <asp:Label CssClass="dataInput bold" ID="lblMenuStatus" runat="server"></asp:Label> </div>   
        </div>
        <div class="line8"></div>
        <br />
        <div>
            <uc3:ViewMenuWeekStatus ID="ViewMenuWeekStatus1" runat="server" />
        </div>
        
        <div class="dataRow">
            <uc2:MenuItemGrid ID="MenuItemGrid1" runat="server" ShowDeleteButton="false" />              
        </div>

        <%-- 
        <asp:Button cssClass="btn_black2" ID="btnValidate" runat="server" Text="How Is My Menu?" 
        onclick="btnValidate_Click" />

        <asp:Button cssClass="btn_black2" ID="btnComplete" runat="server" Text="Mark As Complete" 
        onclick="btnComplete_Click" /><br />
        --%>
         </div>
          <asp:Panel ID="pnValidation" runat="server" Visible="false">
          Oops!  All nutrition requirements have not been met.
        <h2 class="title2">Required Fields</h2>
        <div class="dataList">
       
        <table class="alerts">    
     
            <tr>
                <td class="listAlerts">
                  <h4>Meal Component :</h4> 
                     <asp:Label ID="lblValidationMsg" runat="server" Text="" ForeColor="#9C2614" />
                </td>
                </tr>
                <tr>

                <td class="listAlerts" >
                   <h4>Nutritional Analysis :</h4><asp:Label ID="lblNutritionValidation" runat="server" Text="" ForeColor="#9C2614" />
                </td>
            </tr>
        </table>
       
   </div>
    </asp:Panel>
    <asp:Panel ID="pnSuccess" runat="server" Visible="false">
       <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"/>
       </asp:Panel>
    
    </div>


    <div class="contentBox marginTophack">
            <h2 class="title2">Menu Status History</h2>
            <div class="dataList">                                                       
                                 
                <uc4:MenuStatusHistoryGrid ID="MenuStatusHistoryGrid1" runat="server" />
                                 
            </div>
        </div>
        <div class="contentBox marginTophack" runat="server" id="divMenuItemLog" visible="false">
            <h2 class="title2">Sample Menu Item Change History</h2>
            <div class="dataList">                                 
             <uc5:MenuItemGridChangeHistory runat="server" ID="MenuItemGridChangeHistory1" />                                 
            </div>
        </div>
     
         <div class="menuListRight floatR">

      </div>
   
   
</asp:Panel>
 

 

 

 