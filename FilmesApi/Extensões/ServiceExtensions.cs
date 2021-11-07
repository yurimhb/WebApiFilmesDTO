using Contracts;
using Contracts.Model;
using FilmesApi.Data;
using FilmesApi.Model;
using FilmesApi.Repository;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FilmesApi.Extensões
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options => { options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });

        public static void ConfigureMysql(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<FilmeContext>(opts =>
            opts.UseLazyLoadingProxies().UseMySQL(configuration.GetConnectionString("FilmeConnection")));

        public static void ConfigureRepositoryBase(this IServiceCollection services) {
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IGerenteRepository, GerenteRepository>();
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }

    }
}
