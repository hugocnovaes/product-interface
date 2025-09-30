using MediatR;
using medTC.Infrastructure.Repositorys.Interfaces;

namespace medTC.ZAPI.Controllers.Product.Commands.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IProductRepository _repository;
        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var response = await _repository.DeleteProduct(request.Id);

            return new DeleteProductResponse()
            {
                Message = "Product deleted successfully",
                Success = true,
                StatusCode = 200
            };
        }
    }
}
