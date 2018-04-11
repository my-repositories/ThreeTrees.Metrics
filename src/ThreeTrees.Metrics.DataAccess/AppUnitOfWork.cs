// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ThreeTrees.Metrics.DataAccess.Repositories;
using ThreeTrees.Metrics.Domain;
using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Repositories;
using ThreeTrees.Tools.EFCore2;

namespace ThreeTrees.Metrics.DataAccess
{
    /// <inheritdoc cref="IAppUnitOfWork" />
    public class AppUnitOfWork : EfUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private IEmployeeRepository employeeRepository;

        private IEmployeeStatisticRepository employeeStatisticRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppUnitOfWork"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public AppUnitOfWork(AppDbContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new EmployeeRepository(this.Context);
                }

                return this.employeeRepository;
            }
        }

        /// <inheritdoc/>
        public IEmployeeStatisticRepository EmployeeStatisticRepository
        {
            get
            {
                if (this.employeeStatisticRepository == null)
                {
                    this.employeeStatisticRepository = new EmployeeStatisticRepository(this.Context);
                }

                return this.employeeStatisticRepository;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        public IQueryable<Employee> Employees => this.Context.Employees;

        /// <summary>
        /// Gets the employee statistics.
        /// </summary>
        public IQueryable<EmployeeStatistic> EmployeeStatistics => this.Context.EmployeeStatistics;
    }
}
