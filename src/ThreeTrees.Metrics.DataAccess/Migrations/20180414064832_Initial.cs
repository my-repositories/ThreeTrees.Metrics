// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeTrees.Metrics.DataAccess.Migrations
{
    /// <summary>
    /// The initial.
    /// </summary>
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(),
                    Branch = table.Column<int>(),
                    Name = table.Column<string>(maxLength: 255)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "EmployeeStatistics",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BilledHours = table.Column<int>(),
                    CompletedTasks = table.Column<int>(),
                    DrunkedCups = table.Column<int>(),
                    EmployeeId = table.Column<int>(),
                    Month = table.Column<int>(),
                    PlayedMcGames = table.Column<int>(),
                    Year = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatistics", x => x.Id);
                    table.UniqueConstraint("AK_EmployeeStatistics_Year_Month", x => new { x.Year, x.Month });
                    table.ForeignKey(
                        "FK_EmployeeStatistics_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_EmployeeStatistics_EmployeeId",
                "EmployeeStatistics",
                "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "EmployeeStatistics");

            migrationBuilder.DropTable(
                "Employees");
        }
    }
}
