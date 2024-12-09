using BlogPlatform.DAL.Configuration;
using BlogPlatform.DAL.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.DAL
{
    public class Context : DbContext
    {

        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EntityConfigurationUser());
            modelBuilder.ApplyConfiguration(new EntityConfigurationPost());
            modelBuilder.ApplyConfiguration(new EntityConfigurationComment());
        }
        public Context(DbContextOptions options) : base(options)
        {
           // Database.EnsureCreated();   // создаем базу данных при первом обращении

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1234;Database=BlogPlatform;");
        //}


    }

}

