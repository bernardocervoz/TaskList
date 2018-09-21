-$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

});
function ShowMsgModal(title, body) {
    var modal = new MetaModal({
        elemento: "#msgModal",
        header: title,
        body: body.replace(/_/g, "</br>"),
        footer: '<button id="modalOk" style="width:100px;" type="button" class="btn btn-primary">OK</button>',
        btnOK: '#modalOk',
        onOK: function (e) {
            modal.fechar();
        }
    });
    modal.exibir();
}

function DateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    return dd + '/' + mm + '/' + yyyy;
}

