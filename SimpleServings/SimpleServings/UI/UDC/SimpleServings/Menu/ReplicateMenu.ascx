<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReplicateMenu.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.ReplicateMenu" %>
<%@ Register src="../Supplier/ContractGrid.ascx" tagname="ContractGrid" tagprefix="uc2" %>
<%@ Register src="../Supplier/ListContract.ascx" tagname="ListContract" tagprefix="ucConList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Label ID="lblMsg" runat="server"></asp:Label>
<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
<asp:HiddenField ID="hdnField" runat="server" />
<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager> 

 <div class="title2 h2Size">Add Menu
<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>
<div class="dataList">
           <div class="dataRow">
	     
            <div class="dataRow w500">
                    <div class="dataLabel">Menu Name :</div><asp:Label ID="lblMenuTypeID" runat="server" Text="" style="display: none"></asp:Label>
                     <div class="dataInput">                                              
             <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>                   
                      </div>
            </div>

            <div class="dataRow w500">
            
            <div class="dataLabel"><span class="wtitle">Program Type :</span> 
            <%--<asp:Label CssClass="dataInput" ID="lblContract" runat="server"></asp:Label>--%>    
             <%--<asp:Label ID="lblContractTypeID" runat="server" Visible="false"></asp:Label>--%> 
                <div class="dataInput"> 
                    <asp:DropDownList ID="ddlContract" runat="server" OnSelectedIndexChanged="ddlDietTypeContractType_SelectedIndexChanged1" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>                    
            <!--<div class="dataInput">                                              
                               
            </div>-->
        </div>
         <div class="clearfix"></div>   
        <div class="dataRow w500">
            <div class="dataLabel w501"><span class="wtitle">Meal Type :</span> 
            <asp:Label  CssClass="dataInput" ID="lblMealType" runat="server"></asp:Label>     
            <asp:Label ID="lblMealTypeID" runat="server" Visible="false"></asp:Label> 

            </div>                    
            <div class="dataInput">                     
                    <asp:DropDownList ID="ddlMealType" runat="server" AutoPostBack="true" onselectedindexchanged="ddlMealType_SelectedIndexChanged"></asp:DropDownList>
                          
            </div>
        </div>
        <div class="dataRow w500">
            <div class="dataLabel">Diet Type :</div>                    
            <div class="dataInput">                     
            <asp:DropDownList ID="ddlDietType" runat="server" OnSelectedIndexChanged="ddlDietTypeContractType_SelectedIndexChanged1" AutoPostBack="true">

            </asp:DropDownList>
            </div>
        </div>

         <%-- Mandy add --%>
        <div class="dataRow w500">
            <div class="dataLabel">Meal Served Format :</div>                    
            <div class="dataInput">                     
                 <asp:DropDownList ID="ddlMealServedFormat" runat="server" AutoPostBack="true" onselectedindexchanged="ddlMealServedFormat_SelectedIndexChanged"></asp:DropDownList>
                     
            </div>
       </div>      

        <div class="dataRow w500 containerBox" id="divSelectCont" runat="server">
            <div class="dataInput" style="max-height:500px;">
                
                <asp:LinkButton runat="server"  Text="Select Contract(s) &#x27a4;" ID="btnSelectcontract"  CssClass="floatL" OnClick="btnSelectcontract_Click"/> 
                
