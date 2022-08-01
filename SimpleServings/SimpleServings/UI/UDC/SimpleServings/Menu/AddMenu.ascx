<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Menu.AddMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Register src="../Supplier/ContractGrid.ascx" tagname="ContractGrid" tagprefix="uc2" %>
<%@ Register src="../Supplier/ListContract.ascx" tagname="ListContract" tagprefix="ucConList" %>
<%@ Register src="MenuGrid.ascx" tagname="MenuGrid" tagprefix="ucMenuGrid" %>



<script type="text/javascript" src="<%# Page.ResolveUrl("~/UI/js/custom.js") %>"></script>
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
<asp:Panel  CssClass="contentBox" ID="pnPage" runat="server">
<asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>  
<asp:HiddenField ID="hdnField" runat="server" />

 <div class="title2 h2Size" > <asp:Label ID="lblAddMenuHeader" Text="Add Menu" runat="server"></asp:Label>
<a class="back floatR" href="JavaScript:history.back();">Back</a>
</div>

<div class="dataList" >
           <div class="dataRow">
	      
            <div class="dataRow w500">
                    <div class="dataLabel">Menu Name :</div>                    
                     <div class="dataInput">                                              
             <asp:TextBox ID="txtMenuName" runat="server"    ></asp:TextBox>      
                         <%--<asp:TextBox ID="txtMenuName" runat="server" disabled=""></asp:TextBox>     --%>
                      </div>
            </div>



             <div class="dataRow w500">
                    <div class="dataLabel">Program Type : </div>
                     <div class="dataInput">   
                  <asp:DropDownList ID="ddlSampleMenuProgramType" runat="server" Enabled="false"   Visible="false" >
                      <asp:ListItem Selected="True" Text="Congregate/ Home Delivered Meal" Value="131"></asp:ListItem>
                  </asp:DropDownList>            
                 <%--<asp:Label ID="lblSampleMenuProgramType" runat="server" Text="Congregate/ Home Delivered Meal" Visible="false"></asp:Label>     --%>                          
                 <asp:DropDownList ID="ddlContract" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlContract_SelectedIndexChanged" ></asp:DropDownList>  
                       
                      </div>
            </div>
            <div class="dataRow w500">
                    <div class="dataLabel">Meal Type :</div>                    
                     <div class="dataInput">                     
             <asp:DropDownList ID="ddlMealType" runat="server" AutoPostBack="true" onselectedindexchanged="ddlMealType_SelectedIndexChanged"></asp:DropDownList>
                     
                      </div>
            </div>
            <div class="dataRow w500" style="display:none">
                <div class="dataLabel">Diet Type :</div>                    
                <div class="dataInput">                     
                <asp:DropDownList ID="ddlDietType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDietType_SelectedIndexChanged1">

                </asp:DropDownList>
                </div>
            </div>
             <%--  add --%>
             <div class="dataRow w500">
                  <div class="dataLabel">Meal Served Format :</div>                    
                     <div class="dataInput">                     
                 <asp:DropDownList ID="ddlMealServedFormat" runat="server" AutoPostBack="true" onselectedindexchanged="ddlMealServedFormat_SelectedIndexChanged"></asp:DropDownList>
                     
                      </div>
             </div>

            <div class="dataRow w500 containerBox" id="divSelectCont" runat="server">
            <div class="dataInput" style="max-height:500px;">
                <asp:LinkButton runat="server"  Text="Select Contract(s) &#x27a4;" ID="btnSelectcontract"  CssClass="floatL" OnClick="btnSelectcontract_Click"/> 
                
                <ajaxToolkit:ModalPopupExtender ID="ajaxModalPopup" runat="server" PopupControlID="pnlcontract" CancelControlID="btnCancel" TargetControlID="hdnField" BackgroundCssClass="modalPopupBackGround">
                </ajaxToolkit:ModalPopupExtender>

               <asp:panel ID="pnlcontract" runat="server" class="modalPopupPanel">
                   <div style="max-height:500px; overflow:auto; text-align:center;">
                    <uc2:ContractGrid runat="server" ID="ucContractGrid" />
                   </div>
                   <asp:Button id="btnSelect" Text="Select" runat="server" class="btn_black" style="text-align:right" OnClick="btnSelect_Click"/>
                   <asp:Button id="btnCancel" Text="Cancel" runat="server" class="btn_black" style="text-align:right" />
                </asp:panel>   

            </div>
       </div>

         <div class="dataRow w760" runat="server" id="divContractGrid" visible="false">
             <div class="dataRow w760">                 
                 <ucConList:ListContract runat="server" ID="ucContractList" style="margin:0px"></ucConList:ListContract>                 
  
             </div>
        </div>


    <div class="dataRow w500 containerBox" runat="server" id="divSelectSample" visible="false">
                <div class="dataInput" style="max-height:500px;">
                    <asp:LinkButton runat="server"  Text="Select Sample Menu &#x27a4;" ID="lnkSelectSample"  CssClass="floatL" OnClick="lnkSelectSample_Click"/>

                                     
                 <ajaxToolkit:ModalPopupExtender ID="ajaxPopupSampleMenu" runat="server" PopupControlID="pnlSampleMenu" CancelControlID="btnCancel1" TargetControlID="hdnField" BackgroundCssClass="modalPopupBackGround">
                 </ajaxToolkit:ModalPopupExtender>

                  <asp:panel ID="pnlSampleMenu" runat="server" class="modalPopupPanel">
                    <div style="max-height:500px; overflow:auto; text-align:center;">
                        <ucMenuGrid:MenuGrid runat="server" ID="ucMenuGrid"></ucMenuGrid:MenuGrid>  
                    </div>
                    <asp:Button id="btnSelectSampleMenu" Text="Select" runat="server" class="btn_black" style="text-align:right" OnClick="btnSelectSampleMenu_Click" />
                    <asp:Button id="btnCancel1" Text="Cancel" runat="server" class="btn_black" style="text-align:right" />
                </asp:panel> 

                </div>

            </div>

         <div class="dataRow w760" runat="server" id="divSampleMenuList" Visible="false">
             <div class="dataRow w760">                 
                 <asp:Panel ID="Panel1" CssClass="contentBox" runat="server">
                      <div class="title2 h2Size"><asp:Label runat="server" Text="Selected Sample Menu" ID="lblMenuGridHeader"></asp:Label></div>
                        <ucMenuGrid:MenuGrid runat="server" ID="ucMenuGrid1"></ucMenuGrid:MenuGrid>
                 </asp:Panel>
             </div>
        </div>

