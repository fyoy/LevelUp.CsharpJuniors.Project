using FedorStore.Api.DAL;
using FedorStore.Api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnString = builder.Configuration.GetConnectionString("Products");
var dbConnStringUsers = builder.Configuration.GetConnectionString("Users");

builder.Services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(dbConnString));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(dbConnStringUsers));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

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
