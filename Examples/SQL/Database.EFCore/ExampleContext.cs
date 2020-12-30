using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }

        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("News");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.User);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<User>().HasData(new User {Id = 1, Name = "Alex"});
            modelBuilder.Entity<User>().HasData(new User {Id = 2, Name = "Nasty"});
            modelBuilder.Entity<User>().HasData(new User {Id = 3, Name = "Oleg"});
            modelBuilder.Entity<User>().HasData(new User {Id = 4, Name = "Vlad"});
            modelBuilder.Entity<User>().HasData(new User {Id = 5, Name = "Kostya"});

            modelBuilder.Entity<News>().HasData(new
            {
                Id = 2,
                TimeStamp = new DateTime(2020, 1, 2),
                Title = "First title",
                UserId = 5
            });

            modelBuilder.Entity<News>().HasData(new
            {
                Id = 3,
                TimeStamp = new DateTime(2020, 1, 3),
                Title = "Second title",
                SummaryId = 1
            });

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}