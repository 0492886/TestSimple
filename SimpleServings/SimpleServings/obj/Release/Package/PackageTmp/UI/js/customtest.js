jQuery(document).ready(function () {

    $("a.listToggle").click(function () {
        $("#listView").removeClass('hide').addClass('show');
        $("#gridView").removeClass('show').addClass('hide');
        return false;
    });

    $("a.gridToggle").click(function () {
        $("#listView").removeClass('show').addClass('hide');
        $("#gridView").removeClass('hide').addClass('show');
        return false;
    });

});


function scroll() {



    $(".menuList").mCustomScrollbar("disable");
    $(".menuList").mCustomScrollbar({
        theme: "dark-thin",
        scrollButtons: {
            enable: true
        }
    });
    $(".content_scroll").hover(function () {
        $(document).data({ "keyboard-input": "enabled" });
        $(this).addClass("keyboard-input");
    }, function () {
        $(document).data({ "keyboard-input": "disabled" });
        $(this).removeClass("keyboard-input");
    });
    $(document).keydown(function (e) {
        if ($(this).data("keyboard-input") === "enabled") {
            var activeElem = $(".keyboard-input"),
					activeElemPos = Math.abs($(".keyboard-input .mCSB_container").position().top),
					pixelsToScroll = 60;
            if (e.which === 38) { //scroll up
                e.preventDefault();
                if (pixelsToScroll > activeElemPos) {
                    activeElem.mCustomScrollbar("scrollTo", "top");
                } else {
                    activeElem.mCustomScrollbar("scrollTo", (activeElemPos - pixelsToScroll), { scrollInertia: 300, scrollEasing: "easeOutCirc" });
                }
            } else if (e.which === 40) { //scroll down
                e.preventDefault();
                activeElem.mCustomScrollbar("scrollTo", (activeElemPos + pixelsToScroll), { scrollInertia: 300, scrollEasing: "easeOutCirc" });
            }
        }
    });

}

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
            scroll();
            window.clearInterval(renewDrag);
        }
    }, 200);
    var weekNumber = document.getElementById("WeekNumber");
    if (weekNumber != null)
        weekNumber.value = $("#DragMenuItems1_MenuItemGrid1_ddlWeek").val();


}


