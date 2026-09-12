using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Hobron.IdentityServer.Data;
using Hobron.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hobron.IdentityServer;

public static class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

        var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        context.Database.Migrate();
        EnsureSeedData(context);

        var identityContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        identityContext.Database.Migrate();

        EnsureIdentityData(scope.ServiceProvider).GetAwaiter().GetResult();
    }

    private static async Task EnsureIdentityData(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        const string adminRole = "admin";
        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            var createRoleResult = await roleManager.CreateAsync(new IdentityRole(adminRole));
            if (!createRoleResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to seed admin role.");
            }
        }

        await EnsureUserAsync(userManager, "alice", "AliceSmith@example.com", "_alice1Spring_", ["Alice", "Smith"]);
        await EnsureUserAsync(userManager, "bob", "BobSmith@example.com", "_bob2Spring_", ["Bob", "Smith"]);
        await EnsureUserAsync(userManager, "admin", "CharlieBrown@example.com", "_admin3Spring_", ["Charlie", "Brown"], [adminRole]);
    }

    private static async Task EnsureUserAsync(
        UserManager<ApplicationUser> userManager,
        string userName,
        string email,
        string password,
        string[] names,
        string[]? roles = null)
    {
        var user = await userManager.FindByNameAsync(userName);
        if (user is null)
        {
            user = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = true
            };

            var createUserResult = await userManager.CreateAsync(user, password);
            if (!createUserResult.Succeeded)
            {
                throw new InvalidOperationException($"Failed to seed user '{userName}'.");
            }

            var claims = new List<System.Security.Claims.Claim>
            {
                new("given_name", names[0]),
                new("family_name", names[1]),
                new("name", $"{names[0]} {names[1]}"),
                new("email", email),
                new("email_verified", "true", System.Security.Claims.ClaimValueTypes.Boolean),
                new("website", $"http://{userName}.example.com"),
                new("picture", "/img/avatar_default.png")
            };

            var addClaimsResult = await userManager.AddClaimsAsync(user, claims);
            if (!addClaimsResult.Succeeded)
            {
                throw new InvalidOperationException($"Failed to seed claims for user '{userName}'.");
            }
        }

        if (roles is null)
        {
            return;
        }

        foreach (var role in roles)
        {
            if (!await userManager.IsInRoleAsync(user, role))
            {
                var addRoleResult = await userManager.AddToRoleAsync(user, role);
                if (!addRoleResult.Succeeded)
                {
                    throw new InvalidOperationException($"Failed to assign role '{role}' to user '{userName}'.");
                }
            }
        }
    }

    private static void EnsureSeedData(ConfigurationDbContext context)
    {
        if (!context.IdentityResources.Any())
        {
            Log.Debug("IdentityResources being populated");
            foreach (var resource in Config.IdentityResources.ToList())
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
        else
        {
            Log.Debug("IdentityResources already populated");
        }

    }
}
