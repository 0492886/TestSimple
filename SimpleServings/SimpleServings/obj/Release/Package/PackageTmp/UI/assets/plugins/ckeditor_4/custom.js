function fnLinkClick(src) {
    if (src) {
        if (src.id.indexOf("lnkAddRule") > -1) {
            $('input[type=submit][name$=Button2]').click();
        }
        else if (src.id.indexOf("lnkInsertCode") > -1) {
            $('input[type=submit][name$=Button3]').click();
        }
        else if (src.id.indexOf("lnkViewRules") > -1) {
            $('input[type=submit][name$=Button4]').click();
        }
        return false;
    }
}

function fnOnChange(src) {
    if (src) {
        if (src.hasChildNodes()) {  //checkbox
            if (src.firstChild.id.indexOf("cbNutritionalMessage") > -1) {
                if (src.firstChild.checked) {
                    //$("textarea[id$=ckeNutritionalMessage]").removeClass("msgDisabled");
                    //$("textarea[id$=ckeNutritionalMessage]").removeAttr("disabled");
                    $("textarea[id$=ckeNutritionalMessage]").attr("placeholder", "Enter nutritional message content...");
                    var editor = $('#ctl00_containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
                    editor.setReadOnly(false);
                }
                else {
                    $("textarea[id$=ckeNutritionalMessage]").removeAttr("placeholder");
                    var editor = $('#ctl00_containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
                    editor.setReadOnly(true);
                    //$("textarea[id$=ckeNutritionalMessage]").addClass("msgDisabled");
                    //$("textarea[id$=ckeNutritionalMessage]").attr("disabled", "disabled");
                }
            }
            if (src.firstChild.id.indexOf("cbWelcomeMessage") > -1) {
                if (src.firstChild.checked) {

                    $("textarea[id$=txtWelcomeMessage]").removeClass("msgDisabled");
                    $("textarea[id$=txtWelcomeMessage]").removeAttr("readonly");
                    $("textarea[id$=txtWelcomeMessage]").attr("placeholder", "Enter welcome text...");
                    //document.getElementById("txtWelcomeMessage").setAttribute("placeholder", "Enter welcome text...");
                    //document.getElementById("txtWelcomeMessage").className = "";
                    //document.getElementById("txtWelcomeMessage").readOnly = false;
                }
                else {
                    $("textarea[id$=txtWelcomeMessage]").removeAttr("placeholder");
                    $("textarea[id$=txtWelcomeMessage]").addClass("msgDisabled");
                    $("textarea[id$=txtWelcomeMessage]").attr("readonly", "readonly");
                }
            }
        }
        else if (src.value.trim() != "") {  //fileupload
            var regexext = (src.id.indexOf("fuRecipeImage") > -1) ? /^(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])|.*\.([Gg][Ii][Ff])$)/
                : (src.id.indexOf("fuWelcomeImage") > -1) ? /^(.*\.([Jj][Pp][Gg])$)/ : /^(.*\.([Pp][Dd][Ff])$)/;



            if (src.id.indexOf("fuRecipeImage") > -1) {
                if (!regexext.test(src.value.trim())) {
                    alert("Only .jpg, .jpeg, .gif and .png files allowed");
                    src.value = "";
                }
            }
            else if (src.id.indexOf("fuWelcomeImage") > -1) {
                if (!regexext.test(src.value.trim())) {
                    alert("Only .jpg files allowed");
                    src.value = "";
                }
            }
            else if (src.id.indexOf("fuRecipePrintFile") > -1) {
                if (!regexext.test(src.value.trim())) {
                    alert("Only .pdf files allowed");
                    src.value = "";
                }
            }
            else if (src.id.indexOf("fuMessage") > -1) {
                //if (document.getElementById("txtNutritionalMessage").value == "") {
                //    alert("nutritional message title required");
                //}
                //else {
                if (!regexext.test(src.value.trim())) {
                    alert("Only .pdf files allowed");
                    src.value = "";
                }
                //}
            }
        }
    }
}

