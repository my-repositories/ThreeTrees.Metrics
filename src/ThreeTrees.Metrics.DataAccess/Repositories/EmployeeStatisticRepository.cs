// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

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
    }
}
