<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuItemGridByWeek.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuItemGridByWeek" %>


<asp:Label ID="lblMenuID" runat="server" Visible="false"></asp:Label>

    <div class="dropdownBox"  >
        <div style="float:left">
            <span class="dataLabel">Week in Cycle :</span>
            <asp:DropDownList CssClass="dataInput" ID="ddlWeek" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged" onChange="checkUpdating();" >
            </asp:DropDownList>
            <asp:Label ID="lblMenuTypeID" runat="server" Text="" CssClass="menutype" Style="display: none"/>&nbsp;
        </div>
        <div id="divSwap" runat="server" style="float:left" >
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
        <asp:GridView ID="gvMenuItems" runat="server" AutoGenerateColumns="False" CssClass="menuGridStyle"  OnRowDataBound="gvMenuItems_RowDataBound">
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

