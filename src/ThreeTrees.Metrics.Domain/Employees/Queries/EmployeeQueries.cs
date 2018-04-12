// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Domain.Employees.Queries
{
    /// <summary>
    /// Employee queries.
    /// </summary>
    public class EmployeeQueries
    {
        private readonly IAppUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeQueries"/> class.
        /// </summary>
        /// <param name="uow">Unit of work.</param>
        public EmployeeQueries(IAppUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Get Employee by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The employee.</returns>
        public Employee Get(int id)
        {
            return this.uow.EmployeeRepository.Get(id);
        }

        /// <summary>
        /// Get all employees.
        /// </summary>
        /// <returns>The employees.</returns>
        public IEnumerable<Employee> GetAll()
        {
            return this.uow.EmployeeRepository.GetAll();
        }

        // TODO: Implement it.
        /*public PagedResult<Product> Search(ProductsObjectQuery objectQuery)
        {
            return objectQuery.Search(GetAll());
        }*/
    }
}
