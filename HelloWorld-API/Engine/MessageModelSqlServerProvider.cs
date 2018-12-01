using Dapper;
using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HelloWorld.API.Engine
{
    /// <summary>
    /// The provider for the Message model on Sql Server
    /// </summary>
    /// <remarks>
    /// Use this to perform CRUD operations on the Message model against Sql Server.
    /// </remarks>
    public class MessageModelSqlServerProvider : IModelProvider<MessageModel>
    {
        private readonly string _connectionString;
        private readonly IGenericMapper<MessageQueryParametersModel, DynamicParameters> _messageQueryParametersMapper;

        public MessageModelSqlServerProvider
        (
            string connectionString,
            IGenericMapper<MessageQueryParametersModel, DynamicParameters> messageQueryParametersMapper    
        )
        {
            _connectionString = connectionString;
            _messageQueryParametersMapper = messageQueryParametersMapper;
        }

        /// <summary>
        /// Stub for future Create functionality
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Create(MessageModel message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Query the Messages table.
        /// </summary>
        /// <param name="queryParametersModel"></param>
        /// <returns></returns>
        public IEnumerable<MessageModel> Read(IQueryParametersModel queryParametersModel)
        {
            if (!(queryParametersModel is MessageQueryParametersModel messageQueryModel))
            {
                throw new ArgumentException($"{nameof(queryParametersModel)} parameter is not of type MessageQueryModel");
            }

            if (string.IsNullOrWhiteSpace(messageQueryModel.ApiKey))
            {
                throw new ArgumentException($"{nameof(queryParametersModel)} parameter does not contain any filtering");
            }

            // apiKeys are SHA512 hashed - all keys should be exactly 128 chars long
            if (messageQueryModel.ApiKey.Length != 128)
            {
                throw new ArgumentException($"{nameof(queryParametersModel)} parameter contains improperly formatted filter");
            }

            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new Exception("Connection string not found");
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = _messageQueryParametersMapper.Map(messageQueryModel);

                return connection.Query<MessageModel>("ReadMessages", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Stub for future Update functionality
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Update(MessageModel message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stub for future Delete functionality
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Delete(MessageModel message)
        {
            throw new NotImplementedException();
        }
    }
}