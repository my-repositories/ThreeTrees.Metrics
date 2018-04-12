// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;

namespace ThreeTrees.Metrics.DataAccess.Repositories
{
    /// <inheritdoc cref="IEmployeeRepository" />
    public class EmployeeRepository : Saritasa.Tools.EFCore.EFRepository<Employee, AppDbContext>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public EmployeeRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
