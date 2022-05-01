using System;
using System.Collections.Generic;
using System.Text;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastracture.EFCore
{
    public class InventoryContext:DbContext
    {
        public  DbSet<Inventory> Inventories { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asmbly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asmbly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
