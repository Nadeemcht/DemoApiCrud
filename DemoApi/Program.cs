using AutoMapper;
using DemoApi.Container;
using DemoApi.Helper;
using DemoApi.Repos;
using DemoApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddDbContext<LearndataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("apicon")));
var automapper = new MapperConfiguration(item => item.AddProfile( new AutoMapperHandler()));
IMapper mapper=automapper.CreateMapper();
builder.Services.AddSingleton(mapper);  

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
