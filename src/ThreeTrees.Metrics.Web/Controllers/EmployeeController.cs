// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThreeTrees.Metrics.DataAccess;
using ThreeTrees.Metrics.Domain.Employees.Entities;

namespace ThreeTrees.Metrics.Web.Controllers
{
    /// <inheritdoc />
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="context">AppDb context.</param>
        public EmployeeController(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// POST: Employee
        /// </summary>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Index()
        {
            return this.View(await this.context.Employees.ToListAsync());
        }

        /// <summary>
        /// POST: Employee/Details/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        /// <summary>
        /// GET: Employee/Create
        /// </summary>
        /// <returns>The action result.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// POST: Employee/Create
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(employee);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(employee);
        }

        /// <summary>
        /// GET: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        /// <summary>
        /// POST: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="employee">The employee.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Birthday,Branch,Name")] Employee employee)
        {
            if (id != employee.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                this.context.Update(employee);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(employee);
        }

        /// <summary>
        /// GET: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.context.Employees
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        /// <summary>
        /// POST: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await this.context.Employees.SingleOrDefaultAsync(m => m.Id == id);
            this.context.Employees.Remove(employee);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
