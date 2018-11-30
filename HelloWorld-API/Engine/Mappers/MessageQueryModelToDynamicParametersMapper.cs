using System;
using Dapper;
using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Models;

namespace HelloWorld.API.Engine.Mappers
{
    /// <summary>
    /// Maps a MessageQueryModel to a DynamicParameters object.
    /// </summary>
    /// <remarks>
    /// Use this to convert a MessageQueryModel (part of the api request) to an
    /// object Dapper uses to query the database.
    /// </remarks>
    public class MessageQueryModelToDynamicParametersMapper : IGenericMapper<MessageQueryParametersModel, DynamicParameters>
    {
        public DynamicParameters Map(MessageQueryParametersModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var parameters = new DynamicParameters();

            if (!string.IsNullOrWhiteSpace(item.ApiKey))
            {
                parameters.Add("@apiKey", item.ApiKey);
            }

            return parameters;
        }
    }
}