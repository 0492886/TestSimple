<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DragMenuItems.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.DragMenuItems" %>
<%@ Register src="MenuItemGrid.ascx" tagname="MenuItemGrid" tagprefix="uc2" %>
<%@ Register src="../Recipe/RecipeSearchList.ascx" tagname="RecipeSearchList" tagprefix="uc3" %>
<%@ Register src="ViewMenuWeekStatus.ascx" tagname="ViewMenuWeekStatus" tagprefix="uc1" %>

<asp:Label ID="lblMsg" runat="server"></asp:Label>


<asp:Panel ID="pnPage" CssClass="menuContentBox" runat="server">
<asp:Label ID="lblMenuID" runat="server" Visible="false" ></asp:Label>
<asp:Label ID="lblCannotAlternate" runat="server" style="display:none" />
 <div class="dataRow floatL">
        <div class="dataLabel">Name:</div>                    
        <div class="dataInput"><asp:Label ID="lblMenuName" runat="server"></asp:Label></div>
    </div>
    <div class="dataRow floatL">
        <div class="dataLabel">Program Type :</div>                    
        <div class="dataInput">
            <asp:Label ID="lblContract" runat="server"></asp:Label>
            
        </div>
    </div>
    <div class="dataRow floatL">
        <div class="dataLabel">Meal Type :</div>                    
        <div class="dataInput"><asp:Label ID="lblMealType" runat="server"></asp:Label></div>
    </div>
<div runat="server" id ="divCycle">
    <div class="dataRow floatL">
        <div class="dataLabel">Cycle :</div>                    
        <div class="dataInput"><asp:Label ID="lblCycle" runat="server"></asp:Label></div>
    </div>
    <div class="dataRow floatL">
        <div class="dataLabel">Start Date :</div>                    
        <div class="dataInput"><asp:Label ID="lblStartDate" runat="server"></asp:Label></div>
    </div>
    <div class="dataRow floatL">
        <div class="dataLabel">End Date :</div>                    
        <div class="dataInput"><asp:Label ID="lblEndDate" runat="server"></asp:Label></div>
    </div>

</div>
    <div class="dataRow floatL hide">
        <div class="dataLabel">Days of service :</div>                    
        <div class="dataInput">
            <asp:Repeater runat="server" id="rptDays">
            <ItemTemplate>
            <i class="icon-tags"></i> <%# DataBinder.Eval(Container.DataItem, "DayName") %>
            </ItemTemplate> 
            </asp:Repeater>
        </div>
    </div>
    <div class="dataRow floatL">
        <div class="dataLabel">Menu Status :</div>                    
        <div class="dataInput"><asp:Label ID="lblMenuStatus" runat="server"></asp:Label></div>
    </div>
    <div class="clearfix"></div>

    <div class="menuDataList">
        <div class="menuListLeft floatL"> 
            <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <uc3:RecipeSearchList ID="RecipeSearchList1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
           <%-- <ProgressTemplate>
                <div id="up1Loading"></div>
            </ProgressTemplate>
               --%>
                 <progresstemplate>                     
 
                        <div class="searchoverlay">
                            <div class="searchoverlayContent">
                                <img alt="Loading" src="../../../Imgs/ajax-loader2.gif"/><br /><br />
                                <!--<h2>Loading, please wait…</h2>-->
                                </div>
                        </div>
                    </progresstemplate>
 
            </asp:UpdateProgress>
        </div>
        <div class="menuListRight floatR">                
            <asp:Button ID="btnValidate2" CssClass="floatR btn_black2 marginBtn" runat="server" Text="How Is My Menu?" onclick="btnValidate_Click" />
            <asp:Button cssClass="floatR btn_black2 marginBtn" ID="btnComplete2" runat="server" Text="Mark As Complete" onclick="btnComplete_Click" />

                <uc1:ViewMenuWeekStatus ID="ViewMenuWeekStatus1" runat="server" />
                 <uc2:MenuItemGrid ID="MenuItemGrid1" runat="server" /> 
               
                    
            <asp:Button ID="btnValidate" CssClass="floatR btn_black2 marginBtn" runat="server" Text="How Is My Menu?" onclick="btnValidate_Click" />
            <asp:Button cssClass="floatR btn_black2 marginBtn" ID="btnComplete" runat="server" Text="Mark As Complete" onclick="btnComplete_Click" />
    <!--this panel is used to hide the validation during ADD/EDIT-->
    <asp:Panel ID="pnValidation" runat="server" Visible="false">     
        <div class="dataList" style="border:0px; padding: 0px;">
           
      <div class="error">Oops! Some nutrition requirements have not been met.</div>
        <table class="alerts">    
     
            <tr>
                <td class="listAlerts">
                  <h4>Meal Component :</h4> 
                     <asp:Label ID="lblValidationMsg" runat="server" Text="" ForeColor="#9C2614" />
                </td>

                 <td class="listAlerts" >
                   <h4>Nutritional Analysis :</h4><asp:Label ID="lblNutritionValidation" runat="server" Text="" ForeColor="#9C2614" />
                </td>
                </tr>
               
        </table>
       
   </div>
    </asp:Panel>
     <asp:Panel ID="pnSuccess" runat="server" Visible="false"> 
     <div class="dataList" style="border:0px; padding: 0px;">
        <asp:Label ID="lblSuccess" runat="server" Text="" ForeColor="Green"/> 
       </div>   
 </asp:Panel>
    </div>
    </div>
</asp:Panel>

