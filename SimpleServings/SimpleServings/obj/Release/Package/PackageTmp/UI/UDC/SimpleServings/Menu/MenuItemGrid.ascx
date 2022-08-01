<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItemGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuItemGrid" %>
<%@ Register Src="~/UI/UDC/SimpleServings/Menu/MenuItemGridByWeek.ascx" TagPrefix="uc1" TagName="MenuItemGridByWeek" %>



<script type="text/javascript">
    function openViewRecipe(recipeID) {
        var w = 700;
        var h = 650;
        var l = (screen.width / 2) - (w / 2);
        var t = (screen.height / 2) - (h / 2);
        window.open('../Recipe/ViewRecipe.aspx?RecipeID=' + recipeID + '&ShowHeader=0', '_blank', 'toolbar=no,location=no,resizable,directories=no,menubar=no,scrollbars,status,titlebar=no,width=' + w + ',height=' + h + ',top=' + t + ',left=' + l);
   }
</script>

<asp:Label ID="lblMenuID" runat="server" Visible="false"></asp:Label>
<asp:Panel ID="pnPage" runat="server">
    <div class="dropdownBox">
        <div style="float:left" >
            <span class="dataLabel">Week in Cycle :</span>
            <asp:DropDownList CssClass="dataInput" ID="ddlWeek" runat="server" 
                AutoPostBack="true" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" onChange="checkUpdating();">
            </asp:DropDownList>
            <asp:Label ID="lblMenuTypeID" runat="server" Text="" CssClass="menutype" Style="display: none"/> &nbsp;
        </div>
        <div id="divSwap" runat="server" style="float: left" >
            <asp:Label ID="Label1" runat="server" class="dataLabel" Text="Swap Week day from: "></asp:Label>
            <asp:DropDownList ID="ddlSwapFrom" runat="server"  CssClass="dataInput"></asp:DropDownList> &nbsp;

            <asp:Label ID="Label2" runat="server" class="dataLabel" Text="Swap Week day to: "></asp:Label>
            <asp:DropDownList ID="ddlSwapTo" runat="server"  CssClass="dataInput" ></asp:DropDownList> &nbsp;
            <asp:Button ID="btnSwap" runat="server" Text="Swap" OnClick="btnSwap_Click" />
            <asp:Label ID="lblSelectWeekDay" runat="server" CssClass="menutype" ></asp:Label>
        </div>
    </div>
    <div class="clearfix"></div> 

    <div class="menuTableContainer">
        <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False" CssClass="menuGridStyle">
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
                        <asp:Label ID="lblMenuItemTypeID_noneDisaply" CssClass="menuItemTypeId" runat="server" Style="display: none"
                            Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemTypeID") %>'>
                        </asp:Label>

                        <asp:Label ID="lblDescription" CssClass="labelBold" runat="server"
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
                        
                        <asp:Label ID="lblMenuItemInfo_1" runat="server"  Style="display: none" />
                        <asp:Repeater ID="rpDay1" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)" 
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %> );">

                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />

                                    <%--<asp:Label runat="server" ID="hdnfld1" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' Style="display: none"></asp:Label>--%>
                                    
                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:Label ID="lblMenuItemInfo_2" runat="server" Style="display: none" />
                        <asp:Repeater ID="rpDay2" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />

                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem"  Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Label ID="lblMenuItemInfo_3" runat="server" Style="display: none" /><%----%>
                        <asp:Repeater ID="rpDay3" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />

                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem"  Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Label ID="lblMenuItemInfo_4" runat="server" Style="display: none" />
                        <asp:Repeater ID="rpDay4" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />

                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Label ID="lblMenuItemInfo_5" runat="server" Style="display: none" />
                        <asp:Repeater ID="rpDay5" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />
                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem"  Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Label ID="lblMenuItemInfo_6" runat="server" Style="display: none" />
                        <asp:Repeater ID="rpDay6" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />
                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem"  Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:Label ID="lblMenuItemInfo_7" runat="server" Style="display: none" />
                        <asp:Repeater ID="rpDay7" runat="server">
                            <ItemTemplate>
                                <div class='<%# DataBinder.Eval(Container.DataItem, "ClassName") %>' ondblclick="openViewRecipe(<%# Eval("RecipeID") %>)"
                                    onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event, <%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>);">
                                    <asp:Label ID="lblMenuItemID" CssClass="menuItemId" runat="server" Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemID") %>' />
                                    <asp:Label CssClass="clearLine" ID="lblRecipeName" runat="server"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeName")%>'
                                        ToolTip='<%# string.Format("Contributed By: {0}\nRecipeView: {1}", DataBinder.Eval(Container.DataItem, "ContributedBy"), DataBinder.Eval(Container.DataItem, "RecipeViewText")) %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblRecipeID" CssClass="recipeId" runat="server" Style="display: none"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "RecipeID") %>'>
                                    </asp:Label>
                                    <asp:Label ID="lblIsSamplemenuItem" runat="server" CssClass="isSampleMenuItem"  Style="display: none" Text='<%# DataBinder.Eval(Container.DataItem, "IsSampleMenuItem") %>' />

                                    <asp:LinkButton ID="lnkbRemove" runat="server" CssClass="remove"
                                        Text="Remove"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkb_Click"
                                        OnClientClick="return confirm('Are you sure you want to remove this Recipe?');"
                                        Visible='<%# CanDelete %>'>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkBAlternate" runat="server"
                                        CssClass="zeroPadding"
                                        Text="Alternate"
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuItemID")%>'
                                        OnClick="lnkbAlternate_Click"
                                        Visible='<%# CanAlternate %>'>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>



    <div><%--class="menuTableContainer"--%>

         <uc1:MenuItemGridByWeek runat="server" id="MenuItemGridByWeek2" />
    </div>

    <div >

         <uc1:MenuItemGridByWeek runat="server" id="MenuItemGridByWeek3" />
    </div>

    <div>

         <uc1:MenuItemGridByWeek runat="server" id="MenuItemGridByWeek4" />
    </div>

    <div>

         <uc1:MenuItemGridByWeek runat="server" id="MenuItemGridByWeek5" />
    </div>


    <div>

         <uc1:MenuItemGridByWeek runat="server" id="MenuItemGridByWeek6" />
    </div>

