<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeSearchList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeSearchList" %>
<%--<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>--%>
<%@ Register Src="RecipeSearchRepeater.ascx" TagName="RecipeSearchRepeater" TagPrefix="uc1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
<asp:Panel ID="pnPage" runat="server" >
    <div class="searchBoxMenu">
        <asp:Panel ID="hidden" runat="server" Visible="false">
            <div class="filterView">
                Filter By Recipe View :
        <asp:DropDownList ID="ddlRecipeView" runat="server" AutoPostBack="true"
            OnSelectedIndexChanged="ddlRecipeView_SelectedIndexChanged" onChange="UpdateScrolling();">
        </asp:DropDownList>
            </div>
        </asp:Panel>

        <div class="searchBox" >
            <div style="float:left" >
            <asp:TextBox ID="txtName" CssClass="searchInput"  runat="server" style="width:95%;"  AutoPostBack="false" onkeypress="SetSearchBox(event);" />
            <%--<input type="text"  ID="txtName" CssClass="searchInput" style="width:95%;"  runat="server"  spellcheck="true" />--%>
           </div>
            <div style="float:left">
            <asp:Button ID="btnSearch" runat="server" Text="Search"
                CssClass="floatL btn_black" OnClick="btnSearch_Click" OnClientClick="UpdateScrolling();" />
            </div>
        </div>

        <%--following is original--%>
        <%-- 
        <div class="searchBox">
           <asp:TextBox ID="txtName" CssClass="searchInput"  runat="server" AutoPostBack="false" onkeypress="SetSearchBox(event);" />            
            <asp:Button ID="btnSearch" runat="server" Text="Search"
                CssClass="floatL btn_black" OnClick="btnSearch_Click" OnClientClick="UpdateScrolling();" />
        </div>
        --%>

        <%--follow is spell check--%>
        <%--<div class="searchBox">         
             <div style="float:left">
                <ASPNetSpell:SpellTextBox ID="txtName" runat="server" Height="16" Style="overflow: hidden;" ></ASPNetSpell:SpellTextBox>
            </div>
             <div style="float:left">
                <asp:Button ID="btnSearch" runat="server" Text="Search"
                    CssClass="floatL btn_black" OnClick="btnSearch_Click" OnClientClick="UpdateScrolling();" />
            </div>
        </div>--%>
        <div class="dropdownBox2">
            <span style="float: left; margin-top: 3px">Filter By: </span>
            <asp:DropDownList ID="ddlRecipeTag" runat="server" AutoPostBack="true"
                OnSelectedIndexChanged="ddlRecipeTag_SelectedIndexChanged" onChange="UpdateScrolling();">
            </asp:DropDownList>
        </div>
        <div class="lineBreak">
            <div></div>
        </div>
        View:
        <asp:LinkButton CssClass="favoriteIcon" ID="lnkBFavorites" runat="server" Text="My Favorites"
            OnClick="lnkBFavorites_Click" OnClientClick="UpdateScrolling();" /><br />
        <br />


        <div class="clearfix"></div>
    </div>
    <div class="clearfix"></div>
    <uc1:RecipeSearchRepeater ID="RecipeSearchRepeater1" runat="server" />

</asp:Panel>
