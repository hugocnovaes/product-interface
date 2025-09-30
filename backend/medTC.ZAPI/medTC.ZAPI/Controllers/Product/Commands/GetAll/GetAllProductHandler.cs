using MediatR;
using medTC.Infrastructure.Repositorys.Interfaces;

namespace medTC.ZAPI.Controllers.Product.Commands.GetAll
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
    {
        private readonly IProductRepository _repository;
        public GetAllProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllProducts();

            return new GetAllProductResponse()
            {
                Message = "Products retrieved successfully",
                Success = true,
                StatusCode = 200,
                Products = response
            };
        }
    }
}
