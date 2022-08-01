<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewComments.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.ViewComments" %>


<asp:Label ID="lblMsg" runat="server" />

<asp:DataList ID="dlComments" runat="server" CssClass="stretcherClass">
    <ItemTemplate>
    
        <div class="ViewPageContainer">
             <div class="section">
                <table class="InformationListing">
                    <colgroup>
                        <col style="width:300px;" />
                        <col style="width:300px;" />
                    </colgroup>
       
                    <tr>
                        <td>
                            Created By :
                            <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedByText") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Created On :
                            <asp:Label ID="lblCreatedOn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" class="noteContent"><asp:Label  ID="lblComments" runat="server"  Text='<%# DataBinder.Eval(Container.DataItem, "Comment") %>' /></td>
                    </tr>
                </table>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>

