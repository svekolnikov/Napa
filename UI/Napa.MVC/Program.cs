using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Napa.DAL.Context;
using Napa.DTO.Options;
using Napa.Interfaces;
using Napa.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

//My services
services.AddScoped<IProductService, ProductService>();

//Mapper
services.AddAutoMapper(Assembly.GetEntryAssembly());

//VAT from options
builder.Services.Configure<ConfigDetails>(builder.Configuration);

//Database
services.AddDbContext<ApplicationDbContext>(optionsAction => optionsAction
    .UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQL")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