function getMenuTypeId() {
    scroll();
    var weekNumber = document.getElementById("WeekNumber");
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

var initDragDrop = function () {

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
            var resultstimeName = $(scheduleTDs[j]).prop("id", "_" + timeName + j);
            $(scheduleTDs[j]).prop("id", "_" + timeName + j);
            //console.log("this is results: " + resultstimeName.text());
            //console.log("this is results 2: " + timeName);

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
            if ($.trim($(nullTD[j]).html()) != "") {
                var content = $(nullTD[j]).html();
                $(nullTD[j]).empty();
                var newContent = $("<div></div>");
                newContent.append(content);
                $(nullTD[j]).append(newContent);
            }
            $(nullTD[j]).droppable({
                drop: function (event, ui) {
                    if ($(this).children().length == 0)
                        $(this).empty();
                    $(this).append($(ui.draggable).clone());
                    var targetTDID = $(this).prop("id").substring(1);
                    if ($("input[id*='" + targetTDID + "']").val() == "") {
                        $("input[id*='" + targetTDID + "']").val($(ui.draggable).text());
                    } else {
                        $("input[id*='" + targetTDID + "']").val(
                            $("input[id*='" + targetTDID + "']").val() + "," + $(ui.draggable).text()
                            );
                    }


                    //TRIGGER AUTOSAVE HERE  
                    //alert("Autosave Trigger");
                    function SaveUserInput() {
                        //var name = $get(resultstimeName).value;                       

                        var menuID = document.getElementById("MenuItemsId");
                        var weekNumber = document.getElementById("WeekNumber");
                        var mNameA = document.getElementById("Row1Col2");
                        var mNameB = document.getElementById("Row1Col3");
                        var mNameC = document.getElementById("Row1Col4");
                        var mNameD = document.getElementById("Row1Col5");
                        var mNameE = document.getElementById("Row1Col6");
                        var mNameF = document.getElementById("Row1Col7");

                        var mNameG = document.getElementById("Row2Col1");
                        var mNameH = document.getElementById("Row2Col2");
                        var mNameI = document.getElementById("Row2Col3");
                        var mNameJ = document.getElementById("Row2Col4");
                        var mNameK = document.getElementById("Row2Col5");
                        var mNameL = document.getElementById("Row2Col6");
                        var mNameM = document.getElementById("Row2Col7");

                        var mNameN = document.getElementById("Row3Col1");
                        var mNameO = document.getElementById("Row3Col2");
                        var mNameP = document.getElementById("Row3Col3");
                        var mNameQ = document.getElementById("Row3Col4");
                        var mNameR = document.getElementById("Row3Col5");
                        var mNameS = document.getElementById("Row3Col6");
                        var mNameT = document.getElementById("Row3Col7");

                        var mNameU = document.getElementById("Row4Col1");
                        var mNameV = document.getElementById("Row4Col2");
                        var mNameW = document.getElementById("Row4Col3");
                        var mNameX = document.getElementById("Row4Col4");
                        var mNameY = document.getElementById("Row4Col5");
                        var mNameZ = document.getElementById("Row4Col6");
                        var mNameAA = document.getElementById("Row4Col7");

                        var mNameAB = document.getElementById("Row5Col1");
                        var mNameAC = document.getElementById("Row5Col2");
                        var mNameAD = document.getElementById("Row5Col3");
                        var mNameAE = document.getElementById("Row5Col4");
                        var mNameAF = document.getElementById("Row5Col5");
                        var mNameAG = document.getElementById("Row5Col6");
                        var mNameAH = document.getElementById("Row5Col7");

                        var mNameAI = document.getElementById("Row6Col1");
                        var mNameAJ = document.getElementById("Row6Col2");
                        var mNameAK = document.getElementById("Row6Col3");
                        var mNameAL = document.getElementById("Row6Col4");
                        var mNameAM = document.getElementById("Row6Col5");
                        var mNameAN = document.getElementById("Row6Col6");
                        var mNameAO = document.getElementById("Row6Col7");

                        var mNameAP = document.getElementById("Row7Col1");
                        var mNameAQ = document.getElementById("Row7Col2");
                        var mNameAR = document.getElementById("Row7Col3");
                        var mNameAS = document.getElementById("Row7Col4");
                        var mNameAT = document.getElementById("Row7Col5");
                        var mNameAU = document.getElementById("Row7Col6");
                        var mNameAV = document.getElementById("Row7Col7");

                        var mNameAX = document.getElementById("Row8Col1");
                        var mNameAY = document.getElementById("Row8Col2");
                        var mNameAZ = document.getElementById("Row8Col3");
                        var mNameBA = document.getElementById("Row8Col4");
                        var mNameBB = document.getElementById("Row8Col5");
                        var mNameBC = document.getElementById("Row8Col6");
                        var mNameBD = document.getElementById("Row8Col7");

                        var mNameBE = document.getElementById("Row9Col1");
                        var mNameBF = document.getElementById("Row9Col2");
                        var mNameBG = document.getElementById("Row9Col3");
                        var mNameBH = document.getElementById("Row9Col4");
                        var mNameBI = document.getElementById("Row9Col5");
                        var mNameBJ = document.getElementById("Row9Col6");
                        var mNameBK = document.getElementById("Row9Col7");

                        var mNameBL = document.getElementById("Row10Col1");
                        var mNameBM = document.getElementById("Row10Col2");
                        var mNameBN = document.getElementById("Row10Col3");
                        var mNameBO = document.getElementById("Row10Col4");
                        var mNameBP = document.getElementById("Row10Col5");
                        var mNameBQ = document.getElementById("Row10Col6");
                        var mNameBR = document.getElementById("Row10Col7");


                        //Saving all input in a single value     
                        var input = menuID.value + "+" + weekNumber.value + "+" + mNameA.value + "+" + mNameB.value + "+" + mNameC.value + "+" + mNameD.value + "+" + mNameE.value + "+" + mNameF.value + "+" + mNameG.value + "+" + mNameH.value + "+" + mNameI.value + "+" + mNameJ.value + "+" + mNameK.value + "+" + mNameL.value + "+" + mNameM.value + "+" + mNameN.value + "+" + mNameO.value + "+" + mNameP.value + "+" + mNameQ.value + "+" + mNameR.value + "+" + mNameS.value + "+" + mNameT.value + "+" + mNameU.value + "+" + mNameV.value + "+" + mNameW.value + "+" + mNameX.value + "+" + mNameY.value + "+" + mNameZ.value + "+"

                        + mNameAA.value + "+" + mNameAB.value + "+" + mNameAC.value + "+" + mNameAD.value + "+" + mNameAE.value + "+" +
                        mNameAF.value + "+" + mNameAG.value + "+" + mNameAH.value + "+" + mNameAI.value + "+" +
                        mNameAJ.value + "+" + mNameAK.value + "+" + mNameAL.value + "+" + mNameAM.value + "+" + mNameAN.value + "+" +
                        mNameAO.value + "+" + mNameAP.value + "+" + mNameAQ.value + "+" + mNameAR.value + "+" + mNameAS.value + "+" +
                        mNameAT.value + "+" + mNameAU.value + "+" + mNameAV.value + "+" + mNameAX.value + "+" +
                        mNameAY.value + "+" + mNameAZ.value + "+"

                        + mNameBA.value + "+" + mNameBB.value + "+" + mNameBC.value + "+" + mNameBD.value + "+" + mNameBE.value + "+" +
                        mNameBF.value + "+" + mNameBG.value + "+" + mNameBH.value + "+" + mNameBI.value + "+" + mNameBJ.value + "+" +
                        mNameBK.value + "+" + mNameBL.value + "+" + mNameBM.value + "+" + mNameBN.value + "+" +
                        mNameBO.value + "+" + mNameBP.value + "+" + mNameBQ.value + "+" + mNameBR.value
                        ;
                        //console.log("There values are posted :"+input);
                        
                        SimpleServings.UI.Page.AsynchronousSave.SaveInput(input, SucceededCallback);
                    }

                    // This is the callback function that processes the Web Service return value.     
                    function SucceededCallback(result) {
                        var divPreview = document.getElementById("Preview");
                        divPreview.innerHTML = result;
                    }
                    // execute SaveUserInput for every 10 sec, timeout value is in miliseconds
                   // window.setInterval('SaveUserInput()', 10000);
                    SaveUserInput();

                    // AUTOSAVE ENDS
                }
            });
        }
    }

};
getMenuTypeId();
$(initDragDrop);
