<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewContactPerson.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ViewContactPerson" %>

<asp:Label ID="lblPersonID" runat="server" Visible="false"></asp:Label>


<h2 class="title2">
    <asp:Label ID="Label1" runat="server" Text="Contact Person"></asp:Label>
</h2>
<div class="dataList">
     
        <div class="w500">
            <div class="dataLabel"><span class="wtitleSmall">First Name :</span> <asp:Label  CssClass="dataInput" ID="lblFirstName" runat="server"></asp:Label></div>
           
        </div>
        <div class="clearfix"></div>
        <div class="w500">
            <div class="dataLabel"><span class="wtitleSmall">Last Name :</span><asp:Label  CssClass="dataInput" ID="lblLastName" runat="server"></asp:Label></div>
          
        </div>
        <div class="clearfix"></div>
        <div class="w500">
            <div class="dataLabel"><span class="wtitleSmall">Address :</span><asp:Label  CssClass="dataInput" ID="lblAddress" runat="server"></asp:Label></div>
            
        </div>
        <div class="clearfix"></div>
        <div class="w500">
            <div class="dataLabel"><span class="wtitleSmall">Phone :</span><asp:Label  CssClass="dataInput" ID="lblPhone" runat="server"></asp:Label></div>
            
        </div>
        <div class="clearfix"></div>
        <div class="w500">
            <div class="dataLabel"><span class="wtitleSmall">Email :</span><asp:Label  CssClass="dataInput" ID="lblEmail" runat="server"></asp:Label></div>
            
        </div>
 <div class="clearfix"></div>
</div>