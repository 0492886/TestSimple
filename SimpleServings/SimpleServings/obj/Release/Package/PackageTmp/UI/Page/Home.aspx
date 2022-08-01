<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SimpleServings.UI.Page.HomeTest" %>
<%--ViewStateEncryptionMode="Auto"--%>

<%@ Register src="../UDC/Navigation/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../UDC/SimpleServings/Recipe/ViewRecipeIngredient.ascx" tagname="ViewRecipeIngredient" tagprefix="uc2" %>
<%--<%@ Register src="../UDC/SimpleServings/Recipe/RecipeSearchList.ascx" TagName="RecipeSearchList" TagPrefix="uc3" %>--%>
<%--<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>--%>

<!DOCTYPE HTML>
<html>
	<head id="Head1" runat="server">
        <meta http-equiv="X-UA-Compatible" content="IE=8;IE=Edge;chrome=1;" />
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<meta name="viewport" content="width=device-width, maximum-scale=1.0, minimum-scale=1.0, initial-scale=1.0" />
		<title>Simple Servings</title>
       
		<link rel="stylesheet" type="text/css" href="../../UI/css/screen_styles.css" />
		<link rel="stylesheet" type="text/css" href="../../UI/css/screen_styles2.css" />
        <%--<link rel="stylesheet" type="text/css" href="../../UI/css/style.css" />--%>
     <%--   <link href="" rel="shortcut icon"/>--%>
		<!--[if lt IE 9]>
		 <script src="../../UI/js/html5.js"></script>
		<![endif]-->
		<!--[if IE 7]>
		 <link rel="stylesheet" type="text/css" href="../../UI/css/IE7fix.css" />
		<![endif]-->
		<script src="../../UI/js/respond.src.js"></script> 
		

        <link href="../assets/fonts/font.css" rel="stylesheet" type="text/css" />
        	
      <%--  <script type="text/javascript"  src="../../UI/js/jquery-1.9.1.js"></script>--%>
        <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.js"></script>--%>
    <%--    <script type="text/javascript" src="<%# Page.ResolveUrl("http://code.jquery.com/jquery-latest.min.js") %>"></script>--%>

        <script type="text/javascript" src="../../UI/js/jquery-1.7.2.min.js"></script>
		<script type="text/javascript" src="../../UI/js/tinynav.min.js"></script>

		<!-- SimpleServings main JS and CSS files -->
		<script type="text/javascript" src="../../UI/js/jquery.fancybox.js?v=2.1.4"></script>
		<script type="text/javascript" src="../../UI/js/jquery.fancybox.start.js"></script>
		<link rel="stylesheet" type="text/css" href="../../UI/css/jquery.fancybox.css?v=2.1.4" media="screen" />
