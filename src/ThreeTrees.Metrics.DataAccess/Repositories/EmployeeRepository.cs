// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;

namespace ThreeTrees.Metrics.DataAccess.Repositories
{
    /// <inheritdoc cref="IEmployeeRepository" />
    public class EmployeeRepository : Tools.EFCore2.EfRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        /// <inheritdoc />
        public EmployeeRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
