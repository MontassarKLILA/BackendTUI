using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.BusinessLayer.CustomerFiles;
using SharedLib.BusinessLayer.Customers;
using SharedLib.BusinessLayer.Products;

// Create and Initialize DB If does not exist
AppCtx.InitializeDatabase();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppCtx>(
    options => options.UseSqlite(@"Data Source=..\SharedLib\Files\TravelAgency.db;Cache=Shared")
    );

//Services Cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddScoped<ICustomerFileServices, CustomerFileServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");


app.UseAuthorization();

app.MapControllers();

app.Run();
