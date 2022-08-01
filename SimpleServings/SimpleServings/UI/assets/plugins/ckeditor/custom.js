function fnLinkClick(src) {
    if (document.location.toString().indexOf("EditSiteContent") > -1) {
        if (src) {
            if (src.id.indexOf("lnkAddRule") > -1) {
                jQuery('input[type=submit][name$=Button2]').click();
            }
            else if (src.id.indexOf("lnkInsertCode") > -1) {
                jQuery('input[type=submit][name$=Button3]').click();
            }
            else if (src.id.indexOf("lnkViewRules") > -1) {
                jQuery('input[type=submit][name$=Button4]').click();
            }
            
        }
    }
    return false;
}

function fnOnChng(src) {
    if (document.location.toString().indexOf("EditSiteContent") > -1) {
        if (src) {
            if (src.hasChildNodes()) {  //checkbox
                if (src.firstChild.id.indexOf("cbNutritionalMessage") > -1) {
                    if (src.firstChild.checked) {
                        //jQuery("textarea[id$=ckeNutritionalMessage]").removeClass("msgDisabled");
                        //jQuery("textarea[id$=ckeNutritionalMessage]").removeAttr("disabled");
                        jQuery("textarea[id$=ckeNutritionalMessage]").attr("placeholder", "Enter nutritional message content...");
                        var editor = jQuery('#ctl00_containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
                        editor.setReadOnly(false);
                    }
                    else {
                        jQuery("textarea[id$=ckeNutritionalMessage]").removeAttr("placeholder");
                        var editor = jQuery('#ctl00_containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
                        editor.setReadOnly(true);
                        //jQuery("textarea[id$=ckeNutritionalMessage]").addClass("msgDisabled");
                        //jQuery("textarea[id$=ckeNutritionalMessage]").attr("disabled", "disabled");
                    }
                }
                if (src.firstChild.id.indexOf("cbWelcomeMessage") > -1) {
                    if (src.firstChild.checked) {

                        jQuery("textarea[id$=txtWelcomeMessage]").removeClass("msgDisabled");
                        jQuery("textarea[id$=txtWelcomeMessage]").removeAttr("readonly");
                        jQuery("textarea[id$=txtWelcomeMessage]").attr("placeholder", "Enter welcome text...");

                        //document.getElementById("txtWelcomeMessage").setAttribute("placeholder", "Enter welcome text...");
                        //document.getElementById("txtWelcomeMessage").className = "";
                        //document.getElementById("txtWelcomeMessage").readOnly = false;
                    }
                    else {

                        jQuery("textarea[id$=txtWelcomeMessage]").removeAttr("placeholder");
                        jQuery("textarea[id$=txtWelcomeMessage]").addClass("msgDisabled");
                        jQuery("textarea[id$=txtWelcomeMessage]").attr("readonly", "readonly");
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
}

function fnMsgUpdate(src) {
    if (confirm('Click ok to submit changes')) {
        try {
            if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
                //var editor = jQuery('.jquery_ckeditor').ckeditorGet();
                //alert(editor.value);
                if (src.id.indexOf("btnSubmit2") > -1) {

                    //alert(jQuery('#ctl00_containerhome_ctl00_cbWelcomeMessage').prop('checked'));
                    if (jQuery('#ctl00_containerhome_ctl00_cbWelcomeMessage').prop('checked') == true) {
                        var value = jQuery("textarea[id$=txtWelcomeMessage").val();
                        //alert(jQuery(editor).val());
                        jQuery('input[type=hidden][id$=hdnWelcomeMessage]').val(value);
                    }
                    //var editor1 = jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').ckeditorGet();
                    //alert(jQuery(editor1).val());
                    //alert(jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').val());
                    //jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').save();
                }
                else if (src.id.indexOf("btnSubmit1") > -1) {
                    //alert(jQuery('#ctl00_containerhome_ctl00_cbNutritionalMessage').prop('checked'));
                    if (jQuery('#ctl00_containerhome_ctl00_cbNutritionalMessage').prop('checked') == true) {
                        var editor = jQuery('#ctl00_containerhome_ctl00_ckeNutritionalMessage');
                        //alert(jQuery(editor).val());
                        jQuery('input[type=hidden][id$=hdnNutritionalMessage]').val(jQuery(editor).val());
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
    var str = jQuery("textarea[id$=txtWelcomeMessage").val();
    //if (str.match(/([\<])([^\>]{1,})*([\>])/i) == null) {
    if (str.match(/<[a-z][\s\S]*>/i) == null) {
        if (document.location.toString().indexOf("EditSiteContent") > -1) {
            jQuery("input[type=submit][id$=btnSubmit2]").removeClass("disabled");
            jQuery("input[type=submit][id$=btnSubmit2]").removeAttr("disabled");
        }
        else {
            jQuery("input[type=submit][id$=btnWelcomeMessage]").removeClass("disabled");
            jQuery("input[type=submit][id$=btnWelcomeMessage]").removeAttr("disabled");
        }

        y.IsValid = true;
    }
    else {
        if (document.location.toString().indexOf("EditSiteContent") > -1) {
            jQuery("input[type=submit][id$=btnSubmit2]").addClass("disabled");
            jQuery("input[type=submit][id$=btnSubmit2]").attr("disabled", "disabled");
        }
        else {
            jQuery("input[type=submit][id$=btnWelcomeMessage]").addClass("disabled");
            jQuery("input[type=submit][id$=btnWelcomeMessage]").attr("disabled", "disabled");
        }
        y.IsValid = false;
    }
}

function isIEBrowser() {
    //alert("User Agent: " + window.navigator.userAgent + "\nUser Language: " + window.navigator.userLanguage);

    if (window.navigator.userAgent.indexOf("MSIE") > 0 || window.navigator.userAgent.indexOf("Trident") > 0 ||
        window.navigator.userAgent.indexOf("Edge") > 0) {
        return true;
    }
    else {
        return false;
    }
}

//jQuery(document).ready(function () {
    //jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').on('load',
    //    function (e) {
    //        alert(e);
    //        fnLoad(this);
    //    });

var isVisible = false;
var clickAway = false;
var InitPopver = function () {

    if (jQuery('span[id$=lblRecipeImage]').length > 0) {
        var filename = jQuery('span[id$=lblRecipeImage]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var img = jQuery('<img/>', {
                id: 'imgPopup1',
                width: 250,
                height: 200
            });
            //img.contextmenu(function (e) {
            //    e.preventDefault();
            //});
            img.attr('src', '../images/' + filename.replace('Current Image File:', '').trim() + '?random='+ (new Date()).getTime());
            var html = jQuery(img)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No image loaded";
            }

            //jQuery('span[id$=lblRecipeImage]').attr("data-content", html).popover("show");
            //jQuery('span[id$=lblRecipeImage]').attr("data-content", jQuery("img[id$=imgRecipe]").prop("src")).popover("show");

            jQuery('span[id$=lblRecipeImage]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Recipe Image</strong>",
                content: html,
                placement: 'bottom',
                trigger: 'manual'
            }).click(function(e) {
                jQuery(this).popover('show');
                jQuery('.popover-title').append('<button type="button" class="btn floatR close">&times;</button>');
                jQuery('.close').click(function (e) {
                    jQuery('span[id$=lblRecipeImage]').popover('hide');
                });

                isVisible = true;
                clickAway = false;
                e.preventDefault();
            });
        }
        //jQuery('span[id$=lblRecipeImage]').hover(
        //       function () {
        //           jQuery('span[id$=lblRecipeImage]').popover('show');
        //       },
        //       function () {
        //           jQuery('span[id$=lblRecipeImage]').popover('hide');
        //       }
        //);
    }

    //if (jQuery('span[id$=lblRecipePrintFile]').length > 0) {
    //    var filename = jQuery('span[id$=lblRecipePrintFile]')[0].outerText;
    //    if (filename != null && filename != undefined && filename.length > 0) {
    //        var a = jQuery('<a/>', {
    //            href: '../PDF/' + filename.replace('Current Print File:', '').trim(),
    //            title: 'View recipe print file',
    //            target: '_blank',
    //            text: 'View recipe print file'
    //        });
    //        //jQuery(a)[0].outerText = 'view recipe print file';
    //        var html = jQuery(a)[0].outerHTML;
    //        if (html == null || html == undefined || html == "") {
    //            html = "No print file loaded";
    //        }
    //        jQuery('span[id$=lblRecipePrintFile]').popover({
    //            trigger: 'manual',
    //            html: true,
    //            title: "<strong>Current Recipe Print File</strong>",
    //            content: html,
    //            placement: 'bottom'
    //        });
    //    }
    //    jQuery('span[id$=lblRecipePrintFile]').hover(
    //           function () {
    //               jQuery('span[id$=lblRecipePrintFile]').popover('show');
    //           },
    //           function () {
    //               jQuery('span[id$=lblRecipePrintFile]').popover('hide');
    //           }
    //    );
    //}

    if (jQuery('span[id$=lblWelcomeImage]').length > 0) {
        var filename = jQuery('span[id$=lblWelcomeImage]')[0].outerText;
        if (filename != null && filename != undefined && filename.length > 0) {
            var img = jQuery('<img/>', {
                id: 'imgPopup2',
                width: 300,
                height: 180,
            });
            //img.contextmenu(function (e) {
            //    e.preventDefault();
            //});
            img.attr('src', '../assets/img/gallery/' + filename.replace('Current Image File:', '').trim() + '?random=' + (new Date()).getTime());
            var html = jQuery(img)[0].outerHTML;
            if (html == null || html == undefined || html == "") {
                html = "No image loaded";
            }

            jQuery('span[id$=lblWelcomeImage]').popover({
                trigger: 'manual',
                html: true,
                title: "<strong>Current Welcome Image</strong>",
                content: html,
                placement: 'bottom',
                trigger: 'manual'
            }).click(function(e) {
                jQuery(this).popover('show');
                jQuery('.popover-title').append('<button type="button" class="btn floatR close">&times;</button>');
                jQuery('.close').click(function (e) {
                    jQuery('span[id$=lblWelcomeImage]').popover('hide');
                });

                isVisible = true;
                clickAway = false;

                e.preventDefault();
            });
        }

        //jQuery('span[id$=lblWelcomeImage]').hover(
        //       function () {
        //           jQuery('span[id$=lblWelcomeImage]').popover('show');
        //       },
        //       function () {
        //           jQuery('span[id$=lblWelcomeImage]').popover('hide');
        //       }
        //);
    }

    //if (jQuery('span[id$=lblMsgFile]').length > 0) {
    //    var filename = jQuery('span[id$=lblMsgFile]')[0].outerText;
    //    if (filename != null && filename != undefined && filename.length > 0) {
    //        var a = jQuery('<a/>', {
    //            href: '../PDF/' + filename.replace('Current File:', '').trim(),
    //            title: 'View print file',
    //            target: '_blank',
    //            text: 'View print file'
    //        });
    //        //jQuery(a)[0].outerText = 'view recipe print file';
    //        var html = jQuery(a)[0].outerHTML;
    //        if (html == null || html == undefined || html == "") {
    //            html = "No print file loaded";
    //        }
    //        jQuery('span[id$=lblMsgFile]').popover({
    //            trigger: 'manual',
    //            html: true,
    //            title: "<strong>Current Print File</strong>",
    //            content: html,
    //            placement: 'bottom'
    //        });
    //    }
    //    jQuery('span[id$=lblMsgFile]').hover(
    //           function () {
    //               jQuery('span[id$=lblMsgFile]').popover('show');
    //           },
    //           function () {
    //               jQuery('span[id$=lblMsgFile]').popover('hide');
    //           }
    //    );
    //}
    jQuery(document).click(function (e) {
        if (isVisible & clickAway) {
            jQuery('span[id$=lblRecipeImage]').popover('hide');
            jQuery('span[id$=lblWelcomeImage]').popover('hide');
            isVisible = clickAway = false;
        }
        else {
            clickAway = true;
        }

    });

};

//CKEDITOR.replace('editor1');
var Init = function () {
    if (isIEBrowser() == true) {
        //alert("IE Browser");
        if (document.location.toString().indexOf("EditSiteContent") > -1) {
            var txtarea = jQuery("textarea[id$=txtWelcomeMessage]");
            if (txtarea != null && txtarea != undefined && txtarea.length > 0) {
                jQuery(txtarea).attr("placeholder", "Enter welcome text...");
                jQuery(txtarea).addClass("ui-widget-content");
                jQuery(txtarea).resizable();
            }
        }
    }
    //else {
    //    alert("Non-IE Browser");
    //}

    if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
        var editorObj, editor;
        editorObj = jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage');
        if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
            jQuery(editorObj).ckeditor();
            editor = jQuery(editorObj).ckeditorGet();
            editor.setReadOnly(true);
        }
        else {
            editorObj = jQuery('#ctl00_containerhome_ctl00_ckeNutritionalMessage');
            if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
                jQuery(editorObj).ckeditor();
                editor = jQuery(editorObj).ckeditorGet();
                editor.setReadOnly(true);
            }
            else {
                editorObj = jQuery('textarea[id$=ckeNutritionalMessage]');
                if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
                    jQuery(editorObj).ckeditor();
                    editor = jQuery(editorObj).ckeditorGet();
                    editor.setReadOnly(true);
                }
            }
        }

        if (editor != null && editor != undefined) {
            CKEDITOR.editorConfig(editor.config);
        }
    }

    if (document.location.toString().indexOf("EditSiteContent") > -1) {
        this.InitPopver();
    }
};