</asp:Panel>

<div id="contextMenu" class="ContextMenu" draggable="true">

<label style="display:none" id="lblMenuItemID"></label>
<table id="tblContextMenu">
    <tr>
        <td>
            <div  class="ContextHeader">
                <asp:Image runat="server" style="float:Left; margin-right:5px; margin-top:-3px;" ImageUrl="~\UI\images\copy16.png"/>
                 Copy Menu Item: 
                <a class="close" onclick="HideMenu('contextMenu');">×</a>
            </div> 
            
        </td>
    </tr>
    <tr>
        <td>
        <div  class="ContextItem" runat="server"> <asp:Label runat="server" ID="lblweek1IsComplete" style="display:none;" text='<%# IsComplete.ToString() %>'></asp:Label>
            <input type="checkbox" id="cbweek1" value="1" onclick="showcbList(1)" /><label class="lblWeek">Week 1</label>
        </div>
            <div id="div1" style="display:none;" class="selDays">
                <asp:CheckBoxList runat="server" ID="cblWeek1" RepeatDirection="Horizontal" DataTextField="DayOfWeekID" RepeatColumns="3" ></asp:CheckBoxList>
            </div>
        </td>
    </tr>
    <tr>
        <td>
        <div  class="ContextItem">
            <input type="checkbox" id="cbweek2" onclick="showcbList(2)"/><label class="lblWeek">Week 2</label> 
        </div>
            
        <div id="div2" style="display:none;" class="selDays">
            <asp:CheckBoxList runat="server" ID="cblWeek2" RepeatDirection="Horizontal" RepeatColumns="3" ></asp:CheckBoxList>
        </div>
        </td>
    </tr>
        <tr>
        <td>
        <div  class="ContextItem">
            <input type="checkbox" id="cbweek3" onclick="showcbList(3)" /><label class="lblWeek">Week 3</label>
        </div>

        <div id="div3" style="display:none;" class="selDays">
            <asp:CheckBoxList runat="server" ID="cblWeek3" RepeatDirection="Horizontal" RepeatColumns="3"></asp:CheckBoxList>
        </div>
        </td>
    </tr>
        <tr>
        <td>
        <div  class="ContextItem">
            <input type="checkbox" id="cbweek4" onclick="showcbList(4)" /><label class="lblWeek">Week 4</label>
        </div>
            
            
        <div id="div4" style="display:none;" class="selDays">
            <asp:CheckBoxList runat="server" ID="cblWeek4" RepeatDirection="Horizontal" RepeatColumns="3"></asp:CheckBoxList>
        </div>
        </td>
    </tr>
        <tr>
        <td>
        <div  class="ContextItem">
            <input type="checkbox" id="cbweek5" onclick="showcbList(5)" /><label class="lblWeek">Week 5</label>
        </div>

        <div id="div5" style="display:none;" class="selDays">
            <asp:CheckBoxList runat="server" ID="cblWeek5" RepeatDirection="Horizontal" RepeatColumns="3"></asp:CheckBoxList>
        </div>
        </td>
    </tr>
        <tr>
        <td>
        <div  class="ContextItem">
            <input type="checkbox" id="cbweek6" onclick="showcbList(6)"/><label class="lblWeek">Week 6</label>
        </div>

        <div id="div6" style="display:none;" class="selDays">
            <asp:CheckBoxList runat="server" ID="cblWeek6" RepeatDirection="Horizontal" RepeatColumns="3"></asp:CheckBoxList>
        </div>       
       </td>
    </tr>
    <tr>
        <td style="text-align:center;">
        <div><input type="button" id="btnSave" value="Save" class="btn_save btn" style="float:none;" onclick="saveMenuItems()"/>
        </div>
        </td>
    </tr>

