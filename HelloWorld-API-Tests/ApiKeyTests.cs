using HelloWorld.API.Engine;
using HelloWorld.API.Engine.Mappers;
using HelloWorld.API.Engine.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace HelloWorld.API.Tests
{
    /// <summary>
    /// Suite that tests validity of key queries in the api.
    /// </summary>
    [Collection("ApiKeyTests")]
    public class ApiKeyTests
    {
        private readonly IConfigurationRoot _config;
        private readonly MessageModelSqlServerProvider _provider;
        private readonly MessageModelToMessageQueryResultMapper _resultMapper;

        public ApiKeyTests()
        {
            var dataDirectory = Path.GetFullPath($"{Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))}\\..\\..\\HelloWorld-API\\App_Data\\");

            _config = new ConfigurationBuilder().AddJsonFile("test-configs.json").Build();

            var connectionString = _config["connectionString"].Replace("|DataDirectory|", dataDirectory);

            // create system under test
            var parametersMapper = new MessageQueryModelToDynamicParametersMapper();

            _provider = new MessageModelSqlServerProvider(connectionString, parametersMapper);
            _resultMapper = new MessageModelToMessageQueryResultMapper();
        }

        /// <summary>
        /// Confirm that key lengths longer or shorter than 128 characters fail.
        /// </summary>
        /// <remarks>
        /// Keys are SHA512 hashed values, making them always 128 characters long.
        /// </remarks>
        [Fact]
        public void KeyLengthTest()
        {
            var parametersKeyLength1 = new MessageQueryParametersModel {ApiKey = "1"};
            var parametersKeyLength129 = new MessageQueryParametersModel { ApiKey = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789" };
            void Action1() => _provider.Read(parametersKeyLength1);
            void Action129() => _provider.Read(parametersKeyLength129);
            var exception1 = Record.Exception((Action) Action1);
            var exception129 = Record.Exception((Action) Action129);

            Assert.NotNull(exception1);
            Assert.NotNull(exception129);
            Assert.IsType<ArgumentException>(exception1);
            Assert.IsType<ArgumentException>(exception129);
            Assert.Contains("formatted", exception1.Message);
            Assert.Contains("formatted", exception129.Message);
        }

        /// <summary>
        /// Confirm that bad keys do not validate against the database and do not return a message.
        /// </summary>
        [Theory]
        [InlineData("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567a")]
        [InlineData("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567b")]
        [InlineData("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567c")]
        public void InvalidKeyTest(string apiKey)
        {
            var parameters = new MessageQueryParametersModel {ApiKey = apiKey};
            var result = _resultMapper.Map(_provider.Read(parameters).FirstOrDefault());

            Assert.Equal(MessageQueryResultStatus.NoResults, result.ResultStatusCode);
            Assert.Null(result.Message);
        }


        /// <summary>
        /// Confirm that known, valid keys authenticate on the provider against the database.
        /// </summary>
        [Fact]
        public void ValidKeyTest()
        {
            var parametersConsole = new MessageQueryParametersModel {ApiKey = _config["apiKeyConsole"]};
            var parametersWeb = new MessageQueryParametersModel {ApiKey = _config["apiKeyWeb"]};
            var consoleResult = _resultMapper.Map(_provider.Read(parametersConsole).FirstOrDefault());
            var webResult = _resultMapper.Map(_provider.Read(parametersWeb).FirstOrDefault());

            Assert.Equal(MessageQueryResultStatus.Ok, consoleResult.ResultStatusCode);
            Assert.Equal(MessageQueryResultStatus.Ok, webResult.ResultStatusCode);
            Assert.NotNull(consoleResult.Message);
            Assert.NotNull(webResult.Message);
        }
    }
}
