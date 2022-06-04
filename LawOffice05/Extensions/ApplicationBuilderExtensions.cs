using LawOffice05.Infrastructure.Data;
using LawOffice05.Infrastructure.Identity;
using static LawOffice05.Core.Constants.WebConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LawOffice05.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            //MigrateDatabase(services);
            SeedCompanyInfo(services);
            SeedOrderProblemType(services);
            SeedAdministrator(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCompanyInfo(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.CompanyInfos.Any())
            {
                return;
            }

            data.CompanyInfos.AddRange(new[]
            {
                new CompanyInfo { TypeOfLaw = "Наказателно Право", InfoAboutLaw = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new CompanyInfo { TypeOfLaw = "Търговско Право", InfoAboutLaw = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new CompanyInfo { TypeOfLaw = "Трудово Право", InfoAboutLaw = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new CompanyInfo { TypeOfLaw = "Международно Право", InfoAboutLaw = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." }
            });

            data.SaveChanges();
        }

        private static void SeedOrderProblemType(IServiceProvider services)
        {
            var data = services.GetRequiredService<ApplicationDbContext>();

            if (data.OrderProblemTypes.Any())
            {
                return;
            }

            data.OrderProblemTypes.AddRange(new[]
            {
                new OrderProblemType { ProblemType = "Road accident"},
                new OrderProblemType { ProblemType = "Family problems"},
                new OrderProblemType { ProblemType = "Property problems"},
                new OrderProblemType { ProblemType = "Tax problems"},
                new OrderProblemType { ProblemType = "Other"}
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var userManager = services.GetService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    //var role = new IdentityRole { Name = AdministratorRoleName };
                    var role = new IdentityRole { Name = "Test" };

                    //if (!await roleManager.RoleExistsAsync(AdministratorRoleName))
                    if (!await roleManager.RoleExistsAsync("Test"))
                    {                      
                        await roleManager.CreateAsync(role);

                        //return;
                    }

                    const string adminEmail = "admin@admin.adm";
                    const string adminPassword = "admin123";

                    var user = new ApplicationUser
                    {
                        //Email = adminEmail,
                        //UserName = adminEmail,
                        //Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                        Email = "admin@admin.adm",
                        UserName = "admin123",
                        FirstName = "Admin",
                        LastName = "Adminov"
                    };

                    //await userManager.CreateAsync(user, adminPassword);
                    await userManager.CreateAsync(user, "admin123");

                    //await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
