<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditRecipeSupplement.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.AddEditRecipeSupplement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<span>
<ajaxToolkit:AutoCompleteExtender 
        runat="server"
        ID="AutocompleteDescription1" 
        TargetControlID="txtDescription"       
        ServicePath="../../../../AutoCompleteService.asmx"         
        MinimumPrefixLength="2" 
        CompletionInterval="1000"   
        EnableCaching="true"    
        CompletionSetCount="15">    
</ajaxToolkit:AutoCompleteExtender>
    
<asp:Panel runat="server" ID="pnlAdd" DefaultButton="btnAdd">
<div class="dataRow">
    <div class="dataInput">
        <asp:TextBox ID="txtDescription" CssClass="w763" runat="server" EnableTheming="False"></asp:TextBox>
        
          
     <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" OnClientClick="" CssClass="add floatR mr30" />
   
   </div>

    
</div>
<div class="clearfix"></div>
</asp:Panel>



<asp:HiddenField ID="hiddenOrder" runat="server" Value=""  />
<asp:HiddenField ID="hiddenType" runat="server" Value="" />
<div class="dgContainer">
<asp:GridView 
    ID="gvRecipeSupplement" 
    runat="server" 
    AutoGenerateColumns="false"
    onrowdatabound="gvRecipeSupplement_RowDataBound" 
    HeaderStyle-CssClass="hideRow" 
    CssClass="tableStyle"
    CellPadding="0" 
    CellSpacing="0" 
    onrowediting="gvRecipeSupplement_RowEditing" 
    onrowcancelingedit="gvRecipeSupplement_RowCancelingEdit" 
    onrowdeleting="gvRecipeSupplement_RowDeleting" 
    DataKeyNames="RecipeSupplementID" 
    onrowupdating="gvRecipeSupplement_RowUpdating">

    <Columns>
        <asp:TemplateField Visible="false">
            <ItemTemplate>
                <asp:Label ID="lblRecipeSupplementID" runat="server" Text='<%# Eval("RecipeSupplementID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <div class="dataRow">
                    <div class="dataInput w600 mr20">
                        <asp:TextBox ID="txtEditDescription" runat="server" Text='<%# Eval("Description") %>'>
                        </asp:TextBox>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField ItemStyle-CssClass="bgTd">
            <ItemTemplate>
                <asp:LinkButton CssClass="txtLeft" ID="lnkBtnEdit" runat="server" Text="Edit" CommandName="Edit">
                </asp:LinkButton>
            </ItemTemplate>            
            <EditItemTemplate>
                <asp:LinkButton ID="lnkBtnSave" runat="server" Text="Save" CommandName="Update"
                ></asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>     
        
        <asp:TemplateField ItemStyle-CssClass="bgTd">
            <ItemTemplate>
                <asp:LinkButton CssClass="txtLeft" ID="lnkBtnRemove" runat="server" Text="Remove" CommandName="Delete" CommandArgument='<%# Eval("Description") %>'>
                </asp:LinkButton>
            </ItemTemplate>            
            <EditItemTemplate>
                <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CommandName="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>     
    </Columns>
    <HeaderStyle CssClass="hideRow" />    
</asp:GridView>
</div>
<div class="dataRow floatR">
<asp:LinkButton ID="lnkBtnSaveOrder" CssClass="floatR check mr30" runat="server" onclick="lnkBtnSaveOrder_Click">
Save Order
</asp:LinkButton>
</div>

</span>
