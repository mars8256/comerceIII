using comerce.Core.Interfaces.Repositories;
using comerce.Core.Interfaces;
using comerce.Infrastructure.Data;
using comerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<MusicStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);


//https://medium.com/@Afaik_/paso-a-paso-implementando-rest-api-con-net-core-utilizando-clean-architecture-d5cb04c4c79

builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

/*AddSinglenton los servicios son creados la primera vez que son requeridos, despues utilizan la misma instancia*/


/*los servicios son creados cada vez por el request (dependiendo del alcance)*/
//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//builder.Services.AddScoped(typeof(IGenreRepository), typeof(GenreRepository));
//builder.Services.AddScoped(typeof(IClassroomRepository), typeof(ClassroomRepository));


/*los servicios son creados cada vez que son requeridos, funciona mejor para servicios livianos*/
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IGenreRepository), typeof(GenreRepository));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//agregar automaper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
