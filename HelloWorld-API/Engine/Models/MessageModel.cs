using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld.API.Engine.Models
{
    /// <summary>
    /// The message model.
    /// </summary>
    public class MessageModel
    {
        public string ApiKey { get; set; }
        public string Mode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}