<div class="dataLeft">
<div class="dataRow">
                <div class="dataLabel">Select Menu Cuisine Type :</div>
                <div class="dataInput">
                    <asp:CheckBoxList ID="cblCuisines"  runat="server" RepeatColumns="2" RepeatDirection="Vertical" AutoPostBack="true"
                             onselectedindexchanged="cblCuisines_SelectedIndexChanged"></asp:CheckBoxList>
                </div>
            </div>

</div>
<div runat="server" id="divCycleRange">
    <div class="dataLeft">
            <div class="dataRow w500">
                    <div class="dataLabel">Cycle :</div>                    
                     <div class="dataInput">                     
              <asp:DropDownList ID="ddlCycle" runat="server" AutoPostBack="true"
                             onselectedindexchanged="ddlCycle_SelectedIndexChanged"></asp:DropDownList>
                     
                      </div>
            </div>

            <div class="dataRow smlInputs mr20">
                    <div class="dataLabel">Start Date :</div>                    
                     <div class="dataInput">                     
             <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="true"></asp:TextBox>                     
                      </div>
            </div>
            <div class="dataRow smlInputs mr20">
                    <div class="dataLabel">End Date :</div>                    
                     <div class="dataInput">                   
             <asp:TextBox ID="txtEndDate" runat="server" placeholder=" " ReadOnly="true" AutoPostBack="true" OnTextChanged ="txtEndDate_TextChanged"></asp:TextBox>                     
                      </div>
            </div>
        </div>
</div>
             <div class="dataRow w500" >
                    <div class="dataLabel">Days of Service</div>  
                 
                     <div class="dataInput">                                       
                         <asp:CheckBoxList CssClass="tdSpacing" ID="cblDays" runat="server" AutoPostBack="true" onselectedindexchanged="cblDays_SelectedIndexChanged"></asp:CheckBoxList>                     
                      </div>
             
                </div>
              </div>   
     </div>
      
          <asp:Button ID="btnAddMenu" CssClass="btn btn_save" runat="server" Text="Save" onclick="btnAddMenu_Click" />
    <div class="clearfix"></div>  

</asp:Panel>
 

<script type="text/javascript">
var getGridClientID = function ()
{
    var gv = '<%= ucMenuGrid.FindControl("gvMenus").ClientID %>';
    return gv;
    }




 
</script>





