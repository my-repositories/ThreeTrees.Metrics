// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ThreeTrees.Tools.Domain
{
    /// <summary>
    /// Unit of work factory abstraction.
    /// </summary>
    /// <typeparam name="TUnitOfWork">
    /// The TUnitOfWork.
    /// </typeparam>
    public interface IUnitOfWorkFactory<out TUnitOfWork>
        where TUnitOfWork : class
    {
        /// <summary>
        /// Creates unit of work with default isolation level.
        /// </summary>
        /// <returns>Unit of work.</returns>
        TUnitOfWork Create();
    }
}
