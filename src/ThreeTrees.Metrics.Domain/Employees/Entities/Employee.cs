﻿// Copyright (c) ThreeTrees. All rights reserved.
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
        Kazahstan,
        Russia,
        Usa,
        Vietnam
    }

    /// <summary>
    /// The Employee.
    /// </summary>
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public EmployeeBranch Branch { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}