<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewRecipe.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.ViewRecipe" %>
<%@ Register src="../ProgressNote/AddProgressNote.ascx" tagname="AddProgressNote" tagprefix="uc1" %>
<%@ Register src="../ProgressNote/NoteHistory.ascx" tagname="NoteHistory" tagprefix="uc2" %>
<%@ Register src="ViewRecipeSupplement.ascx" tagname="ViewRecipeSupplement" tagprefix="uc3" %>
<%@ Register src="ViewRecipeIngredient.ascx" tagname="ViewRecipeIngredient" tagprefix="uc4" %>
<%@ Register src="ViewRecipeNutrition.ascx" tagname="ViewRecipeNutrition" tagprefix="uc5" %>
<%@ Register src="../Setting/StatusChangeActionPanel.ascx" tagname="StatusChangeActionPanel" tagprefix="uc6" %>
<%@ Register src="../Setting/StatusChangeSubmission.ascx" tagname="StatusChangeSubmission" tagprefix="uc7" %>

<%@ Register Src="~/UI/UDC/SimpleServings/Recipe/RecipeStatusHistory.ascx" tagname="RecipeStatusHistory" TagPrefix="uc8" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Label ID="lblMsg" CssClass="hidden_msg" runat="server"></asp:Label>

<asp:Panel ID="pnPage" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="contentBox recipeViewL">
        <span id="approvalDiv" class="span3 hide">       
            <uc7:StatusChangeSubmission ID="StatusChangeSubmission1" runat="server" />
        </span>
        <h2 class="title2">
            <asp:Label ID="lblRecipeName" CssClass="maxWidth" runat="server"></asp:Label>
             <%--<a class="print floatR" href="#" id="lnkPrintRecipe" target="_blank" runat="server">Print Recipe</a>--%>
             <asp:LinkButton ID="lnkPrintRecipe" runat="server" OnClick="lnkPrintRecipe_Click"  class="print floatR" >Print Recipe</asp:LinkButton>

             <asp:HyperLink ID="hlEdit" CssClass="edit floatR" runat="server" Text="Edit"></asp:HyperLink>
              <asp:LinkButton CssClass="deleteIcon floatR"  ID="lnkBtnDeactivate" runat="server" CommandName="Delete" oncommand="lnkBtnDeactivate_Command">Delete</asp:LinkButton>
              <asp:LinkButton CssClass="add floatR"  ID="lnkBtnReactivate" runat="server" CommandName="Reactivate" oncommand="lnkBtnDeactivate_Command" Visible="false">Activate</asp:LinkButton> 
             <asp:LinkButton CssClass="favoriteIcon floatR"  ID="lnkBtnFavorite" runat="server" onclick="lnkBtnFavorite_Click"></asp:LinkButton>
            <%--<a class="back floatR" href="RecipeList.aspx">Back</a>--%>

            <a class="back floatR" href="javascript:history.go(-1)">Back</a>
