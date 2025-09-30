using medTC.Domain.Models;
using medTC.Infrastructure.Repositorys.Data;
using medTC.Infrastructure.Repositorys.DTOS;
using medTC.Infrastructure.Repositorys.Interfaces;
using medTC.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medTC.Infrastructure.Repositorys.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly MedTcDbContext _context;
        public ProductRepository(MedTcDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _context.Product.ToListAsync();

            var productDTOs = products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                LastUpdatedOn = p.LastUpdatedOn.ToLocalTime()
            });

            return productDTOs;
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return false;
            }
            _context.Product.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ProductDTO> GetOneProduct(long id)
        {
            var product = await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                LastUpdatedOn = product.LastUpdatedOn
            };
        }

        public async Task<bool> InsertProduct(string name, string description)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                LastUpdatedOn = DateTime.UtcNow
            };
            await _context.Product.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateProduct(ProductDTO productDto)
        {
            var product = await _context.Product.FirstOrDefaultAsync(p => p.Id == productDto.Id);
            if (product == null)
            {
                return false;
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.LastUpdatedOn = DateTime.UtcNow;

            _context.Product.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
