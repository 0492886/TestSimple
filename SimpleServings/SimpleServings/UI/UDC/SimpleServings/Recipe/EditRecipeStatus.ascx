<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditRecipeStatus.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.EditRecipeStatus" %>

<%@ Register src="ViewRecipeIngredient.ascx" tagname="ViewRecipeIngredient" tagprefix="uc1" %>
<%@ Register src="ViewRecipeSupplement.ascx" tagname="ViewRecipeSupplement" tagprefix="uc2" %>

<%@ Register src="RecipeStatusHistory.ascx" tagname="RecipeStatusHistory" tagprefix="uc3" %>

<%@ Register src="ViewRecipeNutrition.ascx" tagname="ViewRecipeNutrition" tagprefix="uc4" %>

<%@ Register src="../Setting/StatusChangeActionPanel.ascx" tagname="StatusChangeActionPanel" tagprefix="uc5" %>

<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Label ID="lblCurrentStatus" runat="server" Visible="false" ></asp:Label>
    <br />
<asp:Panel ID="pnPage" runat="server">

   
           <asp:Label ID="lblRecipeID" runat="server" Visible="false" />
 <div class="alert alert-block alert-warning fade in">  
           <table class="InformationListing">
            <colgroup>
                <col style="width:130px;" />
                <col style="width:3px" />
            </colgroup>        
                <tr>
                    <td class="lead">Recipe Name</td>
                     <td>:</td>
                    <td class="lead"><asp:Label ID="lblRecipeName" runat="server" Width="220px"></asp:Label></td>
                </tr>

                </table>
</div>
<h3>Ingredients </h3>
 <div class="alert alert-block alert-warning fade in">  


               

             <uc1:ViewRecipeIngredient ID="ViewRecipeIngredient1" ShowArrow="true" runat="server" />
</div>
<h3>Directions</h3>
 <div class="alert alert-block alert-warning fade in">  
         
        
         
             <uc2:ViewRecipeSupplement ID="ViewRecipeSupplement1" runat="server"  RecipeSupplementType="20" />
  </div>
  <h3>Nutrition Facts</h3>
   <div class="alert alert-block alert-warning fade in"> 
        
             <uc4:ViewRecipeNutrition ID="ViewRecipeNutrition1" runat="server" />
   </div>
   <h3>Status History  </h3>
   <div class="alert alert-block alert-warning fade in">     
        
         
             <uc3:RecipeStatusHistory ID="RecipeStatusHistory1" runat="server" />
    </div>   
       
<br />
<uc5:StatusChangeActionPanel ID="StatusChangeActionPanel1" runat="server" />



</asp:Panel>

