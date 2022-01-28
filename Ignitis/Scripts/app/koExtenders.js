ko.observableArray.fn.map = function (data, Constructor) {
    return ko.utils.arrayMap(data,
        function (item) {
            return new Constructor(item);
        });
};