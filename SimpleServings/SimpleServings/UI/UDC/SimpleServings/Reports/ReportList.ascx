<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Reports.ReportList" %>

<script>
    function NewWindow() {
        document.forms[0].target = "_blank";
    }
</script>

<span class="hidden_msg"><asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label></span>
<asp:Panel CssClass="dataList" ID="pnPage" runat="server">
<div class="contentBox">
    <div class="title2 h2Size">Report List<asp:LinkButton ID="lnkBAddReport" 
            runat="server"  CssClass="add floatR" Visible="false" Text="Add Report" 
            onclick="lnkBAddReport_Click"></asp:LinkButton></div>
    <div class="dataList">
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <div class="dgContainer2">
            <asp:Repeater ID="rpReport" runat="server" 
                onitemdatabound="rpReport_ItemDataBound">
                <ItemTemplate>
                     <li>  
                     <asp:Label ID="lblReportCategory" runat="server" CssClass="SideBarTitles" Text='<%#Eval("ReportTypeText")%>' />   
                     <table class="DatagridStyle table table-hover">
                        <thead>
                        <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                        </thead>

                        <tbody>
                            <tr>
                 <%--               
                                <td class="wReportLink">
                                    <asp:LinkButton cssClass="reportNames" ID="lnkReportLink" runat="server"
                                        Text='<%# Eval("ReportName") %>' CommandArgument='<%# Eval("ReportID") %>' 
                                        OnClientClick="NewWindow()"
                                        OnClick="lnkbHyperlink_Click" />

                                </td>--%>



                                       
                                <td class="wReportLink">
                                    <asp:LinkButton cssClass="reportNames" ID="LinkButton1" runat="server"
                                        Text='<%# Eval("ReportName") %>' CommandArgument='<%# Eval("ReportID") %>' 
                                        OnClick="lnkbHyperlink_Click" />

                                </td>


                                <td class="wReportDescription"><asp:Label ID="lblReportDescription" runat="server" Text='<%#Eval("ReportDescription")%>' /></td>  
                                <td><asp:LinkButton  ID="lnkbEdit" CssClass="edit" runat="server" Text="Edit" Visible="false" CommandArgument='<%# Eval("ReportID") %>' OnClick="lnkbEdit_Click" /></td>                              
                            </tr>
                        </tbody>
                     
                     
                     </table>
                                       
                                                 
                            <asp:Label ID="lblReportID" runat="server" Text='<%#Eval("ReportID")%>' Visible="false" />                                          
                            <asp:Label ID="lblReportCat" runat="server" Text='<%#Eval("ReportCategory")%>' Visible="false" />                                          
                                                        
                            
                            
                     </li>                     
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
</asp:Panel>