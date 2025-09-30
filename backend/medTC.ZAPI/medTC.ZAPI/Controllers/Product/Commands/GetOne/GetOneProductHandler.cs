using MediatR;
using medTC.Domain.Models;
using medTC.Infrastructure.Repositorys.Interfaces;

namespace medTC.ZAPI.Controllers.Product.Commands.GetOne
{
    public class GetOneProductHandler : IRequestHandler<GetOneProductRequest, GetOneProductResponse>
    {
        private readonly IProductRepository _repository;
        public GetOneProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOneProductResponse> Handle(GetOneProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetOneProduct(request.Id);

            if (response == null)
            {
                return new GetOneProductResponse
                {
                    Message = "Product not found.",
                    Success = false,
                    StatusCode = 404
                };
            }

            return new GetOneProductResponse()
            {
                Message = "Product retrieved successfully",
                Success = true,
                StatusCode = 200,
                Product = response
            };
        }
    }
}
