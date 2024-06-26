using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Models;
using Microsoft.Extensions.DependencyInjection;
using ShoppingListApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShoppingListApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingListApiContext") ?? throw new InvalidOperationException("Connection string 'ShoppingListApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShoppingListContext>(opt => opt.UseInMemoryDatabase("ShoppingList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");

}

else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
