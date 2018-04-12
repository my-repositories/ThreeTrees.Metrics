// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Data;

using ThreeTrees.Metrics.Domain;

namespace ThreeTrees.Metrics.DataAccess
{
    /// <inheritdoc />
    public class AppUnitOfWorkFactory : IAppUnitOfWorkFactory
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppUnitOfWorkFactory"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AppUnitOfWorkFactory(AppDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        public IAppUnitOfWork Create()
        {
            return new AppUnitOfWork(this.context);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>The <see cref="IAppUnitOfWork"/>.</returns>
        public IAppUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new AppUnitOfWork(this.context);
        }
    }
}
