//TOGGLE LIST

jQuery(document).ready(function () {   
    $("a.listToggle").click(function () {
        $("#listView").removeClass('hide').addClass('show');
        $("#myFavoriteList").removeClass('show').addClass('hide');
        $("#gridView").removeClass('show').addClass('hide');
        return false;
    });

    $("a.gridToggle").click(function () {
        $("#listView").removeClass('show').addClass('hide');
        $("#myFavoriteList").removeClass('show').addClass('hide');
        $("#gridView").removeClass('hide').addClass('show');
        return false;
    });

    $("a.favToggle").click(function () {
        $("#listView").removeClass('show').addClass('hide');
        $("#gridView").removeClass('show').addClass('hide');
        $("#myFavoriteList").removeClass('hide').addClass('show');
        return false;
    });
});


////function scroll() {
////    $(".menuList").mCustomScrollbar("disable");
////    $(".menuList").mCustomScrollbar({
////        theme: "dark-thin",
////        scrollButtons: {
////            enable: true
////        }
////    });
////    $(".content_scroll").hover(function () {
////        $(document).data({ "keyboard-input": "enabled" });
////        $(this).addClass("keyboard-input");
////    }, function () {
////        $(document).data({ "keyboard-input": "disabled" });
////        $(this).removeClass("keyboard-input");
////    });
////    $(document).keydown(function (e) {
////        if ($(this).data("keyboard-input") === "enabled") {
////            var activeElem = $(".keyboard-input"),
////					activeElemPos = Math.abs($(".keyboard-input .mCSB_container").position().top),
////					pixelsToScroll = 60;
////            if (e.which === 38) { //scroll up
////                e.preventDefault();
////                if (pixelsToScroll > activeElemPos) {
////                    activeElem.mCustomScrollbar("scrollTo", "top");
////                } else {
////                    activeElem.mCustomScrollbar("scrollTo", (activeElemPos - pixelsToScroll), { scrollInertia: 300, scrollEasing: "easeOutCirc" });
////                }
////            } else if (e.which === 40) { //scroll down
////                e.preventDefault();
////                activeElem.mCustomScrollbar("scrollTo", (activeElemPos + pixelsToScroll), { scrollInertia: 300, scrollEasing: "easeOutCirc" });
////            }
////        }
////    });

////}



//Disable text selection

////





function checkUpdating() {
    $("#DragMenuItems1_UpdateProgress1").css("display", "block");
    var renewDrag = window.setInterval(function () {
        if ($("#DragMenuItems1_UpdateProgress1").css("display") == "none") {
            initDragDrop();
            window.clearInterval(renewDrag);
        }
    }, 200);
    var weekNumber = document.getElementById("WeekNumber");
    if (weekNumber != null)
        weekNumber.value = $("#DragMenuItems1_MenuItemGrid1_ddlWeek").val();


}

function UpdateScrolling() {
    $("#DragMenuItems1_UpdateProgress1").css("display", "block");
    var renewDrag = window.setInterval(function () {
        if ($("#DragMenuItems1_UpdateProgress1").css("display") == "none") {
            initDragDrop();
            //scroll();
            window.clearInterval(renewDrag);
        }
    }, 200);
    var weekNumber = document.getElementById("WeekNumber");
    if (weekNumber != null)
        weekNumber.value = $("#DragMenuItems1_MenuItemGrid1_ddlWeek").val();
}


function getMenuTypeId() {
    //scroll();
    var weekNumber = document.getElementById("WeekNumber");
    if ($("#DragMenuItems1_MenuItemGrid1_ddlWeek").val() != null) {
        weekNumber.value = $("#DragMenuItems1_MenuItemGrid1_ddlWeek").val();
        var menuItems = $(".menuItemTypeId");
        var hiddenMenuItemsId = document.getElementById("MenuItemsId");
        hiddenMenuItemsId.value = "";
        for (var i = 0; i < menuItems.length; i++) {
            if (hiddenMenuItemsId.value == "") {
                hiddenMenuItemsId.value = $(menuItems[i]).text();
            } else {
                hiddenMenuItemsId.value = hiddenMenuItemsId.value + "," + $(menuItems

[i]).text();
            }
        }
    }
}

