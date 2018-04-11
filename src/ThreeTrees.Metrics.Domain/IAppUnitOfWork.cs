// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Repositories;
using ThreeTrees.Tools.Domain;

namespace ThreeTrees.Metrics.Domain
{
    /// <inheritdoc />
    public interface IAppUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        IEmployeeRepository EmployeeRepository { get; }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        IQueryable<Employee> Employees { get; }

        /// <summary>
        /// Gets the employee statistic repository.
        /// </summary>
        IEmployeeStatisticRepository EmployeeStatisticRepository { get; }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        IQueryable<EmployeeStatistic> EmployeeStatistics { get; }
    }
}
