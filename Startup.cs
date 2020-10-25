using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Data;
using Calendar.Repositories;
using Calendar.Repositories.IRepository;
using Calendar.Services;
using Calendar.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Calendar
{
    public class Startup
    {
        public const string AppS3BucketKey = "AppS3Bucket";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICriticalDateRepository, CriticalDateRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICriticalDateService, CriticalDateService>();
            services.AddScoped(factory =>
            {
                return new QueryFactory
                {
                    Compiler = new PostgresCompiler(),
                    Connection = new NpgsqlConnection(Configuration.GetConnectionString("defaultConnection")),
                    Logger = compiled => Console.WriteLine(compiled)
                };
            });


            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDBContext>(opt =>
              opt.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:8080",
                                "https://localhost:8080", "http://localhost:8080/", "https://localhost:8080"
                                )
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });

            // Add S3 to the ASP.NET Core dependency injection framework.
            services.AddAWSService<Amazon.S3.IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
