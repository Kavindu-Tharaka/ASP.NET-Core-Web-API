using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ResturentAPI.Data;
using ResturentAPI.Repositories.Product;
using ResturentAPI.Repositories.ProductCategory;
using ResturentAPI.Repositories.Resturant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ResturentAPI
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
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ResturentAPI", Version = "v1" });
            });

            services.AddTransient<IProductRepository, ProductRepository>();  //singleton, scoped dala wenasa balanna
            services.AddTransient<IResturantRepository, ResturantRepository>();  //singleton, scoped dala wenasa balanna
            services.AddTransient<IProductCategoriesRepository, ProductCategoriesRepository>();  //singleton, scoped dala wenasa balanna

            //services.AddDbContext<ResturantStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ResturantStoreDB")));

            services.AddDbContext<ResturantStoreContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ResturantStoreDBPostgres")));

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ResturentAPI v1"));
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
