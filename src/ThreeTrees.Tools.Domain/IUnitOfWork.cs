﻿// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeTrees.Tools.Domain
{
    /// <inheritdoc />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit pending changes. If not called explicitly the changes will be roll backed.
        /// </summary>
        /// <returns>Records affected.</returns>
        int SaveChanges();

        /// <summary>
        /// Commit pending changes async. If not called explicitly the changes will be roll backed.
        /// </summary>
        /// <returns>Records affected.</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Commit pending changes async. If not called explicitly the changes will be roll backed.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Records affected.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
