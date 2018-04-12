// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;

namespace ThreeTrees.Metrics.DataAccess.Repositories
{
    /// <inheritdoc cref="IEmployeeRepository" />
    public class EmployeeRepository : Tools.EFCore2.EfRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public EmployeeRepository(AppDbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public Employee Get(int id, IEnumerable<Expression<Func<Employee, object>>> includes = null)
        {
            return this.Find(p => p.Id == id, includes?.ToArray()).SingleOrDefault();
        }
    }
}
