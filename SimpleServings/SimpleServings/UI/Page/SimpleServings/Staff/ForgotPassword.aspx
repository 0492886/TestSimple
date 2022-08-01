<%@ Page Language="C#" AutoEventWireup="true" Title="Forgot Password" CodeBehind="ForgotPassword.aspx.cs" MasterPageFile="~/UI/Page/dashboardmain.Master" Inherits="SimpleServings.UI.Page.SimpleServings.Staff.ForgotPassword" %>

<asp:Content ID="ct1" runat="server" ContentPlaceHolderID="containerhome">
    <h1 class="titanictitle">Password Recovery</h1>
    <div class="contentBox">
        <div class="dataList">
            <form id="Form1" runat="server">


                <asp:Label CssClass="msglabel" ID="lblMsg" runat="server" />


                <div class="SectionTitle curvedTop">Forgot Username and Password</div>
                <br />
                <div class="section">
                    <table class="w325">
                        <colgroup>
                            <col style="width: 36px;" />
                        </colgroup>
                        <tr>
                            <td class="dataLabel">Email:</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" /><br />
                                <br />
                                <asp:Button CssClass="btn" ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                <asp:RegularExpressionValidator CssClass="msglabel" Text="Please enter a valid email address" runat="server" ControlToValidate="txtEmail"
                                    ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$" Display="Dynamic" />
                                <asp:RequiredFieldValidator CssClass="msglabel" Text="Please enter an email address" runat="server" ControlToValidate="txtEmail" Display="Dynamic" />
                            </td>
                        </tr>
                    </table>
                </div>


            </form>
        </div>
    </div>
</asp:Content>

