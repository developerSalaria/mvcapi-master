window.onbeforeunload = function (e) {
    
    $('#loading-wrapper').show();
};

$(document).ajaxStart(function () {
    //console.log('show loader')
    //debugger;
    $('#loading-wrapper').show();
});

//$(document).ajaxSuccess(function () {
//    $('#loading-wrapper').hide();
//});

$(document).ajaxStop(function () {
    console.log('remove loader')
    $('#loading-wrapper').hide();
});

$(document).ajaxError(function () {
    $('#loading-wrapper').show();
});
