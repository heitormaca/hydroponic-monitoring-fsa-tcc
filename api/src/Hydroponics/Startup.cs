using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Hydroponics.Models;
using Hydroponics.Repositories;
using Hydroponics.Useful;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Hydroponics
{
    public class Startup
    {
        readonly string PermissaoEntreOrigens = "_PermissaoEntreOrigens";
        private readonly IConfiguration config;
        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("pt-br"),
                new CultureInfo("en")
            };
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = Int32.MaxValue;
            });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-br");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });
            services.AddTransient<LoginRepository>();
            services.AddTransient<ProdutorRepository>();
            services.AddTransient<EstufaRepository>();
            services.AddTransient<BancadaRepository>();
            services.AddTransient<Cryptography>();
            services.AddTransient<Email>();
            services.AddTransient<UploadImage>();
            services.AddDbContext<hydroponicsContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Default"))
            );
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  
            .AddJwtBearer(options =>  
            {  
                options.TokenValidationParameters = new TokenValidationParameters  
                {  
                    ValidateIssuer = true,  
                    ValidateAudience = true,  
                    ValidateLifetime = true,  
                    ValidateIssuerSigningKey = true,  
                    ValidIssuer = config["Jwt:Issuer"],  
                    ValidAudience = config["Jwt:Issuer"],  
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))  
                };  
            });
            services.AddCors (options => {
                options.AddPolicy (PermissaoEntreOrigens,
                    builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization();

            app.UseCors (builder => builder.AllowAnyOrigin ().AllowAnyMethod ().AllowAnyHeader ());

            app.UseAuthentication();

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                // https://localhost:5001/swagger/index.html
            });
        }
    }
}
