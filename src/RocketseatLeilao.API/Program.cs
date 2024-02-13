using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RocketseatLeilao.API.Contratos;
using RocketseatLeilao.API.Filtros;
using RocketseatLeilao.API.Repositorios;
using RocketseatLeilao.API.Repositorios.DataAcces;
using RocketseatLeilao.API.Serviços;
using RocketseatLeilao.API.UseCase.Leiloes.GetCurrent;
using RocketseatLeilao.API.UseCase.Ofertas.CriarOferta;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                      Enter 'Bearer' [space] and then your token in the text input below;
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<AutorizacaoUserAtributo>();
builder.Services.AddScoped<ILoginUser, LoginUser>();
builder.Services.AddScoped<CriarOfertaUseCase>();
builder.Services.AddScoped<GetCurrentLeilaoUseCase>();
builder.Services.AddScoped<ILeilaoRepository, LeilaoRepository>();
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<RocketseatLeilaoDbContext>(options =>
{
    options.UseSqlite(@"Data Source=C:\Users\criss\Downloads\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
