// Copyright (c) ThreeTrees. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.
using System.Reflection;

using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saritasa.Tools.Messages.Abstractions;
using Saritasa.Tools.Messages.Commands;
using Saritasa.Tools.Messages.Common;

using ThreeTrees.Metrics.DataAccess;
using ThreeTrees.Metrics.Domain;
using ThreeTrees.Metrics.Domain.Employees.Entities;
using ThreeTrees.Metrics.Domain.Employees.Queries;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Entities;
using ThreeTrees.Metrics.Domain.EmployeeStatistics.Queries;

namespace ThreeTrees.Metrics.Web
{
    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ConfigureContainer is where you can register things directly
        /// with Autofac. This runs after ConfigureServices so the things
        /// here will override registrations made in ConfigureServices.
        /// Don't build the container; that gets done for you. If you
        /// need a reference to the container, you need to use the
        /// "Without ConfigureContainer" mechanism shown later.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // TODO: Make friends .NET Core and Autofac.
            // builder.RegisterModule(new AutofacModule());
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            var pipelinesContainer = new DefaultMessagePipelineContainer();
            pipelinesContainer.AddCommandPipeline()
                .UseDefaultMiddlewares(
                    Assembly.GetAssembly(typeof(Employee)),
                    Assembly.GetAssembly(typeof(EmployeeStatistic)));

            services.AddSingleton<IMessagePipelineContainer>(pipelinesContainer);

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(this.Configuration.GetConnectionString("AppDbContext")));

            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IAppUnitOfWorkFactory, AppUnitOfWorkFactory>();
            services.AddScoped<EmployeeQueries>();
            services.AddScoped<EmployeeStatisticQueries>();
            services.AddScoped<IMessagePipelineService, DefaultMessagePipelineService>();

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
