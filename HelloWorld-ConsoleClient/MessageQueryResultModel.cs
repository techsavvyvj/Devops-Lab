using System;

namespace HelloWorld.ConsoleClient
{
    /// <summary>
    /// The result body model to send back to an api request for a Message item.
    /// </summary>
    public class MessageQueryResultModel
    {
        public MessageQueryResultStatus ResultStatusCode { get; set; }
        public string ResultStatusText { get; set; }
        public MessageModel Message { get; set; }
        public Exception Exception { get; set; }

        public MessageQueryResultModel()
        {
            ResultStatusCode = MessageQueryResultStatus.Ok;
            ResultStatusText = "Ok";
            Message = null;
            Exception = null;
        }
    }
}