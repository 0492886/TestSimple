<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddRecipe.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.AddRecipe" %>
<%@ Register src="../ProgressNote/AddProgressNote.ascx" tagname="AddProgressNote" tagprefix="uc1" %>
<%@ Register src="AddEditRecipeSupplement.ascx" tagname="AddEditRecipeSupplement" tagprefix="uc2" %>
<%@ Register src="AddEditRecipeIngredient.ascx" tagname="AddEditRecipeIngredient" tagprefix="uc3" %>
<%@ Register src="AddEditRecipeNutrition.ascx" tagname="AddEditRecipeNutrition" tagprefix="uc4" %>
<%@ Register src="RecipeImage.ascx" tagname="RecipeImage" tagprefix="uc5" %>
<%@ Register src="AddEditRecipeSupplementCheckList.ascx" tagname="AddEditRecipeSupplementCheckList" tagprefix="uc6" %>
 
 <asp:Label ID="lblMsg" class="hidden_msg" runat="server"></asp:Label>

<asp:Panel ID="pnPage" CssClass="contentBox" runat="server">
    
    <h2 class="title2">Recipe Details</h2>
    <div class="dataList">
        <div class="dataLeft">
            <div class="dataRow">
                <div class="dataLabel">Recipe Name :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtRecipeName" runat="server"></asp:TextBox>
                </div>
            </div>          
            <div class="dataRow smlInputs mr20">
                <div class="dataLabel">Yield :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtYield" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="dataRow smlInputs mr20">
                <div class="dataLabel">Serving Size :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtServingSize" runat="server" Text="1" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <div class="dataRow smlInputs mr20">
                <div class="dataLabel">Portion Size :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtPortionSize" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="dataRow smlInputs">
                <div class="dataLabel">Recipe View :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlRecipeView" runat="server" AutoPostBack="true" onselectedindexchanged="ddlRecipeView_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>

            <div class="dataRow clearfix">
                <div class="dataLabel">Contributed By :</div>
                <div class="dataInput">
                <asp:DropDownList ID="ddlContributedBy" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlContributedBy_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:DropDownList ID="ddlContributor" runat="server"></asp:DropDownList>
                </div>
            </div>

            <div class="dataRow">
                <asp:Panel ID="pnSponsor" runat="server" Visible="false">
                    <div class="dataLabel">Sponsor :</div>
                    <div class="dataInput">
                        <asp:DropDownList ID="ddlSponsor" runat="server"></asp:DropDownList>
                    </div>
                </asp:Panel>
            </div>

            <div class="dataRow">
                <asp:Panel ID="pnCaterer" runat="server" Visible="false">
                    <div class="dataLabel">Caterer :</div>
                    <div class="dataInput">
                        <asp:DropDownList ID="ddlCaterer" runat="server"></asp:DropDownList>
                    </div>
                </asp:Panel>
            </div>
        </div>

        <div class="dataLeft">
            <div class="dataRow">
                <div class="dataLabel">Categories :</div>
                <div class="dataInput">
                    <asp:CheckBoxList ID="cbCategories" CssClass="tags" runat="server" AutoPostBack="true" RepeatColumns="1" RepeatDirection="Horizontal" OnSelectedIndexChanged="cbCategories_SelectedIndexChanged"></asp:CheckBoxList>
                </div>
            
            </div>



            <div class="dataRow">
                <div class="dataLabel">Tags :</div>
                <div class="dataInput">
                    <asp:CheckBoxList ID="cblTags" CssClass="tags" runat="server" RepeatColumns="2" RepeatDirection="Vertical"></asp:CheckBoxList>
                </div>
            </div>
        </div>
    </div>

    <h2 class="title2">Ingredients</h2>
    <div class="dataList">
        <uc3:AddEditRecipeIngredient ID="AddEditRecipeIngredient1" runat="server" />
    </div>

    <h2 class="title2">Directions</h2>
    <div class="dataList">
        <uc2:AddEditRecipeSupplement ID="AddEditRecipeSupplement1" runat="server" RecipeSupplementType="20"/>
    </div>

    <h2 class="title2">Nutrients</h2>
    <div class="dataList">
        <uc4:AddEditRecipeNutrition ID="AddEditRecipeNutrition1" runat="server"/>
    </div>


    <h2 class="title2">Recommendations</h2>
    <div class="dataList">
        <%--<uc2:AddEditRecipeSupplement ID="AddEditRecipeSupplement2" runat="server" RecipeSupplementType="21"/>--%>
        <uc6:AddEditRecipeSupplementCheckList ID="AddEditRecipeSupplement2" runat="server" RecipeSupplementType="21"/>
    </div>
    
    <h2 class="title2">Requirements</h2>
    <div class="dataList">
       <%-- <uc2:AddEditRecipeSupplement ID="AddEditRecipeSupplement3" runat="server" RecipeSupplementType="22"/>--%>
        <uc6:AddEditRecipeSupplementCheckList ID="AddEditRecipeSupplement3" runat="server" RecipeSupplementType="22"/>
    </div>

     <h2 class="title2">Recipe Icon</h2>
    <div class="dataList">
            <uc5:RecipeImage ID="RecipeImage1" runat="server" />
    </div>

    <h2 class="title2">Notes</h2>
    <div class="dataList">
        <uc1:AddProgressNote ID="AddProgressNote1" runat="server" />
        <div class="validationErrors">
        
        </div>
    </div>
 
    
 
    <asp:Button ID="btnAddRecipe" runat="server" Text="Save" onclick="btnAddRecipe_Click" CssClass="btn btn_save" />
    <div class="clearfix"></div>
</asp:Panel>

<script src="../../../js/jquery-1.9.1.js" type="text/javascript"></script>
<script src="../../../../Scripts/tableDnD.js" type="text/javascript"></script>
 <script type="text/javascript" language="javascript">
     var init = function () {
         var tables = $('.tableStyle');
         var tableDropFunc = function (table, row) {
            
             var tableParent = $(table).parents("span");
             var hiddenOrder = tableParent.find("[id*=\"_hiddenOrder\"]");
             hiddenOrder.val($.tableDnD.serialize());
         };
         for (var j = 0; j < tables.length; j++) {
             var rows = $(tables[j]).find("tr");
             $(tables[j]).parents("span").find("[id*=\"_hiddenOrder\"]").val("");
             for (var i = 0; i < rows.length; i++) {
                 $(rows[i]).prop("id", i);
             }
             $(tables[j]).tableDnD({
                 onDrop: tableDropFunc
             });
         }
     }
     init();
     onDrop: init();
     //$("body").resize(init);
</script>











