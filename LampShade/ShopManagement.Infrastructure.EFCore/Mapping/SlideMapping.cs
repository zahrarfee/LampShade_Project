﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping:IEntityTypeConfiguration<Slide>

    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Picure).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PicureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(255).IsRequired();
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();
        }
    }
}
