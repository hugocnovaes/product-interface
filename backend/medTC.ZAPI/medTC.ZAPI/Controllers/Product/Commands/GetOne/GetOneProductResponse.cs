using medTC.Domain.Models;
using medTC.Infrastructure.Repositorys.DTOS;

namespace medTC.ZAPI.Controllers.Product.Commands.GetOne
{
    public class GetOneProductResponse : BaseResponse
    {
        public ProductDTO Product { get; set; }
    }
}
