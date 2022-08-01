
function myReportMenu(){
	var myMenu;
	myMenu = new SDMenu("my_Reportmenu");

	myMenu.init();
	
//	myMenu.collapseAll();                 
//	var firstSubmenu = myMenu.submenus[0];
//    myMenu.expandMenu(firstSubmenu);      
//	

    if(document.getElementById('homepage'))
    {
        myMenu.oneSmOnly = true;       
    }
    else
    {
        myMenu.oneSmOnly = false; 
    }
} 
//Start SDMenu
function myZoneMenu(){
	var myMenu;
	myMenu = new SDMenu("my_menu");

	myMenu.init();
	
//	myMenu.collapseAll();                 
//	var firstSubmenu = myMenu.submenus[0];
//    myMenu.expandMenu(firstSubmenu);      
//	

    if(document.getElementById('homepage'))
    {
        myMenu.oneSmOnly = true;       
    }
    else
    {
        myMenu.oneSmOnly = false; 
    }
}   

//StartTabs	
function loginTxt(){
    var NameTextBox = document.getElementById('txtUserName');
    var PassFTextBox = document.getElementById('txtPasswordF');
    var PassTextBox = document.getElementById('txtPassword');
    
    PassFTextBox.style.display = 'inline';
    PassTextBox.style.display = 'none';
    
    function clearInputFld(f){
        if(f==1 && NameTextBox.value=='Username'){
            NameTextBox.value = '';
            NameTextBox.style.color = '#333333';}
        
        else if(f==2 && PassFTextBox.value=='Password'){
            PassFTextBox.style.display = 'none';
            PassTextBox.style.display = 'inline';
            PassTextBox.style.color = '#333333';
            PassTextBox.focus();}
    }
    
    function RefillInputFld(f){
        if(f==1 && NameTextBox.value==''){
            NameTextBox.value = 'Username';
            NameTextBox.style.color = '#898989';}
        
        else if(f==2 && PassTextBox.value==''){
            PassFTextBox.style.display = 'inline';
            PassTextBox.style.display = 'none';
            PassTextBox.style.color = '#898989';
            }
    }
    
    NameTextBox.onfocus = function(){clearInputFld(1);}
    NameTextBox.onkeydown = function(){clearInputFld(1);}
    NameTextBox.onclick = function(){clearInputFld(1);}
    NameTextBox.onblur = function(){RefillInputFld(1);}
    PassFTextBox.onfocus = function(){clearInputFld(2);}
    PassTextBox.onblur = function(){RefillInputFld(2);}
}

/*******PopUpResize**********/
function popResizerFnt(){
    if(document.getElementById('announcePopWrap') && document.getElementById('btnClose').style.visibility == 'visible'){
        
        window.onresize = popResizerFnt; 
        var DocHeight = document.documentElement.clientHeight; //HTML Height
        var thePopUp = document.getElementById('announcePopWrap'); //Announcement
        var margins = 210; 
        var popNewHeight = DocHeight - margins;//HTML Height with margins for popup
        var AnnounceHeight = thePopUp.clientHeight;//Announcement Height
      
        
        if (AnnounceHeight < thePopUp.scrollHeight && AnnounceHeight <= popNewHeight ){
            thePopUp.style.height = 'auto';
        }
        if(AnnounceHeight > popNewHeight && AnnounceHeight >= 100){
            thePopUp.style.height = popNewHeight + 'px';
        }
        
        
    }
}     
   
   
   
/*function easyTabber(){
    function changeTab(n)
    {
            document.getElementById('tabDiv1').className = 
                document.getElementById('tabButton1').className = 
                n==1 ? 'tabActive' : 'tabInactive';
            document.getElementById('tabDiv2').className = 
                document.getElementById('tabButton2').className = 
                n==2 ? 'tabActive' : 'tabInactive';
            document.getElementById('tabDiv3').className = 
                document.getElementById('tabButton3').className = 
                n==3 ? 'tabActive' : 'tabInactive';
            document.getElementById('tabDiv4').className = 
                document.getElementById('tabButton4').className = 
                n==4 ? 'tabActive' : 'tabInactive';
    };
    
    if (document.getElementById('tabButton1') || document.getElementById('tabButton2') || document.getElementById('tabButton3') || document.getElementById('tabButton4')){
        document.getElementById('tabButton1').onclick = function(){changeTab(1);return false;}
        document.getElementById('tabButton2').onclick = function(){changeTab(2);return false;} 
        document.getElementById('tabButton3').onclick = function(){changeTab(3);return false;} 
        document.getElementById('tabButton4').onclick = function(){changeTab(4);return false;}
    }
 
}*/

function newSession() {
    //debugger;
    jQuery.ajax({
        type: "POST",
        url: "landingPage.aspx/ClearSession",
        data: "{}",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            jQuery.ajax({
                type: "POST",
                url: "landingPage.aspx/NewSession",
                data: "{}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                //success: function () { console.log("Success!"); },
                error: function (x, y, z) {
                    console.log("Failure!");
                }
            });
        },
        error: function (x, y, z) {
            console.log("Failure!");
        }
    });
}
