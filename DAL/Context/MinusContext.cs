using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace DAL.Context
{
    public class MinusContext : DbContext
    {
        //public MinusContext(DbContextOptions<MinusContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=localhost;database=minus;user=root;password=admin");
        }

        public virtual void Commit()
        {
            SaveChanges();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.PublishDate).IsRequired();
                entity.Property(e => e.IsVisible);
                entity.HasOne(e => e.User).WithMany(src => src.Comments).HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderStatus).IsRequired();
                entity.Property(e => e.OrderTime).IsRequired();
                entity.Property(e => e.TotalAmount).IsRequired();
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Order).WithMany(e => e.OrderProducts).HasForeignKey(e => e.OrderId);
                entity.HasOne(e => e.Product).WithMany(e => e.OrderProducts).HasForeignKey(e => e.ProductId);

            });
            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.SiteUrl).IsRequired();
                entity.Property(e => e.BannerUrl).IsRequired();
                entity.Property(e => e.Address).IsRequired();
            });
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IsInStock).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.ProductVolumeUnit).IsRequired();
                entity.Property(e => e.TotalProductVolume).IsRequired();
                entity.Property(e => e.UnitPrice).IsRequired();
                entity.Property(e => e.Rating);
            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasMany(e => e.Products).WithOne(t => t.Category).HasForeignKey(e => e.CategoryId);
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Address);
                entity.Property(e => e.PhotoUrl);
                entity.Property(e => e.Age);
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Permission).WithMany(t => t.RolePermissions);
                entity.HasOne(e => e.Role).WithMany(t => t.RolePermissions);
            });
        }
    }
}
