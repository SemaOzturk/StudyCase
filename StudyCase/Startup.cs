using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudyCase.Application;
using StudyCase.Application.Entities;
using StudyCase.Domain;
using StudyCase.Repository;

namespace StudyCase
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudyCase", Version = "v1" });
            });
            services.AddDbContext<DbContext, StudyDbContext>(builder =>
                builder.UseSqlServer(@"Data Source=.;Initial Catalog=StudyCase;Integrated Security=True"));
            services.AddScoped<IRepository<QueueMessage>, Repository<QueueMessage>>();
          services.AddMediatR(typeof(Domain.CQ.Domain), typeof(SaveQueueMessageHandler));
          //  services.AddMediatR(Assembly.GetExecutingAssembly());
            // services.AddSingleton(Configuration.GetSection("RabbitMqOptions").Get<RabbitMqOptions>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyCase v1"));
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
