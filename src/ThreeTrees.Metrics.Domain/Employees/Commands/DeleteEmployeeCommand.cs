// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace ThreeTrees.Metrics.Domain.Employees.Commands
{
    /// <summary>
    /// Delete employee command.
    /// </summary>
    public class DeleteEmployeeCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEmployeeCommand"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public DeleteEmployeeCommand(int id)
        {
            this.EmployeeId = id;
        }

        /// <summary>
        /// Gets or sets the EmployeeId.
        /// </summary>
        [Key]
        public int EmployeeId { get; set; }
    }
}
