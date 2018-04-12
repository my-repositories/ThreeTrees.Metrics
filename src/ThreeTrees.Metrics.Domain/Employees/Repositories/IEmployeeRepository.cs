// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Tools.Domain;

namespace ThreeTrees.Metrics.Domain.Employees.Repositories
{
    /// <summary>
    /// The Employee repository interface.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Get Employee by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="includes">The Relations to include.</param>
        /// <returns>The employee.</returns>
        Employee Get(int id, IEnumerable<Expression<Func<Employee, object>>> includes = null);
    }
}
