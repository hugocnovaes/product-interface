using MediatR;
using medTC.Infrastructure.Repositorys.Interfaces;

namespace medTC.ZAPI.Controllers.Product.Commands.Insert
{
    public class InsertProductHandler : IRequestHandler<InsertProductRequest, InsertProductResponse>
    {
        private readonly IProductRepository _repository;
        public InsertProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<InsertProductResponse> Handle(InsertProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.InsertProduct(request.Name, request.Description);

            return new InsertProductResponse()
            {
                Message = response ? "Product inserted successfully." : "Failed to insert product.",
                Success = response,
                StatusCode = response ? 201 : 400
            };
        }
    }
}