<style type="text/css">
    .fancybox-custom .fancybox-skin {box-shadow: 0 0 50px #222;}

    a {
        text-decoration:underline;
        /*font-style:italic;*/
        color:blue;
    }
</style>  
		  
		  
<%--		<script type="text/javascript" src="../../UI/js/menu.js"></script>--%>
		<script type="text/javascript" src="../../UI/js/tooltip.js"></script>
		<script type="text/javascript" src="../../UI/js/jquery.tipsy.js"></script>			
		<script type="text/javascript" src="../../UI/js/ticker00.js"></script>
		
		<!-- Loads transitions and animations --> 
		<script type="text/javascript" src="../../UI/js/ani/jquery-ui.js" ></script>
		<script type="text/javascript" src="../../UI/js/ani/modernizr.js" ></script>	 
		
		<!-- Initializing & Custom functions -->
		<script type="text/javascript" src="../../UI/js/functions.js"></script>         
        <%--<script type="text/javascript" src="../../UI/js/custom2.js"></script>--%>

		<!-- Tweets Script -->
		<script type="text/javascript" src="../../UI/js/jquery.tweet.js"></script> 


		<!-- CarouFredSell -->
    	<script type="text/javascript" src="../../UI/js/jquery.carouFredSel-6.1.0-packed.js"></script>
		<script type="text/javascript" src="../../UI/js/helper-plugins/jquery.mousewheel.min.js"></script>
		<script type="text/javascript" src="../../UI/js/helper-plugins/jquery.touchSwipe.min.js"></script>

		

	    <!-- CSS STYLE -->
		<link rel="stylesheet" type="text/css" href="../../UI/css/revstyle.css" media="screen" />	
		<!-- REVOLUTION BANNER CSS SETTINGS -->
		<link rel="stylesheet" type="text/css" href="../../UI/rs-plugin/css/settings.css" media="screen" />			
		<!-- jQuery KenBurn Slider  -->	
		<script type="text/javascript" src="../../UI/rs-plugin/js/jquery.themepunch.plugins.min.js"></script>			
		<script type="text/javascript" src="../../UI/rs-plugin/js/jquery.themepunch.revolution.min.js"></script>			
		<script type="text/javascript" src="../../UI/js/activate-revolution-slider.js"></script>	           
        
        <%--CKEDITOR--%>
        <%--<script type="text/javascript" src="../../UI/assets/plugins/ckeditor/ckeditor.js"></script>
        <script type="text/javascript" src="../../UI/assets/plugins/ckeditor/adapters/jquery.js"></script>
        <script type="text/javascript" src="../../UI/assets/plugins/ckeditor/config.js"></script>--%>

        <script type="text/javascript">
            //jQuery(document).ready(function () {
            //    Init();
            //});

        </script>

        </head>
	<body id="top" class="boxedbg"> 

<form id="form1" class="contactform" runat="server">
<div  class="boxedcontainer"> 

	
            <!-- Header -->    

    <uc1:header ID="header1" runat="server" />  
            <!-- header end -->
		
			<!--
			#################################
				- BANNER -
			#################################
			-->
           
			<div class="fullwidthbanner-container">				
					<div class="fullwidthbanner">  
                    <span class="dftaHome">

                        <%--<asp:Panel ID="pnlEditWM" runat="server" Style="display: none;">
                                <asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="fnEdit(this); freezeScreen(); return false;" CommandName="Edit"
                                    Style="background: url('../assets/icons/plus-16.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: block; color: white; font-weight:bold;">Edit</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton7" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                    Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: none; color: white; font-weight:bold;">Cancel</asp:LinkButton>
                        </asp:Panel>--%>
                        
                        <p class="dftaTitle">
                            <asp:Label ID="lblDFTATitle" Text="Welcome to Simple Servings, a web-based menu application for congregate and home-delivered meal providers. This application allows users to view healthy recipes and menus, as well as develop menus that meet city, state and federal nutrition requirements. Simple Servings is the primary vehicle for the menu submission and approval process between contractors and DFTA Nutritional Services. The Intuitive Selections feature simplifies the overall process by notifying meal providers when menus meet all nutrition requirements. Simple Servings has replaced the paper menu submission process and drastically reduces the time spent on menu development, submission and approval. We hope this application simplifies and improves the menu creation process for you." runat="server" />                    
<%--DFTA is pleased to announce the launch of Simple Servings, a web-based menu application for congregate and home-delivered meal providers. This application allows users to view healthy recipes and menus, as well as develop menus that meet city, state and federal nutrition requirements. Simple Servings is the primary vehicle for the menu submission and approval process between contractors and DFTA Nutritional Services. The Intuitive Selections feature simplifies the overall process by notifying meal providers when menus meet all nutrition requirements. Simple Servings replaces the current paper process and drastically reduces the time spent on menu development, submission and approval. We hope this application simplifies and improves the menu creation process for you.--%>
                        <%--Welcome to Simple Servings, a web-based menu application for congregate and home-delivered meal providers. This application allows users to view healthy recipes and menus, as well as develop menus that meet city, state and federal nutrition requirements. Simple Servings is the primary vehicle for the menu submission and approval process between contractors and DFTA Nutritional Services. The Intuitive Selections feature simplifies the overall process by notifying meal providers when menus meet all nutrition requirements. Simple Servings has replaced the paper menu submission process and drastically reduces the time spent on menu development, submission and approval. We hope this application simplifies and improves the menu creation process for you.--%>
                        </p>
                    </span>
                   
					</div><!-- End of  Banner -->	
                
			</div>
	  
		
<div style="background: #ff6634; height: 70px;   max-width: 100%;  position: relative;">
<h1 style="color: white; padding-left: 30px; padding-top: 20px">Welcome</h1>
</div>	


			<div class="box2b">
				<div class="shadow2">
				</div>
				<div class="squareb">
						<div class="row1">

                            <%--<asp:Panel ID="pnlEditRecipe" runat="server" Style="display: none;">
                                <asp:LinkButton ID="lnkBtnEdit" runat="server" OnClientClick="fnEdit(this); freezeScreen(); return false;" CommandName="Edit"
                                    Style="background: url('../assets/icons/plus-16.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: block; font-weight:bold;">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lnkBtnCancel" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                    Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: none; font-weight:bold;">Cancel</asp:LinkButton>
                            </asp:Panel>--%>
                            
                            <br />
                            <h2>Featured Recipe &nbsp; <%--<a href="../PDF/July2016FeaturedRecipe.pdf" target="_blank" class="orange">print featured recipe</a>--%>
                                <asp:HyperLink runat="server" ID="hlkFeaturedRecipe" Target="_blank" CssClass="orange" Text="print featured recipe" Visible="true" />
                            </h2>


                            <h4>
                                <%--<b>Chickpea Salad with Tomatoes and Parsley</b>--%>
                                <asp:Label ID="lblFeaturedRecipe" runat="server" Font-Bold="true" />

                                <%--<b>Tofu Broccoli Souffle</b>--%>
                                <%--<b>Pumpkin Harvest Beef Stew </b>--%>
                                <br />
                                <span style="font-size: 10px; font-weight: normal"><%--Contributed by UBA BEATRICE LEWIS NEIGHBORHOOD SC--%></span>
                                <br />
                                <br />
                                <%--<img src="../images/bigos8.jpg" style="width: 300px;" />--%>

                                <asp:Image ID="imgFeaturedRecipe" runat="server" Style="width: 300px;" />

                                <br />
                                <br />
<span style="font-weight:400; font-family: Verdana,sans-serif; font-size: 14px">Ingredients</span><br />

<uc2:ViewRecipeIngredient ID="ViewRecipeIngredient1" ShowArrow="false" runat="server" />

<%--<ul>
<li class="li1">1 #10 can chickpeas, drained and rinsed</li>
<li class="li1">4 cucumbers, sliced</li>
<li class="li1">3 red onions, sliced</li>
<li class="li1">6 tomatoes, chopped</li>
<li class="li1">1 1/2 bunches parsley, chopped </li>
<li class="li1">1 1/2 cup(s) balsamic vinegar </li>
<li class="li1">1 1/2 cup(s) red wine vinegar</li>
</ul>--%>

<%--<li class="li1">7 lb(s) beef-raw, top round, steak</li>
<li class="li1">1 lb(s) small red potatoes</li>
<li class="li1">4 oz(s) onions, chopped</li>
<li class="li1">1 lb(s) pumpkin, cubed, peeled</li>
<li class="li1">4 oz(s) acorn squash, cubed</li>
<li class="li1">13 oz(s) canned diced tomatoes, low sodium</li>
<li class="li1">2 qt(s) beef broth, low sodium</li>
<li class="li1">1/2 garlic clove, minced</li>
<li class="li1">1/2 bay leaf</li>
<li class="li1">1/4 tsp(s) chili pepper</li>
<li class="li1">1/2 tsp(s) black pepper, ground</li>
<li class="li1">dash of all spice, ground</li>
<li class="li1">2 tbsp(s) all purpose flour</li>
<li class="li1">2 tbsp(s) water</li>
<li class="li1">1 tbsp(s) canola oil</li>--%>
    
<%--<li class="li1">1/4 cup(s) tomato paste, canned</li>
<li class="li1">1 1/2 bay leaves</li>
<li class="li1">1 tbsp(s) ground black pepper</li>
<li class="li1">1 tsp(s) ground nutmeg</li>
<li class="li1">6 cup(s) water (add more as needed)</li>
<li class="li1">7 1/4 lb(s) pork loin - raw, bone and skin removed</li>
<li class="li1">1/4 cup(s) vegetable oil</li>--%>
    

</h4>
                                              
							<br/>
                            <asp:HyperLink runat="server" ID="hlkViewMore" Target="_self" CssClass="btn1" Text="view more" Visible="true" />
                           <%-- <a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=1407") %>' class="btn1">view more</a>--%>
                            <%--<a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=2164") %>' class="btn1">view more</a>--%>
							<%--<a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/ViewRecipe.aspx?RecipeID=1612") %>' class="btn1">view more</a>--%>
						</div>
						<div class="row2">

                                        <%--<asp:Panel ID="pnlEditMessage" runat="server" Style="display: none;">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="fnEdit(this); freezeScreen(); return false;" CommandName="Edit"
                                                Style="background: url('../assets/icons/plus-16.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: block; font-weight:bold;">Edit</asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                                Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; display: none; font-weight:bold;">Cancel</asp:LinkButton>
                                        </asp:Panel>--%>
										
                                    <div class="line4"></div>
										<div class="circleft">											
											<div class="circle3"><img src="../../UI/images/spacer.png" alt="" class="invizible">
                                                <%--<asp:Panel ID="pnlNurtionalMessage" runat="server" style="display: none;">
                                                    <asp:TextBox ID="txtNutritionalMessage" CssClass="textbox2" Width="150px" runat="server" ToolTip="enter nutritional message title" style="border: 1px solid lightgrey; visibility: visible;" placeholder="Enter Title..." />
                                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="fileupload" Width="250px" onchange="fnOnChange(this);" ToolTip="upload nutritional message file" Style="visibility: visible;" />
                                                    <asp:Button ID="btnMessage" runat="server" Text="Add" OnClick="btUpload_Click" CommandName="NutritionalMessage" Style="display: none;" />
                                                </asp:Panel>--%>
												
                                                <h2>A Message From Your Nutritionists&nbsp;<%-- <a href="../PDF/Homepage Content - Nutrition Message Summer 2016.pdf" target="_blank" class="orange">print message</a>--%>
                                                    <asp:HyperLink runat="server" ID="hlkNutritionalMessage" Target="_blank" CssClass="orange" Text="print message" Visible="true" />
                                                </h2><br/>
                                               
                                                <h4 style="-webkit-align-content: center; align-content: center">
                                                    <asp:Label ID="lblNutritionalMessage" runat="server" Font-Bold="true" />
                                                    <%--<b>Drink Water This Summer</b>--%>
                                                </h4>
                                                <br />
                                                <asp:Label ID="lblNutritionalMessageText" runat="server" />

                                                <%--<p>
                                                    Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer.
                                                </p>
                                                <br />
                                                <p>
                                                    Like vitamins and minerals, water is important for our health. Often though, its importance can be overlooked. Water is vital for survival, so be sure to drink up this summer.
                                                </p>
                                                <br />
                                                <p>
                                                    If you do not drink enough fluids, you can become dehydrated. Water is the ideal fluid to drink because it is naturally free of sugar and calories. 
                                                </p>
                                                <br />
                                                <p>
                                                    Think water is boring? Try these tips:
                                                    <ul>
                                                        <li class="li5">Flavor your water with fresh herbs, citrus, cucumber slices or berries</li>
                                                        <li class="li5">Drink seltzer</li>
                                                        <li class="li5">Add a small spash of 100% juice</li>
                                                    </ul>
                                                </p>--%>                                                

                                                <%--<h4 style="-webkit-align-content: center; align-content: center">
                                                    <b>Spring Clean Your Diet</b>
                                                </h4>
                                                <br />
                                                <p>
                                                    Many people use the spring season as a chance to clean. Why not expand your cleaning plans to include your eating habits as well?
                                                </p>
                                                <br />
                                                <h4><b>How to eat cleaner</b></h4>
                                                <br />
                                                <p>
                                                    <b>Limit added sugars:</b> Table sugar is not the only source of sugar in the diet. Avoid drinking sweetened beverages like soda, sugary teas, sports drinks, and punches. Also try eating less candy, cookies, cakes, pastries, and other sweet treats.
                                                </p>
                                                    <br />
                                                <p>    
                                                    <b>Avoid high sodium foods:</b> Eating too much sodium can increase blood pressure and lead to heart disease. To lower the amount of sodium you eat, avoid processed foods such as canned soups, salty snacks, and cold cuts. When shopping, choose products that are labeled “no added salt” or “low sodium.”
                                                </p>
                                                    <br />
                                                <p>
                                                    <b>Eat less saturated fat:</b> Fat is an important part of the diet, but eating too much saturated fat can be harmful. Animal products like beef, lamb, pork, poultry with skin, butter, cheese and 2% or whole milk contain saturated fat.
                                                </p>
                                                    <br />
                                                <p>
                                                    <b>Eat more fruits and vegetables:</b> Many Americans do not eat enough fruits and vegetables. Fruits and vegetables are naturally low in calories and provide fiber. They are also a wonderful source of many vitamins and minerals, which are needed to stay healthy.
                                                </p>--%>

                                                <%--<h4 style="-webkit-align-content: center; align-content: center">
                                                    <b><u>Add Bright Orange Vegetables to Your Plate</u></b><br />
                                                    Bright orange vegetables like pumpkin, butternut squash, sweet potatoes and carrots are packed with nutrients and fiber. 
                                                    They are a great source of vitamin A, which can help support your immune system this winter. 
                                                    Try throwing these vegetable into your favorite recipes. 
                                                    For example, this season’s feature recipe incorporates pumpkin into a beef stew. 
                                                    Have a sweet tooth? Try roasting these vegetables to bring out their natural sweetness.
                                                </h4>--%>
                                              
<br /><br />
                                                    <%-- 
  <table class="pure-table pure-table-bordered">
    <thead>
        <tr>
          
            <th>Bad Habits</th>
            <th>Good Habits</th>            
        </tr>
    </thead>
<tbody>
<tr><td>Drinking soda</td> 	<td>Drinking water or milk</td></tr>
<tr><td>Eating processed foods</td> 	<td>Eating fresh, whole foods that are minimally processed</td></tr>
<tr><td>Skipping breakfast</td> 	<td>Eating breakfast (try to include fiber, protein and whole grains)</td></tr>
<tr><td>Adding salt to cooked foods</td> 	<td>Adding other spices such as garlic or pepper to cooked foods</td></tr>
<tr><td>Eating foods that are high in cholesterol and unhealthy saturated and trans fats </td> 	<td>Eating healthy fats like those found in avocados and olive oil</td></tr>
<tr><td>Eating the same foods everyday</td> 	<td>Choosing a variety of healthy foods that color your plate</td></tr>
<tr><td>Skimping on fiber</td> 	<td>Eating fiber-rich foods such as whole grains, fruit, vegetables, nuts and seeds, and beans</td></tr>
</tbody>
</table>

                                                 
                                                 </h4>--%>
											</div>
										</div>
								

						</div>
                        <div class="clear"></div>
						
				</div>
			</div>
			

			
			
	<div class="shadow3"></div>
	<div class="page">
	
	<div class="title"><h2>Our latest Recipes &nbsp; | &nbsp; <span class="orange"><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx") %>' >View all recipes</a></span></h2></div>
	<div class="info"></div>
	<div class="clear"></div>
	
	
			<!-- resp-->
			<div class="page">
				<div class="list_carousel7 responsive" >
					<ul id="foo7">
						<li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/entreeCat.jpg" alt="Entree">
								<div class="thumbRollover"><a class="fancybox-effects-d" href="../../UI/images/thumbs/entreeCat.jpg" data-fancybox-group="gallery"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Entrees:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=23") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
						<li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/vegetarianCat.jpg" alt="Vegetarian">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/vegetarianCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Vegetarian:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=133") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
						<li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/grainsCat.jpg" alt="Grains">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/grainsCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Grains:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=45") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
						<li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/breakfastCat.jpg" alt="Breakfast">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/breakfastCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Breakfast:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=149") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>

                        <li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/vegetablesCat.jpg" alt="Vegetables">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/vegetablesCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Vegetables:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=25") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
                        
                        <li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/nondairyCat.jpg" alt="Non-dairy">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/nondairyCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Non-dairy:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=78") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
                        
                        <li>
							<div class="thumb">
								<img src="../../UI/images/thumbs/appetizerCat.jpg" alt="Appetizer">
								<div class="thumbRollover"><a class="fancybox-effects-d" data-fancybox-group="gallery" href="../../UI/images/thumbs/appetizerCat.jpg"><img src="../../UI/images/spacer.png" alt=""></a></div>
							</div>
							<br/><h5><span class="dark"><br/><b>Appetizer:</b><a href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx?TagID=24") %>' > view</a></span><br/><span class="light"></span></h5>
						</li>
					
					</ul>
					<div class="clearfix"></div>
				</div>
			</div>
			<!-- resp-->	
				<div class="line3"></div>
				<div class="clearfix"></div>
				

			<div class="box3">

						<div class="row1a">
							<span class="title2">Sample Menus</span><br/><br/>
						
                            <h4>
                            <ul>
                            <li class="li1"><a href="../PDF/Sample Spring Summer Congregate Breakfast Menu.pdf" target="_blank" class="orange">DFTA Sample Congregate Spring/Summer Breakfast Menu</a></li><br />
                            <li class="li1"><a href="../PDF/Sample Spring Summer Congregate Lunch Menu.pdf" target="_blank" class="orange">DFTA Sample Congregate Spring/Summer Lunch Menu</a></li><br />
                            </ul>  
                            </h4>
						</div><div class="line5"></div>
						
						<div class="row2a">
							<span class="title2">What's New</span><br/><br/>
							<h4>
                            <ul>
                            <li class="li1">New Spring/Summer menu templates now available.</li><br />
                            <li class="li1">Have you checked out the public recipes lately? New recipes are available!</li><br /> 
                            <li class="li1">Did you know you can use Simple Servings to print daily and monthly calendar menus? Visit the reports tab to print.</li><br /> 
                            <li class="li1">Need to contact a DFTA Nutritionist? Contact information available <a href="contact.aspx" target="_blank" class="orange">here</a>. </li><br />

                           </ul>  
                            </h4>
							<!--<div class="tweet"></div>-->

						</div><div class="line5"></div>
						
				
                        <div class="clear"></div>

			</div>

