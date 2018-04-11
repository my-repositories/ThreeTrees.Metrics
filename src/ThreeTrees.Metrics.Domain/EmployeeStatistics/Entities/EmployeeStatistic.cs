// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities
{
    /// <summary>
    /// The Employee statistic.
    /// </summary>
    public class EmployeeStatistic
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BilledHours.
        /// </summary>
        [Required]
        public int BilledHours { get; set; }

        /// <summary>
        /// Gets or sets the CompletedTasks.
        /// </summary>
        [Required]
        public int CompletedTasks { get; set; }

        /// <summary>
        /// Gets or sets the DrunkedCups.
        /// </summary>
        [Required]
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
        public int PlayedMCGames { get; set; }

        /// <summary>
        /// Gets or sets the Month.
        /// </summary>
        [Required]
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        [Required]
        [Range(2000, int.MaxValue)]
        public int Year { get; set; }
    }
}
