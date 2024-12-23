using FluxoDeCaixa.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FluxoDeCaixa.API;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Configuração dos serviços
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddInfrastructure(_configuration);

        services
            .AddRazorPages(options =>
            {
                options.Conventions.AllowAnonymousToPage("/");
                options.Conventions.AllowAnonymousToPage("/Login");
            })
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();

        services
                .AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login"; // Caminho da página de login
                    //Soptions.AccessDeniedPath = "/AccessDenied"; // Opcional: página de acesso negado
                    options.ExpireTimeSpan = TimeSpan.FromDays(1); // Configura o tempo de expiração do cookie
                    options.SlidingExpiration = true; // Renova o cookie antes de expirar
                });

        services
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FluxoDeCaixa.API",
                    Description = "Uma API para uso interno de dados comuns da aplicação Fluxo de caixa.",
                    Contact = new OpenApiContact
                    {
                        Name = "Gasparello Tech"
                    }
                });

                c.TagActionsBy(api =>
                {
                    if (api.GroupName != null)
                        return new[] { api.GroupName };

                    if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                        return new[] { controllerActionDescriptor.ControllerName };

                    throw new InvalidOperationException("Não foi possível determinar a tag para o endpoint.");
                });

                c.DocInclusionPredicate((name, api) => true);
            });


        services
               .AddCors(options =>
               {
                   options.AddPolicy("AnyOrigin", builder =>
                   {
                       builder
                           .AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                   });
               });       

    }

    // Configuração do pipeline de middleware
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors("AnyOrigin");

        app.UseStaticFiles();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluxoDeCaixa.API v1");

#if !DEBUG
                c.DefaultModelsExpandDepth(-1);
#endif
            c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

            c.RoutePrefix = "swagger-api"; // Define o prefixo explícito para acessar o Swagger

            //c.InjectStylesheet("/swagger/themes/3.x/theme-material.css");
            //c.InjectStylesheet("/swagger/themes/custom.css");
        });

        using (var scope = app.ApplicationServices.CreateScope())
        {
            /*
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.EnsureCreated();

            var pendingMigrations = db.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
                db.Database.Migrate();
            */
        }
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseStatusCodePagesWithRedirects("~/{0}.html");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });
    }
}
