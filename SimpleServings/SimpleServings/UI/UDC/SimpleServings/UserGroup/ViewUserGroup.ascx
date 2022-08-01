<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewUserGroup.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.UserGroup.ViewUserGroup" %>


<div class="contentLeftPad">
 <div class="ViewPageContainer curved">
 <asp:Label ID="lblMsg" runat="server" />

<asp:Panel ID="pnPage" runat="server">

         
        <div class="section">
            <asp:Label ID="lblUserGroupID" runat="server" Visible="false" /> 
            <table class="InformationListing" >
                <tr>
                    <td>User Group Name :</td>
                    <td> <asp:Label ID="lblUserGroupName" runat="server" Width="324px" /></td>
                </tr>
                  <tr>
                    <td>Case View :</td>
                    <td><asp:Label ID="lblCasePermission" runat="server" /></td>
                </tr>
                <tr>
                    <td>Group Description :</td>
                    <td><asp:Label ID="lblComments" runat="server" Height="98px" Width="325px" /></td>
                </tr>
                 <tr>
                    <td>Created By :</td>
                    <td>
                        <asp:Label ID="lblCreatedByText" runat="server" />
                        <asp:Label ID="lblCreatedBy" runat="server" Visible="False" /></td>
                </tr>
            </table>
        </div>
        </asp:Panel>
        </div>
        </div>