<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditMenu.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.EditMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="../Supplier/ContractGrid.ascx" TagName="ContractGrid" TagPrefix="uc2" %>
<%@ Register Src="../Supplier/ListContract.ascx" TagName="ListContract" TagPrefix="ucConList" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:HiddenField ID="hdnField" runat="server" />
<asp:Panel CssClass="contentBox" ID="pnPage" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="title2 h2Size">
        Edit Menu
        <a class="back floatR" href="JavaScript:history.back();">Back</a>
    </div>
    <div class="dataList">
        <div class="dataRow">
            <asp:Label ID="lblMenuID" runat="server" Visible="false" />
            <div class="dataRow w500">
                <div class="dataLabel">Menu Name :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="dataRow w500">
                <div class="dataLabel">Program Type :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlContract" runat="server" OnSelectedIndexChanged="ddlContract_SelectedIndexChanged" AutoPostBack="true" onchange="ConfirmDietOrProgramTypeChange(menuTypeID)"></asp:DropDownList>
                </div>
            </div>

            <%--<div class="dataRow w500" style="display:none">
                   <div class="dataLabel">Meal Type :</div>                    
                     <div class="dataInput">                     
             <asp:DropDownList ID="ddlMealType" runat="server"></asp:DropDownList>
                     
                 </div>
          </div>--%>

            <div class="dataRow w500">
                <div class="dataLabel">Diet Type :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlDietType" runat="server" OnSelectedIndexChanged="ddlDietType_SelectedIndexChanged" AutoPostBack="true" onchange="ConfirmDietOrProgramTypeChange(menuTypeID)"></asp:DropDownList>
                </div>
            </div>

        </div>

        <%-- <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="panelInfoMsg" CancelControlID="btnCancel1" TargetControlID="hdnField" BackgroundCssClass="modalPopupBackGround">
        </ajaxToolkit:ModalPopupExtender>

        <asp:Panel ID="panelInfoMsg" runat="server" Width="400px" Height="250px" CssClass="modalPopupPanel" Visible="false">
            <br />
            <asp:Label ID="lblInfoMsg" runat="server" Text="If Program Type/ Diet Type is changed, Associated contracts must be changed!!" style="color:Red; font-weight:bold" />

           <div style="text-align: left; margin-top: 20px;">
            <asp:Button ID="btnOK" runat="server" Text="OK" OnClick="btnOK_Click" /> 
            <asp:Button ID="btnCancel1" runat="server" Text="Cancel" />
            </div>
        </asp:Panel>--%>

        <div class="dataRow w500 containerBox" id="divSelectCont" runat="server">
            <div class="dataInput" style="max-height: 500px;">
                <asp:LinkButton runat="server" Text="Change Contract(s) &#x27a4;" ID="btnSelectcontract" CssClass="floatL" OnClick="btnSelectcontract_Click" />

                <ajaxToolkit:ModalPopupExtender ID="ajaxModalPopup" runat="server" PopupControlID="pnlcontract" CancelControlID="btnCancel" TargetControlID="hdnField" BackgroundCssClass="modalPopupBackGround">
                </ajaxToolkit:ModalPopupExtender>

                <asp:Panel ID="pnlcontract" runat="server" class="modalPopupPanel">
                    <div style="max-height: 500px; overflow: auto; text-align: center;">
                        <uc2:ContractGrid runat="server" ID="ucContractGrid" />
                    </div>
                    <asp:Button ID="btnSelect" Text="Select" runat="server" class="btn_black" Style="text-align: right" OnClick="btnSelect_Click" />
                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" class="btn_black" Style="text-align: right" />
                </asp:Panel>

            </div>
        </div>

        <div class="dataRow w760" runat="server" id="divContractGrid">
            <div class="dataRow w760">
                <ucConList:ListContract runat="server" ID="ucContractList" style="margin: 0px"></ucConList:ListContract>
            </div>
        </div>




        <%--<div class="dataRow w500">
            <div class="dataLabel">Meal Type :</div>
            <div class="dataInput">
                <asp:DropDownList ID="ddlMealType" runat="server"></asp:DropDownList>
            </div>
        </div>--%>
        <div runat="server" id="divCycleSection">
            <div class="dataRow w500">
                <div class="dataLabel">Cycle :</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlCycle" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlCycle_SelectedIndexChanged">
                    </asp:DropDownList>

                </div>
            </div>

            <div class="dataRow w500">
                <div class="dataLabel">Start Date :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="dataRow w500">
                <div class="dataLabel">End Date :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlBtn">
        <asp:Button ID="btnCancelFrom" CssClass="btn btn_save" Style="margin-left: 5px" runat="server" Text="Cancel" OnClick="btnCancelFrom_Click" />
        <asp:Button ID="btnEditMenu" CssClass="btn btn_save" Style="margin-right: 5px" runat="server" Text="Save" OnClick="btnEditMenu_Click" />
    </asp:Panel>
    <div class="clearfix"></div>




</asp:Panel>

<%--<script type = "text/javascript">
function ConfirmDietOrProgramTypeChange() {
    var confirmChanges = document.createElement('INPUT');
    confirmChanges.type = 'hidden';
    confirmChanges.style.display = 'none';
    confirmChanges.name = 'confirmChanges';
    if (confirm('Associated Contracts must be changed, If Program Type/ Diet Type is changed! Please confirm if you want to change Associated Contratcs?')) {
        confirmChanges.value = 'Yes';
    } else {
        confirmChanges.value = 'No';
    }
    document.forms[0].appendChild(confirmChanges);
}
</script>--%>









