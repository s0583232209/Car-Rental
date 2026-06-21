//////using Infrastructure.Extensions;
//////var builder = WebApplication.CreateBuilder(args);

//////// Add services to the container.
//////builder.Services.AddInfrastructure(builder.Configuration);
//////builder.Services.AddControllers();
//////// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//////builder.Services.AddOpenApi();

//////builder.Services.AddDbContext<AppDbContext>(options =>
//////    options.UseMySql(
//////        builder.Configuration.GetConnectionString("DefaultConnection"),
//////        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
//////    ));



//////var app = builder.Build();

//////// Configure the HTTP request pipeline.
//////if (app.Environment.IsDevelopment())
//////{
//////    app.MapOpenApi();
//////}

//////app.UseAuthorization();

//////app.MapControllers();

//////app.Run();
////using DAL.Data;
////using Microsoft.EntityFrameworkCore;
////using Services.Mapping;

////var builder = WebApplication.CreateBuilder(args);

////var connectionString =
////    builder.Configuration.GetConnectionString("DefaultConnection");

////builder.Services.AddDbContext<AppDbContext>(options =>
////    options.UseMySql(
////        connectionString,
////        ServerVersion.AutoDetect(connectionString)
////    ));
////builder.Services.AddAutoMapper(typeof(MappingProfile));
////builder.Services.AddControllers();

////var app = builder.Build();

////app.MapControllers();

////app.Run();
//using Scalar.AspNetCore;  // ← הוסיפי בראש הקובץ
//using AutoMapper;
//using DAL.Data;
//using DAL.Entities;
//using DAL.Interfaces;
//using DAL.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Services.Classes;
//using Services.DTOs;
//using Services.Interfaces;
//using Services.Mapping;

//var builder = WebApplication.CreateBuilder(args);

//var connectionString =
//    builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(
//        connectionString,
//        new MySqlServerVersion(new Version(8, 0, 0))  // ← במקום ServerVersion.AutoDetect
//    ));
//builder.Services.AddAutoMapper(typeof(MappingProfile));

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
//builder.Services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
//builder.Services.AddScoped<IRepository<Rental>, RentalRepository>();
//builder.Services.AddScoped<IRepository<Payment>, PaymentRepository>();

//builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
//builder.Services.AddScoped<IService<VehicleDTO>, VehiclesService>();
//builder.Services.AddScoped<IService<RentalDTO>, RentalService>();
//builder.Services.AddScoped<IService<PaymentDTO>, PaymentService>();
//builder.Services.AddOpenApi();

//var app = builder.Build();

//if (app.Environment.IsDevelopment()||true)
//{
//    app.MapOpenApi();
//    app.MapScalarApiReference();
//}


//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using Scalar.AspNetCore;
using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.DTOs;
using Services.Interfaces;
using Services.Mapping;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 0))));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Repositories
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
builder.Services.AddScoped<IRepository<Rental>, RentalRepository>();
builder.Services.AddScoped<IRepository<Payment>, PaymentRepository>();

// Services
builder.Services.AddScoped<IService<CustomerDTO>, CustomerService>();
builder.Services.AddScoped<IService<VehicleDTO>, VehiclesService>();
builder.Services.AddScoped<IService<RentalDTO>, RentalService>();
builder.Services.AddScoped<IService<PaymentDTO>, PaymentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()||true)
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();
app.MapControllers();
app.Run();