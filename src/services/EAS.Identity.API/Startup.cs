using EAS.Identity.API.Configuration;
using EAS.Identity.API.Data;
using EAS.Identity.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS.Identity.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            //instancia de ConfigurationBuilder para criar uma config completa.
            var builder = new ConfigurationBuilder()
                //pegando caminho de onde está a aplicação
                .SetBasePath(hostEnvironment.ContentRootPath)
                //para descobrir o arquivo app settings.json e adicione a config
                .AddJsonFile("appsettings.json", true, true)
                //adicionamos também outro arquivo dependendo do ambiente que eu estiver
                .AddJsonFile($"apssetings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            //se for ambiente de desenvolvimento, utilizo o secrets para não colocar uma chave privada minha no fonte.
            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UserSwaggerConfiguration();
            app.UseApiConfiguration(env);
        }
    }
}
