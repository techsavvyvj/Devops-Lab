define(
    ["models/MessageModel"],
    function () {
        var MessageModel = require("models/MessageModel");

        return {
            map: function (data) {
                if (data.Message === null) {
                    return null;
                }

                var message = new MessageModel();

                message.Message = data.Message.Message;
                message.Mode = data.Message.Mode;
                message.ApiKey = data.Message.ApiKey;
                message.Detail = data.Message.Detail;

                return message;
            }
        };
});