using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Presistance.Context.Configuration
{
    public class TypeConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("VarChar")
                .HasMaxLength(256);

        }

    }
}
