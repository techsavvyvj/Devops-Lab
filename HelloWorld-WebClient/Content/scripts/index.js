define(
[
    "mappers/XhrToMessageModelMapper"
],
function () {
    "use strict";

    var _mapper = require("mappers/XhrToMessageModelMapper");
    var vue = new Vue({
        el: "#app",
        data: {
            loading: true,
            success: false,
            failed: false,
            failure_message: "API fetch failed."
        }
    });

    var fetched = function(data) {
        var message = _mapper.map(data);

        // todo: add error handling in the future for null message from mapper

        vue.message = message.Message;
        vue.mode = message.Mode;
        vue.loading = false;
        vue.success = true;
    };
    var failed = function () {
        vue.failed = true;
    };

    jQuery
        .get(window.api.endPoint + "/" + window.api.key)
        .done(fetched)
        .fail(failed);
});