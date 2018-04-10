// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;

using ThreeTrees.Metrics.DataAccess.Repositories;
using ThreeTrees.Metrics.Domain;
using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Repositories;
using ThreeTrees.Tools.EFCore2;

namespace ThreeTrees.Metrics.DataAccess
{
    /// <inheritdoc cref="IAppUnitOfWork" />
    public class AppUnitOfWork : EfUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private IEmployeeRepository employeeRepository;

        /// <inheritdoc />
        public AppUnitOfWork(AppDbContext context)
            : base(context)
        {
        }

        /// <inheritdoc/>
        public IEmployeeRepository EmployeeRepository
        {
            get
            {

                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(Context);
                }

                return employeeRepository;
            }
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        public IQueryable<Employee> Employees => Context.Employees;

        /*public IProductRepository ProductRepository => new ProductRepository(Context);

        public IQueryable<Product> Products => Context.Products;

        public ICompanyRepository CompanyRepository => new CompanyRepository(Context);

        public IQueryable<Company> Companies => Context.Companies;

        public IProductPropertyRepository ProductPropertyRepository => new ProductPropertyRepository(Context);

        public IQueryable<ProductProperty> ProductsProperties => Context.ProductProperties;*/
    }
}
