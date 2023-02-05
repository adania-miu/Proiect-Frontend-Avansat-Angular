using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DAL.Configurations
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(x => x.Pin)
                    .HasColumnType("nvarchar(13)")
                    .HasMaxLength(13);
            builder.Property(x => x.CVV)
                    .HasColumnType("nvarchar(3)")
                    .HasMaxLength(3);
            builder.Property(x => x.Sold)
                    .HasColumnType("int");
        }
    }
}
