using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chat.Domain.Repositories;
using Chat.Infrastructure.Interface;
using ChatApp.Server.Domain;
using chatServer.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace chatServer
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

            services.AddScoped<DbConnection>();
            services.AddScoped<IUser, UserRepository>();

            //Real-time
            services.AddSignalR();

            services.AddCors(options => {
                options.AddPolicy("Client", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials()
                        .WithOrigins("https://brpchat.herokuapp.com",
                                     "http://brpchat.herokuapp.com");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatApp.Server", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatApp.Server v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("Client");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
