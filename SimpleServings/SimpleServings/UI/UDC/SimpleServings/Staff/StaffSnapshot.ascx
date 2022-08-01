<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffSnapshot.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.StaffSnapshot" %>

<asp:Label CssClass="msglabel" ID="lblMsg" runat="server"></asp:Label>
 <div class="ViewPageContainer curved">
 
<div class="SectionTitle curvedTop">Staff Info</div>
<div class="section">
<table class="InformationListing">
     <tr>
        <td >Name</td>
        <td>:</td>
        <td ><asp:Label ID="lblFullName" runat="server"></asp:Label></td>
    </tr>
   
    <tr>
        <td>Site</td>
         <td>:</td>
        <td><asp:Label ID="lblSite" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >Unit</td>
         <td>:</td>
        <td><asp:Label ID="lblUnit" runat="server"></asp:Label>
        </td>
    </tr>
   
    <tr>
        <td >Case Load</td>
         <td>:</td>
        <td><asp:Label ID="lblCaseLoad" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >Telephone#</td>
         <td>:</td>
        <td><asp:Label ID="lblTelephone" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >Fax#</td>
         <td>:</td>
        <td><asp:Label ID="lblFax" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td >Email</td>
         <td>:</td>
        <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
    </tr>
</table>
</div>
 <br />

<div class="SectionTitle curvedTop">Supervisor Info</div>
<div class="section">
<table class="InformationListing">
    
    <tr>
        <td >Name</td>
        <td>:</td>
        <td><asp:Label ID="lblSupFullName" runat="server"></asp:Label></td>
    </tr>
   
    <tr>
        <td >Site</td>
         <td>:</td>
        <td><asp:Label ID="lblSupSite" runat="server"></asp:Label></td>
    </tr>
    
    
    <tr>
        <td>Telephone#</td>
         <td>:</td>
        <td><asp:Label ID="lblSupTelephone" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Fax#</td>
         <td>:</td>
        <td><asp:Label ID="lblSupFax" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td>Email</td>
         <td>:</td>
        <td><asp:Label ID="lblSupEmail" runat="server"></asp:Label></td>
    </tr>
</table>
</div>
</div>


