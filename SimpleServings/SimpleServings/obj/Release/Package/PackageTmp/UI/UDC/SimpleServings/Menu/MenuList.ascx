<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuList" %>
<%--<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>--%>
<%@ Register src="MenuGrid.ascx" tagname="MenuGrid" tagprefix="uc1" %>

<asp:Label ID="lblMsg" runat="server" CssClass="hidden_msg"></asp:Label>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">

    <div class="title2 h2Size"><asp:Label runat="server" Text="Menu List" ID="lblMenuGridHeader"></asp:Label>
        <asp:HyperLink ID="hlAddMenu" runat="server" CssClass="add floatR" Text="Add Menu" 
                    NavigateUrl="~/UI/Page/SimpleServings/Menu/AddMenu.aspx?MenuType=AddMenu"> 
        </asp:HyperLink>
        <asp:HyperLink ID="hlAddSampleMenu" runat="server" CssClass="add floatR" Text="Add Sample Menu" 
                    NavigateUrl="~/UI/Page/SimpleServings/Menu/AddMenu.aspx?MenuType=SampleMenu" Visible="False">
        </asp:HyperLink>
    </div>
   
    <div class="dataList">
    <div class="findOptions"> 
        <asp:Panel ID="pnSampleMenuDietTypeFilter" runat="server" Visible="false">
        <asp:CheckBox ID="cbIncompleteSampleMenu" Visible="false" AutoPostBack="true" Text="Show Incomplete Sample Menus" runat="server"  OnCheckedChanged="cbIncompleteSampleMenu_CheckedChanged"/>
        <br />  <br />
        Diet Type :
        <asp:DropDownList ID="ddlDietType" Width="130" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddlDietType_SelectedIndexChanged"></asp:DropDownList>
        </asp:Panel>
    <asp:Panel ID="pnMenuFilter" runat="server" Visible="false"> 
        <%-- 
     <asp:HyperLink ID="hlOldMenus" CssClass="old" runat="server" Text="Show me my old menus" NavigateUrl="~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus&CurrentMenus=2"></asp:HyperLink>
     <asp:HyperLink ID="hlCurrentMenus" CssClass="current" runat="server" Text="Show me my current menus" NavigateUrl="~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus&CurrentMenus=1"></asp:HyperLink>
            --%>
        <asp:LinkButton ID="lnkBCurrentOldMenus" runat="server" Text="Show me my old menus" CssClass="old" OnClick="lnkBCurrentOldMenus_Click" />
         
       
        <br />
    <asp:Label runat="server" ID="lblMenuStatus" Text="Menu Status :"></asp:Label>
    <asp:DropDownList ID="ddlMenuStatus" Width="130" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlMenuStatus_SelectedIndexChanged"></asp:DropDownList>
        

    Contract Name:
    <asp:DropDownList CssClass="listWidth" ID="ddlContractType" runat="server" AutoPostBack="true" 
    onselectedindexchanged="ddlContractType_SelectedIndexChanged"></asp:DropDownList> 

        &nbsp;


        <asp:Button ID="btnSearch" runat="server" CssClass="mr20 btn_black floatR" Text="Search" onclick="btnSearch_Click"/>
    <asp:TextBox  ID="txtName"  CssClass="searchInput floatR mr20" Width="100" runat="server" EnableViewState="true"></asp:TextBox> 
        <%--following is using spell check--%>
       <%-- <div style="float:right">
        <ASPNetSpell:SpellTextBox ID="txtName" Style="overflow: hidden;" CssClass="searchInput floatR"  runat="server" Height="20"  Width="200" EnableViewState="true"  TextMode="SingleLine"  ></ASPNetSpell:SpellTextBox>
           &nbsp;
    <asp:Button ID="btnSearch" runat="server"  CssClass="floatR btn_black"  Text="Search" onclick="btnSearch_Click"/>

        </div>
        --%>
        
         <br />
         <br />
    
        
        <div style="float:right">
        <asp:Label ID="lblSearch" runat="server"  Text="You may search by MenuID, Menu Name " ForeColor="Green" ></asp:Label>       
         </div>        
                                           
    </asp:Panel>
    </div>
        <uc1:MenuGrid ID="MenuGrid1" runat="server" />
    </div>
</asp:Panel>

