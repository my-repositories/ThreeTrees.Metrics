// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System;

using Microsoft.AspNetCore.Mvc;
using ThreeTrees.Metrics.Domain.Employees.Commands;
using ThreeTrees.Metrics.Domain.Employees.Queries;
using ThreeTrees.Tools.Domain.Exceptions;
using ThreeTrees.Tools.Messages.Abstractions;

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
        /// <returns>The view result.</returns>
        public ViewResult Index()
        {
            return this.View(this.employeeQueries.GetAll());
        }

        /// <summary>
        /// GET: Employee/Details/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The view result.</returns>
        public ViewResult Details(int id)
        {
            return this.View(this.employeeQueries.Get(id));
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
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEmployeeCommand command)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            // TODO: Replace context to commands
            // this.context.Add(command);
            // this.context.SaveChanges();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public IActionResult Edit(int id)
        {
            var employee = this.employeeQueries.Get(id);
            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(new UpdateEmployeeCommand(employee));
        }

        /// <summary>
        /// POST: Employee/Edit/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="command">The create employee command.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdateEmployeeCommand command)
        {
            if (id != command.EmployeeId)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(command);
            }

            // TODO: Replace context to commands
            // this.context.Update(command);
            // this.context.SaveChanges();
            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// GET: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        public ViewResult Delete(int id)
        {
            return this.View(new DeleteEmployeeCommand(id));
        }

        /// <summary>
        /// POST: Employee/Delete/5
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Replace context to commands
            try
            {
                // pipelineService.HandleCommand(new DeleteProductCommand(id));
            }
            catch (DomainException ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(id);
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
