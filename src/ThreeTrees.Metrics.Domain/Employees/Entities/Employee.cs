// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeTrees.Metrics.Domain.Employees.Entities
{
    /// <summary>
    /// The employee branch.
    /// </summary>
    public enum EmployeeBranch
    {
        /// <summary>
        /// The Kazahstan.
        /// </summary>
        Kazahstan,

        /// <summary>
        /// The Russia.
        /// </summary>
        Russia,

        /// <summary>
        /// The Usa.
        /// </summary>
        Usa,

        /// <summary>
        /// The Vietnam.
        /// </summary>
        Vietnam
    }

    /// <summary>
    /// The Employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

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
