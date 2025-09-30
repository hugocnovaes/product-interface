using AutoMapper;
using MediatR;
using medTC.Infrastructure.Repositorys.DTOS;
using medTC.Infrastructure.Repositorys.Interfaces;

namespace medTC.ZAPI.Controllers.Product.Commands.Update
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var responseDto = _mapper.Map<ProductDTO>(request.Product);
            var response = await _repository.UpdateProduct(responseDto);

            return new UpdateProductResponse()
            {
                Message = "Products retrieved successfully",
                Success = true,
                StatusCode = 200
            };
        }
    }
}
