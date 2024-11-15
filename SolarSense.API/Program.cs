using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SolarSense.Repository.Interface;
using SolarSense.Repository;
using SolarSense.Services.Services;

namespace Pharmaease.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IProdPainelService, ProdPainelService>();

            // Configuração para o Oracle
            builder.Services.AddDbContext<SolarDBContext>(options =>
                options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase"))); // Usando Oracle aqui

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SolarSense API",
                    Version = "v1",
                    Description = "Documentação da API para o serviço de monitoramento de energia e paineis solares Solar Sense\n" +
                    "\nArthur Mitsuo Yamamoto - RM551283 |" +
                    " Daniel dos Santos Araujo Faria - RM99067 |" +
                    " Enzo Lafer Gallucci - RM551111 |" +
                    " Francineldo Luan Martins Alvelino - RM99558 |" +
                    " Ramon Cezarino Lopez - RM551279 |",
                    Contact = new OpenApiContact
                    {
                        Name = "Grupo SolarSense",
                        Email = ""
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            var app = builder.Build();

            // Configuração do pipeline de requisições HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