var initDragDrop = function () {

    //added this to prevent drag and drop when menu week is completetd
    if (document.getElementById("lblIsComplete")) {
        if (document.getElementById("lblIsComplete").innerHTML == '1')
            return;
    }
        // added this to prevent drag and drop in ViewMenu page
    else return;
    //end of added this.

    var scheduleTRs = $(".menuGridStyle").find("tr");
    for (var i = 1; i < scheduleTRs.length; i++) {
        var scheduleTDs = $(scheduleTRs[i]).children();
        var timeName = "Row1Col";
        if (i == 2) {
            timeName = "Row2Col";
        } else if (i == 3) {
            timeName = "Row3Col";
        } else if (i == 4) {
            timeName = "Row4Col";
        } else if (i == 5) {
            timeName = "Row5Col";
        } else if (i == 6) {
            timeName = "Row6Col";
        } else if (i == 7) {
            timeName = "Row7Col";
        } else if (i == 8) {
            timeName = "Row8Col";
        } else if (i == 9) {
            timeName = "Row9Col";
        } else if (i == 10) {
            timeName = "Row10Col";
        }
        for (var j = 1; j < scheduleTDs.length; j++) {
            $(scheduleTDs[j]).prop("id", "_" + timeName + j);
        }
    }

    $(".draggable").draggable({
        helper: "clone",
        appendTo: "body",
        cursor: "pointer",
        opacity: 0.80,
        revert: "invalid",
        zIndex: 800

    });

    var nullTR = $(".menuGridStyle tr");
    for (var i = 1; i < nullTR.length; i++) {
        var nullTD = $(nullTR[i]).children();
        for (var j = 1; j < nullTD.length; j++) {
            $(nullTD[j]).droppable({
                drop: function (event, ui) {
                    if ($(this).children().length == 0)
                        $(this).empty();
                    var newItem;
                    if ($(ui.draggable).parents(".ui-droppable").length <= 0 || event.ctrlKey == true)  //07-28-2016
                        newItem = $(ui.draggable).clone();
                    else
                        newItem = $(ui.draggable);

                    var targetTDID = $(this).prop("id");
                    var infos = $("#" + targetTDID).children("span").text();
                    var menuInfos = infos.split(',');
                    var recipeId = $($(ui.draggable).children(".recipeId")[0]).text();
                    var newRecipeId = recipeId.match(/\d+/);
                    var isSampleMenuItem = $($(ui.draggable).children(".isSampleMenuItem")[0]).text();
                    var myThis = $(this);
                    var removeId = 0;
                    var originalId = 0;
                    var menuTypeID = getMenuType();
                    if (menuTypeID == 183) // Sample Menu 
                        isSampleMenuItem = "True";
                    try {
                        if (event.ctrlKey == false) {  //07-28-2016
                            removeId = $(newItem.children(".menuItemId")[0]).text();
                        }
                        else
                        {
                            originalId = $(newItem.children(".menuItemId")[0]).text();                            
                            if(menuTypeID != 183) // If not sample menu 
                            isSampleMenuItem = "False";

                        }
                    } catch (e) {
                    }

                    GetInfo(menuInfos, newRecipeId, myThis, newItem, removeId, originalId, isSampleMenuItem);
                    //UpdateMeter(menuInfos);
                    
                    /*var targetTDID = $(this).prop("id").substring(1);
                    if ($("input[id*='" + targetTDID + "']").val() == "") {
                    $("input[id*='" + targetTDID + "']").val($(ui.draggable).text());
                    } else {
                    $("input[id*='" + targetTDID + "']").val(
                    $("input[id*='" + targetTDID + "']").val() + "," + $(ui.draggable).text()
                    );
                    }*/
                }
            });
        }
    }

};

