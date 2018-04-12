// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using ThreeTrees.Metrics.Domain.Employees.Commands;
using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Tools.Domain.Exceptions;

namespace ThreeTrees.Metrics.Domain.Employees.Handlers
{
    /// <summary>
    /// Employee handler.
    /// </summary>
    public class EmployeeHandler
    {
        /// <summary>
        /// Handle CreateEmployeeCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleCreate(CreateEmployeeCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (IAppUnitOfWork uow = uowFactory.Create())
            {
                var employee = new Employee
                {
                    Birthday = command.Birthday,
                    Branch = command.Branch,
                    Name = command.Name
                };
                uow.EmployeeRepository.Add(employee);
                uow.SaveChanges();
                command.EmployeeId = employee.Id;
            }
        }

        /// <summary>
        /// Handle DeleteEmployeeCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleDelete(DeleteEmployeeCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (IAppUnitOfWork uow = uowFactory.Create())
            {
                var employee = uow.EmployeeRepository.Get(command.EmployeeId);
                if (employee == null)
                {
                    throw new NotFoundException("Deleted employee not found");
                }

                uow.EmployeeRepository.Remove(employee);
                uow.SaveChanges();
            }
        }

        /// <summary>
        /// Handle UpdateEmployeeCommand.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="uowFactory">The unit of work factory.</param>
        public void HandleUpdate(UpdateEmployeeCommand command, IAppUnitOfWorkFactory uowFactory)
        {
            using (IAppUnitOfWork uow = uowFactory.Create())
            {
                var employee = uow.EmployeeRepository.Get(command.EmployeeId);
                employee.Birthday = command.Birthday;
                employee.Branch = command.Branch;
                employee.Name = command.Name;

                uow.SaveChanges();
            }
        }
    }
}
