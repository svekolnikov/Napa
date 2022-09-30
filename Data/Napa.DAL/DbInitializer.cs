using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Napa.DAL.Context;
using Napa.Domain.Entities.Identity;
using Napa.Interfaces;


namespace Napa.DAL
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationDbContext dbContext,
            IServiceProvider serviceProvider,
            ILogger<DbInitializer> logger)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task Initialize(CancellationToken cancel = default)
        {
            _logger.LogInformation("Initialization of database...");

            try
            {

                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync(cancel).ConfigureAwait(false);
                if (pendingMigrations.Any())
                {
                    _logger.LogInformation("Migration started...");
                    await _dbContext.Database.MigrateAsync(cancel).ConfigureAwait(false);
                    _logger.LogInformation("Migration finished");
                }

                await InitializeBase(cancel).ConfigureAwait(false);
                _logger.LogInformation("Initialization of database finished");
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Initialization of database was interrupted");
                throw;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e, "Error while initialization of database");
                throw;
            }
        }


        private async Task InitializeBase(CancellationToken cancel = default)
        {
            var roleManager = _serviceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = _serviceProvider.GetRequiredService<UserManager<User>>();

            //Seed Admin
            var admin = new User
            {
                FirstName = "Johnny ",
                LastName = "Deep",
                UserName = "johnny.deep@company.com",
                Email = "johnny.deep@company.com",
            };

            if (await userManager.FindByEmailAsync(admin.Email) is null)
            {
                var result = await userManager.CreateAsync(admin, "AdminPa$$w0rd1");
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("Admin"))
                        await roleManager.CreateAsync(new Role("Admin"));

                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            //Seed User
            var user = new User
            {
                FirstName = "Jack",
                LastName = "Sparrow",
                UserName = "jack.sparrow@company.com",
                Email = "jack.sparrow@company.com",
            };

            if (await userManager.FindByEmailAsync(user.Email) is null)
            {
                var result = await userManager.CreateAsync(user, "UserPa$$w0rd1");
                if (result.Succeeded)
                {
                    if (!await roleManager.RoleExistsAsync("User"))
                        await roleManager.CreateAsync(new Role("User"));

                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}