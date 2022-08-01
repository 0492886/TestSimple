<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItems.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuItems" %>

<asp:Label ID="lblMenuID" runat="server" Visible="false" />
 Week in Cycle
              <asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" 
    onselectedindexchanged="ddlWeek_SelectedIndexChanged"></asp:DropDownList>
             <br />


  <asp:Repeater runat="server" id="rptMenuItemTypes" >
     <ItemTemplate>
         <ul>
              
              <h3> <u>                                                
                  <%# DataBinder.Eval(Container.DataItem, "Description") %> 
                   </u> 
                  </h3> 
               <%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>                                   
               <%# DataBinder.Eval(Container.DataItem, "Comment") %> 
         </ul>
         <asp:Repeater runat="server" id="rptDaysOfWeek" DataSource='<%# GetDaysOfWeekByMenuID() %>'>
            <ItemTemplate>
                   <h4>                     
                  <%# DataBinder.Eval(Container.DataItem, "DayName")%>                                 
                    </h4>            
             
          <asp:Repeater runat="server" id="rptRecipes" DataSource='<%# GetMenuItemsByMenuAndItemTypeAndDayAndWeek(DataBinder.Eval(Container.DataItem,"MenuID"),DataBinder.Eval(Container.Parent.Parent,"DataItem.MenuItemTypeID"),DataBinder.Eval(Container.DataItem,"DayOfWeekID")) %>'>
            <ItemTemplate>
                    <ul>
              <li>                             
                  <%# DataBinder.Eval(Container.DataItem, "RecipeName")%>                                 
                </li>
         </ul>                      
             </ItemTemplate>
             <SeparatorTemplate>
               
             </SeparatorTemplate> 
         </asp:Repeater>

       </ItemTemplate> 
       <SeparatorTemplate>
                <br />
             </SeparatorTemplate> 
         </asp:Repeater>                     
    </ItemTemplate> 

    <SeparatorTemplate>
   <hr />
   
   </SeparatorTemplate>
                            
  </asp:Repeater>

   