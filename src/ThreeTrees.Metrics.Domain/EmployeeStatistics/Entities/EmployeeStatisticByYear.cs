// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities
{
    /// <summary>
    /// The ranked statistic.
    /// </summary>
    public class EmployeeStatisticByYear
    {
        /// <summary>
        /// Gets or sets The statistic name.
        /// </summary>
        public string StatisticName { get; set; }

        /// <summary>
        /// Gets or sets The best employee.
        /// </summary>
        public Employee BestEmployee { get; set; }

        /// <summary>
        /// Gets or sets The worst employee.
        /// </summary>
        public Employee WorstEmployee { get; set; }
    }
}
