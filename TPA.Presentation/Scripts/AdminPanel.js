
$(function () {
    $(".phoneFormat").inputmask({ "mask": "+(999) 999-999999" });
});

$(function () {

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    });
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });

});

$('.numbersOnly').keyup(function () {
    this.value = this.value.replace(/[^0-9\.]/g, '');
});


$('.phoneNumber').keyup(function () {
    this.value = this.value.replace(/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/, '');
});

function arabicCharacters(event, crtl) {

    if (crtl != null && crtl != undefined && crtl.attributes.maxlength != undefined) {
        var length = crtl.value.length;
        var maxLength = crtl.attributes.maxlength.value;

        if (length >= maxLength) {
            event.preventDefault();
            return false;
        }
    }

    var seek = 0;
    var addL = false;
    if (event.which == 13 || event.which == 42 || event.which == 45) {
        event.preventDefault();
        return false;
    }

    if (event.which == 38 || event.which == 94 || event.which == 37 || event.which == 36) {
        event.preventDefault();
        return false;
    }
    if (event.which == 43 || event.which == 95 || event.which == 41 || event.which == 40) {
        event.preventDefault();
        return false;
    }
    if (event.which == 61 || event.which == 92 || event.which == 64 || event.which == 33 || event.which == 35) {
        event.preventDefault();
        return false;
    }
    if (event.which == 60 || event.which == 62 || event.which == 63 || event.which == 34) {
        event.preventDefault();
        return false;
    }

    if (event.which > 47 && event.which < 59) {
        event.preventDefault();
        return false;
    }
    else if (event.which > 95 && event.which < 123) {
        seek = 96;
    }
    else if (event.which > 64 && event.which < 91)
        seek = 64;
    if (event.which == 98 || event.which == 66 || event.which == 71 || event.which == 84)
        addL = true;
    if (seek > 0) {
        if (event.shiftKey) {
            event.preventDefault();
            insertAtCaret(event.srcElement.id, String.fromCharCode(shftLatinKeys[event.which - seek]))
        }
        else {
            event.preventDefault();
            insertAtCaret(event.srcElement.id, String.fromCharCode(latinKeys[event.which - seek]))
        }
        if (addL) {
            event.preventDefault();
            insertAtCaret(event.srcElement.id, String.fromCharCode(1604))
        }
    }
    else {
        for (var i = 0; i < specialKeys[0].length; i++) {
            if (specialKeys[0][i] == event.which) {
                event.preventDefault();
                insertAtCaret(event.srcElement.id, String.fromCharCode(specialKeys[1][i]))
                break;
            }
        }
    }
}

var latinKeys = new Array(1584, 1588, 1575, 1572, 1610, 1579, 1576, 1604, 1575, 1607, 1578, 1606, 1605, 1577, 1609, 1582, 1581, 1590, 1602, 1587, 1601, 1593, 1585, 1589, 1569, 1594, 1574);
var shftLatinKeys = new Array(1617, 1616, 1570, 125, 93, 1615, 91, 1571, 1571, 247, 1600, 1548, 47, 8271, 1570, 215, 1563, 1614, 1612, 1613, 1573, 8216, 123, 1611, 1618, 1573, 126);
var specialKeys = new Array(new Array(32, 39, 44, 46, 47, 59, 91, 93, 126, 40, 41, 123, 125, 58, 34, 60, 62, 63), new Array(32, 1591, 1608, 1586, 1592, 1603, 1580, 1583, 1617, 41, 40, 60, 62, 58, 34, 44, 46, 1567));

function insertAtCaret(areaId, text) {
    var txtarea = document.getElementById(areaId);
    var scrollPos = txtarea.scrollTop;
    var strPos = 0;
    var br = ((txtarea.selectionStart || txtarea.selectionStart == '0') ?
        "ff" : (document.selection ? "ie" : false));
    if (br == "ie") {
        txtarea.focus();
        var range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        strPos = range.text.length;
    }
    else if (br == "ff") strPos = txtarea.selectionStart;

    var front = (txtarea.value).substring(0, strPos);
    var back = (txtarea.value).substring(strPos, txtarea.value.length);
    txtarea.value = front + text + back;
    strPos = strPos + text.length;
    if (br == "ie") {
        txtarea.focus();
        var range = document.selection.createRange();
        range.moveStart('character', -txtarea.value.length);
        range.moveStart('character', strPos);
        range.moveEnd('character', 0);
        range.select();
    }
    else if (br == "ff") {
        txtarea.selectionStart = strPos;
        txtarea.selectionEnd = strPos;
        txtarea.focus();
    }
    txtarea.scrollTop = scrollPos;
}


function SelectControlLanguage(event) {
    if (languageId == 1) {
        OnlyCharacters(event);
    }
    else {
        arabicCharacters(event);
    }
}


function OnlyCharacters(e) {
    if (e.keyCode != 13) {
        if (((e.keyCode >= 65) && (e.keyCode <= 90)) || ((e.keyCode >= 97) && (e.keyCode <= 122)) || e.keyCode == 32) {
            e.returnValue = true;
        }
        else {
            e.returnValue = false;
            e.preventDefault();
        }
    }
    else {
        e.returnValue = false;
        e.preventDefault();
    }
}