using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

using UpSkillFoundationApi.Repository;
using UpSkillFoundationApi.Models;
using UpSkillFoundationApi.CustomeFormat;
using UpSkillFoundationApi.CustomException;
using UpSkillFoundationApi.Context;
using UpSkillFoundationApi.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace UpSkillFoundationApi
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
            services.AddControllers(opt =>
            {
                opt.RespectBrowserAcceptHeader = true;
                //opt.ReturnHttpNotAcceptable = true; // if want format compulsary
            }).AddNewtonsoftJson().AddXmlSerializerFormatters().AddMvcOptions(options => options.OutputFormatters.Add(new CSVoutputFormatter()));
            services.AddDbContext<AdventureWorks2019Context>(Opt => Opt.UseSqlServer(Configuration.GetConnectionString("conn")));
            services.AddDbContext<AuthenticationContext>(Opt => Opt.UseSqlServer(Configuration.GetConnectionString("conn")));

            // dependency injection
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            services.AddScoped<IEmployeeDepartmentHistoryRepository,EmployeeDepartmentHistoryRepository>();
            services.AddSwaggerGen();
            
            // enable cors
            services.AddCors(cors => cors.AddPolicy("EnableCORS", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            //add identity
            services.AddIdentity<Users, IdentityRole>(o => { o.Password.RequireNonAlphanumeric = false; o.Password.RequireUppercase = false; }).AddEntityFrameworkStores<AuthenticationContext>().AddDefaultTokenProviders();

            // add Authentication
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                
            })
            .AddJwtBearer(o =>
           {

               o.RequireHttpsMetadata = false;
               o.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = false,
                   ValidIssuer = Configuration["JWT:validissure"],
                   ValidAudience = Configuration["JWT:validaudience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:secretkey"]))
               };
           });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "UpSkillSwagger v1"); });
            }
            app.UseExceptionHandler();
            app.UseCors("EnableCORS");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.Use(async (context, next) => {
                if (context.Request.ContentType == "application/csv")
                {
                    context.Response.Headers.Add("Customer Content", "true");
                }
                await next();
            });
            app.UseGlobalExceptionMiddleware();
            app.UseFirstMiddleware();
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath="/images"
            });
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
