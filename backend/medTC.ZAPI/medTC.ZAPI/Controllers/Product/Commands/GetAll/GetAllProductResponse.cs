using medTC.Domain.Models;
using medTC.Infrastructure.Repositorys.DTOS;

namespace medTC.ZAPI.Controllers.Product.Commands.GetAll
{
    public class GetAllProductResponse : BaseResponse
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