function fnMsgUpdate(src) {
    if (confirm('Click ok to submit changes')) {
        try {
            if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
                //var editor = $('.jquery_ckeditor').ckeditorGet();
                //alert(editor.value);
                if (src.id.indexOf("btnSubmit2") > -1) {

                    //alert($('#ctl00_containerhome_ctl00_cbWelcomeMessage').prop('checked'));
                    if ($('#ctl00_containerhome_ctl00_cbWelcomeMessage').prop('checked') == true) {
                        var value = $("textarea[id$=txtWelcomeMessage").val();
                        //alert($(editor).val());
                        $('input[type=hidden][id$=hdnWelcomeMessage]').val(value);
                    }
                    //var editor1 = $('#ctl00_containerhome_ctl00_ckeWelcomeMessage').ckeditorGet();
                    //alert($(editor1).val());
                    //alert($('#ctl00_containerhome_ctl00_ckeWelcomeMessage').val());
                    //$('#ctl00_containerhome_ctl00_ckeWelcomeMessage').save();
                }
                else if (src.id.indexOf("btnSubmit1") > -1) {
                    //alert($('#ctl00_containerhome_ctl00_cbNutritionalMessage').prop('checked'));
                    if ($('#ctl00_containerhome_ctl00_cbNutritionalMessage').prop('checked') == true) {
                        var editor = $('#ctl00_containerhome_ctl00_ckeNutritionalMessage');
                        //alert($(editor).val());
                        $('input[type=hidden][id$=hdnNutritionalMessage]').val($(editor).val());
                    }
                }
                else {
                    throw new Error("invalid request");
                }
            }
        }
        catch (e) {
            alert(e.message);
        }
        return true;
    }
    else {
        return false;
    }
}

function Validate(x, y) {
    var str = $("textarea[id$=txtWelcomeMessage").val();
    if (str.match(/([\<])([^\>]{1,})*([\>])/i) == null) {
        $("input[type=submit][id$=btnSubmit2]").removeClass("disabled");
        $("input[type=submit][id$=btnSubmit2]").removeAttr("disabled");
        y.IsValid = true;
    }
    else {
        $("input[type=submit][id$=btnSubmit2]").addClass("disabled");
        $("input[type=submit][id$=btnSubmit2]").attr("disabled", "disabled");
        y.IsValid = false;
    }
}

function isIEBrowser() {
    if (window.navigator.userAgent.indexOf("MSIE") > 0 || window.navigator.userAgent.indexOf("Trident") > 0 ||
        window.navigator.userAgent.indexOf("Edge") > 0) {
        return true;
    }
    else {
        return false;
    }
}

