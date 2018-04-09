// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;
using ThreeTrees.Tools.Domain;

namespace ThreeTrees.Metrics.Domain
{
    /// <inheritdoc />
    public interface IAppUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the employee repository.
        /// </summary>
        IEmployeeRepository EmployeeRepository { get; }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        IQueryable<Employee> Employees { get; }

        /* IProductRepository ProductRepository { get; }

        IQueryable<Product> Products { get; }

        ICompanyRepository CompanyRepository { get; }

        IQueryable<Company> Companies { get; }

        IProductPropertyRepository ProductPropertyRepository { get; }

        IQueryable<ProductProperty> ProductsProperties { get; }*/
    }
}
