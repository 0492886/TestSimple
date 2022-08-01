//Custom JScript support for Home & EditSiteContent screens - (10-06-16)
/*  validate text-only entry  */
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
/*  validate file upload  */
function fnOnChange(src) {
	if (src) {
		if (src.hasChildNodes()) {  //checkbox
			if (src.firstChild.id.indexOf("cbMessageContent") > -1) {
				if (src.firstChild.checked) {
					if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
						jQuery("textarea[id$=ckeNutritionalMessage]").attr("placeholder", "Enter nutritional message content...");
						var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
						editor.setReadOnly(false);
					}
					else {
						document.getElementById("txtMessageContent").setAttribute("placeholder", "Enter message content...");
						document.getElementById("txtMessageContent").className = "";
						document.getElementById("txtMessageContent").readOnly = false;
					}
				}
				else {
					if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
						jQuery("textarea[id$=ckeNutritionalMessage]").removeAttr("placeholder");
						var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
						editor.setReadOnly(true);
					}
					else {
						document.getElementById("txtMessageContent").removeAttribute("placeholder");
						document.getElementById("txtMessageContent").className = "msgDisabled";
						document.getElementById("txtMessageContent").readOnly = true;
					}
				}
			}
			else if (src.firstChild.id.indexOf("cbNutritionalMessage") > -1) {
				if (src.firstChild.checked) {
					jQuery("textarea[id$=ckeNutritionalMessage]").attr("placeholder", "Enter nutritional message content...");
					var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
				   // var editor = jQuery('#containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
					editor.setReadOnly(false);
				}
				else {
					jQuery("textarea[id$=ckeNutritionalMessage]").removeAttr("placeholder");
					var editor = jQuery('#containerhome_ctl00_ckeNutritionalMessage').ckeditorGet();
					editor.setReadOnly(true);
				}
			}
			else if (src.firstChild.id.indexOf("cbWelcomeMessage") > -1) {
				if (src.firstChild.checked) {
					//document.getElementById("txtWelcomeMessage").setAttribute("placeholder", "Enter welcome text...");
					//document.getElementById("txtWelcomeMessage").className = "";
					//document.getElementById("txtWelcomeMessage").readOnly = false;
					jQuery("textarea[id$=txtWelcomeMessage]").removeClass("msgDisabled");
					jQuery("textarea[id$=txtWelcomeMessage]").removeAttr("readonly");
					jQuery("textarea[id$=txtWelcomeMessage]").attr("placeholder", "Enter welcome text...");
				}
				else {
					//document.getElementById("txtWelcomeMessage").removeAttribute("placeholder");
					//document.getElementById("txtWelcomeMessage").className = "msgDisabled";
					//document.getElementById("txtWelcomeMessage").readOnly = true;
					jQuery("textarea[id$=txtWelcomeMessage]").removeAttr("placeholder");
					jQuery("textarea[id$=txtWelcomeMessage]").addClass("msgDisabled");
					jQuery("textarea[id$=txtWelcomeMessage]").attr("readonly", "readonly");
				}
			}
		}
		else if (src.value.trim() != "") {  //fileupload
			var regexext = (src.id.indexOf("fuRecipeImage") > -1) ? /^(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])|.*\.([Pp][Nn][Gg])|.*\.([Gg][Ii][Ff])$)/
				: (src.id.indexOf("fuWelcomeImage") > -1 || src.id.indexOf("fupWelcomeImage") > -1) ? /^(.*\.([Jj][Pp][Gg])$)/ : /^(.*\.([Pp][Dd][Ff])$)/;
			
			if (src.id.indexOf("fuWelcomeImage") > -1) {
				if (!regexext.test(src.value.trim())) {
					alert("Only .jpg files allowed");
					document.getElementById("fuWelcomeImage").value = "";
				}
			}
			if (src.id.indexOf("fupWelcomeImage") > -1) {
				if (!regexext.test(src.value.trim())) {
					alert("Only .jpg files allowed");
					document.getElementById("fupWelcomeImage").value = "";
				}
			}
			else if (src.id.indexOf("fuRecipeImage") > -1) {
				if (!regexext.test(src.value.trim())) {
					alert("Only .jpg, .jpeg, .gif and .png files allowed");
					document.getElementById("fuRecipeImage").value = "";
				}
			}
			else if (src.id.indexOf("fuRecipePrintFile") > -1) {
				if (!regexext.test(src.value.trim())) {
					alert("Only .pdf files allowed");
					document.getElementById("fuRecipePrintFile").value = "";
				}
			}
			else if (src.id.indexOf("fuMessage") > -1) {
				//if (document.getElementById("txtNutritionalMessage").value == "") {
				//    alert("nutritional message title required");
				//}
				//else {
				if (!regexext.test(src.value.trim())) {
					alert("Only .pdf files allowed");
					document.getElementById("fuMessage").value = "";
				}
				//}
			}
		}
	}
}
/*  validate button click  */
function fnOnClick(src) {
	if (src.id.indexOf("btnFeaturedRecipe") > -1) {
		if (document.getElementById("ddlRecipe").value == "[Select]" ||
			document.getElementById("ddlRecipe").value == "" || document.getElementById("ddlRecipe").value == 0) {
			alert("recipe selection is required");
			return false;
		}
		else if (document.getElementById("fuRecipePrintFile").value == "") {
			alert("recipe print file is required");
			return false;
		}
		else if (document.getElementById("fuRecipeImage").value == "") {
			alert("recipe image file is required");
			return false;
		}
	}
	else if (src.id.indexOf("btnMessage") > -1) {
		if (document.getElementById("txtNutritionalMessage").value == "") {
			alert("nutritional message title required");
			return false;
		}
		else if (document.getElementById("fuMessage").value == "") {
			alert("nutritional message print file required");
			return false;
		}
		else if (document.getElementById("cbMessageContent").checked) {
			if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
				//alert(document.getElementById("ckeNutritionalMessage").value);
				//if (document.getElementById("ckeNutritionalMessage").value == "") {
				//    alert("nutritional message content required");
				//    return false;
				//}
				var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
				var value = null;

				if (editor.checkDirty() == true) {
					value = jQuery("textarea[id$=ckeNutritionalMessage]").val();
					//alert(value);
				}

				if (value == null || value == "") {
					alert("nutritional message content required");
					return false;
				}

				jQuery("input[type=hidden][id$=hdnMessageContent]").val(value);
				//document.getElementById("hdnMessageContent").value = document.getElementById("ckeNutritionalMessage").value;

			}
			else {
				if (document.getElementById("txtMessageContent").value == "") {
					alert("nutritional message content required");
					return false;
				}

				document.getElementById("hdnMessageContent").value = document.getElementById("txtMessageContent").value;
			}
		}
	}
	else if (src.id.indexOf("btnWelcomeMessage") > -1) {
		//if (document.getElementById("fupWelcomeImage").value == "") {
		//    alert("welcome banner image file is required");
		//    return false;
		//}

		if (document.getElementById("cbWelcomeMessage").checked) {
			if (document.getElementById("txtWelcomeMessage").value == "") {
				alert("welcome message is required");
				return false;
			}

			document.getElementById("hdnWelcomeMessage").value = document.getElementById("txtWelcomeMessage").value;
		}
	}
	else if (src.id.indexOf("lnkFeaturedRecipe") > -1) {
		if (document.location.toString().indexOf("EditSiteContent") > -1) {
			jQuery('input[type=submit][name$=Button2]').click();
			return false;
		}
	}
	else if (src.id.indexOf("lnkWelcomeMessage") > -1) {
		if (document.location.toString().indexOf("EditSiteContent") > -1) {
			jQuery('input[type=submit][name$=Button3]').click();
			return false;
		}
	}
	else if (src.id.indexOf("lnkNutritionalMessage") > -1) {
		if (document.location.toString().indexOf("EditSiteContent") > -1) {
			jQuery('input[type=submit][name$=Button4]').click();
			return false;
		}
	}
}
/*  validate messages  */
function fnMsgUpdate(src) {
	if (confirm('Click OK to submit changes')) {
		try {
			if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
				//var editor = jQuery('.jquery_ckeditor').ckeditorGet();
				//alert(editor.value);
				if (src.id.indexOf("btnSubmit2") > -1) {

					
					if (jQuery('containerhome_ctl00_cbWelcomeMessage').prop('checked') == true) {
						var value = jQuery("textarea[id$=txtWelcomeMessage").val();
						//alert(jQuery(editor).val());
						jQuery('input[type=hidden][id$=hdnWelcomeMessage]').val(value);
					}
					//var editor1 = jQuery('#containerhome_ctl00_ckeWelcomeMessage').ckeditorGet();
					//alert(jQuery(editor1).val());
					//alert(jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').val());
					//jQuery('#ctl00_containerhome_ctl00_ckeWelcomeMessage').save();
				}
				else if (src.id.indexOf("btnSubmit1") > -1) {
					//alert(jQuery('#ctl00_containerhome_ctl00_cbNutritionalMessage').prop('checked'));
					//alert("imin");
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

function fnEdit(src) {
	if (src.id == "lnkBtnEdit") {
		src.style.display = "none";
		document.getElementById("lnkBtnCancel").style.display = "block";
		document.getElementById("pnlFeaturedRecipe").style.display = "block";
		document.getElementById("pnlNutritionalMessage").style.display = "none";
		document.getElementById("pnlWelcomeMessage").style.display = "none";

		document.getElementById("ddlRecipe").value = "[Select]";
		document.getElementById("fuRecipeImage").value = "";
		document.getElementById("fuRecipePrintFile").value = "";
		document.getElementById("txtNutritionalMessage").value = "";
		document.getElementById("fuMessage").value = "";
	}
	else if (src.id == "LinkButton1") {
		src.style.display = "none";
		document.getElementById("LinkButton2").style.display = "block";

		//document.getElementById("txtMessageContent").value = document.getElementById("lblNutritionalMessageText").innerHTML;

		document.getElementById("pnlNutritionalMessage").style.display = "block";
		document.getElementById("pnlFeaturedRecipe").style.display = "none";
		document.getElementById("pnlWelcomeMessage").style.display = "none";

		document.getElementById("txtNutritionalMessage").value = "";
		document.getElementById("fuMessage").value = "";

		if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
			//document.getElementById("ckeNutritionalMessage").value = document.getElementById("lblNutritionalMessageText").innerHTML;
			//document.getElementById("ckeNutritionalMessage").className = "msgDisabled";
			//document.getElementById("ckeNutritionalMessage").readOnly = true;
			
			jQuery("textarea[id$=ckeNutritionalMessage]").val(document.getElementById("lblNutritionalMessageText").innerHTML);
			var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
			editor.setReadOnly(true);
		}
		else {
			document.getElementById("txtMessageContent").value = document.getElementById("lblNutritionalMessageText").innerHTML;
			document.getElementById("txtMessageContent").className = "msgDisabled";
			document.getElementById("txtMessageContent").readOnly = true;
		}
		document.getElementById("cbMessageContent").checked = false;
	}
	else if (src.id == "LinkButton6") {
		src.style.display = "none";
		document.getElementById("LinkButton7").style.display = "block";

		document.getElementById("pnlWelcomeMessage").style.display = "block";
		document.getElementById("pnlNutritionalMessage").style.display = "none";
		document.getElementById("pnlFeaturedRecipe").style.display = "none";

		document.getElementById("txtWelcomeMessage").value = document.getElementById("lblDFTATitle").innerHTML;
		document.getElementById("txtWelcomeMessage").className = "msgDisabled";
		document.getElementById("txtWelcomeMessage").readOnly = true;
		document.getElementById("txtWelcomeMessage").checked = false;
	}

	//document.getElementById("LinkButton3").style.display = "block";
	//document.getElementById("pnlFeaturedRecipe").style.display = "block";
	//document.getElementById("pnlPrintFeaturedRecipe").style.display = "block";
}
function fnCancel(src) {
	if (src.id == "lnkBtnCancel" || src.id == "LinkButton3") {

		document.getElementById("lnkBtnCancel").style.display = "none";
		document.getElementById("lnkBtnEdit").style.display = "block";

		//document.getElementById("pnlFeaturedRecipe").style.display = "none";
		document.getElementById("ddlRecipe").value = "[Select]";
		document.getElementById("fuRecipeImage").value = "";
		document.getElementById("fuRecipePrintFile").value = "";
		document.getElementById("txtNutritionalMessage").value = "";
		document.getElementById("fuMessage").value = "";
	}
	else if (src.id == "LinkButton2" || src.id == "LinkButton4") {
		document.getElementById("LinkButton2").style.display = "none";
		document.getElementById("LinkButton1").style.display = "block";

		document.getElementById("txtNutritionalMessage").value = "";
		document.getElementById("fuMessage").value = "";

		if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
			//document.getElementById("ckeNutritionalMessage").value = document.getElementById("lblNutritionalMessageText").innerHTML;
			//document.getElementById("ckeNutritionalMessage").className = "msgDisabled";
			//document.getElementById("ckeNutritionalMessage").readOnly = true;

			jQuery("textarea[id$=ckeNutritionalMessage]").val(document.getElementById("lblNutritionalMessageText").innerHTML);
			var editor = jQuery("textarea[id$=ckeNutritionalMessage]").ckeditorGet();
			editor.setReadOnly(true);
		}
		else {
			document.getElementById("txtMessageContent").value = document.getElementById("lblNutritionalMessageText").innerHTML;
			document.getElementById("txtMessageContent").className = "msgDisabled";
			document.getElementById("txtMessageContent").readOnly = true;
		}
		document.getElementById("cbMessageContent").checked = false;
	}
	else if (src.id == "LinkButton5" || src.id == "LinkButton7") {
		document.getElementById("LinkButton7").style.display = "none";
		document.getElementById("LinkButton6").style.display = "block";

		document.getElementById("txtWelcomeMessage").value = document.getElementById("lblDFTATitle").innerHTML;
		document.getElementById("txtWelcomeMessage").className = "msgDisabled";
		document.getElementById("txtWelcomeMessage").readOnly = true;
		document.getElementById("txtWelcomeMessage").checked = false;
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

/*  show/hide hidden window  */
function freezeScreen(msg) {
	//scroll(0, 0);
	var outerPane = document.getElementById('FreezePane');
	var innerPane = document.getElementById('InnerFreezePane');
	if (outerPane) {
		outerPane.className = 'FreezePaneOn';
		outerPane.onclick = checkFreezePaneClick;
	}
	//if (innerPane) {
	//    innerPane.innerHTML = msg;
	//    outerPane.className = 'InnerFreezePane';
	//}
}
function unFreezeScreen() {
	document.getElementById('FreezePane').className = 'FreezePaneOff';
	document.getElementById('FreezePane').removeAttribute('onclick');
}
function checkFreezePaneClick(event) {
	if (event.target) {
		if (event.target.id == 'FreezePane' && event.target.className == 'FreezePaneOn') {
			document.getElementById("lnkBtnCancel").click();
			document.getElementById("LinkButton2").click();
			document.getElementById("LinkButton5").click();
			unFreezeScreen();
		}
	}
}

/*  refresh home welcome banner image  */
function refreshBanner() {
	var background = '#321710 url("../assets/img/gallery/homeDFTA.jpg?random=' + (new Date()).getTime() + '") no-repeat;';
	jQuery('.dftaHome').css('background', background);
	jQuery('.dftaHome').css('background-size', '100% 100%;');
}

/*  initialize bootstrap popover  */
var isVisible = false;
var clickAway = false;
var InitPopover = function () {

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
			img.attr('src', '../images/' + filename.replace('Current Image File:', '').trim() + '?random=' + (new Date()).getTime());
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
			}).click(function (e) {
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
			}).click(function (e) {
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

/*  initialize custom page elements  */
var Init = function () {

		if (CKEDITOR.instances != null && CKEDITOR.instances != undefined) {
			var editorObj, editor;
			editorObj = jQuery('textarea[id$=ckeNutritionalMessage]');
			if (editorObj != null && editorObj != undefined && editorObj.length > 0) {
				jQuery(editorObj).ckeditor();
				editor = jQuery(editorObj).ckeditorGet();
				editor.setReadOnly(true);
			}

			if (editor != null && editor != undefined) {
				CKEDITOR.editorConfig(editor.config);
			}
		}

		if (document.location.toString().indexOf("EditSiteContent") > -1) {
			if (document.location.toString().indexOf("EditSiteContent") > -1) {
				var txtarea = jQuery("textarea[id$=txtWelcomeMessage]");
				if (txtarea != null && txtarea != undefined && txtarea.length > 0) {
					jQuery(txtarea).attr("placeholder", "Enter welcome text...");
					jQuery(txtarea).addClass("ui-widget-content");
					jQuery(txtarea).resizable();
				}
			}

			InitPopover();
		}
		else {
			setInterval(function () { refreshBanner(); }, 1000);
		}
};