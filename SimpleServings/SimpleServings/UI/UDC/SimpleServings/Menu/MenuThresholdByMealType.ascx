<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuThresholdByMealType.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuThresholdByMealType" %>

<%@ Register src="MenuThresholdGrid.ascx" tagname="MenuThresholdGrid" tagprefix="uc1" %>


<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel ID="pnPage" CssClass="contentBox" runat="server"> 
<div class="title2 h2Size">Menu Threshold
<a class="back floatR" href="JavaScript:history.back();">Back</a>
<asp:LinkButton ID="lnkBAddMenuThreshold" CssClass="add floatR" runat="server" Text ="Add Menu Threshold" onclick="lnkBAddMenuThreshold_Click"></asp:LinkButton>

</div>   
    <div class="dataList">
    <asp:Label ID="lblMsg" runat="server" CssClass="hidden_msg"></asp:Label>
        <div class="dataRow w325">
            <div class="dataLabel"><span class="wtitle">Meal Type :</span> </div>                    
            <div class="dataInput">                     
                <asp:DropDownList ID="ddlMealType" runat="server" ></asp:DropDownList>          
            </div>
        </div>
        <div class="dataRow w325">
            <div class="dataLabel"><span class="wtitle">Diet Type :</span> </div>                    
            <div class="dataInput">                     
                <asp:DropDownList ID="ddlDietType" runat="server" ></asp:DropDownList>          
            </div>
        </div>


        <div class="dataRow w325">
            <div class="dataLabel"><span class="wtitle">Contract Type :</span> </div>                    
            <div class="dataInput">                     
                <asp:DropDownList ID="ddlContractType" runat="server" ></asp:DropDownList>          
            </div>
        </div>
        <div class="dataRow w325">
            <div class="dataLabel"><span class="wtitle">Periodical Type :</span> </div>                    
            <div class="dataInput">                     
                <asp:DropDownList ID="ddlPeriodicalType" runat="server" ></asp:DropDownList>          
            </div>
        </div>
        <br />
        <asp:Button ID="btnSearchMenuuThreshold" CssClass="btn" runat="server" 
            Text="Search" onclick="btnSearchMenuuThreshold_Click" />
    </div>
     <h2 class="title2">Menu Threshold List</h2>
  <div class="dataList">
    <uc1:MenuThresholdGrid ID="MenuThresholdGrid1" runat="server" />
  </div>
</asp:Panel>