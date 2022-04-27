using System;
using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.CollegueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CollegueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastracture.EFCore;
using DiscountManagement.Infrastracture.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();


            services.AddTransient<ICollegueDiscountRepository, CollegueDiscountRepository>();

            services.AddTransient<ICollegueDiscountApplication, CollegueDiscountApplication>();



            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}








