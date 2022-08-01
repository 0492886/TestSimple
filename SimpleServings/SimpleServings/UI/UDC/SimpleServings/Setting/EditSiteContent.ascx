<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditSiteContent.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Setting.EditSiteContent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="cc2" %>--%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%--CKEDITOR--%>
<script type="text/javascript" src="../../UI/assets/plugins/ckeditor/ckeditor.js"></script>
<script type="text/javascript" src="../../UI/assets/plugins/ckeditor/adapters/jquery.js"></script>
<script type="text/javascript" src="../../UI/assets/plugins/ckeditor/config.js"></script>

<%--Bootstrap--%>
<script type="text/javascript" src="../../UI/assets/plugins/bootstrap/js/bootstrap.min.js"></script>
<%--<link rel="stylesheet" type="text/css" href="../../UI/assets/plugins/bootstrap/css/bootstrap.min.css" media="screen" />--%>

<%--custom jscript--%>
<%--<script type="text/javascript" src="../../UI/assets/plugins/ckeditor/custom.js"></script>--%>
<script type="text/javascript" src="../../UI/js/custom2.js"></script>

<%--custom css--%>
<link rel="stylesheet" type="text/css" href="../../UI/css/screen_styles2.css" media="screen" />
<link rel="stylesheet" type="text/css" href="../../UI/css/contentEdit.css" media="screen" />

<script type="text/javascript">
    $(document).ready(function () { Init(); });
</script>

<span class="hidden_msg"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></span>

