<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditRecipeSupplementCheckList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Recipe.AddEditRecipeSupplementCheckList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<style type="text/css">
    .item {
        background-color: #f9f9f9;
        border: .1px solid lightgrey;
        font-style: normal;
        color: none;
    }

    .item_alt {
        background-color: #f2f2f2;
        border: .1px solid lightgrey;
        font-style: normal;
        color: none;
    }

    .item_selected {
        background-color: orange;
        border: .1px solid lightgrey;
        font-style: normal;
        color: none;
    }

    .item_disabled {
        background-color: lightgrey;
        border: .1px solid lightgrey;
        font-style: italic;
        color: red;
    }
</style>

<script type="text/javascript">

    function OnRSuppClick(val) {

        var parent = val.parentNode.parentNode;
        //var submit = document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_btnAgree");
        if (val.checked) {
            $(parent).toggleClass('item', false);
            $(parent).toggleClass('item_selected', true);
        }
        else {
            $(parent).toggleClass('item_selected', false);
            $(parent).toggleClass('item', true);
        }
    }

    function OnRSuppClickAlt(val) {

        var parent = val.parentNode.parentNode;
        if (val.checked) {
            $(parent).toggleClass('item_alt', false);
            $(parent).toggleClass('item_selected', true);
        }
        else {
            $(parent).toggleClass('item_selected', false);
            $(parent).toggleClass('item_alt', true);
        }
    }
</script>

<span>
    
    <asp:HiddenField ID="hiddenOrder" runat="server" Value="" />
    <asp:HiddenField ID="hiddenType" runat="server" Value="" />
    <div class="dgContainer">
        <%--<div class="dataList">--%>
        <asp:ListView ID="lvRecipeSuppCode" runat="server">
            <LayoutTemplate>
                <table border="1">
                    <tr id="itemPlaceholder" runat="server">
                        <%--<td align="left">
                            <asp:Label ID="lblSupplementSelect" runat="server" Text="Selected" Enabled="true"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSupplementDescription" runat="server" Text="Supplement Description" Enabled="true"></asp:Label>
                        </td>--%>
                        <td colspan="3"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr class='<%# !((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) && !(!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "item_disabled" : ((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) ? "item_selected" : "item" %>'
                    title='<%# !((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) && !(!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "flagged for removal" : string.Empty %>'>
                    <td style="cursor: <%# ((Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "none" : "pointer" %>;">
                        <asp:HiddenField ID="hdnRecipeId" runat="server" Value="" />
                        <asp:HiddenField ID="hdnSupplementCodeType" runat="server" Value='<%# Eval("Type") %>' />
                        <asp:HiddenField ID="hdnRecipeSupplementID" runat="server" Value='<%# Eval("RecipeSupplementID") %>' />

                        <asp:Label ID="lblCodeId" runat="server" Visible="false" Text='<%# Eval("CodeId") %>' Enabled="true">
                        </asp:Label>

                        <asp:CheckBox ID="chkSupplementItem" runat="server" onclick="OnRSuppClick(this);" Checked='<%# (Boolean)Eval("IsSelected") %>'
                            Enabled='<%# ((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) || (!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch"))%>' />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <%--<td style="font-style: <%# ((Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "italic" : "normal" %>; 
                        color: <%# ((Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "red" : "none" %>;">--%>
                        <asp:Label ID="lblSupplementDescription" runat="server" Text='<%# Eval("Description") %>' Enabled="true">
                        </asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class='<%# !((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) && !(!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "item_disabled" : ((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) ? "item_selected" : "item_alt" %>'
                    title='<%# !((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) && !(!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "flagged for removal" : string.Empty %>'>
                    <td style="cursor: <%# ((Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch")) ? "none" : "pointer" %>;">
                        <asp:HiddenField ID="hdnRecipeId" runat="server" Value="" />
                        <asp:HiddenField ID="hdnSupplementCodeType" runat="server" Value='<%# Eval("Type") %>' />
                        <asp:HiddenField ID="hdnRecipeSupplementID" runat="server" Value='<%# Eval("RecipeSupplementID") %>' />

                        <asp:Label ID="lblCodeId" runat="server" Visible="false" Text='<%# Eval("CodeId") %>' Enabled="true">
                        </asp:Label>

                        <asp:CheckBox ID="chkSupplementItem" runat="server" onclick="OnRSuppClickAlt(this);" Checked='<%# (Boolean)Eval("IsSelected") %>'
                            Enabled='<%# ((Boolean)Eval("IsSelected") && (Boolean)Eval("IsMatch")) || (!(Boolean)Eval("IsSelected") && !(Boolean)Eval("IsMatch"))%>' />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblSupplementDescription" runat="server" Text='<%# Eval("Description") %>' Enabled="true">
                        </asp:Label>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</span>
