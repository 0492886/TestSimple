<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuStatusChangeSubmission.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.MenuStatusChangeSubmission" %>


<%@ Register src="SubmitMenuToContracts.ascx" tagname="SubmitMenuToContracts" tagprefix="uc1" %>


<%@ Register src="MenuStatusHistoryGrid.ascx" tagname="MenuStatusHistoryGrid" tagprefix="uc2" %>


<asp:Panel CssClass="contentBox" ID="pnPage" runat="server">
    <div class="title2 h2Size">Status Change
        <a class="back floatR" href="JavaScript:history.back();">Back</a>
    </div>
    <div class="dataList">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <div class="dataRow w500">
            <div class="dataLabel">Change Status :</div>                    
            <div class="dataInput">
                <asp:DropDownList ID="ddlMenuStatus" runat="server"></asp:DropDownList>                      
            </div>
        </div>

        <br /><br />
      <div class="dataLabel w501"><span class="wtitleLarge" id="spanContractName" runat="server">Selected Contract Names :</span> 
            <asp:Label CssClass="dataInput" ID="lblContractName" runat="server"></asp:Label>
            <div>
            <asp:DataList CssClass="dataInput tdSpacing"  ID="dlContracts" runat="server">
                <ItemTemplate>
                    &#9679;
                    <asp:Label ID="lblCatererName" runat="server" Text='<%# Container.DataItem.ToString() %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:DataList>
            </div>
      </div>



        <asp:Panel ID="pnlSubmitTocontract" runat="server" Visible="false">
        <div class="clearfix"></div>
        <div class="dataRow">
            <div class="dataLabel">Select Contracts :</div>
            <div class="dataInput">
                <uc1:SubmitMenuToContracts ID="SubmitMenuToContracts1" runat="server" />
            </div>
        </div>
        </asp:Panel>
        <div class="dataRow w500">
            <div class="dataLabel">Comment :</div>                    
            <div class="dataInput">
                <asp:TextBox ID="txtCustomMessage" CssClass="widthComment" TextMode="MultiLine" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    
<%--    <asp:Button ID="btnEditMenuStatus" CssClass="btn btn_save" runat="server"
        Text="Submit" onclick="btnEditMenuStatus_Click" />--%>
    <asp:Button ID="btnEditMenuStatus" CssClass="btn btn_save" runat="server"
        Text="Submit" onclick="btnEditMenuStatus_Click"  OnClientClick="Javascript:Init();" />
    <button class="btn saveClose rightFloat hide" type="button">Close</button>

</asp:Panel>

<div class="contentBox marginTophack">
    <h2 class="title2">Menu Status History</h2>
    <div class="dataList">                                                                                                                                         
        <uc2:MenuStatusHistoryGrid ID="MenuStatusHistoryGrid1" runat="server" />                                                             
    </div>
</div>

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="btnCancel" TargetControlID="hdn" PopupControlID="panelAgreement" BackgroundCssClass="modalBackground">
    </ajaxToolkit:modalpopupextender>
 <%--<asp:LinkButton runat="server" ID="lnk" CssClass="{display:none;}" Text="popup" />--%>
<asp:HiddenField runat="server" ID="hdn" />

<asp:Panel ID="panelAgreement" runat="server" Width="400px" Height="250px" Style="text-align: left; padding: 20px; display: none; font-style: italic;" CssClass="modalPopup">
    <asp:CheckBox ID="chxAgree" runat="server" onclick="EnableSubmit(this);" Text="By checking this box, I certify that my program will follow the approved menus and recipes within, and that any changes made will be equivalent in nutritional value.  I acknowledge that changes to the menu or recipes may alter the overall nutritional content." />

    <div style="text-align: left; margin-top: 20px;">
        <asp:Button ID="btnAgree" runat="server" Text="Submit" OnClick="btnAgree_Click" Enabled="false" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
    </div>
</asp:Panel>

<script type="text/javascript">
    function EnableSubmit(val) {
        var btnAgreeId = '<%= btnAgree.ClientID %>';
        var submit = document.getElementById(btnAgreeId);
        if (val.checked) {
            submit.disabled = false;
        }
        else {
            submit.disabled = true;
        }
    }

    function Init() {
        var chxAgree = '<%= chxAgree.ClientID %>';
        var btnAgreeId = '<%= btnAgree.ClientID %>';

        document.getElementById(chxAgree).checked = false;
        document.getElementById(btnAgreeId).disabled = true;

       // document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_chxAgree").checked = false;
       // document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_btnAgree").disabled = true;
    }

</script>
