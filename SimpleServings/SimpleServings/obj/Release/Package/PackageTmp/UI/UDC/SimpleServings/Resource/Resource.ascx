<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Resource.ascx.cs" Inherits="SimpleServings.UI.UDC.SimpleServings.Resource.Resource" %>


<%@ Register Src="ResourceList.ascx" TagName="ResourceList" TagPrefix="uc1" %>


<asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
<asp:HiddenField ID="hidden" runat="server" />

<asp:Panel CssClass="contentBox" ID="pnPage" runat="server">


    <h1 class="titanictitle">Resources</h1>


    <br />
<%--    <asp:Panel runat="server" ID="pnlInfo" CssClass="dgContainer" style="margin: 5px; background-color:antiquewhite; color:#c10e0e; font-style:italic; text-shadow: 1px 1px #fff;">
        <div>
        <h4>To help with the required quarterly in-services, the DFTA Nutrition Department has created lesson plans and accompanying handouts for your use.
            <br />
            For each topic below, you will find a link to a PDF document, which includes an outline, to guide those who are leading the in-service, as well as a handout to distribute to each participant.
        </h4>
        </div>
     </asp:Panel>--%>

        <asp:Panel ID="pnManageResources" CssClass="dgContainer" runat="server" Visible="false" style="width:600px; margin-left:5px;">
        <h2 class="title2">Add Resource</h2>
        <div class="dataRow">
            <div class="dataRow w500">
                <div class="dataLabel">Title :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="dataRow w500">
            <div class="dataLabel">Type :</div>
            <div class="dataInput">
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>

            </div>
        </div>
        <div class="dataRow">
            <div class="dataRow w500">
                <asp:FileUpload ID="fileUpload" runat="server" OnDataBinding="fileUpload_DataBinding" />
                <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="fileUpload"
                    ErrorMessage="Only .doc, .docx, and .pdf files allowed"
                    ValidationExpression="(.*\.([Pp][Dd][Ff])|.*\.([Dd][Oo][Cc])|.*\.([Dd][Oo][Cc][Xx])$)"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="dataRow">

            <div class="dataRow floatL">

                <div class="dataInput">
                    <asp:Button ID="btnAdd" runat="server" style="float:left" CssClass="btn btn_save" Text="Add Resource" OnClick="btnAdd_Click" />
                </div>
            </div>


        </div>

    </asp:Panel>

<div class="clearfix"></div>




    <br />
    <br />
    <br />
     <div class="dataLabel"> Select Resource Type :</div>
              <asp:DropDownList ID="ddlTypeFilter" runat="server" AutoPostBack="true" 
                  OnSelectedIndexChanged="ddlTypeFilter_SelectedIndexChanged" ></asp:DropDownList>  
    <br />
    <br />
    <br />

    <div class="dataList">

        <uc1:ResourceList ID="ResourceList1" runat="server" />

    </div>


    <br />
    <br />
    <br />


<%--    <asp:Panel ID="pnManageResources" runat="server" Visible="false" style="margin-left:5px;">
        <h2 class="title2">Add Resource</h2>
        <div class="dataRow">
            <div class="dataRow w500">
                <div class="dataLabel">Title :</div>
                <div class="dataInput">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="dataRow w500">
            <div class="dataLabel">Type :</div>
            <div class="dataInput">
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>

            </div>
        </div>
        <div class="dataRow">
            <div class="dataRow w500">
                <asp:FileUpload ID="fileUpload" runat="server" OnDataBinding="fileUpload_DataBinding" />
                <asp:RegularExpressionValidator ID="rexp" runat="server" ControlToValidate="fileUpload"
                    ErrorMessage="Only .doc, .docx, and .pdf files allowed"
                    ValidationExpression="(.*\.([Pp][Dd][Ff])|.*\.([Dd][Oo][Cc])|.*\.([Dd][Oo][Cc][Xx])$)"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="dataRow">

            <div class="dataRow floatL">

                <div class="dataInput">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn_save" Text="Add Resource" OnClick="btnAdd_Click" />
                </div>
            </div>


        </div>

    </asp:Panel>--%>



    <div class="clearfix"></div>
</asp:Panel>




