// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.Domain.EmployeeStatistics.Queries
{
    /// <summary>
    /// Employee statistic queries.
    /// </summary>
    public class EmployeeStatisticQueries
    {
        private readonly IAppUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatisticQueries"/> class.
        /// </summary>
        /// <param name="uow">Unit of work.</param>
        public EmployeeStatisticQueries(IAppUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Get Employee statistic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The employee.</returns>
        public EmployeeStatistic Get(int id)
        {
            return this.uow.EmployeeStatisticRepository.Get(id);
        }

        /// <summary>
        /// Get all employees statistics.
        /// </summary>
        /// <returns>The employees.</returns>
        public IEnumerable<EmployeeStatistic> GetAll()
        {
            return this.uow.EmployeeStatisticRepository.GetAll();
        }

        // TODO: Implement it.
        /*public PagedResult<Product> Search(ProductsObjectQuery objectQuery)
        {
            return objectQuery.Search(GetAll());
        }*/
    }
}
