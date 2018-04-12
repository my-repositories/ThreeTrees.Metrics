// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Domain.Employees.Commands
{
    /// <summary>
    /// Create employee command.
    /// </summary>
    public class CreateEmployeeCommand
    {
        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the Birthday.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the Branch.
        /// </summary>
        [Required]
        public EmployeeBranch Branch { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
