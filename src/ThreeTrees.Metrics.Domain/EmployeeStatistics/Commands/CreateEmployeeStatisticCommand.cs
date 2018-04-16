// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Shared;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands
{
    /// <summary>
    /// Create employee statistic command.
    /// </summary>
    public class CreateEmployeeStatisticCommand
    {
        /// <summary>
        /// Gets or sets the EmployeeStatisticId.
        /// </summary>
        [Key]
        public int EmployeeStatisticId { get; set; }

        /// <summary>
        /// Gets or sets the BilledHours.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int BilledHours { get; set; } = 0;

        /// <summary>
        /// Gets or sets the CompletedTasks.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CompletedTasks { get; set; } = 0;

        /// <summary>
        /// Gets or sets the DrunkedCups.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int DrunkedCups { get; set; } = 0;

        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the Employee.
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the PlayedMCGames.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int PlayedMCGames { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Month.
        /// </summary>
        [Range(1, 12)]
        public int Month { get; set; } = DateTime.Now.Month;

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        [RangeUntilCurrentYear(2000)]
        public int Year { get; set; } = DateTime.Now.Year;
    }
}
