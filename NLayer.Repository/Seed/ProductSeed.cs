using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seed
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, CategoryId = 1, Name = "Kalem 1", Price = 100, Stock = 200, CreatedDate = DateTime.Now },
                new Product() { Id = 2, CategoryId = 1, Name = "Kalem 2", Price = 200, Stock = 300, CreatedDate = DateTime.Now },
                new Product() { Id = 3, CategoryId = 1, Name = "Kalem 3", Price = 300, Stock = 300, CreatedDate = DateTime.Now },
                new Product() { Id = 4, CategoryId = 2, Name = "Kitap 1", Price = 600, Stock = 700, CreatedDate = DateTime.Now },
                new Product() { Id = 5, CategoryId = 2, Name = "Kitap 2", Price = 500, Stock = 300, CreatedDate = DateTime.Now },
                new Product() { Id = 6, CategoryId = 3, Name = "Defter 1", Price = 400, Stock = 500, CreatedDate = DateTime.Now }
                );
        }
    }
}
