
var _iLeft, _iTop, _iRight, _iBottom;
_iLeft = _iTop = _iRight = _iBottom = 0;

var console = window['console'] ? window['console'] : { 'log': function () { } };
Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', Dynamsoft_OnReady); // Register OnWebTwainReady event. This event fires as soon as Dynamic Web TWAIN is initialized and ready to be used
window.onload = function () {
    if (Dynamsoft) {
        Dynamsoft.WebTwainEnv.Load();
    }
};

Dynamsoft.WebTwainEnv.RegisterEvent('OnWebTwainReady', function () {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    if (DWObject) {
        DWObjectLargeViewer = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainerLargeViewer'); // Get the 2nd Dynamic Web TWAIN object that is embeded in the div with id 'dwtcontrolContainerLargeViewer'
        DWObject.RegisterEvent('OnGetFilePath', OnGetFilePath);
        DWObject.RegisterEvent('OnImageAreaSelected', function (sImageIndex, left, top, right, bottom) {
            _iLeft = left;
            _iTop = top;
            _iRight = right;
            _iBottom = bottom;
        });
        DWObject.RegisterEvent('OnImageAreaDeSelected', function (sImageIndex) {
            _iLeft = _iTop = _iRight = _iBottom = 0;
        });

        document.getElementById('drpdwnSourceList').options.add(new Option('Select a source', 0));
        var count = DWObject.SourceCount;
        for (var i = 0; i < count; i++)
            document.getElementById('drpdwnSourceList').options.add(new Option(DWObject.GetSourceNameItems(i), i + 1));
    }
});

function acquireImage() {
    var selectedSource = document.getElementById("drpdwnSourceList").selectedIndex;
    if (selectedSource > 0) {
        var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
        var status = DWObject.RemoveAllImages();
        if (status) {
            DWObject.IfDisableSourceAfterAcquire = true;
            DWObject.SelectSourceByIndex(selectedSource - 1);
            DWObject.OpenSource();
            DWObject.AcquireImage(onAcquireSuccess, onAcquireFailure);
            resetParams();
        } else {
            alert('Error :' + DWObject.ErrorString);
        }
    }
    else {
        alert('Please select a source');
    }
}

function onAcquireSuccess() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    DWObject.CopyToClipboard(DWObject.CurrentImageIndexInBuffer);
}

function onAcquireFailure(errorCode, errorString) {
    alert('Error :' + errorString);
}

function rotateLeft() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var imgCount = DWObject.HowManyImagesInBuffer;
    if (imgCount == 0) {
        alert('Please upload a Image');
    }
    else {
        var sindex = DWObject.CurrentImageIndexInBuffer;
        var result = DWObject.RotateLeft(sindex);
        if (!result) {
            alert('Error :' + DWObject.ErrorString);
        }
    }
}

function rotateRight() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var imgCount = DWObject.HowManyImagesInBuffer;
    if (imgCount == 0) {
        alert('Please upload a Image');
    }
    else {
        var sindex = DWObject.CurrentImageIndexInBuffer;
        var result = DWObject.RotateRight(sindex);
        if (!result) {
            alert('Error :' + DWObject.ErrorString);
        }
    }
}

function flip() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var imgCount = DWObject.HowManyImagesInBuffer;
    if (imgCount == 0) {
        alert('Please upload a Image');
    }
    else {
        var sindex = DWObject.CurrentImageIndexInBuffer;
        var result = DWObject.Flip(sindex);
        if (!result) {
            alert('Error :' + DWObject.ErrorString);
        }
    }
}

function crop() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var imgCount = DWObject.HowManyImagesInBuffer;
    if (imgCount == 0) {
        alert('Please upload a Image');
    }
    else {
        if (_iLeft != 0 || _iTop != 0 || _iRight != 0 || _iBottom != 0) {
            var result = DWObject.Crop(DWObject.CurrentImageIndexInBuffer, _iLeft, _iTop, _iRight, _iBottom);
            _iLeft = _iTop = _iRight = _iBottom = 0;
            if (!result) {
                alert('Error :' + DWObject.ErrorString);
            }
        }
        else {
            alert('Please select the area to crop.');
        }
    }
}

function revert() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var imgCount = DWObject.HowManyImagesInBuffer;
    if (imgCount == 0) {
        alert('Please upload a Image');
    }
    else {
        var status = DWObject.RemoveAllImages();
        if (status) {
            var result = DWObject.LoadDibFromClipboard();
            _iLeft = _iTop = _iRight = _iBottom = 0;
            if (!result) {
                alert('Error :' + DWObject.ErrorString);
            }
        }
        else {
            alert('Error :' + DWObject.ErrorString);
        }
    }
}

function uploadImage() {
    var result;
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');

    DWObject.IfShowFileDialog = false;
    result = DWObject.ShowFileDialog(false, "JPG|*.jpg", 0, "", "", false, false, 0);
    if (!result) {
        alert('Error :' + DWObject.ErrorString);
    }

}

function OnGetFilePath(bSave, filesCount, index, path, filename) {
    if (bSave === false) {
        if (filesCount > 0) {
            resetParams();
            var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
            DWObject.RemoveAllImages();
            DWObject.LoadImage(path + '\\' + filename);
            DWObject.CopyToClipboard(DWObject.CurrentImageIndexInBuffer);
            $("#divUploadProp").show();
            $('#spnFilepath').text(path + '\\' + filename);
        }
    }
}

function clearBuffer() {
    var DWObject = Dynamsoft.WebTwainEnv.GetWebTwain('dwtcontrolContainer');
    var status = DWObject.RemoveAllImages();
    if (!status) {
        alert('Error :' + DWObject.ErrorString);
    }
    resetParams();
}

function resetParams() {
    _iLeft = _iTop = _iRight = _iBottom = 0;
    $("#divUploadProp").hide();
    $('#spnFilepath').text('');
    $("drpdwnSourceList").prop('selectedIndex', 0);
}