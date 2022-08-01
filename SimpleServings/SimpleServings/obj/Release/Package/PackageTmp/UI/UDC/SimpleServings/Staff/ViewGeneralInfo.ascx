<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewGeneralInfo.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ViewGeneralInfo" %>

<asp:Label ID="lblSummary" runat="server" />

    <div class="InformationListing">

        
                    <div class="dataLabel"><span class="wtitleSmall">Name :</span><asp:Label CssClass="dataInput" ID="lblFirstName" runat="server" />
                     <asp:Label CssClass="dataInput"  ID="lblLastName" runat="server" /></div>                    
          
                    <div class="dataLabel"><span class="wtitleSmall">Work Phone :</span><asp:Label  CssClass="dataInput" ID="lblWorkPhone" runat="server" />  </div>                    
                    
              
                    <div class="dataLabel"><span class="wtitleSmall">Fax :</span><asp:Label  CssClass="dataInput" ID="lblFax" runat="server" /></div>                    
                   
            

              
                    <div class="dataLabel"><span class="wtitleSmall">Street Address :</span><asp:Label  CssClass="dataInput" ID="lblStreetAddres1" runat="server" />
                     <asp:Label  CssClass="dataInput"  ID="lblStreetAddres2" runat="server" />  </div>                    
                  
            
  
        <%-- 
             
                    <div class="dataLabel"><span class="wtitleSmall">Site :</span><asp:Label  CssClass="dataInput" ID="lblSiteName" runat="server" />       
                     [<asp:Label ID="lblSiteCode" runat="server" />]  </div>                    
                 
             
 --%>
             
                              
                     <div class="dataInput">
                      <asp:Label ID="lblCity" runat="server" />
                      <asp:Label ID="lblState" runat="server" />
                      <asp:Label ID="lblZipCode" runat="server" />                     
                      </div>
                   
             
     
       
            
                    <div class="dataLabel"><span class="wtitleSmall">Unit :</span><%-- 
                <asp:Label ID="lblProgramCD"  CssClass="dataInput" runat="server" />           
            --%></div>                    
                   
           


                    
                    <div class="dataLabel"><span class="wtitleSmall">Managed By :</span><asp:LinkButton CssClass="dataInput" ID="lnkBStaff" runat="server" /></div>                    
                  
                
 <%-- 
                 <div class="dataRow">
                    <div class="dataLabel"><span class="wtitleSmall">Staff Field Days :</span><asp:Label  CssClass="dataInput" ID="lblFieldDays" runat="server" />          </div>                    
                  
                </div>
  --%>
 

   
       
    </div>

