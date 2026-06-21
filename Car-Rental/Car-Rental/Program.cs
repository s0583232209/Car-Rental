////using Infrastructure.Extensions;
////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.
////builder.Services.AddInfrastructure(builder.Configuration);
////builder.Services.AddControllers();
////// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
////builder.Services.AddOpenApi();

////builder.Services.AddDbContext<AppDbContext>(options =>
////    options.UseMySql(
////        builder.Configuration.GetConnectionString("DefaultConnection"),
////        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
////    ));



////var app = builder.Build();

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.MapOpenApi();
////}

////app.UseAuthorization();

////app.MapControllers();

////app.Run();
//using DAL.Data;
//using Microsoft.EntityFrameworkCore;
//using Services.Mapping;

//var builder = WebApplication.CreateBuilder(args);

//var connectionString =
//    builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(
//        connectionString,
//        ServerVersion.AutoDetect(connectionString)
//    ));
//builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddControllers();

//var app = builder.Build();

//app.MapControllers();

//app.Run();
using AutoMapper;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.DTOs;
using Services.Interfaces;
using Services.Classes;
using VehicleRental.BLL.Mapping;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
builder.Services.AddScoped<IRepository<Rental>, RentalRepository>();
builder.Services.AddScoped<IRepository<Payment>, PaymentRepository>();

builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
builder.Services.AddScoped<IService<VehicleDTO>, VehiclesService>();
builder.Services.AddScoped<IService<RentalDTO>, RentalService>();
builder.Services.AddScoped<IService<PaymentDTO>, PaymentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

app.Run();