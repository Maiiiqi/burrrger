using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerSystem.Ability;
using BurgerSystem.Http.Client;
using Youshow.Ace;
using Youshow.Ace.AspNetCore.Web;
using Youshow.Ace.AspNetCore.Web.Conventions;
using Youshow.Ace.Modularity;

namespace BurgerSystem.Web
{
    [RelyOn(
        typeof(AceAspNetCoreWebModule),
        typeof(BurgerSystemHttpClientModule),
        typeof(BurgerSystemAbilityModule)
    )]
    public class BurgerSystemWebModule : AceModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // Add services to the container.
            context.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            context.Services.AddEndpointsApiExplorer();
            // register cors: solve cross-origin problem
            context.Services.AddCors(c => c.AddPolicy("any", p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            context.Services.AddSwaggerGen(c =>
            {
                c.DocInclusionPredicate((_, _) => true);
            });
            Configure<AceAspNetCoreWebOptions>(opt =>
            {
                opt.Create<BurgerSystemAbilityModule>();
            });
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetWebApplication();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // use cors: solve cross-origin problem
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
