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

        /// <summary>
        /// Initializes a new instance of the <see cref="EfUnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfUnitOfWork(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Gets database context.
        /// </summary>
        protected virtual TContext Context { get; private set; }

        /// <inheritdoc />
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public virtual int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        /// <inheritdoc />
        public virtual Task<int> SaveChangesAsync()
        {
            return this.Context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return this.Context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Dispose object.
        /// </summary>
        /// <param name="disposing">Dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.Context != null)
                    {
                        this.Context.Dispose();
                        this.Context = null;
                    }
                }

                this.disposed = true;
            }
        }
    }
}
