﻿// Copyright (c) ThreeTrees. All rights reserved.
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
        [Key]
        public int Id { get; set; }

        [Required]
        public int BilledHours { get; set; }

        [Required]
        public int CompletedTasks { get; set; }

        [Required]
        public int DrunkedCups { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public int PlayedMCGames { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        [Range(2000, int.MaxValue)]
        public int Year { get; set; }
    }
}
