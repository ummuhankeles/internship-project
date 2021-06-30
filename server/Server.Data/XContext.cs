using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Server.Models.Entities;
namespace Server.Data
{
    //todo: Context name change - (we have to find a project name for it.)
    public class XContext : DbContext
    {
        public XContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<ShopList> ShopLists { get; set; }
        public virtual DbSet<ShopItem> ShopItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopList>().HasKey(p => p.ID);
            modelBuilder.Entity<ShopList>().Property(p => p.Name).HasMaxLength(100);
            modelBuilder.Entity<ShopList>().Property(p => p.ShortURL).HasMaxLength(15).IsRequired();
            modelBuilder.Entity<ShopList>().HasIndex(p => p.ShortURL).HasDatabaseName("Unique_ShortURL").IsUnique();
            modelBuilder.Entity<ShopList>().Property(p => p.CreatedAt).IsRequired();

            modelBuilder.Entity<ShopItem>().HasOne<ShopList>()
                        .WithMany(shopList => shopList.Items)
                        .HasForeignKey(shopItem => shopItem.ShopListId);

            modelBuilder.Entity<ShopItem>().HasKey(p => p.ID);
            modelBuilder.Entity<ShopItem>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<ShopItem>().Property(p => p.Definition).HasMaxLength(500);
            modelBuilder.Entity<ShopItem>().Property(p => p.Status).IsRequired();
            modelBuilder.Entity<ShopItem>().Property(p => p.CreatedAt).IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}