<br/>
<br/>

<!-- END OF PAGE Class-->
</div>
		
		
		<!-- FOOTER -->
		<footer>
			<div class="footerwrapper">
					<div class="fcol1">
							 <div class="ftitle">Recipes</div>
							 <ul class="footerlist">
								<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/AddRecipe.aspx") %>' >Add Recipe</a></li>
								<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Recipe/RecipeList.aspx") %>' >Recipe List</a></li>								
							 </ul>
					</div>
					<div class="footerbrake2"></div>
					<div class="fcol2">
							 <div class="ftitle">Providers</div>
							 <ul class="footerlist">
					<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Sponsor.aspx") %>' >Sponsors</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Contract.aspx") %>' >Contracts</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Supplier/Caterer.aspx") %>' >Caterers</a></li>
							 </ul>
					</div>
					<div class="footerbrake"></div>
					<div class="fcol3">
							 <div class="ftitle">Menus</div>
							 <ul class="footerlist">
					<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/AddMenu.aspx") %>' >Add Menu</a></li>                    
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyMenus") %>' >My Menus</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Menu/MenuList.aspx?MenuType=MyDrafts") %>' >My Drafts</a></li>
			
							 </ul>
					</div>
					<div class="footerbrake2"></div>
					<div class="fcol4">
							 <div class="ftitle">Settings</div>
							 <ul class="footerlist">
					<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=Setting") %>' >Code Management</a></li>                    
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=UserGroup") %>' >User Groups</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=ManageStaff") %>' >Manage Staff</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=MenuCycle") %>' >Menu Cycle</a></li>
                    <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/myzone.aspx?Control=NutritionalAnalysis") %>' >Nutritional Analysis</a></li>
							 </ul>
					</div>
					<div class="footerbrake"></div>
					<div class="fcol5">
							 <div class="ftitle">Support</div>
							 <ul class="footerlist">
							 <!--<li><a class="flink" href='<%= ResolveUrl("~/UI/Page/SimpleServings/Help/index.html")  %>' onclick="window.open(this.href);return false;">Help</a></li>                -->
                                  <li><a class="flink" href='<%= ResolveUrl("~/UI/PDF/SimpleServingsHelpPage.pdf")  %>' target="_blank" >Help</a></li>  
                             <li><a class="flink" href='<%= ResolveUrl("~/UI/Page/contact.aspx")  %>'>Contact</a></li>
							 </ul>
					</div>
			</div> 
			<div class="clearfix"></div>            	
			<div class="line6"></div>			
			<div class="copyright">		
				<div class="fright">Copyright ©  2013 <a href="#" class="flink2">SimpleServings™</a>. All rights reserved.</div>
				<div class="fleft"><a href="http://www.nyc.gov/html/dfta/html/home/home.shtml" target="_blank"><img src="../images/DeptAgingLogo.jpg" /></a></div>
				<div class="clearfix"></div>
                <div style="padding: 20px;" >Please note that certain products within the Simple Servings website may be listed by brand name.  Although the NYC Department for the Aging does not endorse or promote the use of any particular product, the brand name is being provided for informational purposes only, which includes the nutritional value of the food item.  Additional brand name products that meet the NYC Food Standards and DFTA guidelines may be submitted for consideration.</div>
				<p id="back-top"><a href="#top"><span></span>Top</a></p>	
			</div>

		</footer>
		<!-- END OF FOOTER -->
        
    
        </div>

    <!-- CUSTOM EDIT PANES -->
    <%--<div align="center" id="FreezePane" class="FreezePaneOff">
        <div id="InnerFreezePane" class="InnerFreezePane">
            <asp:Panel ID="pnlWelcomeMessage" runat="server" style="display: none;">
                <asp:HiddenField ID="hdnWelcomeMessage" runat="server" />
                <asp:LinkButton ID="LinkButton5" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; float: left; margin-right: 20px; margin-bottom: 20px; font-weight: bold;">Cancel</asp:LinkButton> 
                <table>
                    <tr  style="vertical-align: top;">
                        <td colspan="2">
                            Change Welcome Message:
                        </td>
                    </tr>
                    <tr><td style="height:10px;">&nbsp;</td></tr>
                    <tr  style="vertical-align: top;">
                        <td>
                            Change Banner Image:
                        </td>
                        <td>
                            <asp:FileUpload ID="fupWelcomeImage" runat="server" CssClass="fileupload" Width="250px" onchange="fnOnChange(this);" ToolTip="upload welcome banner image" Style="visibility: visible;" placeholder="upload image file" />
                        </td>

                    </tr>
                    <tr>
                       <td style="vertical-align: top;">
                           <asp:CheckBox ID="cbWelcomeMessage" runat="server" onchange="fnOnChange(this);" Text="Update Text"/>
                        </td>
                        <td>
                           <asp:TextBox ID="txtWelcomeMessage" runat="server" Width="350px" Height="200px" TextMode="MultiLine" ReadOnly="true" style="overflow-y: scroll; visibility: visible;" CausesValidation="false" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="* HTML Tags Not Allowed" ControlToValidate="txtWelcomeMessage" ClientValidationFunction="Validate" />
                       </td>
                   </tr>
                    <tr>
                       <td>&nbsp;</td>
                       <td>
                           <asp:Button ID="btnWelcomeMessage" runat="server" Text="Update Welcome Message" CssClass="btn1" OnClientClick="return fnOnClick(this);" OnClick="btUpload_Click" CommandName="WelcomeMessage" style="margin-top: 10px;" />
                       </td>
                   </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlFeaturedRecipe" runat="server" style="display: none;">    
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; float: left; margin-right: 20px; margin-bottom: 20px; font-weight: bold;">Cancel</asp:LinkButton>        
                <table>
                    <tr  style="vertical-align: top;">
                        <td>
                            Change Recipe:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRecipe" runat="server" OnDataBound="ddlRecipe_DataBound" Width="250px" Style="margin-bottom: 9px;" />
                        </td>
                    </tr>
                    <tr  style="vertical-align: top;">
                        <td>
                            Change Print File:
                        </td>
                        <td>
                            <asp:FileUpload ID="fuRecipePrintFile" runat="server" CssClass="fileupload" Width="250px" onchange="fnOnChange(this);" ToolTip="upload featured recipe print file" Style="visibility: visible;" placeholder="upload print file" />
                        </td>
                    </tr>
                    <tr  style="vertical-align: top;">
                        <td>
                            Change Image File:
                        </td>
                        <td>
                            <asp:FileUpload ID="fuRecipeImage" runat="server" CssClass="fileupload" Width="250px" onchange="fnOnChange(this);" ToolTip="upload featured recipe image" Style="visibility: visible;" placeholder="upload image file" />
                        </td>

                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnFeaturedRecipe" runat="server" Text="Update Featured Recipe" CssClass="btn1" OnClientClick="return fnOnClick(this);" OnClick="btUpload_Click" CommandName="UpdateRecipe" style="margin-top: 10px;" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlNutritionalMessage" runat="server" style="display: none;">
                <asp:HiddenField ID="hdnMessageContent" runat="server" />
                            <asp:LinkButton ID="LinkButton4" runat="server" OnClientClick="fnCancel(this); unFreezeScreen(); return false;" CommandName="Cancel"
                                Style="background: url('../images/deleteIcon.png') no-repeat left center; padding-left: 18px; line-height: 15px; float: left; margin-right: 20px; margin-bottom: 20px; font-weight: bold;">Cancel</asp:LinkButton>
                <table>
                    <tr style="vertical-align: top;">
                       <td>
                           Change Message Title:
                        </td>
                        <td>
                           <asp:TextBox ID="txtNutritionalMessage" CssClass="textbox2" Width="250px" runat="server" ToolTip="enter nutritional message title" Style="border: 1px solid lightgrey; visibility: visible;" placeholder="Enter Title..." />
                       </td>
                   </tr>
                   <tr style="vertical-align: top;">
                       <td>
                           Change Message File:
                        </td>
                        <td>
                           <asp:FileUpload ID="fuMessage" runat="server" CssClass="fileupload" Width="250px" onchange="fnOnChange(this);" ToolTip="upload nutritional message file" Style="visibility: visible;" />
                       </td>
                   </tr>
                   <tr><td style="height:10px;">&nbsp;</td></tr>
                   <tr>
                       <td style="vertical-align: top;">
                           <asp:CheckBox ID="cbMessageContent" runat="server" onchange="fnOnChange(this);" Text="Update Content"/>
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="ckeNutritionalMessage" runat="server" ResizeMinWidth="350" ResizeMinHeight="150" Width="500px" Height="200px" ResizeEnabled="true" HtmlEncodeOutput="true" CausesValidation="false" style="visibility: visible;" />
                            <asp:TextBox ID="txtMessageContent" runat="server" Width="350px" Height="200px" TextMode="MultiLine" ReadOnly="true" style="overflow-y: scroll; visibility: visible;" CausesValidation="false" Visible="false" />
                        </td>
                   </tr>
                    
                   <tr>
                       <td>&nbsp;</td>
                       <td>
                           <asp:Button ID="btnMessage" runat="server" Text="Update Nutritional Message" CssClass="btn1" OnClientClick="return fnOnClick(this);" OnClick="btUpload_Click" CommandName="NutritionalMessage" style="margin-top: 10px;" />
                       </td>
                   </tr>

                </table>
            </asp:Panel>
        </div>
    </div>--%>
    <!-- END OF CUSTOM EDIT PANES -->

    </form>
	</body>
</html>
