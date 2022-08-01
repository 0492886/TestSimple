<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffWizard.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.StaffWizard" %>
<%@ Register Src="Comments.ascx" TagName="Comments" TagPrefix="uc4" %>
<%@ Register Src="ModulePermissions.ascx" TagName="ModulePermissions" TagPrefix="uc3" %>
<%@ Register Src="AddEditAccountInfo.ascx" TagName="AddEditAccountInfo" TagPrefix="uc2" %>
<%@ Register Src="AddEditStaff.ascx" TagName="AddEditStaff" TagPrefix="uc1" %>

<%@ Register src="AddStaffAccessLevel.ascx" tagname="AddStaffAccessLevel" tagprefix="uc5" %>
  <div style="margin-left:-21px">
<asp:Wizard ID="wzStaff" runat="server"  
    NavigationButtonStyle-CssClass="wizard_btn" ActiveStepIndex="3" 
    OnFinishButtonClick="wzStaff_FinishButtonClick" 
    OnActiveStepChanged="wzStaff_ActiveStepChanged" 
    OnNextButtonClick="wzStaff_NextButtonClick">
     <WizardSteps>
        <asp:WizardStep ID="WizardStep1" runat="server" Title="General Info" >
           
            <uc1:AddEditStaff ID="AddEditStaff1" runat="server" IsUsedInWizard="True">
            </uc1:AddEditStaff>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep2" runat="server" Title="Account Info" >
         
            <uc2:AddEditAccountInfo ID="AddEditAccountInfo1" runat="server" IsUsedInWizard="True">
            </uc2:AddEditAccountInfo>
        </asp:WizardStep>
        <%-- 
        <asp:WizardStep ID="WizardStep3" runat="server" Title="Module Permissions" >
            <uc3:ModulePermissions ID="ModulePermissions1" runat="server" IsUsedInWizard="True"/>
        </asp:WizardStep>
        --%>

       <asp:WizardStep ID="WizardStep4" runat="server" Title="Permissions" >
            <uc5:AddStaffAccessLevel ID="AddStaffAccessLevel1" runat="server" IsUsedInWizard="True"/>
        </asp:WizardStep>
       
       
        <asp:WizardStep ID="WizarStep6" runat="server" Title="Comments" >
            <uc4:Comments ID="Comments1" runat="server" IsUsedInWizard="True">
            </uc4:Comments>
        </asp:WizardStep>
        <asp:WizardStep ID="WizardStep7" runat="server" Title="Done" StepType="Finish">
            
            <div class="contentBox">
            <div class="dataList">
            <span class="dataLabel">Click Finish to Create Staff<asp:Label ID="lblMsg" runat="server"></asp:Label>
            </span>
            </div>
            </div>
            
            </asp:WizardStep>
    </WizardSteps>
    
     <SideBarStyle HorizontalAlign="Left" VerticalAlign="Top"  />
   <SideBarTemplate>
    <asp:Panel ID="Panel1"  style="margin-right:15px; display:none;"  Runat="Server">
      <asp:DataList ID="SideBarList" Runat="Server">
        <ItemTemplate>
          <asp:Button ID="SideBarButton"  BorderStyle="Solid"  BorderColor="#6ba0ad" BorderWidth="1px" CssClass="space"  ForeColor="#305d68" Font-Bold="true" CommandName="MoveTo" BackColor="#e6f3f6" Font-Size="14px" Height="30px" Width="190px"  Runat="Server"/>
         </ItemTemplate>
         
         <SelectedItemTemplate>
            <asp:Button ID="SideBarButton" BorderStyle="Solid"  BorderColor="#6ba0ad" BorderWidth="1px"  CssClass="space"  ForeColor="white" Font-Bold="true" CommandName="MoveTo" BackColor="#305d68"  Font-Size="14px" Height="30px" Width="190px"  Runat="Server"/>
         </SelectedItemTemplate>
         </asp:DataList>
    </asp:Panel>
  </SideBarTemplate>
    <NavigationButtonStyle CssClass="btn btn_save"  />


</asp:Wizard>
</div>
   <div class="clearfix"></div>   