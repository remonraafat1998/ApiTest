﻿using LinkDev.Talabat.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Presistance.Data.Config
{
    internal class BaseEntityConfigrations<TEntity, TKey>
        : IEntityTypeConfiguration<TEntity> where TEntity
        : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(E => E.Id).UseIdentityColumn(1, 1);
            builder.Property(E => E.CreatedBy).IsRequired();
            builder.Property(E => E.CreatedOn).IsRequired();
            builder.Property(E => E.LastModifiedBy).IsRequired();
            builder.Property(E => E.LastModifiedOn).IsRequired();
        }
    }
}
