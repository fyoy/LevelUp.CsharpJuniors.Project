using FedorStore.WebUI.DAL;
using FedorStore.WebUI.Models;
using FedorStore.WebUI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var endpoints = builder.Configuration.GetSection("Endpoints").Get<Endpoints>();
builder.Services.AddHttpClient("default",
    (c) =>
    {
        c.BaseAddress = new Uri(endpoints.BaseUrl);
    });

builder.Services.AddScoped<IOptions<Endpoints>>(_ => new OptionsWrapper<Endpoints>(endpoints));
builder.Services.AddScoped<IProductsServiceProxy, ProductsServiceProxy>();

var dbUsers = builder.Configuration.GetConnectionString("Users");

builder.Services.AddDbContext<UsersDbContext>(options =>
    options.UseSqlServer(dbUsers));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
