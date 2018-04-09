// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Autofac;

namespace ThreeTrees.Metrics.Infrastructure
{
    /// <inheritdoc cref="IServiceProvider" />
    public class AutofacServiceProvider : IServiceProvider, IDisposable
    {
        private readonly IComponentContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProvider"/> class.
        /// </summary>
        /// <param name="componentContext">The context in which a service can be accessed
        /// or a component's dependencies resolved. Disposal of a context will dispose any owned components.</param>
        public AutofacServiceProvider(IComponentContext componentContext)
        {
            this.context = componentContext;
        }

        /// <inheritdoc />
        public object GetService(Type serviceType) => context.Resolve(serviceType);

        /// <inheritdoc />
        public void Dispose()
        {
            var disposable = context as IDisposable;
            disposable?.Dispose();
        }
    }
}
