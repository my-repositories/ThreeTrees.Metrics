// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands
{
    /// <summary>
    /// Delete employee statistic command.
    /// </summary>
    public class DeleteEmployeeStatisticCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteEmployeeStatisticCommand"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public DeleteEmployeeStatisticCommand(int id)
        {
            this.EmployeeStatisticId = id;
        }

        /// <summary>
        /// Gets or sets the EmployeeStatisticId.
        /// </summary>
        [Key]
        public int EmployeeStatisticId { get; set; }
    }
}
