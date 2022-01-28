function ajaxHelper(uri, method, data) {
    return $.ajax({
        type: method,
        url: uri,
        dataType: "json",
        contentType: "application/json",
        data: data ? JSON.stringify(data) : null
    });
}

function cloneObservable(observableObject) {
    return ko.mapping.fromJS(ko.toJS(observableObject))();
}