<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewStaffAccessLevel.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ViewStaffAccessLevel" %>


<asp:Label ID="lblStaffID" runat="server" Visible="False" />
<asp:Label ID="lblMsg" runat="server"  />
<asp:Panel ID="pnPage" runat="server" >
   
             
                    <div class="dataLabel"><span class="wtitleLarge">User Group Access Level :</span><asp:Label CssClass="dataInput" ID="lblGroupAccessLevel" runat="server" Visible="false"/>
                      <asp:Label CssClass="dataInput" ID="lblGroupAccessLevelText" runat="server" />    </div> 
             
                <asp:Panel ID="pnSponsor" runat="server" >
                <div class="dataRow">
                    <div class="dataLabel"><span class="wtitleLarge">Sponsor :</span><asp:Label CssClass="dataInput" ID="lblSponsor" runat="server" /></div>                   
                  
                </div>
            </asp:Panel>
             <asp:Panel ID="pnCaterer" runat="server" >     
                  
                    <div class="dataLabel"><span class="wtitleLarge">Caterer :</span><asp:Label  CssClass="dataInput" ID="lblCaterer" runat="server" /></div>  
               
           </asp:Panel>

             <asp:Panel ID="pnContract" runat="server" >     

                 <div class="dataRow">
                    <div class="dataLabel">Contracts :</div>                    
                     <div class="dataInput">
   
    <asp:GridView ID="gvContract" CssClass="DatagridStyle" runat="server" AutoGenerateColumns="False"    
    DataKeyNames="ContractID">    
        <Columns>
            <asp:BoundField DataField="ContractID" Visible="false" />
            <asp:BoundField DataField="ContractName" HeaderText="Contract Name" />
            <asp:BoundField DataField="ContractNumber" HeaderText="Contract Number" />
        </Columns>
    </asp:GridView>

   
                      </div>
                </div>

   </asp:Panel> 
  



   

     

</asp:Panel>