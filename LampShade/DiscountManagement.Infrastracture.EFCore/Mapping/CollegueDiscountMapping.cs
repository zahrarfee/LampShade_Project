using System;
using System.Collections.Generic;
using System.Text;
using DiscountManagement.Domain.CollegueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastracture.EFCore.Mapping
{
    public class CollegueDiscountMapping:IEntityTypeConfiguration<CollegueDiscount>
    {
        public void Configure(EntityTypeBuilder<CollegueDiscount> builder)
        {
            builder.ToTable("CollegueDiscounts");
            builder.HasKey(x => x.Id);
        }
    }
}