<%--                <ajaxToolkit:ModalPopupExtender ID="ajaxModalPopup" runat="server" PopupControlID="pnlcontract" TargetControlID="hdnField" BackgroundCssClass="modalPopupBackGround">
                </ajaxToolkit:ModalPopupExtender>--%>
                
                <%--<asp:panel ID="pnlcontract" runat="server" class="modalPopupPanel" style="display:none;"> --%>
                    <div id="dialog" style="display:none;">
                          <div style="max-height:500px; overflow:auto; text-align:center;">
                          <uc2:ContractGrid runat="server" ID="ucContractGrid" />
                          </div>
                        <asp:Button id="btnSelect" Text="Select" runat="server" class="btn_black" style="text-align:right" OnClick="btnSelect_Click" UseSubmitBehavior="false"/>
                        <asp:Button id="btnCancel" Text="Cancel" runat="server" class="btn_black" style="text-align:right" OnClick="btnCancel_Click" UseSubmitBehavior ="false" />

                    </div>
               <%-- </asp:panel>--%>
            </div>
       </div>

         <div class="dataRow w760" runat="server" id="divContractGrid" visible="false">
             <div class="dataRow w760">
                 <ucConList:ListContract runat="server" ID="ucContractList" style="margin:0px"></ucConList:ListContract>
             </div>
        </div>
<%-- Mandy add  --%>
<div class="dataLeft">
<div class="dataRow">
                <div class="dataLabel">Menu Tags :</div>
                <div class="dataInput">
                    <asp:CheckBoxList ID="cblCuisines"  runat="server" RepeatColumns="2" RepeatDirection="Vertical" AutoPostBack="true"
                             onselectedindexchanged="cblCuisines_SelectedIndexChanged"></asp:CheckBoxList>
                </div>
            </div>

</div>
<%-- Mandy add  --%>

<div runat="server" id="divCycleRange">
            <div class="dataRow w500">
                    <div class="dataLabel">Cycle :</div>
                     <div class="dataInput">
              <asp:DropDownList ID="ddlCycle" runat="server" AutoPostBack="true"
                             onselectedindexchanged="ddlCycle_SelectedIndexChanged"></asp:DropDownList>
                     
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
              <div class="clearfix"></div>
        <div class="dataRow w500">
            <div class="dataLabel">Days of Service</div>
                <div class="dataInput">
                    <asp:CheckBoxList CssClass="tdSpacing" ID="cblDays" runat="server"></asp:CheckBoxList>
                </div>

<%--            <div class="dataLabel w501"><span class="wtitle">Days of service :</span> <asp:Repeater runat="server" id="rptDays">
                    <ItemTemplate>
                        <i class="icon-tags"></i> <span class="dataInput"><%# DataBinder.Eval(Container.DataItem, "DayName") %></span>
                    </ItemTemplate> 
                </asp:Repeater>  </div>   --%>                 
            <div class="dataInput">
                        
            </div>
        </div>

 <div class="clearfix"></div>
        <div style="float:left; margin-left:0px; text-align:left;">
            <div class="dataLabel">Swap Weeks: </div>
                <div class="dataInput">
                     <asp:CheckBox runat="server" Text="Check to reorder weeks" ID="cbSwapWeek" OnCheckedChanged="cbSwapWeek_CheckedChanged" AutoPostBack="true" />
                </div>

            <div  id="divSwap" runat="server" visible="false">
                <div style="display:none;"> 
                    <%--Not using this section--%>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek1" Text="Week 1" ToolTip="Drag Me!" /> </div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek2" Text="Week 2" ToolTip="Drag Me!"/> </div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek3" Text="Week 3" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek4" Text="Week 4" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek5" Text="Week 5" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="lblWeek6" Text="Week 6" ToolTip="Drag Me!"/></div>
               <asp:HiddenField runat="server" ID="hdnWeek" />
                </div>

                <div class="dataLabel">Reorder Weeks &#x27a4;</div>

                <div>
                    <table style="width:300px; border-radius:5px; border:1px solid gray;  text-align:center" >
                        <tr>
                            <td style="border:1px solid gray; width:50%; height:60%;">
                                <div class="dataLabel" style="border-bottom:double;">New Menu Order </div>
                                <div id="divNewWeek" style="width:100%; background:#ccc;overflow:auto;">
                                                    <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label7" Text="Week 1" ToolTip="Drag Me!" /> </div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label8" Text="Week 2" ToolTip="Drag Me!"/> </div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label9" Text="Week 3" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label10" Text="Week 4" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label11" Text="Week 5" ToolTip="Drag Me!"/></div>
                <div class="dragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label12" Text="Week 6" ToolTip="Drag Me!"/></div>

                                </div>
                            </td>

                            <td style="width:50%;">
                              <div id="divOriginalOrder">
                                <div class="dataLabel" style="border-bottom: double;">Original Menu Order </div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label1" Text="Week 1" /> </div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label2" Text="Week 2" /> </div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label3" Text="Week 3" /></div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label4" Text="Week 4" /></div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label5" Text="Week 5" /></div>
                                <div class="nodragdrop" ><asp:Label runat="server" class="lblWeek" ID="Label6" Text="Week 6" /></div>
                              </div>
                            </td>

                            
                        </tr>
                    </table>



                </div>
                
            </div>
             
        </div>





    </div> 
