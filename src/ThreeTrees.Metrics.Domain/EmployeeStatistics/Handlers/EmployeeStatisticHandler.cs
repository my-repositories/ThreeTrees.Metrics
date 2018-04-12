// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.Messages.Abstractions.Commands;

using ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Handlers
{
    /// <summary>
    /// Employee statistic handler.
    /// </summary>
    [CommandHandlers]
    public class EmployeeStatisticHandler
    {
        /// <summary>
        /// Handle CreateEmployeeStatisticCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleCreate(CreateEmployeeStatisticCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (var uow = uowFactory.Create())
            {
                var statistic = new EmployeeStatistic
                {
                    BilledHours = command.BilledHours,
                    CompletedTasks = command.CompletedTasks,
                    DrunkedCups = command.DrunkedCups,
                    Employee = command.Employee,
                    EmployeeId = command.EmployeeId,
                    PlayedMcGames = command.PlayedMCGames,
                    Month = command.Month,
                    Year = command.Year
                };
                uow.EmployeeStatisticRepository.Add(statistic);
                uow.SaveChanges();
                command.EmployeeStatisticId = statistic.Id;
            }
        }

        /// <summary>
        /// Handle DeleteEmployeeStatisticCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleDelete(DeleteEmployeeStatisticCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (var uow = uowFactory.Create())
            {
                var statistic = uow.EmployeeStatisticRepository.Get(command.EmployeeStatisticId);
                if (statistic == null)
                {
                    throw new NotFoundException("Deleted employee statistic not found");
                }

                uow.EmployeeStatisticRepository.Remove(statistic);
                uow.SaveChanges();
            }
        }

        /// <summary>
        /// Handle UpdateEmployeeStatisticCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleUpdate(UpdateEmployeeStatisticCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (var uow = uowFactory.Create())
            {
                var statistic = uow.EmployeeStatisticRepository.Get(command.EmployeeStatisticId);
                statistic.BilledHours = command.BilledHours;
                statistic.CompletedTasks = command.CompletedTasks;
                statistic.DrunkedCups = command.DrunkedCups;
                statistic.Employee = command.Employee;
                statistic.EmployeeId = command.EmployeeId;
                statistic.PlayedMcGames = command.PlayedMCGames;
                statistic.Month = command.Month;
                statistic.Year = command.Year;

                uow.SaveChanges();
            }
        }
    }
}
