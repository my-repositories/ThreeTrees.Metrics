// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Repositories;

namespace ThreeTrees.Metrics.DataAccess.Repositories
{
    /// <inheritdoc cref="IEmployeeStatisticRepository" />
    public class EmployeeStatisticRepository : Tools.EFCore2.EfRepository<EmployeeStatistic, AppDbContext>, IEmployeeStatisticRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatisticRepository"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public EmployeeStatisticRepository(AppDbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public EmployeeStatistic Get(int id, IEnumerable<Expression<Func<EmployeeStatistic, object>>> includes = null)
        {
            return this.Find(p => p.Id == id, includes?.ToArray()).SingleOrDefault();
        }
    }
}
