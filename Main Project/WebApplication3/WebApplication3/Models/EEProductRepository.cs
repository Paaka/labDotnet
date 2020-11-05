using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class EEProductRepository : IProductRepository
    {
        private readonly AppDbContext ctx;

        public EEProductRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IQueryable<Product> Products => ctx.Products;
    }
}
