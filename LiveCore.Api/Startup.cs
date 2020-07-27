using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveCore.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace LiveCore.Api
{
    public class Startup
    {
        //Install-Package Swashbuckle.AspNetCore -Version 5.0.0-rc4 °²×°swaager
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(m=> {
                m.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title="LiveCoreApi",Version="v1"});
            });

            services.AddCors(m=>m.AddPolicy("any",a=>a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddDbContext<MyContext>(options=> {
                options.UseSqlServer("Data Source=LIVE;Initial Catalog=LiveCore;User Id=sa;Password=123456;");
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors();
            app.UseSwagger();
            app.UseSwaggerUI(m=> {
                m.SwaggerEndpoint("/swagger/v1/swagger.json","swaggerTest");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
