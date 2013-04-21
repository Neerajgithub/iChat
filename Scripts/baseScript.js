/// <reference path="jquery-1.4.1-vsdoc.js" />

function addFields() {
    var container = $("#containerNode");
    var no = container.children().length + 1;
    var $ctrl = $('<input/>').attr({ type: 'text', id: 'desc' + no, name: 'desc' + no, style: 'width:100px; display:none;' }).addClass('inpText');
    container.append($ctrl);
    $ctrl.fadeIn("slow");
    $ctrl.focus();
//    $("input", container).focusin(function () {
//        $(this).focusout(concateAll);
    //    });
    $("input", container).focusout(concateAll);
}

function restoreVal(v) {
    var container = $("#containerNode");
    if (v != "") {
        var str = v.split(":");
        if (str.length > 5) {
            var no = container.children().length + 1;
            for (var j = 0; j < str.length - 5; j++) {
                var $ctrl = $('<input/>').attr({ type: 'text', id: 'desc' + no, name: 'desc' + no, style: 'width:100px;' }).addClass('inpTextDyna');
                container.append($ctrl);
            }
        }
        var elements = container.children();
        for (var i = 0; i < str.length; i++) {
            $(elements[i]).val(str[i]);
        }
    }
    else {
        var elements1 = container.children();
        for (var j = 0; j < elements1.length; j++) {
            $(elements1[j]).val("");
        }
    }

//    $("input", container).focusin(function () {
//        $(this).focusout(concateAll);
//    });
    $("input", container).focusout(concateAll);
}

function concateAll() {
    var elements = $("#containerNode").children();
    var completeDesc = "";
    for (var i = 0; i < elements.length; i++) {
        var strVal = $(elements[i]).val();
        if (strVal.replace(/ /g, "") != "") {
            completeDesc += strVal + ":";
        }
    }
    $("#hdValues").val(completeDesc.substring(0, completeDesc.length - 1));
}

function checktypepg() {
    var error = "<ul>";
    if ($("#ddlProdType").val().toUpperCase() == "SELECT") {
        error += "<li>Please Select Product Type.</li>";
    }
    if ($("#hdValues").val().replace(/ /g, "") == "" && $("#txtDesc").val().replace(/ /g, "") == "") {
        error += "<li>Please Fill Description Fomate.<br /></li>OR<br /><li>Type Description.</li>";
    }
    if (error != "<ul>") {
        error += "</ul>";
        $("#infoDiv").html("").hide();
        $("#errorDiv").html(closeBtn() + error).fadeIn("normal");
        return false;
    }
    else {
        $("#infoDiv").html("").hide();
        $("#errorDiv").html("").hide();
        return true;
    }
}

function resettypepg() {
    $("#infoDiv").html("").hide();
    $("#errorDiv").html("").hide();
    document.getElementById("txtProdType").value = "";
    document.getElementById("txtDesc").value = "";
    $("#containerNode").html('<input type="text" id="desc1" name="desc1" class="inpTextDyna" style="width: 100px;" /><input type="text" id="desc2" name="desc2" class="inpTextDyna" style="width: 100px;" /><input type="text" id="desc3" name="desc3" class="inpTextDyna" style="width: 100px;" /><input type="text" id="desc4" name="desc4" class="inpTextDyna" style="width: 100px;" /><input type="text" id="desc5" name="desc5" class="inpTextDyna" style="width: 100px;" />');
    document.getElementById("hdValues").value = "";
    restoreVal(document.getElementById("hdValues").value);
    return false;
}

function showError(err) {
    $("#errorDiv").html("").hide();
    $("#errorDiv").html(closeBtn() + unescape(err)).fadeIn("normal", function () {
        scrollTo(0, 0);
    });
}

function showInfo(inf) {
    $("#infoDiv").html("").hide();
    $("#infoDiv").html(closeBtn() + unescape(inf)).fadeIn("normal", function () {
        scrollTo(0, 0);
    });
}

function showWarn(warn) {
    $("#warnDiv").html("").hide();
    $("#warnDiv").html(closeBtn() + unescape(warn)).fadeIn("normal", function () {
        scrollTo(0, 0);
    });
}

