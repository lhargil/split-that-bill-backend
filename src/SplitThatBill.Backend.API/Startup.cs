using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Microsoft.Extensions.Options;
using SplitThatBill.Backend.API.Extensions;
using SplitThatBill.Backend.API.Models;
using SplitThatBill.Backend.Core.Interfaces;
using SplitThatBill.Backend.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using System;
using SplitThatBill.Backend.Business.MappingProfiles;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using SplitThatBill.Backend.SharedKernel.Models;
using SplitThatBill.Backend.SharedKernel;

namespace SplitThatBill.Backend.API
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
            services.Configure<NswagOptions>(Configuration.GetSection("NSwag"));
            var auth0ConfigSection = Configuration.GetSection("Auth0");
            services.Configure<Auth0Config>(auth0ConfigSection);

            services.AddDbContext<SplitThatBillContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("SplitThatBillDb"),
                    config => config.MigrationsAssembly("SplitThatBill.Backend.Data"));
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders(new[] { "Location" });
                });

                options.AddPolicy("OnlyIdentifiedOrigin", builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetValue<string>("CORSOrigin"))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders(new[] { "Location" });
                });
            });

            services.AddRouting(opts => opts.LowercaseUrls = true);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var auth0Config = new Auth0Config();
                auth0ConfigSection.Bind(auth0Config);

                options.Authority = $"https://{auth0Config.Domain}/";
                options.Audience = auth0Config.Audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        if (context.SecurityToken is JwtSecurityToken token)
                        {
                            if (context.Principal.Identity is ClaimsIdentity identity)
                            {
                                identity.AddClaim(new Claim("access_token", token.RawData));
                            }
                        }

                        return Task.FromResult(0);
                    }
                };
            });

            var businessAssembly = Assembly.Load("SplitThatBill.Backend.Business");
            services
                .AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options =>
                {
                    // Use camel case properties in the serializer and the spec (optional)
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    // Use string enums in the serializer and the spec (optional)
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssembly(businessAssembly);
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    fv.ImplicitlyValidateChildProperties = true;
                });
            services.AddOpenApiDocument((config, sp) =>
            {
                var nswagOptions = sp.GetRequiredService<IOptionsMonitor<NswagOptions>>().CurrentValue;
                config.PostProcess = document =>
                {
                    document.Info.Version = nswagOptions.Info.Version;
                    document.Info.Title = nswagOptions.Info.Title;
                    document.Info.Description = nswagOptions.Info.Description;
                    document.Info.TermsOfService = nswagOptions.Info.TermsOfService;
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = nswagOptions.Info.Contact.Name,
                        Email = nswagOptions.Info.Contact.Email,
                        Url = nswagOptions.Info.Contact.Url
                    };
                };
            });

            services.AddScoped<IContextData, RequestContextData>();
            services.AddMediatR(businessAssembly);
            services.AddAutoMapper(businessAssembly);
            services.AddTransient<IDateTimeManager, DateTimeManager>();
            services.AddTransient<IExternalIdGenerator, GuidExternalIdGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseFileServer();
            app.UseRequestContextDataMiddleware();

            if (env.IsDevelopment())
            {
                app.UseCors("AllowAll");
            }
            else
            {
                app.UseCors("OnlyIdentifiedOrigin");
            }

            app.UseMvc();

            if (Convert.ToBoolean(Configuration.GetValue<string>("CanSwag")))
            {
                app.UseOpenApi(config =>
                {
                    config.PostProcess = (document, ctxt) =>
                    {
                        document.Schemes.Clear();
                        document.Schemes.Add(NSwag.OpenApiSchema.Https);
                    };
                });
                app.UseSwaggerUi3();
            }
        }
    }
}
