<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StaffGrid.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.StaffGrid" %>

	  
<div class="section"> 
<div class="SectionTitle">
    <asp:Label CssClass="amountFound spaceBtm" ID="lblMsg" runat="server" />
</div>
   
<div class="gridViewWrapper dgContainer">
    <asp:GridView ID="gvStaffList" CssClass="DatagridStyle table table-hover" GridLines="None" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize='<%# Convert.ToInt32(ConfigurationManager.AppSettings["GridPageSize"]) %>' OnPageIndexChanging="gvStaffList_PageIndexChanging">
        <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
        <PagerStyle  CssClass="DatagridStylePgRow" />
     
        <Columns>
            <asp:TemplateField HeaderText="Select" Visible="False" >
                <ItemTemplate>
                    <asp:RadioButton ID="rbSelect" runat="server" GroupName="SelectStaff" OnCheckedChanged="rbSelect_CheckedChanged"  AutoPostBack="true"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="StaffID" HeaderText="Staff ID" />
            <asp:BoundField DataField="FullName" HeaderText="Staff Name" />
            <asp:BoundField DataField="SupervisorName" HeaderText="Supervisor" />
            
            <asp:BoundField DataField="UserGroupText" HeaderText="User Group" />
            <asp:BoundField DataField="WorkPhone" HeaderText="Work Phone" />
            <asp:BoundField DataField="CreatedOn" HeaderText="Created On" />
            <asp:HyperLinkField HeaderText="Details" Text="View Details" DataNavigateUrlFormatString="~/UI/Page/MyZone.aspx?Control=MyProfile&StaffID={0}"  DataNavigateUrlFields="StaffID" />
        </Columns>
    </asp:GridView>
</div>
</div>
 
<div class="clearfix"></div>   