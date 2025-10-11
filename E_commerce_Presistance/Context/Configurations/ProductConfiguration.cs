using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_Presistance.Context.Configuration
{
    public class ProductConfiguration: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("VarChar")
                .HasMaxLength(256);

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .HasColumnType("VarChar")
                .HasMaxLength(512);

            builder.Property(p => p.PictureUrl)
                .HasColumnType("VarChar")
                .HasMaxLength(256);

            builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)");

            builder.HasOne(b => b.ProductBrand)
                .WithMany()
                .HasForeignKey(b =>b.BrandId)
                .OnDelete(DeleteBehavior.NoAction); // Cascade

            builder.HasOne(b=>b.ProductType)
                .WithMany()
                .HasForeignKey(t=>t.TypeId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
