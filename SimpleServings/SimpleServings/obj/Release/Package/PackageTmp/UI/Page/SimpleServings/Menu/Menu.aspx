<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs"  Inherits="SimpleServings.UI.Page.SimpleServings.Menu.Menu" %>




<head id="Head1" runat="server">
    <title>Untitled Page</title>    
</head>


<body>
    
<form id="form1" runat="server" method="post">
    <asp:Label ID="lblMenuID" runat="server" Visible="false" />
    <asp:Label ID="lblWeek" runat="server" Visible="false" />
    
        <asp:GridView ID="gvMenuItems1" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   
        

       <asp:GridView ID="gvMenuItems2" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   

       <asp:GridView ID="gvMenuItems3" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   
    
    
       <asp:GridView ID="gvMenuItems4" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   


   <asp:GridView ID="gvMenuItems5" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   

   <asp:GridView ID="gvMenuItems6" runat="server" AutoGenerateColumns="False" >
    <Columns>
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:Label ID="lblMenuItemTypeID" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Menu Items">
        <ItemTemplate>
          
          
            <asp:Label ID="lblDescription"  runat="server" Font-Bold="true" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>'>
            </asp:Label><br />
            <asp:Label ID="lblRequired" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "IsRequiredText") %>'>
            </asp:Label>
            <asp:Label ID="lblComment" runat="server" 
                Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>'>
            </asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
    
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay1" runat="server">
                <ItemTemplate>
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay2" runat="server">
                <ItemTemplate>
                     <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
      
            <asp:Repeater ID="rpDay3" runat="server">
                <ItemTemplate>
                <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay4" runat="server">
                <ItemTemplate>
                            <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
       
      
            <asp:Repeater ID="rpDay5" runat="server">
                <ItemTemplate>
                             
                          <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                                   
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
        <ItemTemplate>
        
       
            <asp:Repeater ID="rpDay6" runat="server">
                <ItemTemplate>
                              <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
                
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField>
        <ItemTemplate>
       
       
            <asp:Repeater ID="rpDay7" runat="server">
                <ItemTemplate>
                          
                    <asp:Label  ID="lblRecipeName" runat="server" 
                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'>
                    </asp:Label><br />
            
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:TemplateField>
    
</Columns>
</asp:GridView>   

</form>

</body>
