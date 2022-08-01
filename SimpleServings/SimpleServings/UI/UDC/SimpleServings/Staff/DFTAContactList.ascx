<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DFTAContactList.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Staff.DFTAContactList" %>

<span>
    <asp:Panel ID="pnlContactAddEdit" runat="server">

        <div class="dataRow smlInputs mr20">
            <div class="dataLabel">First Name :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtContactFName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactFName" ErrorMessage="* required field" ControlToValidate="txtContactFName" runat="server" ValidationGroup="AddContactGroup" />
            </div>
        </div>
        <div class="dataRow smlInputs mr20">
            <div class="dataLabel">Last Name :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtContactLName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactLName" ErrorMessage="* required field" ControlToValidate="txtContactLName" runat="server" ValidationGroup="AddContactGroup" />
            </div>
        </div>
        <div class="dataRow smlInputs mr20">
            <div class="dataLabel">Title :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtContactTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactTitle" ErrorMessage="* required field" ControlToValidate="txtContactTitle" runat="server" ValidationGroup="AddContactGroup" />
            </div>
        </div>
        <div class="dataRow w200 mr20">
            <div class="dataLabel">Email :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtContactEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContactEmail" ErrorMessage="* required field" ControlToValidate="txtContactEmail" runat="server" ValidationGroup="AddContactGroup" />
                <br />
                <asp:RegularExpressionValidator ID="revContactEmail" runat="server" ControlToValidate="txtContactEmail" ErrorMessage="* invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="AddContactGroup" />
            </div>
        </div>
        <div class="dataRow smlInputs mr20">
            <div class="dataLabel">Work Phone :</div>
            <div class="dataInput">
                <asp:TextBox ID="txtContactWorkPhone" runat="server"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvContactWorkPhone" ErrorMessage="* required field" ControlToValidate="txtContactWorkPhone" runat="server" ValidationGroup="AddContactGroup" /> --%>
            </div>
        </div>
        <div class="dataRow floatL">
            <div class="dataLabel">&emsp;</div>
            <div class="dataInput">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="floatR add mr30" ValidationGroup="AddContactGroup" />
            </div>
        </div>

    </asp:Panel>

    <div class="clearfix"></div>

    <asp:HiddenField ID="hiddenOrder" runat="server" Value="" />
    <%--<div class="dataList">--%>
    <div class="dgContainer">
        <%--menuGridStyle pure-table pure-table-bordered--%>
        <%--DatagridStyle table table-hover--%>
        <%--tableStyle table table-hover--%>
        <asp:GridView
            CssClass="tableStyle"
            ID="gvStaffContacts"
            runat="server"
            AutoGenerateColumns="False" AllowSorting="False"
            OnRowEditing="gvStaffContacts_RowEditing"
            OnRowCancelingEdit="gvStaffContacts_RowCancelingEdit"
            OnRowDeleting="gvStaffContacts_RowDeleting"
            OnRowUpdating="gvStaffContacts_RowUpdating"
            OnRowDataBound="gvStaffContacts_RowDataBound"
            DataKeyNames="ContactID">
            <%--onpageindexchanging="gvStaffContacts_PageIndexChanging" onsorting="gvStaffContacts_Sorting" --%>
            <%-- <AlternatingRowStyle CssClass="DatagridStyleAltRow" />--%>
            <%--<PagerSettings Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" FirstPageText="First" LastPageText="Last" />   --%>

            <Columns>

                <asp:TemplateField Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblStaffID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "staffID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" SortExpression="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblContactName" runat="server" Text='<%# string.Format("{0} {1}", DataBinder.Eval(Container.DataItem, "FirstName"), DataBinder.Eval(Container.DataItem, "LastName"))  %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="dataRow w200 mr30">
                            <div class="dataInput">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtEditFName" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>' />
                                            <asp:RequiredFieldValidator ID="rfvEditFName" runat="server" ControlToValidate="txtEditFName" ErrorMessage="* required field" ValidationGroup="EditContactGroup" />
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEditLName" Width="100px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>' />
                                            <asp:RequiredFieldValidator ID="rfvEditLName" runat="server" ControlToValidate="txtEditLName" ErrorMessage="* required field" ValidationGroup="EditContactGroup" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Center" SortExpression="Title">
                    <ItemTemplate>
                        &nbsp;&nbsp;<asp:Label ID="lblTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="dataRow w200 mr30">
                            <div class="dataInput">
                                <asp:TextBox ID="txtEditTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEditTitle" runat="server" ControlToValidate="txtEditTitle" ErrorMessage="* required field" ValidationGroup="EditContactGroup" />
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" SortExpression="Email">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="dataRow mr30">
                            <div class="dataInput">
                                <asp:TextBox ID="txtEditEmail" runat="server" Width="150px" Style="margin-top: 15px;" Text='<%# DataBinder.Eval(Container.DataItem, "Email") %>'>
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEditEmail" runat="server" ControlToValidate="txtEditEmail" ErrorMessage="* required field" ValidationGroup="EditContactGroup" />
                                <asp:RegularExpressionValidator ID="revEditEmail" runat="server" ControlToValidate="txtEditEmail" ErrorMessage="* invalid email format"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="EditContactGroup" />
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Work Phone" HeaderStyle-HorizontalAlign="Center" SortExpression="WorkPhone" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblWorkPhone" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "WorkPhone") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <div class="dataRow smlInputs mr30">
                            <div class="dataInput">
                                <asp:TextBox ID="txtEditWorkPhone" runat="server" Style="margin-bottom: 15px;" Text='<%# DataBinder.Eval(Container.DataItem, "WorkPhone") %>'>
                                </asp:TextBox>
                            </div>
                        </div>
                    </EditItemTemplate>
                </asp:TemplateField>

                <%--<asp:TemplateField HeaderText="Created On" SortExpression="CreatedOn">
     <ItemTemplate>
            <asp:Label ID="lblCreatedOn"  runat="server" Width="80" Text='<%# DataBinder.Eval(Container.DataItem, "CreatedOn") %>' ></asp:Label>
     </ItemTemplate>
    </asp:TemplateField>--%>

                <%--  <asp:HyperLinkField 
        DataNavigateUrlFields="RecipeID" 
        ControlStyle-CssClass="" 
        DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID={0}"
        Text="View" />
    <asp:HyperLinkField 
        DataNavigateUrlFields="RecipeID" 
        ControlStyle-CssClass="" 
        DataNavigateUrlFormatString="~/UI/Page/SimpleServings/Recipe/EditRecipe.aspx?RecipeID={0}"
        Text="Edit" />
                --%>
                <asp:TemplateField ItemStyle-CssClass="bgTd" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Edit" CommandName="Edit">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkBtnSave" runat="server" Text="Save" CommandName="Update" ValidationGroup="EditContactGroup">
                        </asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-CssClass="bgTd" Visible="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkBtnRemove" runat="server" Text="Remove" CommandName="Delete" CommandArgument='<% DataBinder.Eval(Container.DataItem, "ContactID") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="lnkBtnCancel" runat="server" Text="Cancel" CommandName="Cancel">
                        </asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    </div>
    <asp:LinkButton ID="lnkBtnSaveOrder" CssClass="floatR check mr30" runat="server" OnClick="lnkBtnSaveOrder_Click">
                    Save Order
    </asp:LinkButton>

    <br />
    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
</span>