var InitPopvers = function () {
    if ($('span[id$=lblRecipeImage]').length > 0) {
        var filename = $('span[id$=lblRecipeImage]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var img = $('<img/>', {
                id: 'imgPopup1',
                width: 250,
                height: 200,
            });
            img.contextmenu(function (e) {
                e.preventDefault();
            });
            img.attr('src', '../images/' + filename.replace('Current Recipe Image:', '').trim());
            var html = $(img)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No image loaded";
            }

            //$('span[id$=lblRecipeImage]').attr("data-content", html).popover("show");
            //$('span[id$=lblRecipeImage]').attr("data-content", $("img[id$=imgRecipe]").prop("src")).popover("show");

            $('span[id$=lblRecipeImage]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Recipe Image</strong>",
                content: html,
                placement: 'bottom'
            });
        }

        $('span[id$=lblRecipeImage]').hover(
               function () {
                   $('span[id$=lblRecipeImage]').popover('show');
               },
               function () {
                   $('span[id$=lblRecipeImage]').popover('hide');
               }
        );
    }

    if ($('span[id$=lblRecipePrintFile]').length > 0) {
        var filename = $('span[id$=lblRecipePrintFile]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var a = $('<a/>', {
                href: '../PDF/' + filename.replace('Current Print File:', '').trim(),
                title: 'View recipe print file',
                target: '_blank',
                text: 'View recipe print file'
            });
            //$(a)[0].outerText = 'view recipe print file';
            var html = $(a)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No print file loaded";
            }
            $('span[id$=lblRecipePrintFile]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Recipe Print File</strong>",
                content: html,
                placement: 'bottom'
            });
        }
        $('span[id$=lblRecipePrintFile]').hover(
               function () {
                   $('span[id$=lblRecipePrintFile]').popover('show');
               },
               function () {
                   $('span[id$=lblRecipePrintFile]').popover('hide');
               }
        );
    }

    if ($('span[id$=lblWelcomeImage]').length > 0) {
        var filename = $('span[id$=lblWelcomeImage]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var img = $('<img/>', {
                id: 'imgPopup2',
                width: 500,
                height: 200,
            });
            img.contextmenu(function (e) {
                e.preventDefault();
            });
            img.attr('src', '../assets/img/gallery/' + filename.replace('Current Image File:', '').trim());
            var html = $(img)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No image loaded";
            }

            $('span[id$=lblWelcomeImage]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Welcome Image</strong>",
                content: html,
                width: 500,
                placement: 'bottom'
            });
        }

        $('span[id$=lblWelcomeImage]').hover(
               function () {
                   $('span[id$=lblWelcomeImage]').popover('show');
               },
               function () {
                   $('span[id$=lblWelcomeImage]').popover('hide');
               }
        );
    }

    if ($('span[id$=lblMsgFile]').length > 0) {
        var filename = $('span[id$=lblMsgFile]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var a = $('<a/>', {
                href: '../PDF/' + filename.replace('Current File:', '').trim(),
                title: 'View print file',
                target: '_blank',
                text: 'View print file'
            });
            //$(a)[0].outerText = 'view recipe print file';
            var html = $(a)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No print file loaded";
            }
            $('span[id$=lblMsgFile]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Print File</strong>",
                content: html,
                placement: 'bottom'
            });
        }
        $('span[id$=lblMsgFile]').hover(
               function () {
                   $('span[id$=lblMsgFile]').popover('show');
               },
               function () {
                   $('span[id$=lblMsgFile]').popover('hide');
               }
        );
    }

};

//$(document).ready(function () {
    //$('#ctl00_containerhome_ctl00_ckeWelcomeMessage').on('load',
    //    function (e) {
    //        alert(e);
    //        fnLoad(this);
    //    });

//CKEDITOR.replace('editor1');
var Init = function () {
    //alert("User Agent: " + window.navigator.userAgent + "\nUser Language: " + window.navigator.userLanguage);
    if (isIEBrowser() == true) {
        //alert("IE Browser");
        var txtarea = $("textarea[id$=txtWelcomeMessage]");
        if (txtarea != null && txtarea != undefined && txtarea.length > 0) {
            $(txtarea).attr("placeholder", "Enter welcome text...");
            $(txtarea).addClass("ui-widget-content");
            $(txtarea).resizable();
        }
    }
    //else {
    //    alert("Non-IE Browser");
    //}

    if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
        var editorObj, editor;
        editorObj = $('#ctl00_containerhome_ctl00_ckeWelcomeMessage');
        if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
            $(editorObj).ckeditor();
            editor = $(editorObj).ckeditorGet();
            //alert(editor.checkDirty());
        }
        else {
            editorObj = $('#ctl00_containerhome_ctl00_ckeNutritionalMessage');
            if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
                $(editorObj).ckeditor();
                editor = $(editorObj).ckeditorGet();
                //alert(editor.checkDirty());
            }
        }

        if (editor != null && editor != undefined) {
            CKEDITOR.editorConfig(editor.config);
        }
    }

    this.InitPopvers();

};



//});