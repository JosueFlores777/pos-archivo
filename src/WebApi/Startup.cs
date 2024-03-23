
using Aplicacion.Exceptions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dominio.Models.Regla;
using Dominio.Service;
using Infraestructura.Filters;
using Infraestructura.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.DependencyInjection;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHandlers();
            services.AddContextConfiguration(Configuration);
            services.AddMappers();
            services.AddScoped<UnitOfWordFilter>();
            services.AddAplicacionServices();
            services.AddTokenConfiguration(Configuration);
            services.AddHttpContextAccessor();
            services.AddRedis(Configuration);
            services.AddCorsConfig();
            services.AddSwaggerConf();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IGuardarArchivoAlmacenamiento,GuardarArchivoAlmacenamiento>();

            services.Scan(scan => 
            scan.FromAssemblyOf<IExtensionesPermitidas>()
            .AddClasses(classes => classes.AssignableTo(typeof(IRegla)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
       
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UnitOfWordFilter));
            });
        } 

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
     

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            else
            {

                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpException();
            app.UseRouting();

            //sapp.UseAuthorization();

            /* app.UseEndpoints(endpoints =>
              {
                  endpoints.MapControllers();
              });*/
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Docuemntacion SAPI V1");
               // c.RoutePrefix = string.Empty;
            });
            app.UseCors("ApiCorsPolicy");
            app.UseMvc();


        }
    }
}
