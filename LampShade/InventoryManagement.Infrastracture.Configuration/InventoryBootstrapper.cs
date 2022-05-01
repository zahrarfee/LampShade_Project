using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EFCore.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application;
using InventoryManagement.Infrastracture.EFCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastracture.Configuration
{
    public class InventoryBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InventoryApplication>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));


        }
    }
}
