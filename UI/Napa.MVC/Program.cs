using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Napa.DAL;
using Napa.DAL.Context;
using Napa.Domain.Entities.Identity;
using Napa.DTO.Options;
using Napa.Interfaces;
using Napa.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

//My services
services.AddScoped<IProductService, ProductService>();
//Database initializer service 
services.AddTransient<IDbInitializer, DbInitializer>();

//Identity
services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<UserManager<User>>()
    .AddDefaultTokenProviders();

//Identity config
services.Configure<IdentityOptions>(identityOptions =>
{
    identityOptions.User.RequireUniqueEmail = true;
    identityOptions.Password.RequiredLength = 6;
    identityOptions.SignIn.RequireConfirmedEmail = false;
});

//Authentication
services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "Napa";
    config.Cookie.HttpOnly = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);

    config.LoginPath = "/users/login";

    config.SlidingExpiration = true;
});

//Mapper
services.AddAutoMapper(Assembly.GetEntryAssembly());

//VAT from options
builder.Services.Configure<ConfigDetails>(builder.Configuration);

//Database
services.AddDbContext<ApplicationDbContext>(optionsAction => optionsAction
    .UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

var app = builder.Build();


//Initialize database
await using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await db.Initialize();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
