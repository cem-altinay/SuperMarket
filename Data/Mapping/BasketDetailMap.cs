using Entity.ModelDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class BasketDetailMap : IEntityTypeConfiguration<BasketDetail>
    {
      
        public void Configure(EntityTypeBuilder<BasketDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();    
            builder.ToTable("BasketDetail");
        }
    }
}
