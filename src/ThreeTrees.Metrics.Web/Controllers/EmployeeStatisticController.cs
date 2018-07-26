// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Saritasa.Tools.Messages.Abstractions;

using ThreeTrees.Metrics.Domain.Employees.Queries;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Commands;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Queries;

namespace ThreeTrees.Metrics.Web.Controllers
{
    /// <inheritdoc />
    public class EmployeeStatisticController : Controller
    {
        private readonly EmployeeQueries employeeQueries;
        private readonly EmployeeStatisticQueries employeeStatisticQueries;
        private readonly IMessagePipelineService pipelineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeStatisticController"/> class.
        /// </summary>
        /// <param name="employeeQueries">The employee queries.</param>
        /// <param name="employeeStatisticQueries">The employee statistic queries.</param>
        /// <param name="pipelineService">The pipeline service.</param>
        public EmployeeStatisticController(EmployeeQueries employeeQueries, EmployeeStatisticQueries employeeStatisticQueries, IMessagePipelineService pipelineService)
        {
            this.employeeQueries = employeeQueries ?? throw new ArgumentNullException(nameof(employeeQueries));
            this.employeeStatisticQueries = employeeStatisticQueries ?? throw new ArgumentNullException(nameof(employeeStatisticQueries));
            this.pipelineService = pipelineService ?? throw new ArgumentNullException(nameof(pipelineService));
        }

        /// <summary>
        /// GET: EmployeeStatistic
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Index(CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeStatisticQueries.GetAllAsync(token));
        }

        /// <summary>
        /// GET: EmployeeStatistic/Details/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Details(int id, CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeStatisticQueries.GetAsync(id, token));
        }

        /// <summary>
        /// GET: EmployeeStatistic/Create
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Create(CancellationToken token = default(CancellationToken))
        {
            this.ViewBag.EmployeeId = new SelectList(await this.employeeQueries.GetAllAsync(token), "Id", "Name");
            return this.View(new CreateEmployeeStatisticCommand());
        }

        /// <summary>
        /// POST: EmployeeStatistic/Create
        /// </summary>
        /// <param name="command">The create employee statistic command.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeStatisticCommand command, CancellationToken token = default(CancellationToken))
        {
            this.ViewBag.EmployeeId = new SelectList(await this.employeeQueries.GetAllAsync(token), "Id", "Name");

            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            try
            {
                await this.pipelineService.HandleCommandAsync(command, token);
            }
            catch (MessageProcessingException)
            {
                this.ModelState.AddModelError(string.Empty, "Statistic already exists for this user and selected date.");
                return this.View(command);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: EmployeeStatistic/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        public async Task<ViewResult> Edit(int id, CancellationToken token = default(CancellationToken))
        {
            this.ViewBag.EmployeeId = new SelectList(await this.employeeQueries.GetAllAsync(token), "Id", "Name");
            return this.View(new UpdateEmployeeStatisticCommand(await this.employeeStatisticQueries.GetAsync(id, token)));
        }

        /// <summary>
        /// POST: EmployeeStatistic/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="command">The create employee statistic command.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateEmployeeStatisticCommand command, CancellationToken token = default(CancellationToken))
        {
            this.ViewBag.EmployeeId = new SelectList(await this.employeeQueries.GetAllAsync(token), "Id", "Name");

            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            try
            {
                await this.pipelineService.HandleCommandAsync(command, token);
            }
            catch (MessageProcessingException)
            {
                this.ModelState.AddModelError(string.Empty, "Statistic already exists for this user and selected date.");
                return this.View(command);
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: EmployeeStatistic/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        public async Task<ViewResult> Delete(int id, CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeStatisticQueries.GetAsync(id, token));
        }

        /// <summary>
        /// POST: EmployeeStatistic/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> DeleteConfirmed(int id, CancellationToken token = default(CancellationToken))
        {
            await this.pipelineService.HandleCommandAsync(new DeleteEmployeeStatisticCommand(id), token);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: EmployeeStatistic/Total
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Total(CancellationToken token = default(CancellationToken))
        {
            var result = await this.employeeStatisticQueries.GetTotalAsync(token);
            return this.View(result.OrderBy(x => x.Year));
        }

        /// <summary>
        /// GET: EmployeeStatistic/ByYear
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        [Route("~/EmployeeStatistic/ByYear/{year:int}")]
        public async Task<ViewResult> ByYear(int year, CancellationToken token = default(CancellationToken))
        {
            var years = Enumerable.Range(2000, DateTime.Now.Year - 1999);
            var options = years.Select(value => new { Value = value, Selected = value == year });
            this.ViewBag.years = new SelectList(options, "Value", "Value");

            return this.View(new[]
            {
                await this.employeeStatisticQueries.GetByYearAsync(year, "BilledHours", stat => stat.BilledHours),
                await this.employeeStatisticQueries.GetByYearAsync(year, "CompletedTasks", stat => stat.CompletedTasks),
                await this.employeeStatisticQueries.GetByYearAsync(year, "DrunkedCups", stat => stat.DrunkedCups),
                await this.employeeStatisticQueries.GetByYearAsync(year, "PlayedMcGames", stat => stat.PlayedMcGames),
            });
        }
    }
}
