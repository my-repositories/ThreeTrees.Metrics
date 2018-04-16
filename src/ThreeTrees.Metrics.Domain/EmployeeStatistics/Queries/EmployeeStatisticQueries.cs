// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
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
            return this.uow
                .EmployeeStatisticRepository
                .Get(id, EmployeeStatistic.IncludeAll);
        }

        /// <summary>
        /// Get Employee statistic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The employee.</returns>
        public async Task<EmployeeStatistic> GetAsync(int id, CancellationToken token = default(CancellationToken))
        {
            // TODO: WHY THIS DON'T WORK ???!!!!11111111111
            /*
             * ArgumentException:
             * Entity type 'EmployeeStatistic' is defined with a single key property,
             * but 2 values were passed to the 'DbSet.Find' method.
             * */
            /*return await this.uow.EmployeeStatisticRepository
                .GetAsync(token, id, EmployeeStatistic.IncludeAll);*/
            return await this.uow
                .EmployeeStatistics
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == id, token);
        }

        /// <summary>
        /// Get all employee statistics.
        /// </summary>
        /// <returns>The employee statistics.</returns>
        public IEnumerable<EmployeeStatistic> GetAll()
        {
            return this.uow.EmployeeStatisticRepository
                .GetAll(EmployeeStatistic.DefaultInclude.ToArray());
        }

        /// <summary>
        /// Get all employee statistics.
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The employee statistics.</returns>
        public async Task<IEnumerable<EmployeeStatistic>> GetAllAsync(CancellationToken token = default(CancellationToken))
        {
            return await this.uow
                .EmployeeStatisticRepository
                .GetAllAsync(token, EmployeeStatistic.DefaultInclude.ToArray());
        }

        // TODO: Implement it.
        /*public PagedResult<Product> Search(ProductsObjectQuery objectQuery)
        {
            return objectQuery.Search(GetAll());
        }*/
    }
}
