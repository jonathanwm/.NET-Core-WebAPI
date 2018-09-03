﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWM.Clinic.AccessData.Entity.Context;
using JWM.Clinic.AccessData.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using JWM.Repositories.Comum;
using JWM.Clinic.Repository.Entity;
using JWM.Repositories.Comum.Entity;
using JWM.Clinic.Models;
using JWM.Services.Comum;
using JWM.Services;

namespace JWM.Clinic
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
            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Configuration["ConnectionStrings:BancoDB"];
            services.AddDbContext<Contexto>(
                opts => opts.UseNpgsql(connectionString)
            );

            
            services.AddScoped<IRepositoryAnimal, RepositoryAnimal>();
            services.AddScoped<IRepositoryVeterinary, RepositoryVeterinary>();
            services.AddScoped<IRepositoryHandbook, RepositoryHandbook>();
            services.AddScoped<IServiceAnimal, ServiceAnimal>();
            services.AddScoped<IServiceVeterinary, ServiceVeterinary>();
            services.AddScoped<IServiceHandbook, ServiceHandbook>();
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
