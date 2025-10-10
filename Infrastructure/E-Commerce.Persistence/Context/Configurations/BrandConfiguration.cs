﻿
using E_Commerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Persistence.Context.Configurations;

internal class BrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{


    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {

        builder.Property(p => p.Name)
        .HasMaxLength(256)
        .HasColumnType("Varchar");

    }
}