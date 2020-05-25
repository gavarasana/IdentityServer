// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ravi.Learn.IdentityServer.Configurations;
using Serilog;
using System.Linq;

namespace Ravi.Learn.IdentityServer
{
    public class SeedData
    {
        public static void EnsureSeedData(string idpConfigurationConnectionStrong) //, string idpGrantsConnectionString)
        {
            var services = new ServiceCollection();

            services.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlServer(idpConfigurationConnectionStrong, sql => sql.MigrationsAssembly("Ravi.Learn.IdentityServer"));
            });
            //services.AddOperationalDbContext(options =>
            //{
            //    options.ConfigureDbContext = db => db.UseSqlServer(idpGrantsConnectionString, sql => sql.MigrationsAssembly("Ravi.Learn.IdentityServer"));
            //});

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            //scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();
            var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
            //context.Database.Migrate();
            EnsureSeedData(context);

        }

        private static void EnsureSeedData(IConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                Log.Debug("Clients being populated");
                foreach (var client in Config.Clients.ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Log.Debug("Clients already populated");
            }

            if (!context.IdentityResources.Any())
            {
                Log.Debug("IdentityResources being populated");
                foreach (var resource in Config.Ids.ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Log.Debug("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Log.Debug("ApiResources being populated");
                foreach (var resource in Config.Apis.ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Log.Debug("ApiResources already populated");
            }
        }
    }
}
