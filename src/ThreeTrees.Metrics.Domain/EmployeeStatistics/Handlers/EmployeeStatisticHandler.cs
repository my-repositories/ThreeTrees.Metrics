// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Tools.Domain.Exceptions;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Handlers
{
    /// <summary>
    /// Employee statistic handler.
    /// </summary>
    public class EmployeeStatisticHandler
    {
        /// <summary>
        /// Handle CreateEmployeeStatisticCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleCreate(CreateEmployeeStatisticCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (IAppUnitOfWork uow = uowFactory.Create())
            {
                var statistic = new EmployeeStatistic
                {
                    BilledHours = command.BilledHours,
                    CompletedTasks = command.CompletedTasks,
                    DrunkedCups = command.DrunkedCups,
                    Employee = command.Employee,
                    EmployeeId = command.EmployeeId,
                    PlayedMCGames = command.PlayedMCGames,
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
            using (IAppUnitOfWork uow = uowFactory.Create())
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
            using (IAppUnitOfWork uow = uowFactory.Create())
            {
                var statistic = uow.EmployeeStatisticRepository.Get(command.EmployeeStatisticId);
                statistic.BilledHours = command.BilledHours;
                statistic.CompletedTasks = command.CompletedTasks;
                statistic.DrunkedCups = command.DrunkedCups;
                statistic.Employee = command.Employee;
                statistic.EmployeeId = command.EmployeeId;
                statistic.PlayedMCGames = command.PlayedMCGames;
                statistic.Month = command.Month;
                statistic.Year = command.Year;

                uow.SaveChanges();
            }
        }
    }
}
