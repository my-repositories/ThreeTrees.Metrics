// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Saritasa.Tools.Messages.Abstractions;

using ThreeTrees.Metrics.Domain.Employees.Commands;
using ThreeTrees.Metrics.Domain.Employees.Queries;

namespace ThreeTrees.Metrics.Web.Controllers
{
    /// <inheritdoc />
    public class EmployeeController : Controller
    {
        private readonly EmployeeQueries employeeQueries;
        private readonly IMessagePipelineService pipelineService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeQueries">The employee queries.</param>
        /// <param name="pipelineService">The pipeline service.</param>
        public EmployeeController(EmployeeQueries employeeQueries, IMessagePipelineService pipelineService)
        {
            this.employeeQueries = employeeQueries ?? throw new ArgumentNullException(nameof(employeeQueries));
            this.pipelineService = pipelineService ?? throw new ArgumentNullException(nameof(pipelineService));
        }

        /// <summary>
        /// GET: Employee
        /// </summary>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Index(CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeQueries.GetAllAsync(token));
        }

        /// <summary>
        /// GET: Employee/Details/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns>The view result.</returns>
        public async Task<ViewResult> Details(int id, CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeQueries.GetAsync(id, token));
        }

        /// <summary>
        /// GET: Employee/Create
        /// </summary>
        /// <returns>The view result.</returns>
        public ViewResult Create()
        {
            return this.View(new CreateEmployeeCommand());
        }

        /// <summary>
        /// POST: Employee/Create
        /// </summary>
        /// <param name="command">The create employee command.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateEmployeeCommand command, CancellationToken token = default(CancellationToken))
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            await this.pipelineService.HandleCommandAsync(command, token);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        public async Task<ViewResult> Edit(int id, CancellationToken token = default(CancellationToken))
        {
            return this.View(new UpdateEmployeeCommand(await this.employeeQueries.GetAsync(id, token)));
        }

        /// <summary>
        /// POST: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="command">The create employee command.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateEmployeeCommand command, CancellationToken token = default(CancellationToken))
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            await this.pipelineService.HandleCommandAsync(command, token);
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        public async Task<ViewResult> Delete(int id, CancellationToken token = default(CancellationToken))
        {
            return this.View(await this.employeeQueries.GetAsync(id, token));
        }

        /// <summary>
        /// POST: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="token">The token.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToActionResult> DeleteConfirmed(int id, CancellationToken token = default(CancellationToken))
        {
            await this.pipelineService.HandleCommandAsync(new DeleteEmployeeCommand(id), token);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
