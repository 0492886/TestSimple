<%@ Page language="c#" Inherits="SimpleServings.UI.Page.login" Codebehind="login.aspx.cs" ViewStateEncryptionMode="Auto" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->
<!--[if !IE]><!--> <html lang="en"> <!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
  <meta charset="utf-8" />
  <title>Login | Simple Servings</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport" />
  <meta content="" name="description" />
  <meta content="" name="author" />
  <!-- BEGIN GLOBAL MANDATORY STYLES -->
  <link href="../assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/css/style-metro.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/css/style.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/css/style-responsive.css" rel="stylesheet" type="text/css"/>
  <link href="../assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color"/>
  <link href="../assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>

  <!-- END GLOBAL MANDATORY STYLES -->
  <!-- BEGIN PAGE LEVEL STYLES -->
  <link href="../assets/css/pages/login.css" rel="stylesheet" type="text/css"/>
  <!-- END PAGE LEVEL STYLES -->
  <link rel="shortcut icon" href="favicon.ico" />

  	<script type="text/javascript" src="../../UI/Javascript/customScripts.js"></script>

		<!--<script type="text/javascript" src="../../UI/ieFixes/roundCorners2009.js"> </script>-->
		
		
		<script type="text/javascript">
	            // <![CDATA[
		    window.onload = loaderFunct;
		    function loaderFunct() {
		        //newSession();
		        loginTxt();
		    };
	            // ]]>
	    </script>
	      
		<script type="text/javascript">

		    function errorHandler() {
		        return true;
		    }
		    window.onerror = errorHandler; 
	        
		</script>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body id="login" class="login">   
  <!-- BEGIN LOGO -->
  <div class="logo">
    <img src="../assets/img/logo.png" alt="" /> 
  </div>
  <!-- END LOGO -->
  <!-- BEGIN LOGIN -->
  <div class="content">
  
  
<div class="brPanelCover"></div>

    <form  id="Form1" defaultbutton="btnLogin" runat="server" method="post" class="form-vertical login-form">
      <h3 class="form-title">Login to your account</h3>
      <div class="alert alert-error hide">
        <button class="close" data-dismiss="alert"></button>
        <span>Enter any username and passowrd.</span>
      </div>
      <div>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="msglabel" Text="The account has been locked." Visible="false" />
      </div>
      <div class="control-group">
        <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
        <label class="control-label visible-ie8 visible-ie9">Username</label>
        <div class="controls">
          <div class="input-icon left">
            <i class="icon-user"></i>
            <asp:textbox class="m-wrap placeholder-no-fix" placeholder="Username"  ID="txtUserName" runat="server"  />
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="msglabel" Text="Invalid Username" runat="server" ControlToValidate="txtUserName"
                                    ValidationExpression="^(\w+)$" Display="Dynamic" />--%>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserName"
        ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        Display = "Dynamic" ErrorMessage = "Invalid email - Please check your email address"/>
          </div>
        </div>
      </div>
      <div class="control-group">
        <label class="control-label visible-ie8 visible-ie9">Password</label>
        <div class="controls">
          <div class="input-icon left">
            <i class="icon-lock"></i>
            <input type="text" ID="txtPasswordF" class="m-wrap placeholder-no-fix" value="Password" style="display:none;" />
            <asp:textbox class="m-wrap placeholder-no-fix" placeholder="Password"  ID="txtPassword" runat="server" TextMode="Password" /> 
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="msglabel" Text="Invalid Password" Enabled="false" runat="server" ControlToValidate="txtPassword"
                                    ValidationExpression="^(\w+)$" Display="Dynamic" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="msglabel" Text="* Required" runat="server" ControlToValidate="txtPassword" Display="Dynamic"  />           
          </div>
        </div>
      </div>
      <div class="form-actions">       
         <asp:Button  CssClass="btn green pull-right" ID="btnLogin" disabled="true" runat="server" CommandName="Login" Text="Log in" OnClientClick="newSession();" onClick="btnLogin_Click" />             
      </div>
      <%--<div class="forget-password">
        <h4>Forgot your password ?</h4>
        <p>
           <asp:LinkButton ID="lnkPassword" runat="server" CommandName="ForgotPassword" OnClick="lnkPassword_Click" CausesValidation="false">Click here to recover!</asp:LinkButton>
        </p>
      </div>--%>
        You must click I Agree to log into Simple Servings 
    </form>
    <!-- END LOGIN FORM -->        
   

  </div>
  <!-- END LOGIN -->
  <!-- BEGIN COPYRIGHT -->
  <div class="copyright">
    2013 &copy; Simple Serving Admin Dashboard
  </div>

     <div class="copyright2">
        
        <div>
            <input type="checkbox" Id="LegalAgree" name="LegalAgree"/><label style="display:inline-block;font-size:18px;" for="LegalAgree">I Agree</label>
        
        </div> 
    The Simple Servings system and its contents may only be used for DFTA-funded programs and services. 
        You may not share your username and password with any other user. 
        Upon termination of your contract with DFTA, termination of your sub-contract with a DFTA-funded contractor or termination of your employment with DFTA, 
        you must cease use of the Simple Servings system, and may not access the system beyond the last date of your contract/employment. 
        Any contents derived from Simple Servings may not be used for non-DFTA funded entities, 
        and/or beyond the date of termination of your contract with DFTA, sub-contract with a DFTA-funded contractor, or employment with DFTA.
  </div>
  <!-- END COPYRIGHT -->
  <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
  <!-- BEGIN CORE PLUGINS -->
  <script src="../assets/plugins/jquery-1.8.3.min.js" type="text/javascript"></script> 
  <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->  
  <script src="../assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>    
  <script src="../assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
  <!--[if lt IE 9]>
  <script src="../assets/plugins/excanvas.js"></script>
  <script src="../assets/plugins/respond.js"></script> 
  <![endif]-->  
  <script src="../assets/plugins/breakpoints/breakpoints.js" type="text/javascript"></script>  
  <!-- IMPORTANT! jquery.slimscroll.min.js depends on jquery-ui-1.10.1.custom.min.js -->  
  <script src="../assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
  <script src="../assets/plugins/jquery.blockui.js" type="text/javascript"></script> 
  <script src="../assets/plugins/jquery.cookie.js" type="text/javascript"></script>
  <script src="../assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript" ></script>  
  <!-- END CORE PLUGINS -->
  <!-- BEGIN PAGE LEVEL PLUGINS -->
  
  <!-- END PAGE LEVEL PLUGINS -->
  <!-- BEGIN PAGE LEVEL SCRIPTS -->
  <script src="../assets/scripts/app.js" type="text/javascript"></script>
    
  <!-- END PAGE LEVEL SCRIPTS --> 
  <script>
      jQuery(document).ready(function () {
          App.init();
          $("#LegalAgree").click(function () {
              if($("#LegalAgree").prop("checked") == true)
                  $("#btnLogin").prop("disabled", false);
              else
                  $("#btnLogin").prop("disabled", true);
          });
          
      });
  </script>
  <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>