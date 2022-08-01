<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecipeImage.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.RecipeImage" %>


<script type="text/javascript">
    function SetSingleRadioButton(nameregex, current) {        
        re = new RegExp(nameregex);
        for (i = 0; i < document.forms[0].elements.length; i++) {
            elm = document.forms[0].elements[i];
            if (elm.type == 'radio') {
                if (elm != current) {
                    elm.checked = false;
                }
            }
        }
        current.checked = true;
    }
</script>

<asp:Panel ID="pnPage" CssClass="gridList2" runat="server" >
    <asp:LinkButton CssClass="deleteIcon floatR mr30"  ID="lnkBtnClear" runat="server" CommandName="Clear" OnClick="lnkBtnClear_Click">Clear</asp:LinkButton>
<%--    <asp:Button ID="btnClear" runat="server" Text="Clear " onclick="btnClear_Click" OnClientClick="" CssClass="deleteIcon floatR mr30" />--%>
    <asp:Label ID="lblRecipeID" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCount" runat="server"></asp:Label> 
    <div class="lasteventimg scroll-pane">
    <ul>
    <asp:Repeater ID="rptRecipeImg" runat="server" 
            onitemdatabound="rptRecipeImg_ItemDataBound">    
        <ItemTemplate>  
        <li class="gridListBox2">
            <h2 class="hide"><asp:Label ID="lblImgName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ImageName") %>'></asp:Label></h2>
            <div class="gridViewImg2"><asp:Image ID="imgID" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImagePath") %>' /></div>                   
            
            <div class="clearfix"></div>
            <div class="gridviewBtn">                                           
                <asp:RadioButton ID="rbButton"   runat="server" />
            </div>
        </li>
        </ItemTemplate>        
    </asp:Repeater>
    </ul>
    </div>

</asp:Panel>
 