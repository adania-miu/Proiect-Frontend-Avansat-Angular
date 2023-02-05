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
    public class TranscationConfiguration : IEntityTypeConfiguration<Tranzactie>
    {
        public void Configure(EntityTypeBuilder<Tranzactie> builder)
        {
            builder.Property(x => x.Suma)
                    .HasColumnType("int")
                    .HasMaxLength(10);
        }
    }
}
