<%@ Register TagPrefix="uc1" TagName="navigationbar" Src="../UDC/Navigation/navigationbar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="../UDC/Navigation/header.ascx" %>
<%@ Page language="c#" Inherits="SimpleServings.UI.Page.Home" Codebehind="homeold.aspx.cs" %>

<%@ Register Src="../UDC/SimpleServings/Staff/AddEditAccountInfo.ascx" TagName="AddEditAccountInfo" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
      <head>
          <title>Simple Servings</title>
          <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
          
          <link href="../CSS/v2main.css" type="text/css" rel="stylesheet" />
          <link rel="stylesheet" type="text/css" href="../CSS/sdmenu.css" />
	      
	      <script type="text/javascript">
	            window.onload = loaderFunct; 
	            function loaderFunct(){
	                loginTxt();
	                myZoneMenu();
	            };
	      </script>
          
          <script type="text/javascript">
              function stopError() {
              return true;
              }
              window.onerror = stopError;
          </script>
          
          
          
          <script type="text/javascript" src="../../UI/Javascript/contentslider.js"></script>
	      <script type="text/javascript" src="../../UI/Javascript/sdmenu.js"></script>
	      <script type="text/javascript" src="../../UI/Javascript/customScripts.js"></script>
      </head>

      <body id="homepage">
      
        <form id="form" runat="server" method="post">
            <uc1:navigationbar id="Navigationbar1" runat="server" />
            <uc1:header id="Header1" runat="server" />
            
            <div class="search_bar">
                <div class="search_bar">
                    <div id="dvLogIn" class="loginBox" runat="server">
                        <span class="inputFields">
                            <asp:textbox id="txtUserName" runat="server" Text="Username" />
                            <input type="text" id="txtPasswordF" value="Password" style="display:none;" />
                            <asp:textbox id="txtPassword" runat="server" TextMode="Password" />
                        </span>
                        
                        <asp:Button  CssClass="btnStyle" style="width:60px;" id="btnLogin" runat="server" Text="Login" onClick="btnLogin_Click" />
                        <br />                 
                        <asp:LinkButton ID="lnkPassword" runat="server" OnClick="lnkPassword_Click">Forgot your password?</asp:LinkButton>
                    </div>
                </div>
                    
                    
                <div class="search_bar" id="dvLoggedIn" runat="server">
                    <div class="search_input">
                        <div class="radioBtnsSeach">
                            <asp:RadioButton id="rbSSN" runat="server" GroupName="SearchBy"  />
                            <label>ssn</label>
                             <asp:RadioButton id="rbCaseNumber" runat="server" GroupName="SearchBy" />
	                        <label>Case #</label>
	                        
                            <asp:RadioButton id="rbFHNumber" runat="server" GroupName="SearchBy" />
	                        <label>F.H #</label>
                            <asp:RadioButton id="rbName" runat="server" GroupName="SearchBy" Checked="true"  />
                            <label>name</label>
                        </div> <%-- end radioBtnsSeach--%>
                        
                        <div class="searchBoxnBtn">
                            <asp:TextBox id="txtSearchKey" runat="server" CssClass="inputSearch" onfocus="ClearTxt()" onblur="RefillTxt()" Text="search"  />
                            <asp:Button CssClass="search_btn" Text="" id="btnSearch" runat="server" onclick="btnSearch_Click" />
                        </div>
                        
                        <script type="text/javascript">
                             function ClearTxt(){
                               if(document.getElementById('txtSearchKey').value =='search'){
                                document.getElementById('txtSearchKey').value ="";
                               }
                              }
                              
                              function RefillTxt(){
                                if(document.getElementById('txtSearchKey').value === ""){
                                  document.getElementById('txtSearchKey').value ='search';
                                }
                              }  
                        </script>
                        
                        <span class="logout">
                            <asp:Button id="btnLogout" runat="server" Text="Logout" onclick="btnLogout_Click" CausesValidation="False" />
                        </span>
                    </div><%-- end search_input--%>
                 </div><%-- end search_bar--%>
            </div>
    
            
            <div id="v2main">
                <div class="main_body">
                              
                    <!--Left Column Section--> 
                    <div class="ContentWrap" id="DIV1" onclick="return DIV1_onclick()"> 

                        <div class="leftColumn">
                            <div class="sliderClass">
                                <div id="slider1" class="sliderwrapper">
                                    <asp:PlaceHolder id="plAnnouncement" runat="server"></asp:PlaceHolder>
                                </div>
                                
                                <div class="pagination p1" id="paginate-slider1">
                                </div>
                                
                                <script type="text/javascript">
                                    featuredcontentslider.init({
                                        id: "slider1",  //id of main slider DIV
                                        contentsource: ["inline", ""],  //Valid values: ["inline", ""] or ["ajax", "path_to_file"]
                                        toc: "#increment",  //Valid values: "#increment", "markup", ["label1", "label2", etc]
                                        nextprev: [" ", " "],  //labels for "prev" and "next" links. Set to "" to hide.
                                        enablefade: [false, 0.2],  //[true/false, fadedegree]
                                        autorotate: [true, 3000],  //[true/false, pausetime]
                                        onChange: function(previndex, curindex){  //event handler fired whenever script changes slide
                                            //previndex holds index of last slide viewed b4 current (1=1st slide, 2nd=2nd etc)
                                            //curindex holds index of currently shown slide (1=1st slide, 2nd=2nd etc)
                                        }
                                    })
                                    
                                    function DIV1_onclick() {
                                    }

                                </script>
                                <!--webbot bot="HTMLMarkup" endspan i-checksum="14085" -->
                            </div><%-- end sliderClass--%>
                        
                            
                            
                            <!--Accordian Section-->     
                            <div class="sdmenuContainer">
                                <div id="my_menu" class="sdmenu">      
                                </div>
                           </div>       

                        </div> <%-- end leftColumn--%>
                        
                        
                        <div class="rightColumn">
                            <div class="box_1">
                                <h2>Welcome to Simple Servings</h2>
                                <img alt="" src="../Imgs/homeSideIMG.jpg" width="70px" style="position:relative;top:4px;"/>
                                <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. Sed eleifend nonummy diam. Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. Duis tincidunt lectus quis dui viverra vestibulum. Suspendisse vulputate aliquam dui.
                                </p>
                            </div>
                        </div> <%-- end rightColumn--%>
                        
                    </div> <%--end ContentWrap --%>
                  
                    <div class="easyClear" ></div>
                    
                    
                            
                </div><%--end main_body --%>
            </div> <%--end v2main--%>
           
            <div class="preFooter" >
                <div style="background-color:#fff">
                    <h2>We invite you to log in and experience the power of Simple Servings!</h2>
                    <p> 
                   Lorem ipsum dolor sit amet, consectetuer adipiscing elit. 
                   Nam cursus. Morbi ut mi. 
                   Nullam enim leo, egestas id, condimentum at, laoreet mattis, massa. 
                   Sed eleifend nonummy diam. 
                   Praesent mauris ante, elementum et, bibendum at, posuere sit amet, nibh. 
                   Duis tincidunt lectus quis dui viverra vestibulum. 
                   Suspendisse vulputate aliquam dui. Nulla elementum dui ut augue. 
                   Aliquam vehicula mi at mauris. 
                   Maecenas placerat, nisl at consequat rhoncus, sem nunc gravida justo, quis eleifend arcu velit quis lacus. 
                   Morbi magna magna, tincidunt a, mattis non, imperdiet vitae, tellus. 
                   Sed odio est, auctor ac, sollicitudin in, consequat vitae, orci. Fusce id felis. 
                   Vivamus sollicitudin metus eget eros.
                    
                    </p>
                    <br />                
                </div>
                
                
                <br class="easyClear" />
            </div> <%--end preFooter--%>
              
                
                    <p> Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nam cursus. Morbi ut mi. </p>
              
                
        </form>
    </body>
</html>

 