function showSucc(succ) {
    $("#succDiv").html("").hide();
    $("#succDiv").html(closeBtn() + unescape(succ)).fadeIn("normal", function () {
        scrollTo(0, 0);
    });
}

function checksizepg() {
    var error = "<ul>";
    if ($("#ddlSizeType").val().toUpperCase() == "SELECT") {
        error += "<li>Please Select Size Type.</li>";
    }
    if ($("#txtSize").val().replace(/ /g, "") == "") {
        error += "<li>Please Fill Size Name.</li>";
    }
    if (error != "<ul>") {
        error += "</ul>";
        $("#infoDiv").html("").hide();
        $("#errorDiv").html(closeBtn() + error).fadeIn("normal");
        return false;
    }
    else {
        $("#infoDiv").html("").hide();
        $("#errorDiv").html("").hide();
        return true;
    }
}

function resetsizepg() {
    $("#infoDiv").html("").hide();
    $("#errorDiv").html("").hide();
    document.getElementById("txtSize").value = "";
    document.getElementById("txtDesc").value = "";
    document.getElementById("ddlSizeType").value = "Select";
    return false;
}

function closeMe(object) {
    $(object).parent().fadeOut("normal");
}

function closeBtn() {
    return "<a href=\"javascript:void(0)\" onclick=\"javascript:closeMe(this);\"></a>";
}


function NumericOnly(control) {
    $(control).keypress(function (event) {
        return /\d/.test(String.fromCharCode(event.keyCode));
    });
}

function CharOnly(control1) {

    $(control1).keypress(function (event) {        
        return /^[a-zA-Z]/.test(String.fromCharCode(event.keyCode));

    });

}

function conf() {
    var userSelect = window.confirm("Do you really want to delete this record?\nClick OK to confirm.");
    return userSelect;
}

function ChangeRefresh(obj) {
    $(obj).attr("src", "../Images/spinner.gif");
}

function checkMobLength1(val, args) {
    if (args.Value.length < 10) {
        args.IsValid = false;
    }
}

function checkMobLength(val, args) {
    if (args.Value.length < 10) {
        args.IsValid = false;
    }
    checkMobNo(args.IsValid, args.Value);
    //alert(args.Value);
}

function checkSIMLength(val, args) {
    if (args.Value.length < 10) {
        args.IsValid = false;
    }
    checkSIMNo(args.IsValid, args.Value);
}

function checkMobNo(isValid, args) {
    if (isValid) {
        $("#txtMobNoSpan").html('<span class="Checkloader"></span>');
        makeCheckRequest("mob",args);
    }
    else {
        $("#txtMobNoSpan").empty();
    }
}

function checkSIMNo(isValid, args) {
    if (isValid) {
        $("#txtSIMNoSpan").html('<span class="Checkloader"></span>');
        makeCheckRequest("sim",args);
    }
    else {
        $("#txtSIMNoSpan").empty();
    }
}

function checkHideLoader(val, str) {
    if (str == "mob" && val.length == 0) {
        $("#txtMobNoSpan").empty();
    }
    else if (str == "sim" && val.length == 0) {
        $("#txtSIMNoSpan").empty();
    }
}

function makeCheckRequest(ctr,args) {
    if (ctr == "mob") {
        $.ajax({
            url: "../UtilityScript/ChechConnections.ashx",
            data: { check: "mobno", mobno: args },
            cache: false,
            success: function (data) {
                $("#txtMobNoSpan").html(data);
                //alert(data);
            },
            error: function (e) {
                //called when there is an error
                //console.log(e.message);
            }
        });
    }
    else if (ctr == "sim") {
        $.ajax({
            url: "../UtilityScript/ChechConnections.ashx",
            data: { check: "simno", simno: args },
            cache: false,
            success: function (data) {
                $("#txtSIMNoSpan").html(data);
                //alert(data);
            },
            error: function (e) {
                //called when there is an error
                //console.log(e.message);
            }
        });
    }
}