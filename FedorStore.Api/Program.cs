using FedorStore.Api.DAL;
using FedorStore.Api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
var dbConnString = builder.Configuration.GetConnectionString("Products");
var dbConnStringUsers = builder.Configuration.GetConnectionString("Users");

builder.Services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(dbConnString));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseSqlServer(dbConnStringUsers));
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
=======
builder.Services.AddDbContext<UserDbContext>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
>>>>>>> 97fa8c9d025a05c099984761b9d6290805c3f930

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
