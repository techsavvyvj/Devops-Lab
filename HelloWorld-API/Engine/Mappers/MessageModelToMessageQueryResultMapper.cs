using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Models;

namespace HelloWorld.API.Engine.Mappers
{
    /// <summary>
    /// Maps a MessageModel to a MessageQueryResultModel.
    /// </summary>
    /// <remarks>
    /// Use this to convert the MessageModel to the response body that is sent back to the api request.
    /// </remarks>
    public class MessageModelToMessageQueryResultMapper : IGenericMapper<MessageModel, MessageQueryResultModel>
    {
        public MessageQueryResultModel Map(MessageModel message)
        {
            var status = message == null ? MessageQueryResultStatus.NoResults : MessageQueryResultStatus.Ok;

            return new MessageQueryResultModel
            {
                ResultStatusCode = status,
                ResultStatusText = status.ToString(),
                Message = message,
                Exception = null
            };
        }
    }
}