// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Autofac;

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
        public static ContainerBuilder CreateBuilder() =>
            AutofacModule.Configure(new ContainerBuilder());
    }
}