</div>
 <asp:Button ID="btnAddMenu" CssClass="btn btn_save" runat="server" Text="Save" onclick="btnAddMenu_Click" OnClientClick="saveClick()" />
    <div class="clearfix"></div>  
    
     
</asp:Panel>
 
<script type="text/javascript">


    //Initialize dialog
    $("#dialog").dialog({
        autoOpen: false,
        hide: {
            effect: "destroy",
            duration: 1000
        },
        modal: true,
        width: 800,
        open: function () {
            {
                $('.ui-dialog').css('z-index', 103);
                $('.ui-widget-overlay').css('z-index', 102);
                $(this).parent().appendTo($("form"));
            }
        }
    });



    function showSwapWeeks() {
        
        if (document.getElementById("cbSwapWeeks").checked == true) {
            document.getElementById("divSwap").style.visibility = "visible";
        }
    }


    
        jQuery.fn.swap = function (b) {
            
            b = jQuery(b)[0];
            var a = this[0];
            var t = a.parentNode.insertBefore(document.createTextNode(''), a);
            b.parentNode.insertBefore(a, b);
            t.parentNode.insertBefore(b, t);
            t.parentNode.removeChild(t);
            return this;
        };

     

        $(function () {
            $(".dragdrop").draggable({
                connectToSortable: "#divNewWeek",
                revert: true,
                handle: "div.lblWeek"
            });
            
            $("#divNewWeek").sortable({
                revert: true,
                receive: function (event, ui) {
                    var html = [];
                    $(this).find('li').each(function () {
                        html.push('<div class="toggle">' + $(this).html() + '</div>');
                    });
                    $(this).find('li').replaceWith(html.join(''));

                    $(ui.helper).remove();
                    $(ui.draggable).remove();
                }
            });
        });




        function saveClick()
        {
            var NewWeekOrder = document.getElementById('divNewWeek').innerText;
            $('#<%= hdnWeek.ClientID %>').val('');
            $('#<%= hdnWeek.ClientID %>').val(NewWeekOrder);
        }




</script>

<style>


.ui-button-icon-only {
box-sizing: border-box;
text-indent: -9999px;
white-space: nowrap;
}


#dialog {
display: none;
}

.myTarget {
  font-weight: bold;
  font-style: italic;
  color: red;

}






.nodragdrop {
background:LightYellow;
margin:5px;
padding:0px;
width:100px;
height:20px;
border: 1px solid black;
text-decoration:underline;
font-weight: bold;
overflow:hidden;
cursor: pointer;
position:static;
text-align:center;
}


.dragdrop {
background:LightYellow;
margin:5px;
padding:0px;
width:100px;
height:20px;
border: 1px solid black;
text-decoration:underline;
font-weight: bold;
overflow:hidden;
cursor: pointer;
position:static;
text-align:center;

}
.ui-state-hover {
background:gray;  
}

.ui-state-active {
background:lightgray;
border: 1px solid red;
}


#divNewWeek {
width:50%;height:212px;
background:#ccc;overflow:auto;
}

.toggle {background:green;margin:3px 0 0 0;}

</style>








