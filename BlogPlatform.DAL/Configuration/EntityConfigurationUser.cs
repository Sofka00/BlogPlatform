using BlogPlatform.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BlogPlatform.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL.Configuration
{
    internal class EntityConfigurationUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(e => e.Id);
            builder.Property(p => p.Login)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(e => e.Email).IsUnique();

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(p => p.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.User.Id);

        }
    }
}
