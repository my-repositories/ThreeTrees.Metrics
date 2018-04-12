// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Autofac;
using ThreeTrees.Tools.Messages.Common;

namespace ThreeTrees.Metrics.Infrastructure
{
    /// <summary>
    /// Dependency injection configuration.
    /// </summary>
    public class CommonDiConfig
    {
        /// <summary>
        /// Prepares Autofac container builder with common services.
        /// </summary>
        /// <returns>Autofac container builder.</returns>
        public static ContainerBuilder CreateBuilder()
        {
            var builder = new ContainerBuilder();

            // Bindings.
            builder.RegisterType<AutofacServiceProvider>()
                .As<IServiceProvider>()
                .InstancePerRequest()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataAccess.AppUnitOfWorkFactory>()
                .AsSelf()
                .AsImplementedInterfaces();

            builder.Register(c => c.Resolve<DataAccess.AppUnitOfWorkFactory>().Create())
                .AsImplementedInterfaces();

            builder.RegisterType<Domain.Employees.Queries.EmployeeQueries>()
                .AsSelf();

            builder.RegisterType<DataAccess.AppDbContext>().AsSelf();

            // Command pipeline.
            var messagePipelineContainer = new DefaultMessagePipelineContainer();
            messagePipelineContainer.AddCommandPipeline()
                .UseDefaultMiddlewares(System.Reflection.Assembly.GetAssembly(typeof(Domain.Users.Entities.User)))
                .AddMiddleware(adoNetRepositoryMiddleware);

            return builder;
        }
    }
}
