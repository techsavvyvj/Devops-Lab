using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Models;

namespace HelloWorld.API.Controllers
{
    /// <summary>
    /// API controller for Messages, handling all CRUD operations.
    /// </summary>
    public class MessageController : ApiController
    {
        private readonly IModelProvider<MessageModel> _messageProvider;
        private readonly IGenericMapper<MessageModel, MessageQueryResultModel> _messageModelResultMapper;

        public MessageController
        (
            IModelProvider<MessageModel> messageProvider,
            IGenericMapper<MessageModel, MessageQueryResultModel> messageModelResultMapper
        )
        {
            _messageProvider = messageProvider;
            _messageModelResultMapper = messageModelResultMapper;
        }

        /// <summary>
        /// Stub for future Create functionality.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Post([FromBody] MessageModel message)
        {
            return BadRequest();
        }

        /// <summary>
        /// Read functionality Messages.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("*", "*", "GET")]
        public IHttpActionResult Get(string apiKey)
        {
            try
            {
                var message = _messageProvider.Read(new MessageQueryParametersModel {ApiKey = apiKey}).FirstOrDefault();
                var returnBody = _messageModelResultMapper.Map(message);

                return Ok(returnBody);
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }

        /// <summary>
        /// Stub for future Update functionality.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Put([FromBody] MessageModel message)
        {
            return BadRequest();
        }

        /// <summary>
        /// Stub for future Delete functionality.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete([FromBody] MessageModel message)
        {
            // not operational at this time, but future Delete functionality
            return BadRequest();
        }
    }
}
