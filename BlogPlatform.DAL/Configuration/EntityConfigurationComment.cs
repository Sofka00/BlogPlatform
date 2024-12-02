using BlogPlatform.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Configuration
{
    public class EntityConfigurationComment : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Настройка таблицы Comments
            builder.ToTable("Comments")
                .HasKey(e => e.Id);

            builder.Property(c => c.Content)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(c => c.Post)
                   .WithMany(p => p.Comment)
                   .HasForeignKey(c => c.PostId);

            builder.HasOne(c => c.User)
                   .WithMany(u => u.Comment)
                   .HasForeignKey(c => c.UserId);
        }
    }
}
