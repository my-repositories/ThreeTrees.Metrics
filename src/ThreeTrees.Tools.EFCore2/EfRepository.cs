// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ThreeTrees.Tools.Domain;
using ThreeTrees.Tools.Domain.Exceptions;

namespace ThreeTrees.Tools.EFCore2
{
    /// <inheritdoc />
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity, TContext}"/> class.
        /// </summary>
        /// <param name="context">Database context.</param>
        public EfRepository(TContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Set = this.Context.Set<TEntity>();
        }

        /// <summary>
        /// Gets entity set.
        /// </summary>
        public DbSet<TEntity> Set { get; }

        /// <summary>
        /// Gets database context.
        /// </summary>
        protected TContext Context { get; }

        /// <inheritdoc />
        public virtual TEntity Get(params object[] keyValues)
        {
            var entity = this.Set.Find(keyValues);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.Set.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToArray();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.Context.Set<TEntity>().Where(predicate);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToArray();
        }

        /// <inheritdoc />
        public virtual void Add(TEntity entity)
        {
            this.Set.Add(entity);
        }

        /// <inheritdoc />
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            this.Set.AddRange(entities);
        }

        /// <inheritdoc />
        public virtual void Remove(TEntity entity)
        {
            this.Set.Remove(entity);
        }

        /// <inheritdoc />
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Set.RemoveRange(entities);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await this.Set.FindAsync(keyValues, cancellationToken).ConfigureAwait(false);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.Set.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.Context.Set<TEntity>().Where(predicate);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.Set.Add(entity);

            // TODO: Find InternalHelpers
            // return InternalHelpers.CompletedTask;
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            this.Set.Remove(entity);

            // TODO: Find InternalHelpers
            // return InternalHelpers.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
