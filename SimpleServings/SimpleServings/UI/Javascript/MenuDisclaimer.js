function EnableSubmit(val) {
    var submit = document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_btnAgree");
    if (val.checked) {
        submit.disabled = false;
    }
    else {
        submit.disabled = true;
    }
}

function Init() {
    window.alert("Calling here");
    document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_chxAgree").checked = false;
    document.getElementById("ctl00_containerhome_MenuStatusChangeSubmission1_btnAgree").disabled = true;
}
