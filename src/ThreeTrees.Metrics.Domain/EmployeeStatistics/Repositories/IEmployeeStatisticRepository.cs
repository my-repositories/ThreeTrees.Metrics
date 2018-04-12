// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Tools.Domain;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Repositories
{
    /// <summary>
    /// The Employee statistic repository interface.
    /// </summary>
    public interface IEmployeeStatisticRepository : IRepository<EmployeeStatistic>
    {
        /// <summary>
        /// Get Employee statistic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includes">The Relations to include.</param>
        /// <returns>The employee.</returns>
        EmployeeStatistic Get(int id, IEnumerable<Expression<Func<EmployeeStatistic, object>>> includes = null);
    }
}
