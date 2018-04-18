// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Repositories;

namespace ThreeTrees.Metrics.DataAccess.Repositories
{
    /// <inheritdoc cref="IEmployeeStatisticRepository" />
    public class EmployeeStatisticRepository : Saritasa.Tools.EFCore.EFRepository<EmployeeStatistic, AppDbContext>, IEmployeeStatisticRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatisticRepository"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public EmployeeStatisticRepository(AppDbContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Get Employee statistic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includes">The relations to include.</param>
        /// <returns>Get Employee statistic.</returns>
        public EmployeeStatistic Get(int id, IEnumerable<Expression<Func<EmployeeStatistic, object>>> includes = null)
        {
            return this.Find(p => p.Id == id, includes?.ToArray()).FirstOrDefault();
        }

        /// <summary>
        /// Get Employee statistic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <param name="includes">The relations to include.</param>
        /// <returns>Get Employee statistic.</returns>
        public async Task<EmployeeStatistic> GetAsync(int id, CancellationToken token = default(CancellationToken), IEnumerable<Expression<Func<EmployeeStatistic, object>>> includes = null)
        {
            var result = await this.FindAsync(p => p.Id == id, token, includes?.ToArray());
            return result.FirstOrDefault();
        }
    }
}