</table>


</div>



<script type="text/javascript">

    $(document).ready(function () {
        $("#contextMenu").draggable();
    });
   

    var getMenuType = function () {
        var id = $('#<%=lblMenuTypeID.ClientID%>').text();
        return id;
    }


    function ShowMenu(control, e, MenuItemID) {

        var url = window.location.href;
        if (url.indexOf('AddMenuItem.aspx') != -1) {

            var posx = e.clientX + window.pageXOffset + 'px'; //Left Position of Mouse Pointer
            var posy = e.clientY + window.pageYOffset - 150 + 'px'; //Top Position of Mouse Pointer
            document.getElementById(control).style.position = 'absolute';
            document.getElementById(control).style.display = 'inline';
            document.getElementById(control).style.left = posx;
            document.getElementById(control).style.top = posy;
            $('#lblMenuItemID').text(MenuItemID);

            var selWeek = 'cbweek' + $("#DragMenuItems1_MenuItemGrid1_ddlWeek").val();
            $('#' + selWeek).attr("disabled", true);

            var Isweekcomplete= $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl01_lblStatus").text();
            if (Isweekcomplete == 'Complete')
            {
                $('#cbweek2').attr("disabled", true);
            }

            Isweekcomplete = $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl00_lblStatus").text();
            if (Isweekcomplete == 'Complete') {
                $('#cbweek1').attr("disabled", true);

            }

            Isweekcomplete = $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl02_lblStatus").text();
            if (Isweekcomplete == 'Complete') {
                $('#cbweek3').attr("disabled", true);
            }

            Isweekcomplete = $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl03_lblStatus").text();
            if (Isweekcomplete == 'Complete') {
                $('#cbweek4').attr("disabled", true);
            }

            Isweekcomplete = $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl04_lblStatus").text();
            if (Isweekcomplete == 'Complete') {
                $('#cbweek5').attr("disabled", true);
            }
       

            Isweekcomplete = $("#DragMenuItems1_ViewMenuWeekStatus1_dlMenuWeekStatus_ctl05_lblStatus").text();
            if (Isweekcomplete == 'Complete') {
                $('#cbweek6').attr("disabled", true);
                
            }

        }
    }

    function HideMenu(control) {
        document.getElementById(control).style.display = 'none';
        var temp = $('tbody tr td .ContextItem input[type="checkbox"]:checked');

        for (var l = 0; l < temp.length; l++)
        {
            var id = temp[l].id;
            id = id.replace('cbweek', '');
            showcbList(id);
        }
        $('tbody tr td input[type="checkbox"]').attr('checked', false);
    }



    function saveMenuItems() {
        //var selWeeks = $('tbody tr td .ContextItem input[type="checkbox"]:checked');
        var selDays = $('tbody tr td .selDays input[type="checkbox"]:checked');

        var week_days ='';
        for (var d = 0; d < selDays.length; d++)
        {
            var len = selDays[d].id.length;
            var week_day = selDays[d].id.substr(len - 3, len);
            week_days += week_day;
            week_days += ',';
        }

        var MenuItemID = $('#lblMenuItemID').text();


        var obj = {};

        obj.selWeek_day = week_days;
        obj.MenuItemID = MenuItemID;

        $.ajax({
            type: "POST",
            url: "AddMenuItem.aspx/CopyMenuItems",
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                HideMenu('contextMenu');
                alert('Menu Item(s) copied successsfully!!');
            }
            });

    }

    function showcbList(week) {
        var cb = $('#div' + week);
        cb.slideToggle(300);
        $('#div' + week + ' input[type="checkbox"]').attr('checked', false);
    }




</script>


<style type="text/css">

    .selDays {
    margin-bottom:10px;
    }

    .ContextMenu {
        position: relative;       
        border: 1px solid gray;
        border-radius:10px;
        background-color: white;
        display:none;
        
    }

    .close {
        border-radius:50%;
        font-size:15px;
        color:red;
        /*background-color:orange;*/
        float:right;
        margin-left:10px;
        margin-top:-5px;
    }

    .close:hover {
    color:white;
    background-color:Red;
    text-decoration:none;
    }


input[type=checkbox] + label {
    margin: 5px;      
    }

input[type=checkbox]:disabled + label{
    margin: 5px;
    color:#B6AFAF;
    text-decoration:none !important;

    }

    .ContextHeader
    {
        color:Black;
        font-weight:bold;
        font-size:12px;
        margin:10px;
        
    }  
    .ContextItem  
    {
            background-color:#FCF4D9;
            color:Black;
            font-weight:bold;
            text-decoration:underline;
    }
    .ContextItem:hover   
    {
        background-color:#0066FF;
        color:White;
        font-weight:bold;            
    }
    .detailItem
    {
        background-color:transparent;
           
    }
    .detailItem:hover
    {
        background-color:#FEE378;
        border: 1px outset #222222;
        font-weight:bold;
        cursor:default;
    }

</style>