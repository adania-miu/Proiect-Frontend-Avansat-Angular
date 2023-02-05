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
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.Property(x => x.UserName)
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);
            builder.Property(x => x.FirstName)
                    .HasColumnType("nvarchar(40)")
                    .HasMaxLength(40);
            builder.Property(x => x.LastName)
                    .HasColumnType("nvarchar(15)")
                    .HasMaxLength(15);
            builder.Property(x => x.Sold)
                    .HasColumnType("int");
            builder.Property(x => x.IBAN)
                    .HasColumnType("nvarchar(34)")
                    .HasMaxLength(34);
        }
    }
}
