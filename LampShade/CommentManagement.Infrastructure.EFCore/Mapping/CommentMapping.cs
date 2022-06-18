using System;
using System.Collections.Generic;
using System.Text;
using CommentManagement.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CommentManagement.Infrastructure.EFCore.Mapping
{
    public class CommentMapping:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);

            //builder.HasOne(x=>x.Parent).WithMany(x=>x.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
