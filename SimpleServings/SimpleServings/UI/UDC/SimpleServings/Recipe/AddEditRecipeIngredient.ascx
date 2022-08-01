<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditRecipeIngredient.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.AddEditRecipeIngredient" %>

<span>
<div class="dataRow smlInputs mr20">
    <div class="dataLabel">Quantity :</div>
    <div class="dataInput">
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
     
    </div>
</div>
<div class="dataRow smlInputs mr20">
    <div class="dataLabel">Measure Unit :</div>
    <div class="dataInput">
        <asp:DropDownList ID="ddlMeasureUnit" runat="server" ></asp:DropDownList> 
    </div>
</div>
<div class="dataRow w500 mr20">
    <div class="dataLabel">Description :</div>
    <div class="dataInput">
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    </div>
</div>
<div class="dataRow floatL">
    <div class="dataLabel">&emsp;</div>
    <div class="dataInput">
        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="floatR add mr30" onclick="btnAdd_Click" />
    </div>
</div>
    
<div class="clearfix"></div>
<asp:HiddenField ID="hiddenOrder" runat="server" Value="" />
<div class="dgContainer">
<asp:GridView 
    ID="gvRecipeIngredient" 
    runat="server"
    AutoGenerateColumns="false"
    onrowdatabound="gvRecipeSupplement_RowDataBound" 
    HeaderStyle-CssClass="hideRow" 
    CssClass="tableStyle" 
    onrowcancelingedit="gvRecipeIngredient_RowCancelingEdit"
    onrowdeleting="gvRecipeIngredient_RowDeleting" 
    onrowediting="gvRecipeIngredient_RowEditing" 
    onrowupdating="gvRecipeIngredient_RowUpdating"
    DataKeyNames="IngredientID"> 
    <Columns>

        <asp:TemplateField>

            <ItemTemplate>            
                <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("IngredientDescription") %>'></asp:Label>
            </ItemTemplate>

            <EditItemTemplate>
                <div class="dataRow smlInputs mr20">
                    <div class="dataInput">
                        <asp:TextBox ID="txtEditQuantity" runat="server" Text='<%# Eval("QuantityText") %>'>
                        </asp:TextBox>
                    </div>
                </div>
                <div class="dataRow smlInputs mr20">
                    <div class="dataInput">
                        <asp:DropDownList ID="ddlEditMeasureUnit" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="dataRow w440">
                    <div class="dataInput">
                        <asp:TextBox ID="txtEditDescription" runat="server" Text='<%# Eval("Description") %>'>
                        </asp:TextBox>
                    </div>
                </div>     
            </EditItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField ItemStyle-CssClass="bgTd">
            <ItemTemplate>
                <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CommandName="Edit">
                </asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkBtnSave" runat="server" Text="Save" CommandName="Update">
                </asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField ItemStyle-CssClass="bgTd">
            <ItemTemplate>
                <asp:LinkButton ID="lnkBtnRemove" runat="server" Text="Remove" CommandName="Delete" CommandArgument='<%# Eval("IngredientID") %>'>
                </asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CommandName="Cancel">
                </asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
<asp:LinkButton ID="lnkBtnSaveOrder" CssClass="floatR check mr30" runat="server" onclick="lnkBtnSaveOrder_Click">
Save Order
</asp:LinkButton>

<br /><br />
<asp:Label ID="lblMsg" runat="server"></asp:Label>
</span>