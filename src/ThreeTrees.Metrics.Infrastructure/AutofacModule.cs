// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Autofac;
using Saritasa.Tools.Messages.Abstractions;
using Saritasa.Tools.Messages.Commands;
using Saritasa.Tools.Messages.Common;

namespace ThreeTrees.Metrics.Infrastructure
{
    /// <inheritdoc />
    public class AutofacModule : Module
    {
        /// <summary>
        /// Configure container.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        /// <returns>A container builder.</returns>
        public static ContainerBuilder Configure(ContainerBuilder builder)
        {
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

            // Repository for messages.
            var connectionString = Config.Get("ConnectionStrings:AppDbContext");
            var adoNetRepositoryMiddleware = new Saritasa.Tools.Messages.Common.PipelineMiddlewares.RepositoryMiddleware(
               new Saritasa.Tools.Messages.Common.Repositories.AdoNetMessageRepository(
                   new Factory(),
                   connectionString,
                    Saritasa.Tools.Messages.Common.Repositories.AdoNetMessageRepository.Dialect.SqlServer));

            // Command pipeline.
            var messagePipelineContainer = new DefaultMessagePipelineContainer();
            messagePipelineContainer.AddCommandPipeline()
                .UseDefaultMiddlewares(System.Reflection.Assembly.GetAssembly(typeof(Domain.Employees.Entities.Employee)))
                .AddMiddleware(adoNetRepositoryMiddleware);
            builder.RegisterInstance(messagePipelineContainer).As<IMessagePipelineContainer>().SingleInstance();
            builder.RegisterType<DefaultMessagePipelineService>().As<IMessagePipelineService>();
            return builder;
        }

        /// <inheritdoc />
        protected override void Load(ContainerBuilder builder) =>
            Configure(builder);

        private class Factory : System.Data.Common.DbProviderFactory
        {
        }
    }
}
