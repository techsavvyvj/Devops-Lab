using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Models;

namespace HelloWorld.API.Engine.Mappers
{
    /// <summary>
    /// Maps a MessageModel to a MessageGetResultModel.
    /// </summary>
    /// <remarks>
    /// Use this to convert the MessageModel to the response body that is sent back to the api request.
    /// </remarks>
    public class MessageModelToMessageGetResultMapper : IGenericMapper<MessageModel, MessageGetResultModel>
    {
        public MessageGetResultModel Map(MessageModel message)
        {
            var status = message == null ? MessageGetResultStatus.NoResults : MessageGetResultStatus.Ok;

            return new MessageGetResultModel
            {
                ResultStatusCode = status,
                ResultStatusText = status.ToString(),
                Message = message,
                Exception = null
            };
        }
    }
}