<asp:Panel ID="pnPage"  CssClass="contentBox" runat="server">

    <div class="title2"><span class="h2Size">Content Management</span>
        <ul class="floatR">
                <%--<li><asp:LinkButton CssClass="edit floatR" ID="lnkBtnReoderCode" runat="server">Reorder Code Value</asp:LinkButton></li>--%>
                <li><asp:LinkButton CssClass="edit floatR" ID="lnkFeaturedRecipe" runat="server" CommandName="FeaturedRecipe" OnClientClick="return fnOnClick(this);" >Edit Featured Recipe</asp:LinkButton></li>
                <li><asp:LinkButton  ID="lnkWelcomeMessage" runat="server" CssClass="edit floatR" CommandName="WelcomeMessage" OnClientClick="return fnOnClick(this);" >Edit Welcome Message</asp:LinkButton></li>
                <li><asp:LinkButton CssClass="edit floatR" ID="lnkNutritionalMessage" runat="server" CommandName="NutritionalMessage" OnClientClick="return fnOnClick(this);" >Edit Nutritional Message</asp:LinkButton></li>

                <%--insert back button here ?--%>
                <li><asp:Button ID="Button2" runat="server" CommandName="FeaturedRecipe" OnClick="lkBtn_Click" CssClass="btn1 floatR" style="display: none; "/> </li>
                <li><asp:Button ID="Button3" runat="server" CommandName="WelcomeMessage" OnClick="lkBtn_Click" CssClass="btn1 floatR" style="display: none;"/> </li>
                <li><asp:Button ID="Button4" runat="server" CommandName="NutritionalMessage" OnClick="lkBtn_Click" CssClass="btn1 floatR" style="display: none;"/> </li>            
            </ul>
     </div>

    <asp:Panel ID="pnWelcomeMessage" runat="server" Visible="false">
        <div class="dataList">
            <div class="dataRow w500">
                <div class="dataLabel">Change Welcome Image:<asp:Label ID="lblWelcomeImage" CssClass="floatR" runat="server" /></div>
                <div class="dataInput">
                    <asp:FileUpload ID="fuWelcomeImage" runat="server" CssClass="fileupload" Width="500px" onchange="fnOnChange(this);"
                        ToolTip="upload welcome image" Style="visibility: visible;" placeholder="upload image file" />
                </div>
            </div>
            <div class="dataRow w760">
                <div class="dataLabel">Change Welcome Message:</div>
                <div class="dataInput">
                    <asp:HiddenField ID="hdnWelcomeMessage" runat="server" />
                    <asp:CheckBox ID="cbWelcomeMessage" runat="server" Text="Change Content" Checked="true" AutoPostBack="false" onchange="fnOnChange(this);" />  <%--OnCheckedChanged="CheckedChanged" --%>
                    <br />
                    <asp:TextBox ID="txtWelcomeMessage" runat="server" style="min-width:500px; min-height: 250px; resize: both;" Width="700px" TextMode="MultiLine" placeholder="Enter welcome text..." />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="* HTML Tags Not Allowed" ControlToValidate="txtWelcomeMessage" ClientValidationFunction="Validate"
                      OnServerValidate="CustomValidator1_ServerValidate" />
                    <%--#ctl00$containerhome$ctl00$ckeWelcomeMessage--%>
                </div>
            </div>
            <div class="dataRow w760">
                <div class="dataLabel"></div>
                <div class="dataInput">
                    <asp:Button ID="btnSubmit2" Text="Submit" OnClientClick="return fnMsgUpdate(this);" OnClick="btnSubmit_Click" runat="server" CssClass="btn floatR" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnFeaturedRecipe" runat="server" Visible="false">
        <div class="dataList">
            <div class="dataRow w500">
                <div class="dataLabel">Change Recipe:</div>
                <div class="dataInput">
                    <asp:DropDownList ID="ddlRecipe" runat="server" OnDataBound="ddlRecipe_DataBound" Width="500px" Style="margin-bottom: 9px;" />
                </div>
            </div>
            <div class="dataRow w500">
                <div class="dataLabel">Change Recipe Image:<asp:Label ID="lblRecipeImage" CssClass="floatR" runat="server"/></div>
                <div class="dataInput" style="vertical-align: top;">
                    <asp:FileUpload ID="fuRecipeImage" runat="server" CssClass="fileupload" Width="500px" onchange="fnOnChange(this);"
                        ToolTip="upload featured recipe image" Style="visibility: visible;" placeholder="upload image file" />
                    <asp:Image ID="imgFeaturedRecipe" runat="server" CssClass="floatR" Width="50px" Visible="false" />
                </div>
            </div>
            <div class="dataRow w500">
                <div class="dataLabel">Change Print File:<asp:Label ID="lblRecipePrintFile" CssClass="floatR" runat="server" /></div>
                <div class="dataInput">
                    <asp:FileUpload ID="fuRecipePrintFile" runat="server" CssClass="fileupload" Width="500px" onchange="fnOnChange(this);"
                        ToolTip="upload featured recipe print file" Style="visibility: visible;" placeholder="upload print file" />
                </div>
            </div>
            <div class="dataRow w760">
                <div class="dataLabel"></div>
                <div class="dataInput">
                    <asp:Button ID="btnSubmit" Text="Submit" OnClientClick="return confirm('Click ok to submit changes');" OnClick="btnSubmit_Click" runat="server" CssClass="btn floatR" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnNutritionalMessage" runat="server" Visible="false">
        <div class="dataList">
         <div class="dataRow w500">
             <div class="dataLabel">Change Title:</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtNutritionalMessage" CssClass="textbox2" Width="500px" runat="server" ToolTip="enter nutritional message title" 
                        Style="border: 1px solid lightgrey; visibility: visible;" placeholder="Enter Title..." />
                </div>
         </div>
            <div class="dataRow w500">
             <div class="dataLabel">Change Print File:<asp:Label ID="lblMsgFile" CssClass="floatR" runat="server" /></div>
                <div class="dataInput">
                    <asp:FileUpload ID="fuMessage" runat="server" CssClass="fileupload" Width="500px" onchange="fnOnChange(this);" 
                        ToolTip="upload nutritional message file" Style="visibility: visible;" />
                </div>
         </div>
            <div class="dataRow w760">
             <div class="dataLabel">Change Nutritional Message:</div>
                <div class="dataInput">
                    <asp:HiddenField ID="hdnNutritionalMessage" runat="server" />
                    <asp:CheckBox Text="Change Content" ID="cbNutritionalMessage" runat="server" Checked="true" AutoPostBack="false" onchange="fnOnChange(this);" /> <%--OnCheckedChanged="CheckedChanged" --%>
                    <CKEditor:CKEditorControl ID="ckeNutritionalMessage" runat="server" ResizeMinWidth="500" Width="700" HtmlEncodeOutput="true" />
                    <%--<cc2:FreeTextBox runat="server" EnableHtmlMode="true" EnableToolbars="true" ID="ftbNutritionalMessage"  Visible="false" />--%>
                </div>
         </div>
        <div class="dataRow w760">
            <div class="dataLabel"></div>
            <div class="dataInput">
            <asp:Button ID="btnSubmit1" Text="Submit" OnClientClick="return fnMsgUpdate(this);" OnClick="btnSubmit_Click" runat="server" CssClass="btn floatR" />
            </div>
        </div>
        </div>
    </asp:Panel>

</asp:Panel>

