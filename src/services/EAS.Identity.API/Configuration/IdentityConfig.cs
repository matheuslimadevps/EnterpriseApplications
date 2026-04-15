using EAS.Identity.API.Data;
using EAS.Identity.API.Extensions;
using EAS.WebApi.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EAS.Identity.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            /*Aqui adicionamos nosso ApplicationDbContext, usamos o SQL Server e configuramos para 
              o GetConnectionString apontar para nossa appsettings e procurar por DefaultConnection
              que está com nossos dados do banco já configurada.*/
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            //Aqui estamos adicionando em services a identidade do usuário
            //AddRoles: suporte as regras de perfil de usuário
            /*AddEntityFrameworkStores: falando para a aplicação que ela vai trabalhar com o EF e 
            o contexto do banco que ele vai utilizar.*/
            /*AddDefaultTokenProviders: tokens que são gerados para autenticação de contas novas,
            recuperação de contas e enfim, uma criptografia dentro de um link para reconhecer o 
            usuário, que é justamente ele quem deveria receber aquele email.*/
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<MensagensIdentityPortugues>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);

            return services;
        }
    }
}
