// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreeTrees.Tools.EFCore2
{
    /// <inheritdoc />
    public class EfUnitOfWork<TContext> : Domain.IUnitOfWork
        where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private bool disposed;

        /// <inheritdoc />
        public EfUnitOfWork(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets database context.
        /// </summary>
        protected virtual TContext Context { get; private set; }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        /// <inheritdoc />
        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Dispose object.
        /// </summary>
        /// <param name="disposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                        Context = null;
                    }
                }

                disposed = true;
            }
        }
    }
}
