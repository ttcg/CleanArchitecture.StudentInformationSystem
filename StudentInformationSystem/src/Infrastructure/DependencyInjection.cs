using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentInformationSystem.Application.Common.Interfaces;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Infrastructure.Identity;
using StudentInformationSystem.Infrastructure.Persistence;
using StudentInformationSystem.Infrastructure.Repositories;
using StudentInformationSystem.Infrastructure.Services;

namespace StudentInformationSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("StudentInformationSystemDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IDomainEventService, DomainEventService>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
        {
            options.Clients.Add(
                new Client
                {
                    ClientId = "postman",
                    ClientSecrets = { new Secret("8ZE7fDu4rcfHWYmK".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    AllowOfflineAccess = true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "StudentInformationSystem.WebApiAPI"
                    }
                });
        });

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddSingleton<IStudentRepository, InMemoryStudentRepository>();
        services.AddSingleton<ICourseRepository, InMemoryCourseRepository>();
        services.AddSingleton<ITeacherRepository, InMemoryTeacherRepository>();
        services.AddSingleton<IEnrolmentRepository, InMemoryEnrolmentRepository>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        //services.AddAuthentication();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
