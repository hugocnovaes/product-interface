using medTC.Infrastructure.Repositorys.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medTC.Infrastructure.Repositorys.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDTO>> GetAllProducts();
        public Task<ProductDTO> GetOneProduct(long id);
        public Task<bool> InsertProduct(string name, string description, decimal value);
        public Task<bool> UpdateProduct(ProductDTO product);
        public Task<bool> DeleteProduct(long id);
    }
}
