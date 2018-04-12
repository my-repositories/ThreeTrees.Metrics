// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Shared;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities
{
    /// <summary>
    /// The Employee statistic.
    /// </summary>
    public class EmployeeStatistic
    {
        /// <summary>
        /// Gets include Many to One and One to One relations.
        /// </summary>
        public static IEnumerable<Expression<Func<EmployeeStatistic, object>>> DefaultInclude
        {
            get
            {
                yield return p => p.Employee;
            }
        }

        /// <summary>
        /// Gets include all relations.
        /// </summary>
        public static IEnumerable<Expression<Func<EmployeeStatistic, object>>> IncludeAll
        {
            get
            {
                yield return p => p.Employee;
            }
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BilledHours.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int BilledHours { get; set; }

        /// <summary>
        /// Gets or sets the CompletedTasks.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int CompletedTasks { get; set; }

        /// <summary>
        /// Gets or sets the DrunkedCups.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int DrunkedCups { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the Employee.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the PlayedMCGames.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        public int PlayedMcGames { get; set; }

        /// <summary>
        /// Gets or sets the Month.
        /// </summary>
        [Required]
        [Range(1, 12)]
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        [Required]
        [RangeUntilCurrentYear(2000)]
        public int Year { get; set; }
    }
}