/*

function UpdateMeter(menuInfos) 
{

    try 
    {
        $.ajax
        ({
            type: "POST",
            url: "AddMenuItem.aspx/UpdateMenuMeter",
            data: '{menuID: "' + menuInfos[0] + '", weekSelected: "' + menuInfos[2] + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.hasOwnProperty("d"))
                    var JSONObject = response.d;
                else
                    var JSONObject = response;

                document.getElementById("lblMeterLow").innerHTML = "";
                document.getElementById("lblMeterHigh").innerHTML = "";
                document.getElementById("lblMeterNormal").innerHTML = "";

                var msgLow = "";
                var msgHigh = "";
                var msgNormal = "";

                for (var i = 0; i < JSONObject.length; i++) 
                {
                    if (JSONObject[i].MeterColor.indexOf("Low") != -1) 
                    {
                        msgLow += " <span class='bulletArrow'></span> " + JSONObject[i].NutrientName ;
                    }
                    else if (JSONObject[i].MeterColor.indexOf("High") != -1) 
                    {
                        msgHigh += " <span class='bulletArrow'></span> " + JSONObject[i].NutrientName;
                    }
                    else 
                    {
                        msgNormal += " <span class='bulletArrow'></span> " + JSONObject[i].NutrientName;
                    }
                }
                document.getElementById("lblMeterLow").innerHTML=msgLow ; //.substring(0, msgLow.length - 2);
                document.getElementById("lblMeterHigh").innerHTML=msgHigh; //.substring(0, msgHigh.length - 2);;
                document.getElementById("lblMeterNormal").innerHTML=msgNormal; //.substring(0, msgNormal.length - 2);;
            }
        });
    }

    catch (e)  { }

 };
 */

function checkName(myId) {
     //$(".myLink").click(
     //$(".myLink").parent().onclick();
             try{
                 $.ajax({
                     type: "POST",
                     url: "AddMenuItem.aspx/RemoveMenuItem",
                     data: '{removeId: "' + myId + '"}',
                     contentType: "application/json; charset=utf-8",
                     dataType: "json"

                 });

                 $("#" + myId).remove();
     } catch (ex)
        { }

        //__doPostBack('', '');
    }

    function ToggleIsAlternate(myId) {
        
        try {
            $.ajax({
                type: "POST",
                url: "AddMenuItem.aspx/ToggleIsAlternate",
                data: '{menuItemIDText: "' + myId + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json"

            });
            $("#" + myId).toggleClass("alternate");

           
        } catch (ex)
        { }

        //__doPostBack('', '');
    }

    function doColorChange(myId) {
        //$("#" + myId).css("background", "yellow");
        $("#" + myId).toggleClass("alternate");
    }


    function GetInfo(menuInfos, newRecipeId, myThis, newItem, removeId, originalId, isSampleMenuItem) {
    var myId ='';
    try {
        var obj = {};
        obj.menuID = $.trim(menuInfos[0]);
        obj.menuItemTypeIDText = $.trim(menuInfos[1]);
        obj.weekSelected = $.trim(menuInfos[2]);
        obj.DayOfWeekID = $.trim(menuInfos[3]);
        //obj.IsSampleMenuItem = $.trim(menuInfos[4]);
        obj.recipeIdText = $.trim(newRecipeId[0]);
        obj.removeId = $.trim(removeId);
        obj.originalId = $.trim(originalId);
        obj.IsSampleMenuItem = $.trim(isSampleMenuItem);
     $.ajax({
         type: "POST",
         url: "AddMenuItem.aspx/GetUserInfo",
         //data: '{menuID: "' + menuInfos[0] + '", menuItemTypeIDText: "' + menuInfos[1] + '", weekSelected: "' + menuInfos[2] +
         //   '", DayOfWeekID: "' + menuInfos[3] + '", recipeIdText: "' + newRecipeId[0] + '", removeId: "' + removeId + '" }',
         data: JSON.stringify(obj),
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         success: function (response) {
             if (response.hasOwnProperty("d"))
                 var JSONObject = response.d;
             else
                 var JSONObject = response;
             if (JSONObject.MenuItemID == -1) {
                 window.location = "../../Login.aspx";
                 return false;
             }

             var itemDiv = $(newItem).children(".menuItemId");

             if ($(itemDiv).length == 0) {
                 myId = JSONObject.MenuItemID;
                 $(newItem).append("<div class='menuItemId' style='display:none'>" + JSONObject.MenuItemID +"</div>");
             } else {
                 myId = JSONObject.MenuItemID;
                 $(newItem).children(".menuItemId").remove();
                 $(newItem).append("<div class='menuItemId' style='display:none'>" + JSONObject.MenuItemID + "</div>")
             }

             $(newItem).children(1).addClass("clearLine");

             if ($(newItem).children(".remove").length == 0 && $(newItem).children("a").length == 0) {
                 var aTag = document.createElement('a');
                 aTag.setAttribute("class", "remove");
                 aTag.setAttribute('onClick', "return confirm('Are you sure you want to remove this Recipe?');");
                 aTag.setAttribute('href', "javascript:checkName(" + myId + ")");
                 aTag.innerHTML = "Remove";
                 $(newItem).append(aTag);
             } else {
                 $(newItem).children("a").remove();
                 var aTag = document.createElement('a');
                 aTag.setAttribute("class", "remove");
                 aTag.setAttribute('onClick', "return confirm('Are you sure you want to remove this Recipe?');");
                 aTag.setAttribute('href', "javascript:checkName(" + myId + ")");
                 aTag.innerHTML = "Remove";
                 $(newItem).append(aTag);
             }
             if ($(newItem).children(".alternate") != 0) {
                 if (document.getElementById("DragMenuItems1_lblCannotAlternate").innerHTML == '1') {
                 } else {
                     var alt = document.createElement('a');
                     //css attribute below should be changed to class
                     alt.setAttribute('css', 'alternate');
                     //alt.setAttribute('onClick', "return confirm('Are you sure you want alternate this recipe?');");
                     alt.setAttribute('href', "javascript:ToggleIsAlternate(" + myId + ")");
                     alt.innerHTML = "Alternate";
                     $(newItem).append(alt);
                 }



             }


             if (obj.IsSampleMenuItem == "True") {
                 $(newItem).addClass("sampleMenuItem");
             }
             else {
                 $(newItem).removeClass("sampleMenuItem");
                 $(newItem).children(".isSampleMenuItem").text("False");
                 //$("#DragMenuItems1_MenuItemGrid1_gvMenuItems_ctl02_rpDay1_ctl00_lblIsSamplemenuItem").text("False");
             }


             $(newItem).attr("id", myId);
             $(newItem).attr("oncontextmenu", "ShowMenu('contextMenu',event, " + response.d.MenuItemID + ")");
             $(myThis).append(newItem);
             
             newItem.draggable({
                 helper: "clone",
                 appendTo: "body",
                 cursor: "pointer"
             });

        }
     });
     } catch (e)
        { }
    };

