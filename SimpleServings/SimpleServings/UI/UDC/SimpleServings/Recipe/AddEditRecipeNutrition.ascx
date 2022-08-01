<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditRecipeNutrition.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.AddEditRecipeNutrition" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">


<Triggers>
    <asp:PostBackTrigger ControlID="btUpload"/>
    <asp:PostBackTrigger ControlID="dlRecipeNutrition"/>
</Triggers>

<ContentTemplate> 
    <div style="display:block">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
        
    <asp:FileUpload ID="fuNutrients" runat="server" CssClass="upload" />
        
    <asp:Button ID="btUpload" runat="server" Text="Process" onclick="btnUpload_Click" CssClass="add">
    </asp:Button>
        
    <asp:Label ID="fileError" runat="server" Text="Please update valid excel file." Visible="false">
    </asp:Label>


<asp:DataList 
    ID="dlRecipeNutrition" 
    runat="server" 
    RepeatColumns="4" 
    CssClass="nutritionList" 
    RepeatDirection="Horizontal" 
    CellPadding="0" 
    CellSpacing="0">
    
    <ItemTemplate>
    <div class="nutritionItem">
        <asp:Label ID="lblNutritionID" runat="server" Visible="false" Text='<%# Eval("NutritionID") %>'>
        </asp:Label>

        <asp:Label ID="lblNutrientID" runat="server" Visible="false" Text='<%# Eval("NutrientID") %>'>
        </asp:Label>

        <asp:Label ID="lblDisplay" runat="server" Visible="false" Text='<%# Eval("DiplayIndicator") %>'>
        </asp:Label>
        <p>
        <asp:Label ID="lblNutrientName" runat="server" Text='<%# Eval("NutrientName") %>'
        CssClass="nutrientName" ></asp:Label>
        </p>

        <asp:TextBox ID="txtValue" runat="server" Text='<%# Eval("Value") %>'
        CssClass="nutrientValue" ></asp:TextBox>

        <asp:Label ID="lblUnitName" runat="server" Text='<%# Eval("UnitName") %>'
        CssClass="nutrientUnit" ></asp:Label>

        <asp:TextBox ID="txtPercentage" runat="server"  Text='<%# Eval("Percentage") %>' Enabled="true"
        CssClass="nutrientPercent" ></asp:TextBox>
        <div class="clearfix"></div>
    </div>
    </ItemTemplate>

</asp:DataList>   
</ContentTemplate>

</asp:UpdatePanel>
       