<!--<asp:HyperLink ID="hlEditStatus" CssClass="add floatR" runat="server" Text="Handle">
</asp:HyperLink>-->
        </h2>
        <div class="dataList">
        <div class="iconPlaceholder"><asp:Image ID="imgRecipe" runat="server" /></div>
                <div class="dataRow">
                    <div class="dataLabel">Yield :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblYield" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Serving Size :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblServingSize" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Portion Size :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblPortionSize" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Recipe View :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblRecipeView" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Recipe ID :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblRecipeID" runat="server"></asp:Label>
                    </div>
                </div>
                
               <div class="dataRow">
                    <div class="dataLabel">Status :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblActiveStatus" runat="server"></asp:Label>
                    </div>
                </div>

              <div class="dataRow">
                    <div class="dataLabel">Approval Status :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblRecipeApprovalSatus" runat="server"></asp:Label>
                    </div>
                </div>

                <div runat="server" id="divUpdateInfo">
                <div class="dataRow">
                    <div class="dataLabel">Last Updated By :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblLastUpdatedBy" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Last Updated On :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblLastUpdatedOn" runat="server"></asp:Label>
                    </div>
                </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Contributed By :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblContributor" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="dataRow">
                    <asp:Panel ID="pnSponsor" runat="server" Visible="false">
                    <div class="dataLabel">Sponsor :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label ID="lblSponsor" runat="server"></asp:Label>
                    </div>
                    </asp:Panel>
                </div>
                <div class="dataRow">
                    <asp:Panel ID="pnCaterer" runat="server" Visible="false">
                    <div class="dataLabel">Caterer :</div>
                    <div class="dataInput">
                        &nbsp;<asp:Label CssClass="small m-wrap" ID="lblCaterer" runat="server"></asp:Label>
                        </div> 
                    </asp:Panel>
                </div>


                <div class="dataRow">
                    <div class="dataLabel">Categories :</div>
                    <div class="dataInput tagsRow">
                        <asp:Repeater runat="server" id="rpCategory"> 
                            <ItemTemplate>
                               &#8250;<span class="tagz"><%# Container.DataItem %></span> 
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <div class="dataRow">
                    <div class="dataLabel">Tags :</div>
                    <div class="dataInput tagsRow">
                        <asp:Repeater runat="server" id="rptTags">
                            <ItemTemplate>
                               &#8250;<span class="tagz"><%# DataBinder.Eval(Container.DataItem, "TagName") %></span>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            
                <div class="dataRow">
                    <asp:Panel ID="pnlRating" runat="server" Visible="false">
                    <div class="dataLabel">Rating :</div>
                    <div class="dataInput">
                        <table>
                            <tr>
                                <td>
                                    <cc1:Rating ID="Rating1" runat="server"
                                        MaxRating="5"                                        
                                        CssClass="ratingStar"
                                        StarCssClass="ratingItem"
                                        WaitingStarCssClass="SavedIE"
                                        FilledStarCssClass="FilledIE"
                                        EmptyStarCssClass="EmptyIE" AutoPostBack="True" OnChanged="Rating1_Changed"></cc1:Rating>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;<asp:Label ID="lblRating" CssClass="small m-wrap" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    </asp:Panel>
                </div>               
        </div>
       
        <div class="title2 h2Size">Ingredients <span class="floatR marginScale">Scale to <asp:TextBox CssClass="scaleInput" ID="txtScaleTo" runat="server" /> serving(s)
        <asp:LinkButton ID="btnScale" CssClass="btn largeTxt" runat="server" Text="Go" OnClick="lnkScale_Click" /></span></div>
        <div class="dataList">
            <uc4:ViewRecipeIngredient ID="ViewRecipeIngredient1" ShowArrow="true" runat="server" />
        </div>

        <h2 class="title2">Directions</h2>
        <div class="dataList">
            <uc3:ViewRecipeSupplement ID="ViewRecipeSupplement1" 
                runat="server" RecipeSupplementType="20" />
        </div>

        <h2 class="title2">Recommendations</h2>
        <div class="dataList">
            <uc3:ViewRecipeSupplement ID="ViewRecipeSupplement2" 
                runat="server" RecipeSupplementType="21" />
        </div>
	    <h2 class="title2">Requirements</h2>
        <div class="dataList">
            <uc3:ViewRecipeSupplement ID="ViewRecipeSupplement3" 
                    runat="server" RecipeSupplementType="22" />
        </div>

        <asp:Panel ID="pNote" runat="server" Visible="true">
            <h2 class="title2">Notes</h2>
            <div class="dataList">
                <uc2:NoteHistory ID="NoteHistory1" runat="server" />
            </div>
        </asp:Panel>

    </div>
       
  
    <div class="recipeViewR mb0" runat="server" id="divRcpStatusAction">
        <h2 class="title2">Actions Available</h2>
        <div class="dataList">
            <uc6:StatusChangeActionPanel ID="StatusChangeActionPanel1" runat="server" />
        </div>
    </div>
   

    <div class="nutrView">
        <uc5:ViewRecipeNutrition ID="ViewRecipeNutrition2" runat="server" />
    </div>

    <div class="contentBox recipeViewL" runat="server" id="divrcpHistory" >
        <h2 class="title2">Recipe Status History</h2>
        <div class="rcpdataList"> 
            <uc8:RecipeStatusHistory ID ="ucRecipeStatusHistory" runat="server"/>
        </div>
    </div>

        
<%--<h2 class="title2">Nutritional Information</h2>
<div class="light fontsize14">
<uc5:ViewRecipeNutrition ID="ViewRecipeNutrition1" runat="server" />
</div>--%>
<%--<div class="row-fluid">
<div class="SectionTitle"><h3>Add Note</h3></div>
<div class="section">
<uc1:AddProgressNote ID="AddProgressNote1" runat="server" />
</div>
<asp:Button CssClass="btnStyle btnEndofPage" id="btnSubmit" runat="server" 
Text="Submit" OnClick="btnSubmit_Click" />
</div>--%>


<div class="clearfix"></div>
</asp:Panel>






















