var MetaLoading = MetaLoading || {};

MetaLoading.Show = function () {

    $('#modalLoading').modal({
        keyboard: false,
        backdrop: false
    });
};

MetaLoading.Close = function () {

    $('#modalLoading').modal('hide');
};