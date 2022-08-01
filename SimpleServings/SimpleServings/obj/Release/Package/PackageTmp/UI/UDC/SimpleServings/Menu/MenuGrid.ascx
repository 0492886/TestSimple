<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuGrid" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<style>
    /*Taking output extra padding from the "view" column input the menu list table*/
    .noPadding{
        padding:0px;
    }
</style>
<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
<asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
<asp:Panel ID="pnPage" runat="server">
<asp:Label CssClass="labme" ID="lblCount" runat="server"></asp:Label> 
<div class="dgContainer"  ><%--style="overflow-x:scroll;"--%>
<asp:GridView CssClass="DatagridStyle table table-hover" GridLines="None" 
        ID="gvMenus" runat="server"  AutoGenerateColumns="False" AllowPaging="true" 
        AllowSorting="true" PageSize="50" 
        onpageindexchanging="gvMenus_PageIndexChanging" onsorting="gvMenus_Sorting" OnRowDataBound="gvMenus_RowDataBound">
     <AlternatingRowStyle CssClass="DatagridStyleAltRow" />             
<PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" FirstPageText="First" LastPageText="Last" />   
<Columns>

        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:RadioButton ID="rbSelectItem" runat="server" onclick="rbSelectOne(this);" />
        </ItemTemplate>
        </asp:TemplateField>
         
     <asp:TemplateField HeaderText="Menu ID">
     <ItemTemplate>
                <asp:Label ID="lblMenuID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Name" SortExpression="MenuName">
     <ItemTemplate>
            <asp:Label ID="lblMenuName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuName") %>' Width="200px" ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
   
   <asp:TemplateField HeaderText="Program Type" SortExpression="ContractType">
     <ItemTemplate>
            <asp:Label ID="lblContractType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractTypeName") %>'  ></asp:Label>

<%--Width="125px"--%>

     </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Contract Name" SortExpression="ContractName">
     <ItemTemplate>
            <asp:Label ID="lblContractName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ContractName") %>' Width="125px" ></asp:Label>


     </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Meal Type" SortExpression="MealType">
     <ItemTemplate>
            <asp:Label ID="lblMealType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MealServedTypeIDText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
    
     <asp:TemplateField HeaderText="Diet Type" SortExpression="DietType">
     <ItemTemplate>
            <asp:Label ID="lblDietType" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "DietTypeIDText") %>'></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Cycle" SortExpression="Cycle">
     <ItemTemplate>
            <asp:Label ID="lblCycle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CycleIDText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status" SortExpression="MenuStatus">
     <ItemTemplate>
            <asp:Label ID="lblMenuStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuStatusText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>



     <asp:TemplateField HeaderText="Submitted To DFTA" SortExpression="SubmittedToDFTA">
     <ItemTemplate>
            <asp:Label ID="lblSubmittedToDFTA" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SubmittedToDFTA") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:HyperLinkField DataNavigateUrlFields="MenuID"   ControlStyle-CssClass="noPadding" DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Menu/ViewMenu.aspx?MenuID={0}" Text="View"/>  <%--Target="_blank"--%> 
    
        <asp:TemplateField Visible="false">
        <ItemTemplate>
            <asp:LinkButton ID="lnkBtnEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>'
                    OnClick="lnkBtnEdit_Click"  >Edit</asp:LinkButton>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate> 
            <asp:LinkButton ID="lnkBtnRemove" runat="server"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "MenuID") %>'
                    OnClick="lnkBtnRemove_Click" style="padding:0px;">Delete</asp:LinkButton> <%--Visible='<%# Request.QueryString.Get("MenuType") == "MyMenus"? true:false %>'--%>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Are you sure you want to delete/Restore the menu? If so, please click OK button" TargetControlID="lnkBtnRemove">
        </cc1:ConfirmButtonExtender>
        </ItemTemplate>
       </asp:TemplateField>  


     <asp:TemplateField HeaderText="Menu ID" Visible="false">
         <ItemTemplate>
                    <asp:Label ID="lblIsActive" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "IsActive") %>' ></asp:Label>
         </ItemTemplate>
    </asp:TemplateField>
<%--         <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkBtnAddFromSample" runat="server" Visible='<%# Request.QueryString.Get("MenuType") == "ViewSamples"? true:false %>'
                      >Create new menu using sample</asp:LinkButton>
            </ItemTemplate>
         </asp:TemplateField>--%>

 
    </Columns>
 </asp:GridView>
 </div>

<asp:HiddenField ID="hdfInput" runat="server"/>
</asp:Panel>

<%--
      
    <asp:TemplateField HeaderText="Submitted On" SortExpression="CreatedOn" Visible="false">
     <ItemTemplate>
            <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>
      --%>

<%-- <script type="text/javascript">

     function rbSelectOne(rb) {
            var gv = document.getElementById("<%=gvMenus.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }

</script>--%>