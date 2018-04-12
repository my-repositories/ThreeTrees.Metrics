// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThreeTrees.Metrics.DataAccess;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;

namespace ThreeTrees.Metrics.Web.Controllers
{
    /// <inheritdoc />
    public class EmployeeStatisticController : Controller
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatisticController"/> class.
        /// </summary>
        /// <param name="context">The AppDb context.</param>
        public EmployeeStatisticController(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET: EmployeeStatistic
        /// </summary>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Index()
        {
            var appDbContext = this.context.EmployeeStatistics.Include(e => e.Employee);
            return this.View(await appDbContext.ToListAsync());
        }

        /// <summary>
        /// GET: EmployeeStatistic/Details/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employeeStatistic = await this.context.EmployeeStatistics
                .Include(e => e.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeeStatistic == null)
            {
                return this.NotFound();
            }

            return this.View(employeeStatistic);
        }

        /// <summary>
        /// GET: EmployeeStatistic/Create
        /// </summary>
        /// <returns>The action result.</returns>
        public IActionResult Create()
        {
            this.ViewData["EmployeeId"] = new SelectList(this.context.Employees, "Id", "Name");
            return this.View();
        }

        /// <summary>
        /// POST: EmployeeStatistic/Create
        /// </summary>
        /// <param name="employeeStatistic">The employee statistic.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeStatistic employeeStatistic)
        {
            if (this.ModelState.IsValid)
            {
                this.context.Add(employeeStatistic);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["EmployeeId"] = new SelectList(this.context.Employees, "Id", "Name", employeeStatistic.EmployeeId);
            return this.View(employeeStatistic);
        }

        /// <summary>
        /// GET: EmployeeStatistic/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employeeStatistic = await this.context.EmployeeStatistics.SingleOrDefaultAsync(m => m.Id == id);
            if (employeeStatistic == null)
            {
                return this.NotFound();
            }

            this.ViewData["EmployeeId"] = new SelectList(this.context.Employees, "Id", "Name", employeeStatistic.EmployeeId);
            return this.View(employeeStatistic);
        }

        /// <summary>
        /// POST: EmployeeStatistic/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="employeeStatistic">The employee statistic.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeStatistic employeeStatistic)
        {
            if (id != employeeStatistic.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                this.context.Update(employeeStatistic);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["EmployeeId"] = new SelectList(this.context.Employees, "Id", "Name", employeeStatistic.EmployeeId);
            return this.View(employeeStatistic);
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

            var employeeStatistic = await this.context.EmployeeStatistics
                .Include(e => e.Employee)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeeStatistic == null)
            {
                return this.NotFound();
            }

            return this.View(employeeStatistic);
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
            var employeeStatistic = await this.context.EmployeeStatistics.SingleOrDefaultAsync(m => m.Id == id);
            this.context.EmployeeStatistics.Remove(employeeStatistic);
            await this.context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool EmployeeStatisticExists(int id)
        {
            return this.context.EmployeeStatistics.Any(e => e.Id == id);
        }
    }
}
