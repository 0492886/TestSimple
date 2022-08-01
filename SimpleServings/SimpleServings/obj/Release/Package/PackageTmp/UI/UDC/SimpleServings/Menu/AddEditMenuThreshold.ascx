<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditMenuThreshold.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.AddEditMenuThreshold" %>


<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">

<div class="title2 h2Size">Add Menu Threshold
<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
	       <div class="dataList">
           <div class="dataRow">
           <asp:Label ID="lblMsg" runat="server"></asp:Label>
           </div>
             <div class="dataRow w325">
                    <div class="dataLabel">Nutrient :</div>                    
                     <div class="dataInput">                                                                      
                        <asp:DropDownList ID="ddlNutrient" runat="server"></asp:DropDownList>                     
                      </div>
            </div>
            <div class="dataRow w325">
                <div class="dataLabel">Meal Type :</div>                    
                    <div class="dataInput">                     
                        <asp:DropDownList ID="ddlMealType" runat="server"></asp:DropDownList>                     
                    </div>
            </div>
            
            <div class="dataRow w325">
                <div class="dataLabel">Diet Type :</div>                    
                    <div class="dataInput">                     
                        <asp:DropDownList ID="ddldietType" runat="server"></asp:DropDownList>                     
                    </div>
            </div>


            <div class="dataRow w325">
                <div class="dataLabel">Periodical Type :</div>                    
                    <div class="dataInput">                     
                        <asp:DropDownList ID="ddlPeriodicalType" runat="server"></asp:DropDownList>                     
                    </div>
            </div>

            <div class="dataRow w325">
                <div class="dataLabel">Contract Type :</div>                    
                    <div class="dataInput">                     
                        <asp:DropDownList ID="ddlContractType" runat="server"></asp:DropDownList>                     
                    </div>
            </div>

            <div class="dataRow w325">
                <div class="dataLabel">Low to High Threshold :</div>                    
                    <div class="dataInput">
                        <asp:TextBox ID="txtLowThreshold" CssClass="w100"  runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddlInequality" CssClass="w100" runat="server"></asp:DropDownList>
                        <asp:TextBox ID="txtHighThreshold" CssClass="w100" runat="server"></asp:TextBox>                       
                    </div>
            </div>

            
           
           </div>
          <asp:Button ID="btnAddMenuThreshold" CssClass="btn btn_save" 
        runat="server" Text="Save" onclick="btnAddMenuThreshold_Click"/>

    <div class="clearfix"></div>   
</asp:Panel>