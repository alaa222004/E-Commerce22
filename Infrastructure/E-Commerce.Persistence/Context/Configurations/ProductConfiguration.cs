using E_Commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.Context.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                 .HasColumnType("Varchar")
                 .HasMaxLength(256);
            builder.Property(p => p.Description)
                    .HasColumnType("Varchar")
                    .HasMaxLength(512);
            builder.Property(p => p.PictureUrl)
                 .HasColumnType("Varchar")
                    .HasMaxLength(512);
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.ProductBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}