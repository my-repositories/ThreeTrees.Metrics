// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Domain.Employees.Commands
{
    /// <summary>
    /// Update employee command.
    /// </summary>
    public class UpdateEmployeeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeCommand"/> class.
        /// </summary>
        public UpdateEmployeeCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateEmployeeCommand"/> class.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public UpdateEmployeeCommand(Employee employee)
        {
            this.EmployeeId = employee.Id;
            this.Birthday = employee.Birthday;
            this.Branch = employee.Branch;
            this.Name = employee.Name;
        }

        /// <summary>
        /// Gets or sets the Id.
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
