function OpenProgressModel() {
    $('#progressModel').modal({ backdrop: 'static', keyboard: false });
}

function CloseProgressModel() {
    $('#progressModel').modal('toggle');
}

function ShowMessage(message, AlertType) {
    var MessageBox = $(`<div class="message-box" id="MessageBox">
                        <div class="alert alert-danger" role="alert">
                            <h4 class="alert-heading">${AlertType.message}</h4>
                            <p>${message.replace(/\/n/g, ',').split(",").join("<br />")}</p>
                        </div>
                    </div>`)

    $("body").append(MessageBox)
    $(".callout").addClass(AlertType.class);
    MessageBox.find('h4').text(AlertType.message);

    MessageBox.find('p').html();
    MessageBox.fadeIn();
    CloseMessage();
}

function CloseMessage() {
    window.setTimeout(function () {
        $("#MessageBox").fadeOut(1000)
        $("#MessageBox").remove();
    }, 3000);
}

const AlertType = Object.freeze({
    Warning: { class: "callout-warning", message: "Warning!", messageAr: "تحذير!" },
    Info: { class: "callout-info", message: "Information!", messageAr: "معلومات!" },
    Success: { class: "callout-success", message: "Success!", messageAr: "نجاح!" },
    Error: { class: "callout-danger", message: "Error!", messageAr: "خطأ!" }
});