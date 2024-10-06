﻿
using LinkDev.Talabat.Core.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Presistance.Data.Config.Products
{
    internal class ProductConfigurations : BaseEntityConfigrations<Product, int>
    {

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(P => P.Name).IsRequired().HasMaxLength(50);
            builder.Property(P => P.Description).IsRequired();
            builder.Property(P => P.Price).HasColumnType("decimal(9,2)");

            builder.HasOne(P => P.Brand).WithMany().HasForeignKey(P => P.BrandId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(P => P.Category).WithMany().HasForeignKey(P => P.CategoryId).OnDelete(DeleteBehavior.SetNull);


        }
    }
}
