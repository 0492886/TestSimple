<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestLabel.ascx.cs" Inherits="SimpleServings.UI.UDC.TestLabel" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"
         TagPrefix="ajaxToolkit" %>

<script type="text/javascript">
    function resizeCommentsBox(sender) {
        //alert(sender.rows);
        a = sender.value.split('\n');
        b = 1;
        for (x = 0; x < a.length; x++) {
            if (a[x].length >= sender.cols) {
                b += Math.floor(a[x].length / sender.cols);
            }
        }
        b += a.length;
        if (b > sender.rows) {
            sender.rows = b;
        }

        sender.parentNode.style.zIndex = '99';
    }

    function resizeBackCommentsBox(sender) {
        sender.rows = '1';
        sender.parentNode.style.zIndex = '1';
    }
</script>

<ajaxToolkit:AutoCompleteExtender
        runat="server" 
        BehaviorID="AutoCompleteEx";
        ID="AutocompleteDescription1" 
        TargetControlID="txtDescription"
        ServicePath="../../AutoCompleteService.asmx" 
        ServiceMethod="GetRecipeSupplimentRequirements"
        MinimumPrefixLength="3" 
        CompletionInterval="1000"
        EnableCaching="true"
        CompletionSetCount="15"      
        >    
</ajaxToolkit:AutoCompleteExtender>
TextBox: 
<br />
<asp:TextBox ID="txtDescription" runat="server" Width="80"></asp:TextBox>
<br />
<div style="position:relative;width:180px;height:20px;">
	<asp:TextBox id="txtComment" TextMode="MultiLine" runat="server" Rows="1" style="overflow:hidden;z-index:1;position:absolute;" onkeydown="resizeCommentsBox(this);" onfocus="resizeCommentsBox(this);" onblur="resizeBackCommentsBox(this);"  />					
</div> 

