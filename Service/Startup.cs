using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NETDemo.Data.Repository;
using NETDemo.Data.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NETDemo.Domain;
using System.Threading.Tasks;
using static NETDemo.Domain.Handlers.QueryHandlers.GetAllCustomersQuery;
using NETDemo.Domain.Handlers.QueryHandlers;
using SimpleInjector;
using System.ComponentModel.Design;
using NETDemo.Data.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using Ninject.Activation;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service", Version = "v1" });
            //});


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API - V1.0", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "Demo API - V2.0", Version = "v2" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });



            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddMediatR(typeof(GetAllCustomersQueryHandler));
            //services.AddTransient<ICustomerRepository, CustomerRepository>();
            //services.AddDbContext<T>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("Connectionstring")));
            //services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            //services.AddSingleton<ICustomerRepository, CustomerRepository>();
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddSingleton<ICustomerRepository, CustomerRepository>();
            //services.AddMediatR(typeof(ICustomerRepository).GetTypeInfo().Assembly);

            //services.AddMediatR(typeof(Startup));
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //var assembly = AppDomain.CurrentDomain.Load("NETDemo.Domain");
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //var assembly = AppDomain.CurrentDomain.Load("NETDemo.Domain");
            //services.AddMediatR(assembly);

            //services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));

            // Add EF core
            services.AddDbContext<TechnicalAssignmentContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connectionstring")));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly(),
                          typeof(GetAllCustomersQuery).Assembly,
                          typeof(ICustomerRepository).Assembly,
                          typeof(CustomerRepository).Assembly,
                           typeof(TechnicalAssignmentContext).Assembly);

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(typeof(GetAllCustomersQuery));
            //services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(GetAccountListQuery));
            //services.AddMediatR(typeof(GetAllCustomersQuery));
            //services.AddMediatR(typeof(NETDemo.Domain.Handlers.QueryHandlers.GetAllCustomersQuery), typeof(NETDemo.Data.Models.DatabaseModels.Customer));


            // API versioning
            services.AddApiVersioning(options =>
            {
                // For versioning (URL & query string versioning)
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;

                // For header versioning
                //options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");
            });


            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service v1"));
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "V1.0");
                    c.SwaggerEndpoint($"/swagger/v2/swagger.json", "V2.0");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
