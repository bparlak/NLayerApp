﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            return await _context.Products.Include(x=> x.Category).ToListAsync();
        }
    }
}
