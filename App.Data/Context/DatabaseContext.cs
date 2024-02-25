using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Context
{
   public class DatabaseContext : DbContext
   {
      public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
      {

      }

     

    public DbSet<ContactEntity> Messages { get; set; }
    public DbSet<UserEntity> Users { get; set; }
      public DbSet<RoleEntity> Roles { get; set; }
      public DbSet<ProductImageEntity> ProductImages { get; set; }
      public DbSet<ProductEntity> Products { get; set; }
      public DbSet<ProductCommentEntity> ProductComments { get; set; }
      public DbSet<OrderItemEntity> OrderItems { get; set; }
      public DbSet<OrderEntity> Orders { get; set; }
      public DbSet<CategoryEntity> Categories { get; set; }
      public DbSet<CartItemEntity> CartItems { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }

      //protected override void OnModelCreating(ModelBuilder modelBuilder)
      //{

      //   modelBuilder.Entity<RoleEntity>().HasKey(r => r.Id);
      //   modelBuilder.Entity<RoleEntity>().Property(r => r.Name).IsRequired().HasMaxLength(10);



      //   modelBuilder.Entity<RoleEntity>().HasData(new List<RoleEntity>()
      //  {
      //      new RoleEntity(){Id = 1, Name = "seller", CreatedAt = DateTime.UtcNow},
      //      new RoleEntity(){Id = 2, Name = "buyer", CreatedAt = DateTime.UtcNow},
      //      new RoleEntity(){Id = 3, Name = "admin", CreatedAt = DateTime.UtcNow},
      //  });


      //   modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
      //  {
      //      new UserEntity(){Id = 1, Email = "admin@mail.com", FirstName = "Admin", LastName = "Admin", RoleId = 3, Enabled = true, Password = "1234", CreatedAt = DateTime.UtcNow},
      //  });

      //}


   }
}
