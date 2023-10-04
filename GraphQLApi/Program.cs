using GraphQLApi;
using Microsoft.EntityFrameworkCore;
using SharedLib;
//using SharedLib.BusinessLayer.Customers;
using SharedLib.BusinessLayer.Products;
// Create and Initialize DB If does not exist
AppCtx.InitializeDatabase();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Services Cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddSorting();
builder.Services.AddGraphQLServer().AddMutationType<Mutation>();

var app = builder.Build();

app.UseHttpsRedirection();


app.UseCors("corsapp");

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapGraphQL("/graphql"));

app.MapControllers();

app.Run();
