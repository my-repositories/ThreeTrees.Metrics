// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.DataAccess
{
    /// <inheritdoc />
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">DbContext options.</param>
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the employee statistics.
        /// </summary>
        public DbSet<EmployeeStatistic> EmployeeStatistics { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeStatistic>(b =>
            {
                b.HasIndex(e => new { e.Month, e.Year, e.EmployeeId }).IsUnique();
            })
                .Entity<EmployeeStatistic>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeStatistic)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
