// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands
{
    /// <summary>
    /// Update employee statistic command.
    /// </summary>
    public class UpdateEmployeeStatisticCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeStatisticCommand"/> class.
        /// </summary>
        public UpdateEmployeeStatisticCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeStatisticCommand"/> class.
        /// </summary>
        /// <param name="statistic">The employee statistic.</param>
        public UpdateEmployeeStatisticCommand(EmployeeStatistic statistic)
        {
            this.EmployeeStatisticId = statistic.Id;
            this.BilledHours = statistic.BilledHours;
            this.CompletedTasks = statistic.CompletedTasks;
            this.DrunkedCups = statistic.DrunkedCups;
            this.EmployeeId = statistic.Id;
            this.Employee = statistic.Employee;
            this.PlayedMCGames = statistic.PlayedMCGames;
            this.Month = statistic.Month;
            this.Year = statistic.Year;
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int EmployeeStatisticId { get; set; }

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