getMenuTypeId();
$(initDragDrop);

function rbSelectOne(rb) {
    var id = getGridClientID();
    var gv = document.getElementById(id);
    var rbs = gv.getElementsByTagName("input");
    var row = rb.parentNode.parentNode;
    for (var i = 0; i < rbs.length; i++) {
        if (rbs[i].type == "radio") {
            if (rbs[i].checked && rbs[i] != rb) {
                rbs[i].checked = false;
                break;
            }
        }
    }
}


function ConfirmDietOrProgramTypeChange(menuTypeID) {
    if (menuTypeID != 183) {
        var confirmChanges = document.createElement('INPUT');
        confirmChanges.style.display = 'none';
        //confirmChanges.type = 'hidden';
        confirmChanges.name = 'confirmChanges';
        if (confirm('Associated Contracts must be changed, If Program Type/ Diet Type is changed! Please confirm if you want to change Associated Contratcs?')) {
            confirmChanges.value = 'Yes';
        } else {
            confirmChanges.value = 'No';
        }
        document.forms[0].appendChild(confirmChanges);
    }
}



function btnCancelClick()
{
    location.reload();
    
}




function recipeSearchBoxKeyPress(e) {
    var code = e.keyCode ? e.keyCode : e.which;
    if (code.toString() == 13) {
        var param = document.getElementById("recipeSearchBox").value;
        window.location.href = '/SimpleServings/UI/Page/SimpleServings/Recipe/RecipeList.aspx?rcpSearch=' + param.toString();
        return false;

    }
}




function ExpandheaderKeyPress(Expand) {
    $Expandheader = $(Expand);
    var child = $(Expand).find('span');
    $tags = $Expandheader.next();   

    var expandImg = '/SimpleServings/UI/images/recipeIcons/collapse.png';
    var collpaseImg = '/SimpleServings/UI/images/recipeIcons/expand.png';

    $tags.slideToggle(300, function () {
        $tags.is(":visible") ? fadeAnimation(child, 0, expandImg) : fadeAnimation(child, 1, collpaseImg);
    });

}

function fadeAnimation(child, isVisible, img) {
    if (isVisible == 1) {
        child.parent().fadeTo(100, 0.5, function () {
            child.parent().css('background-image', 'url(' + img + ')');
        }).fadeTo('slow', 1);
    }
    else {
        child.parent().fadeTo(100, 0.5, function () {
            child.parent().css('background-image', 'url(' + img + ')');
        }).fadeTo('slow', 1);


    }

}


