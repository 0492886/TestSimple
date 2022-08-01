<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewContract.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Supplier.ViewContract" %>
<%@ Register src="ViewContactPerson.ascx" tagname="ViewContactPerson" tagprefix="uc1" %>

<asp:Label ID="lblContractID" runat="server" Visible="false"></asp:Label>
<div class="contentBox">
    <div class="title2 h2Size">
        <asp:Label ID="Label1" runat="server" Text="View Contract"></asp:Label>

        <asp:LinkButton ID="lnkBtnList" runat="server" onclick="lnkBtnList_Click" CssClass="back floatR">
            Back to Contract List
        </asp:LinkButton>
    
        <asp:LinkButton ID="lnkBtnEdit" runat="server" onclick="lnkBtnEdit_Click" CssClass="edit floatR">
            Edit Contract
        </asp:LinkButton>

        <asp:LinkButton CssClass="deleteIcon floatR"  ID="lnkBtnDeactivate" 
            runat="server" CommandName="Remove" oncommand="lnkBtnDeactivate_Command">Remove</asp:LinkButton>
    </div>
    <div class="dataList">

      
            <div class="dataLabel"><span class="wtitle">Contract Name :</span><asp:Label CssClass="dataInput" ID="lblContractName" runat="server"></asp:Label></div>
                 

        
            <div class="dataLabel"><span class="wtitle">DFTA ID Number :</span><asp:Label CssClass="dataInput"  ID="lblContractNumber" runat="server"></asp:Label></div>
             
       
            <div class="dataLabel"><span class="wtitle">Sponsor Address :</span><asp:Label CssClass="dataInput"  ID="lblSponsorAddress" runat="server" ></asp:Label></div>
            
      

            <div class="dataLabel"><span class="wtitle">Contract Type :</span><asp:Label CssClass="dataInput"  ID="lblContractTypeName" runat="server"></asp:Label></div>
          
       
        
     
            <div class="dataLabel"><span class="wtitle">Contract Assigned To :</span><asp:Label CssClass="dataInput"  ID="lblContractAssignedTo" runat="server"></asp:Label></div>
         
       
     
            <div class="dataLabel"><span class="wtitle">Sponsor :</span><asp:Label  CssClass="dataInput" ID="lblSponsorName" runat="server"></asp:Label></div>
           
       
        </div>
    
  
    <h2 class="title2">Caterers</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"><asp:DataList CssClass="dataInput tdSpacing"  ID="dlCaterer" runat="server">
                    <ItemTemplate>
                        &#x27a4;     
                        <asp:Label ID="lblCatererName" runat="server" Text='<%# Eval("CatererName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList></div>
            <div class="dataInput">
                
            </div>
        </div>
    </div>
    <h2 class="title2">Meals Served</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"><asp:DataList CssClass="dataInput tdSpacing"  ID="dlMeal" runat="server">
                    <ItemTemplate>
                        &#x27a4;
                        <asp:Label ID="lblCatererName" runat="server" Text='<%# Eval("MealServedTypeName") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:DataList></div>
            <div class="dataInput">

            </div>
        </div>
    </div>   
    
    <h2 class="title2">Diet Types</h2>
    <div class="dataList">
        <div class="dataRow">
            <div class="dataLabel"><asp:DataList CssClass="dataInput tdSpacing"  ID="dlDietType" runat="server">
                    <ItemTemplate>
                        &#x27a4;
                        <asp:Label ID="lblCatererName" runat="server" Text='<%#  Eval("DietTypeText") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:DataList></div>
            <div class="dataInput">

            </div>
        </div>
    </div> 
     

    <uc1:ViewContactPerson ID="ctrlViewPerson" runat="server" />
    <div class="clearfix"></div>
</div>
  