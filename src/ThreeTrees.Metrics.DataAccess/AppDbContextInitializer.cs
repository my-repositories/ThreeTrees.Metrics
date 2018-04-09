// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.DataAccess
{
    /// <summary>
    /// The AppDbContext initializer.
    /// </summary>
    public class AppDbContextInitializer
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Initialize(AppDbContext context)
        {
            // Skip initialize step if DB has been seeded.
            if (context.Employees.Any())
            {
                return;
            }

            var employees = new List<Employee>
            {
                new Employee
                {
                    Birthday = System.DateTime.Now.Date,
                    Branch = EmployeeBranch.Russia,
                    Name = "Axel"
                },
                new Employee
                {
                    Birthday = System.DateTime.Now.Date,
                    Branch = EmployeeBranch.Usa,
                    Name = "Michael"
                }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var statistics = new List<EmployeeStatistic>
            {
                new EmployeeStatistic
                {
                    BilledHours = 40,
                    CompletedTasks = 12,
                    DrunkedCups = 24,
                    EmployeeId = 1,
                    PlayedMCGames = 3,
                    Month = 1,
                    Year = 2010
                },
                new EmployeeStatistic
                {
                    BilledHours = 80,
                    CompletedTasks = 36,
                    DrunkedCups = 42,
                    EmployeeId = 2,
                    PlayedMCGames = 7,
                    Month = 4,
                    Year = 2015
                }
            };

            context.EmployeeStatistics.AddRange(statistics);
            context.SaveChanges();
        }
    }
}
