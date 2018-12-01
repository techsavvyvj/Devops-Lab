using System;

namespace HelloWorld_ConsoleClient
{
    /// <summary>
    /// The result body model to send back to an api request for a Message item.
    /// </summary>
    public class MessageQueryResultModel
    {
        public MessageGetResultStatus ResultStatusCode { get; set; }
        public string ResultStatusText { get; set; }
        public MessageModel Message { get; set; }
        public Exception Exception { get; set; }

        public MessageQueryResultModel()
        {
            ResultStatusCode = MessageGetResultStatus.Ok;
            ResultStatusText = "Ok";
            Message = null;
            Exception = null;
        }
    }
}