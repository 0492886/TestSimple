<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.Dashboard" %>

<h2 class="fatortitle">Dashboard</h2>

<div class="iconSpecMenu">
       
    <asp:DataList ItemStyle-CssClass="colm" ID="dlLinks" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" >

        <ItemTemplate>

        <asp:Label ID="lblLinkID" runat="server" Text='<%#Eval("LinkID")%>' Visible="false" />
        <asp:Label ID="lblLinkType" runat="server" Text='<%#Eval("LinkType")%>' Visible="false" /> 
        <asp:Label ID="lblClassType" runat="server" Text='<%#Eval("ClassType")%>' Visible="false" /> 


        <div class="iconSpecMenuSection">
            <a class="iconSpecMenuImgLnk" runat="server" ID="imageLink" href='<%# "~/UI/Page/" + Eval("Hyperlink") %>'><img src='<%# Eval("IconLink") %>' alt="" /> </a>           
            <div class="cont">
                <asp:Label CssClass="ti no" ID="lblCount" runat="server" Visible="false" />
                <asp:LinkButton ID="lnkbHyperlink" runat="server" EnableViewState="true" Text='<%# Eval("Description") %>' CommandArgument='<%# Eval("Hyperlink") %>' CommandName='<%# Eval("LinkType") %>' OnClick="lnkbHyperlink_Click" />
            </div>

            <asp:Label CssClass="dco" ID="lblComment" runat="server" Text='<%#Eval("Comment")%>'  />
        </div>

        </ItemTemplate>

    </asp:DataList>

</div>
