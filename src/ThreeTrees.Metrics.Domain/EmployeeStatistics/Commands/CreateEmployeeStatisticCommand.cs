// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

using ThreeTrees.Metrics.Domain.Employees.Entities;

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
        public int BilledHours { get; set; } = 0;

        /// <summary>
        /// Gets or sets the CompletedTasks.
        /// </summary>
        public int CompletedTasks { get; set; } = 0;

        /// <summary>
        /// Gets or sets the DrunkedCups.
        /// </summary>
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
        public int PlayedMCGames { get; set; } = 0;

        /// <summary>
        /// Gets or sets the Month.
        /// </summary>
        public int Month { get; set; } = DateTime.Now.Month;

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        [Range(2000, int.MaxValue)]
        public int Year { get; set; } = DateTime.Now.Year;
    }
}
