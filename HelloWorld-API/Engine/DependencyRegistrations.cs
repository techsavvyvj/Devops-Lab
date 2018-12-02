using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Dapper;
using HelloWorld.API.Engine.Interfaces;
using HelloWorld.API.Engine.Mappers;
using HelloWorld.API.Engine.Models;
using Ninject;

namespace HelloWorld.API.Engine
{
    /// <summary>
    /// Registers dependency resolution for controllers in the api.
    /// </summary>
    public class DependencyRegistrations
    {
        public static void RegisterControllerDependencies(IKernel kernel)
        {
            kernel
                .Bind<string>()
                .ToMethod(context => ConfigurationManager.ConnectionStrings["default"].ConnectionString)
                .WhenInjectedInto<MessageModelSqlServerProvider>()
                .WithConstructorArgument("connectionString");

            kernel.Bind<IModelProvider<MessageModel>>().To<MessageModelSqlServerProvider>();
            kernel.Bind<IGenericMapper<MessageModel, MessageQueryResultModel>>().To<MessageModelToMessageQueryResultMapper>();

            kernel.Bind<IGenericMapper<MessageQueryParametersModel, DynamicParameters>>().To<MessageQueryModelToDynamicParametersMapper>();
        }
    }
}