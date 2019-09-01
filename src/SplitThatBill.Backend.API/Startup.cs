using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using SplitThatBill.Backend.API.Options;
using Microsoft.Extensions.Options;

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

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    // Use camel case properties in the serializer and the spec (optional)
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    // Use string enums in the serializer and the spec (optional)
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
