using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.API.Engine.Interfaces;

namespace HelloWorld.API.Engine.Models
{
    /// <summary>
    /// The message query model.
    /// </summary>
    /// <remarks>
    /// Use this model to pass query parameters to the message provider.
    /// </remarks>
    public class MessageQueryParametersModel : IQueryParametersModel
    {
        public string ApiKey { get; set; }
    }
}