<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEditCycle.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.AddEditCycle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">
    $(function () {
        $(".pickdate").datepicker();
    });
	        </script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="contentBox">
<div class="title2 h2Size">Menu Cycle<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
<div class="dataList">
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtMenuCycleEndDate"
            ControlToCompare="txtMenuCycleStartDate" Type="Date" Display="Dynamic" ErrorMessage="* End Date must be greater than Start Date"           
            Operator="GreaterThan" SetFocusOnError="true" ></asp:CompareValidator>
        <div class="dataRow">
                    <div class="dataLabel">Period :  <asp:DropDownList CssClass="dataInput" ID="ddMenuCycleName" runat="server">
</asp:DropDownList></div>                   
                  
                </div>
<div class="clearfix"></div>
        <div class="dataRow w300">
                    <div class="dataLabel">Start Date : </div>                    
                   <div class="dataInput"><asp:TextBox ID="txtMenuCycleStartDate" runat="server" ></asp:TextBox></div>
                   <cc1:CalendarExtender ID="CalendarExtender1"  runat="server" TargetControlID="txtMenuCycleStartDate" Format="MM/dd/yyyy" ></cc1:CalendarExtender>
                </div>
<div class="clearfix"></div>
        <div class="dataRow w300">
                    <div class="dataLabel">End Date : </div>                    
                  <div class="dataInput"> <asp:TextBox ID="txtMenuCycleEndDate" runat="server" ></asp:TextBox></div>
                  <cc1:CalendarExtender ID="CalendarExtender2"  runat="server" TargetControlID="txtMenuCycleEndDate" Format="MM/dd/yyyy" ></cc1:CalendarExtender>
             
                </div>
  <asp:Panel ID="pnIsActive" runat="server" Visible="false" >
<div class="clearfix"></div>
        <div class="dataRow">
                    <div class="dataInput"><asp:CheckBox ID="isActive" runat="server" Text="Active"/></div>                    
                  
                </div>
   
    </asp:Panel>
       
     </div>
    <asp:Button ID="btnSubmit" runat="server" cssClass="btn btn_save" Text="Submit" Visible="false" 
    onclick="btnSubmit_Click"/>
<asp:Button ID="btnSave" runat="server" cssClass="btn btn_save" Text="Save" Visible="false" 
    onclick="btnSave_Click"/>
    </div>