<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddStaffNote.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.AddStaffNote" %>

<!--script type="text/javascript">
    function hidebubble(){
    document.getElementById('bubblecontainer').style.display = 'none';}
    
    function showbubble(){
    document.getElementById('bubblecontainer').style.display = 'block';}
    
</script-->
<script type="text/javascript">
    $(document).ready(function(){
        $(".chatbox").hide()
        $(".btn_chat, .btnReply, #hidebubble").click(function () {
            $(".chatbox").slideToggle('fast');
        });
    });
</script>
    <div class="chatbox">
        <div class="bubbletable"  id="bubblecontainer">
            <div class="bubblecontent">
                <div style="display:none;">
                    <asp:Label CssClass="lblMsgFrom" ID="lblSender" runat="server">Latest note from <span>Case Worker</span></asp:Label>
                </div>
                <div class="popUpMsgContent">
                    <asp:Label ID="lblMsg" runat="server" />
                </div>
                
                <div class="popUpMsgReply">
                    <asp:TextBox  ID="txtNote" runat="server" CssClass="txtReply" TextMode="multiLine" /><br />
                    <asp:LinkButton ID="lnkAddNote" CssClass="btn_floatR ActivityEmail" runat="server" Text="Send" />
                    <a href="#" id="hidebubble" class="btn_floatL btn_delete">Close</a>
                    <asp:LinkButton ID="lnkClose" CssClass="btn_floatL btn_delete" CausesValidation="false" runat="server" Visible="false" Text="Close" />
                </div> 
            </div>
        </div>
    </div>
    

