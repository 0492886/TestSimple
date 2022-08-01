<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResourceList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Resource.ResourceList" %>
     

<asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>

<asp:Panel ID="pnPage" CssClass="dgContainer" runat="server"> 

<asp:GridView runat="server" CssClass="DatagridStyle table table-hover"  ID="gvResources" AutoGenerateColumns="False" AllowSorting="true" PageSize="50" OnSorting="gvResources_Sorting">
    <%--onpageindexchanging="gvRecipes_PageIndexChanging" onsorting="gvRecipes_Sorting"--%> 

    <AlternatingRowStyle CssClass="DatagridStyleAltRow" />
    <PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" FirstPageText="First" LastPageText="Last" />             
 
    <Columns>
     <asp:TemplateField Visible="false">
     <ItemTemplate>
                <asp:Label ID="lblResourceID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField HeaderText="Resource" SortExpression="ResourceText">
     <ItemTemplate>
            <%--<asp:Label ID="lblResource" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceText") %>' ></asp:Label>--%>
         <a href='<%# ResolveUrl(DataBinder.Eval(Container.DataItem, "ResourceUrl").ToString()) %>' target="_blank" class="datalista"><%# DataBinder.Eval(Container.DataItem, "ResourceText") %></a>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Resource Type" SortExpression="ResourceTypeText">
     <ItemTemplate>
            <asp:Label ID="lblResourceType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceTypeText") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

     <asp:TemplateField>
     <ItemTemplate>
            <asp:Label ID="lblResourceUrl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ResourceUrl") %> '  Visible="<%# CanDelete %>" ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField>
     <ItemTemplate>
         <asp:LinkButton ID="lnkBtnRemove" runat="server" CssClass="floatR" Text="Remove" OnClick="lnkBtnRemove_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' Visible="<%# CanDelete %>"
         OnClientClick="return confirm('Are you sure you want to remove this resource?');"></asp:LinkButton>
     </ItemTemplate>
    </asp:TemplateField>


<%--     <asp:TemplateField>
     <ItemTemplate>
         <a href='<%# ResolveUrl(DataBinder.Eval(Container.DataItem, "ResourceUrl").ToString()) %>' target="_blank" class="datalista"><%# DataBinder.Eval(Container.DataItem, "ResourceText") %></a>
     </ItemTemplate>
    </asp:TemplateField>--%>





    </Columns>

</asp:GridView>



</asp:Panel>




<asp:DataList ID="dlResources" runat="server" OnDeleteCommand="dlResources_DeleteCommand" style="width: 100%; padding-top: 10em;" Visible="false" >
            <HeaderTemplate>
                <table >
            </HeaderTemplate>
            <ItemTemplate>
                <%--<tr>
                    <td colspan="2">
                        <asp:Label ID="lblResourceCategory" runat="server" CssClass="SideBarTitles" Text='<%#Eval("ResourceTypeText")%>' />
                    </td>
                </tr>--%>
                <tr>
                    <td style="width:95%">
                        <a href='<%# ResolveUrl(DataBinder.Eval(Container.DataItem, "ResourceUrl").ToString()) %>' target="_blank" class="datalista"><%# DataBinder.Eval(Container.DataItem, "ResourceText") %></a>
                    </td>

                    <td style="width:5%">
                        <asp:LinkButton ID="lnkBtnRemove" runat="server" CssClass="floatR" Text="Remove" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' Visible="<%# CanDelete %>"
                            OnClientClick="return confirm('Are you sure you want to remove this resource?');"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <tr>
                    <td colspan="2">
                        <hr class="datalisthr" />
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:DataList>